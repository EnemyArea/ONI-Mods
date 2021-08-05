using System.Collections.Generic;
using TUNING;
using UnityEngine;

public class ExtendedLogicRibbonBridgeConfig : IBuildingConfig
{
    public override BuildingDef CreateBuildingDef()
    {
        var id = "ExtendedLogicRibbonBridge";
        var width = 4;
        var height = 1;
        var anim = "logic_ribbon_bridge_kanim";
        var hitpoints = 30;
        var construction_time = 3f;
        float[] tier = { 10f };
        var refined_METALS = MATERIALS.REFINED_METALS;
        var melting_point = 1600f;
        var build_location_rule = BuildLocationRule.LogicBridge;
        var none = NOISE_POLLUTION.NONE;
        var buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier, refined_METALS, melting_point, build_location_rule, TUNING.BUILDINGS.DECOR.PENALTY.TIER0, none, 0.2f);
        buildingDef.ViewMode = OverlayModes.Logic.ID;
        buildingDef.ObjectLayer = ObjectLayer.LogicGate;
        buildingDef.SceneLayer = Grid.SceneLayer.LogicGates;
        buildingDef.Overheatable = false;
        buildingDef.Floodable = false;
        buildingDef.Entombable = false;
        buildingDef.AudioCategory = "Metal";
        buildingDef.AudioSize = "small";
        buildingDef.BaseTimeUntilRepair = -1f;
        buildingDef.PermittedRotations = PermittedRotations.R360;
        buildingDef.UtilityInputOffset = new CellOffset(0, 0);
        buildingDef.UtilityOutputOffset = new CellOffset(0, 3);
        buildingDef.AlwaysOperational = true;
        var list = new List<LogicPorts.Port>();
        list.Add(LogicPorts.Port.RibbonInputPort(LogicRibbonBridgeConfig.BRIDGE_LOGIC_RIBBON_IO_ID, new CellOffset(-1, 0), STRINGS.BUILDINGS.PREFABS.LOGICRIBBONBRIDGE.LOGIC_PORT, STRINGS.BUILDINGS.PREFABS.LOGICRIBBONBRIDGE.LOGIC_PORT_ACTIVE, STRINGS.BUILDINGS.PREFABS.LOGICRIBBONBRIDGE.LOGIC_PORT_INACTIVE, false, false));
        list.Add(LogicPorts.Port.RibbonInputPort(LogicRibbonBridgeConfig.BRIDGE_LOGIC_RIBBON_IO_ID, new CellOffset(2, 0), STRINGS.BUILDINGS.PREFABS.LOGICRIBBONBRIDGE.LOGIC_PORT, STRINGS.BUILDINGS.PREFABS.LOGICRIBBONBRIDGE.LOGIC_PORT_ACTIVE, STRINGS.BUILDINGS.PREFABS.LOGICRIBBONBRIDGE.LOGIC_PORT_INACTIVE, false, false));
        buildingDef.LogicInputPorts = list;
        GeneratedBuildings.RegisterWithOverlay(OverlayModes.Logic.HighlightItemIDs, buildingDef.PrefabID);
        return buildingDef;
    }

    public override void ConfigureBuildingTemplate(GameObject go, Tag prefab_tag)
    {
        BuildingConfigManager.Instance.IgnoreDefaultKComponent(typeof(RequiresFoundation), prefab_tag);
    }

    public override void DoPostConfigurePreview(BuildingDef def, GameObject go)
    {
        base.DoPostConfigurePreview(def, go);
        this.AddNetworkLink(go).visualizeOnly = true;
        go.AddOrGet<BuildingCellVisualizer>();
    }

    public override void DoPostConfigureUnderConstruction(GameObject go)
    {
        base.DoPostConfigureUnderConstruction(go);
        this.AddNetworkLink(go).visualizeOnly = true;
        go.AddOrGet<BuildingCellVisualizer>();
    }

    public override void DoPostConfigureComplete(GameObject go)
    {
        this.AddNetworkLink(go).visualizeOnly = false;
        go.AddOrGet<BuildingCellVisualizer>();
        go.AddOrGet<LogicRibbonBridge>();
    }

    private LogicUtilityNetworkLink AddNetworkLink(GameObject go)
    {
        var logicUtilityNetworkLink = go.AddOrGet<LogicUtilityNetworkLink>();
        logicUtilityNetworkLink.bitDepth = LogicWire.BitDepth.FourBit;
        logicUtilityNetworkLink.link1 = new CellOffset(-1, 0);
        logicUtilityNetworkLink.link2 = new CellOffset(2, 0);
        return logicUtilityNetworkLink;
    }

    public const string ID = "ExtendedLogicRibbonBridge";

    public static readonly HashedString BRIDGE_LOGIC_RIBBON_EXTENDED_IO_ID = new HashedString("BRIDGE_LOGIC_RIBBON_EXTENDED_IO");
}