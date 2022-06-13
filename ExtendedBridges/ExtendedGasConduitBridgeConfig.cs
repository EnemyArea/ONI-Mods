using TUNING;


// Done
namespace ExtendedBridges
{
    public class ExtendedGasConduitBridgeConfig : GasConduitBridgeConfig
    {
        public override BuildingDef CreateBuildingDef()
        {
            var id = "ExtendedGasConduitBridge";
            var width = 4;
            var height = 1;
            var anim = "utilitygasbridge_kanim";
            var hitpoints = 10;
            var construction_time = 3f;
            float[] tier = { 75f };
            var raw_MINERALS = MATERIALS.RAW_MINERALS;
            var melting_point = 1600f;
            var build_location_rule = BuildLocationRule.Conduit;
            var none = NOISE_POLLUTION.NONE;
            var buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, none);
            buildingDef.ObjectLayer = ObjectLayer.GasConduitConnection;
            buildingDef.SceneLayer = Grid.SceneLayer.GasConduitBridges;
            buildingDef.InputConduitType = ConduitType.Gas;
            buildingDef.OutputConduitType = ConduitType.Gas;
            buildingDef.Floodable = false;
            buildingDef.Entombable = false;
            buildingDef.Overheatable = false;
            buildingDef.ViewMode = OverlayModes.GasConduits.ID;
            buildingDef.AudioCategory = "Metal";
            buildingDef.AudioSize = "small";
            buildingDef.BaseTimeUntilRepair = -1f;
            buildingDef.PermittedRotations = PermittedRotations.R360;
            buildingDef.UtilityInputOffset = new CellOffset(-1, 0);
            buildingDef.UtilityOutputOffset = new CellOffset(2, 0);
            GeneratedBuildings.RegisterWithOverlay(OverlayScreen.GasVentIDs, buildingDef.PrefabID);
            return buildingDef;
        }

        public new const string ID = "ExtendedGasConduitBridge";
    }
}
