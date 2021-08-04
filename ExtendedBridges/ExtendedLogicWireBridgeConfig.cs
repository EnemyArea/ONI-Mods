﻿using System.Collections.Generic;
using UnityEngine;
using TUNING;

// Done
public class ExtendedLogicWireBridgeConfig : IBuildingConfig
{
    public override BuildingDef CreateBuildingDef()
    {
        string id = "ExtendedLogicWireBridge";
        int width = 4;
        int height = 1;
        string anim = "logic_bridge_kanim";
        int hitpoints = 30;
        float construction_time = 3f;
        float[] tier_TINY = { 10f };
        string[] refined_METALS = MATERIALS.REFINED_METALS;
        float melting_point = 1600f;
        BuildLocationRule build_location_rule = BuildLocationRule.LogicBridge;
        EffectorValues none = NOISE_POLLUTION.NONE;
        BuildingDef buildingDef = BuildingTemplates.CreateBuildingDef(id, width, height, anim, hitpoints, construction_time, tier_TINY, refined_METALS, melting_point, build_location_rule, TUNING.BUILDINGS.DECOR.PENALTY.TIER0, none, 0.2f);
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
        List<LogicPorts.Port> list = new List<LogicPorts.Port>();
        list.Add(LogicPorts.Port.InputPort(LogicWireBridgeConfig.BRIDGE_LOGIC_IO_ID, new CellOffset(-1, 0), STRINGS.BUILDINGS.PREFABS.LOGICWIREBRIDGE.LOGIC_PORT, STRINGS.BUILDINGS.PREFABS.LOGICWIREBRIDGE.LOGIC_PORT_ACTIVE, STRINGS.BUILDINGS.PREFABS.LOGICWIREBRIDGE.LOGIC_PORT_INACTIVE, false, false));
        list.Add(LogicPorts.Port.InputPort(LogicWireBridgeConfig.BRIDGE_LOGIC_IO_ID, new CellOffset(2, 0), STRINGS.BUILDINGS.PREFABS.LOGICWIREBRIDGE.LOGIC_PORT, STRINGS.BUILDINGS.PREFABS.LOGICWIREBRIDGE.LOGIC_PORT_ACTIVE, STRINGS.BUILDINGS.PREFABS.LOGICWIREBRIDGE.LOGIC_PORT_INACTIVE, false, false));
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
    }

    private LogicUtilityNetworkLink AddNetworkLink(GameObject go)
    {
        LogicUtilityNetworkLink logicUtilityNetworkLink = go.AddOrGet<LogicUtilityNetworkLink>();
        logicUtilityNetworkLink.bitDepth = LogicWire.BitDepth.OneBit;
        logicUtilityNetworkLink.link1 = new CellOffset(-1, 0);
        logicUtilityNetworkLink.link2 = new CellOffset(2, 0);
        return logicUtilityNetworkLink;
    }

    public const string ID = "ExtendedLogicWireBridge";

    public static readonly HashedString BRIDGE_LOGIC_EXTENDED_IO_ID = new HashedString("BRIDGE_LOGIC_EXTENDED_IO");
}
