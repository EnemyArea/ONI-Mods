using HarmonyLib;

namespace SelfSealingAirlocks
{
    // Update sim state setter to make airlock doors gas impermable
    [HarmonyPatch(typeof(Door), "SetWorldState")]
    internal class SelfSealingAirlocks_Door_SetWorldState
    {
        private static void Postfix(Door __instance)
        {
            // If the attached gameobject doesn't exist, exit here
            if (__instance.gameObject == null) return;

            var doorType = __instance.doorType;
            if (doorType <= Door.DoorType.ManualPressure || doorType == Door.DoorType.Sealed)
            {
                for (var i = 0; i < __instance.building.PlacementCells.Length; i++)
                {
                    var offsetCell = __instance.building.PlacementCells[i];
                    SimMessages.ClearCellProperties(offsetCell, 1);
                    SimMessages.ClearCellProperties(offsetCell, 2);
                    SimMessages.ClearCellProperties(offsetCell, 4);
                    SimMessages.SetCellProperties(offsetCell, (byte)(__instance.CurrentState == Door.ControlState.Auto ? 7 : 4));
                }
            }
        }
    }
}