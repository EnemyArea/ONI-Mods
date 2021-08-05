using TUNING;

// Done
public class ExtendedLiquidConduitBridgeConfig : LiquidConduitBridgeConfig
{
    public override BuildingDef CreateBuildingDef()
    {
        var id = "ExtendedLiquidConduitBridge";
        var width = 4;
        var height = 1;
        var anim = "utilityliquidbridge_kanim";
        var hitpoints = 10;
        var construction_time = 3f;
        float[] tier = { 125f };
        var raw_MINERALS = MATERIALS.RAW_MINERALS;
        var melting_point = 1600f;
        var build_location_rule = BuildLocationRule.Conduit;
        var none = NOISE_POLLUTION.NONE;
        var buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, raw_MINERALS, melting_point, build_location_rule, BUILDINGS.DECOR.NONE, none, 0.2f);
        buildingDef.ObjectLayer = ObjectLayer.LiquidConduitConnection;
        buildingDef.SceneLayer = Grid.SceneLayer.LiquidConduitBridges;
        buildingDef.InputConduitType = ConduitType.Liquid;
        buildingDef.OutputConduitType = ConduitType.Liquid;
        buildingDef.Floodable = false;
        buildingDef.Entombable = false;
        buildingDef.Overheatable = false;
        buildingDef.ViewMode = OverlayModes.LiquidConduits.ID;
        buildingDef.AudioCategory = "Metal";
        buildingDef.AudioSize = "small";
        buildingDef.BaseTimeUntilRepair = -1f;
        buildingDef.PermittedRotations = PermittedRotations.R360;
        buildingDef.UtilityInputOffset = new CellOffset(-1, 0);
        buildingDef.UtilityOutputOffset = new CellOffset(2, 0);
        GeneratedBuildings.RegisterWithOverlay(OverlayScreen.LiquidVentIDs, buildingDef.PrefabID);
        return buildingDef;
    }

    public new const string ID = "ExtendedLiquidConduitBridge";
}
