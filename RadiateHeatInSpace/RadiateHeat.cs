using System;
using RadiateHeatInSpace.SkyLib;

namespace RadiateHeatInSpace
{
    internal class RadiatesHeat : KMonoBehaviour, ISim1000ms
    {
        private static readonly double stefanBoltzmanConstant = 5.67e-8;
        public StatusItem _no_space_status;

        public StatusItem _radiating_status;
        public float emissivity = .9f;
        private Guid handle_notinspace;
        private Guid handle_radiating; // essentially a reference to a statusitem in particular
        public CellOffset[] OccupyOffsets;
        [MyCmpReq] private KSelectable selectable; // does tooltip-related stuff
        private HandleVector<int>.Handle structureTemperature;
        public float surface_area = 1f;

        public float CurrentCooling { get; private set; }

        public void Sim1000ms(float dt)
        {
            var temp = this.gameObject.GetComponent<PrimaryElement>().Temperature;
            if (temp > 5f)
            {
                var cooling = this.radiative_heat(temp);
                if (this.CheckInSpace())
                {
                    if (cooling > 1f)
                    {
                        this.CurrentCooling = (float) cooling;
                        GameComps.StructureTemperatures.ProduceEnergy(this.structureTemperature, (float) -cooling / 1000,
                            "Radiated", 1f);
                    }

                    this.UpdateStatusItem(true);
                }
                else
                {
                    GameComps.StructureTemperatures.ProduceEnergy(this.structureTemperature, 0, "Radiated", 1f);
                    this.UpdateStatusItem();
                }
            }
        }

        protected override void OnSpawn()
        {
            base.OnSpawn();

            this.OccupyOffsets = new[]
            {
                new CellOffset(0, 0)
            }; // i am lazy and will only check building root bc it's annoying to account for rotation
            this.structureTemperature = GameComps.StructureTemperatures.GetHandle(this.gameObject);
        }

        private double radiative_heat(float temp)
        {
            return Math.Pow(temp, 4) * stefanBoltzmanConstant * this.emissivity * this.surface_area;
        }

        private bool CheckInSpace()
        {
            // Check whether in spaaace
            var root_cell = Grid.PosToCell(this);
            foreach (var offset in this.OccupyOffsets)
                if (!OniUtils.IsCellExposedToSpace(Grid.OffsetCell(root_cell, offset)))
                    return false;

            return true;
        }

        private static string _FormatStatusCallback(string formatstr, object data)
        {
            var radiate = (RadiatesHeat) data;
            var radiation_rate = GameUtil.GetFormattedHeatEnergyRate(radiate.CurrentCooling);
            return string.Format(formatstr, radiation_rate);
        }

        private void UpdateStatusItem(bool in_space = false)
        {
            // if it's in space, update status.
            if (in_space)
            {
                // Remove outdated status, if it exists
                this.handle_notinspace = this.selectable.RemoveStatusItem(this.handle_notinspace);
                // Update the existing callback
                this._radiating_status = new StatusItem("RADIATESHEAT_RADIATING", "MISC", "", StatusItem.IconType.Info,
                    NotificationType.Neutral, false, OverlayModes.HeatFlow.ID);
                this._radiating_status.resolveTooltipCallback = _FormatStatusCallback;
                this._radiating_status.resolveStringCallback = _FormatStatusCallback;
                if (this.handle_radiating == Guid.Empty)
                    this.handle_radiating = this.selectable.AddStatusItem(this._radiating_status, this);
            }
            else
            {
                // Remove outdated status-
                this.handle_radiating = this.selectable.RemoveStatusItem(this.handle_radiating);

                this._no_space_status = new StatusItem("RADIATESHEAT_NOTINSPACE", "MISC", "", StatusItem.IconType.Info,
                    NotificationType.Neutral, false, OverlayModes.HeatFlow.ID);
                // add the status item!
                if (this.handle_notinspace == Guid.Empty)
                    this.handle_notinspace = this.selectable.AddStatusItem(this._no_space_status, this);
            }
        }
    }
}