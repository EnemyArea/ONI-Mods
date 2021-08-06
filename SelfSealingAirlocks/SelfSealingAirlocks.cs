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
        private static bool Prefix(Door __instance, bool isDoorOpen, IList<int> cells)
        {
            var component = __instance.GetComponent<PrimaryElement>();
            var mass = component.Mass / (float)cells.Count;
            for (var i = 0; i < cells.Count; i++)
            {
                var offsetCell = cells[i];
                var doorType = __instance.doorType;
                if (doorType <= Door.DoorType.ManualPressure || doorType == Door.DoorType.Sealed)
                {
                    World.Instance.groundRenderer.MarkDirty(offsetCell);
                    if (isDoorOpen)
                    {
                        var methodOpened = AccessTools.Method(typeof(Door), "OnSimDoorOpened");
                        var cbOpened = (System.Action)Delegate.CreateDelegate(typeof(System.Action), __instance, methodOpened);
                        var handle = Game.Instance.callbackManager.Add(new Game.CallbackInfo(cbOpened));

                        SimMessages.Dig(offsetCell, handle.index, true);

                        SimMessages.ClearCellProperties(offsetCell, 1);
                        SimMessages.ClearCellProperties(offsetCell, 2);
                        SimMessages.ClearCellProperties(offsetCell, 4);
                        
                        SimMessages.SetCellProperties(offsetCell, (byte)(__instance.CurrentState == Door.ControlState.Auto ? 7 : 4));
                    }
                    else
                    {
                        var methodClosed = AccessTools.Method(typeof(Door), "OnSimDoorClosed");
                        var cbClosed = (System.Action)Delegate.CreateDelegate(typeof(System.Action), __instance, methodClosed);
                        var handle = Game.Instance.callbackManager.Add(new Game.CallbackInfo(cbClosed));

                        var temperature = component.Temperature;
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