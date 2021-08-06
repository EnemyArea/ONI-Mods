#region

using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;

#endregion

namespace SelfSealingAirlocks
{
    // Add anim override (necesary to prevent game crash)
    [HarmonyPatch(typeof(Door), "OnPrefabInit")]
    internal class SelfSealingAirlocks_Door_OnPrefabInit
    {
        private static void Postfix(ref Door __instance)
        {
            __instance.overrideAnims = new KAnimFile[]
            {
                Assets.GetAnim("anim_use_remote_kanim")
            };
        }
    }
    // Update sim state setter to make airlock doors gas impermable
    [HarmonyPatch(typeof(Door), "SetSimState")]
    internal class SelfSealingAirlocks_Door_SetSimState
    {
        private static bool Prefix(Door __instance, bool is_door_open, IList<int> cells)
        {
            PrimaryElement component = __instance.GetComponent<PrimaryElement>();
            float mass = component.Mass / (float)cells.Count;
            for (int i = 0; i < cells.Count; i++)
            {
                int offsetCell = cells[i];
                Door.DoorType doorType = __instance.doorType;
                if (doorType <= Door.DoorType.ManualPressure || doorType == Door.DoorType.Sealed)
                {
                    World.Instance.groundRenderer.MarkDirty(offsetCell);
                    if (is_door_open)
                    {
                        MethodInfo method_opened = AccessTools.Method(typeof(Door), "OnSimDoorOpened");
                        System.Action cb_opened = (System.Action)Delegate.CreateDelegate(typeof(System.Action), __instance, method_opened);
                        HandleVector<Game.CallbackInfo>.Handle handle = Game.Instance.callbackManager.Add(new Game.CallbackInfo(cb_opened));

                        SimMessages.Dig(offsetCell, handle.index, true);

                        SimMessages.ClearCellProperties(offsetCell, 1);
                        SimMessages.ClearCellProperties(offsetCell, 2);
                        SimMessages.ClearCellProperties(offsetCell, 4);
                        
                        SimMessages.SetCellProperties(offsetCell, (byte)(__instance.CurrentState == Door.ControlState.Auto ? 7 : 4));
                    }
                    else
                    {
                        MethodInfo method_closed = AccessTools.Method(typeof(Door), "OnSimDoorClosed");
                        System.Action cb_closed = (System.Action)Delegate.CreateDelegate(typeof(System.Action), __instance, method_closed);
                        HandleVector<Game.CallbackInfo>.Handle handle = Game.Instance.callbackManager.Add(new Game.CallbackInfo(cb_closed));

                        float temperature = component.Temperature;
                        if (temperature <= 0f)
                        {
                            temperature = component.Temperature;
                        }

                        SimMessages.ReplaceAndDisplaceElement(offsetCell, component.ElementID, CellEventLogger.Instance.DoorClose, mass, temperature, byte.MaxValue, 0, handle.index);

                        SimMessages.ClearCellProperties(offsetCell, 1);
                        SimMessages.ClearCellProperties(offsetCell, 2);
                        SimMessages.SetCellProperties(offsetCell, 4);
                    }
                }
            }

            return false;

            //// If the attached gameobject doesn't exist, exit here
            //if (__instance.gameObject == null) return;

            //var doorType = __instance.doorType;
            //if (doorType <= Door.DoorType.ManualPressure || doorType == Door.DoorType.Sealed)
            //{
            //    for (var i = 0; i < __instance.building.PlacementCells.Length; i++)
            //    {
            //        var offsetCell = __instance.building.PlacementCells[i];
            //        SimMessages.ClearCellProperties(offsetCell, 1);
            //        SimMessages.ClearCellProperties(offsetCell, 2);
            //        SimMessages.ClearCellProperties(offsetCell, 4);
            //        SimMessages.SetCellProperties(offsetCell, (byte)(__instance.CurrentState == Door.ControlState.Auto ? 7 : 4));
            //    }
            //}
        }
    }

    //// Update sim state setter to make airlock doors gas impermable
    //[HarmonyPatch(typeof(Door), "OnCleanUp")]
    //internal class SelfSealingAirlocks_Door_OnCleanUp
    //{
    //    private static void Prefix(Door __instance)
    //    {
    //        // If the attached gameobject doesn't exist, exit here
    //        if (__instance.gameObject == null) return;

    //        var doorType = __instance.doorType;
    //        if (doorType <= Door.DoorType.ManualPressure || doorType == Door.DoorType.Sealed)
    //        {
    //            Debug.Log("OnCleanUp Door: " + __instance.gameObject.GetInstanceID());

    //            for (var i = 0; i < __instance.building.PlacementCells.Length; i++)
    //            {
    //                var offsetCell = __instance.building.PlacementCells[i];
    //                SimMessages.ClearCellProperties(offsetCell, 1);
    //                SimMessages.ClearCellProperties(offsetCell, 2);
    //            }

    //            Debug.Log("OnCleanUp Door complete");
    //        }
    //    }
    //}
}