using System;
using System.Collections.Generic;
using Klei;
using STRINGS;
using UnityEngine;

namespace MoreCanisterFillersMod
{
	// Token: 0x02000005 RID: 5
	internal class UnfilteredBottleEmptier : StateMachineComponent<UnfilteredBottleEmptier.StatesInstance>, IEffectDescriptor
	{
		// Token: 0x06000002 RID: 2 RVA: 0x00002144 File Offset: 0x00000344
		public List<Descriptor> GetDescriptors(BuildingDef def)
		{
			return null;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x00002148 File Offset: 0x00000348
		protected override void OnSpawn()
		{
			base.OnSpawn();
			base.smi.StartSM();
		}

		// Token: 0x04000001 RID: 1
		public float EmptyRate = 10f;

		// Token: 0x0200001C RID: 28
		public class StatesInstance : GameStateMachine<UnfilteredBottleEmptier.States, UnfilteredBottleEmptier.StatesInstance, UnfilteredBottleEmptier, object>.GameInstance
		{
			// Token: 0x0600004A RID: 74 RVA: 0x0000339C File Offset: 0x0000159C
			public StatesInstance(UnfilteredBottleEmptier smi) : base(smi)
			{
				this.Meter = new MeterController(base.GetComponent<KBatchedAnimController>(), "meter_target", "Meter", global::Meter.Offset.Infront, Grid.SceneLayer.NoLayer, new string[]
				{
					"meter_target",
					"meter_arrow",
					"meter_scale"
				});
				base.Subscribe(-1697596308, new Action<object>(this.OnStorageChange));
			}

			// Token: 0x17000003 RID: 3
			// (get) Token: 0x0600004B RID: 75 RVA: 0x00003408 File Offset: 0x00001608
			public MeterController Meter { get; }

			// Token: 0x0600004C RID: 76 RVA: 0x00003410 File Offset: 0x00001610
			private void OnStorageChange(object data)
			{
				Storage component = base.GetComponent<Storage>();
				this.Meter.SetPositionPercent(Mathf.Clamp01(component.RemainingCapacity() / component.capacityKg));
			}

			// Token: 0x0600004D RID: 77 RVA: 0x00003448 File Offset: 0x00001648
			private PrimaryElement GetFirstPrimaryElement()
			{
				Storage component = base.GetComponent<Storage>();
				for (int i = 0; i < component.Count; i++)
				{
					GameObject gameObject = component[i];
					if (!(gameObject == null))
					{
						PrimaryElement component2 = gameObject.GetComponent<PrimaryElement>();
						if (component2 != null)
						{
							return component2;
						}
					}
				}
				return null;
			}

			// Token: 0x0600004E RID: 78 RVA: 0x000034A0 File Offset: 0x000016A0
			public void Emit(float dt)
			{
				PrimaryElement firstPrimaryElement = this.GetFirstPrimaryElement();
				if (firstPrimaryElement == null)
				{
					return;
				}
				Storage component = base.GetComponent<Storage>();
				float num = Mathf.Min(firstPrimaryElement.Mass, base.master.EmptyRate * dt);
				if ((double)num <= 0.0)
				{
					return;
				}
				Tag prefabTag = firstPrimaryElement.GetComponent<KPrefabID>().PrefabTag;
				SimUtil.DiseaseInfo diseaseInfo;
				float temperature;
                float amount_consumed;
				// public void ConsumeAndGetDisease(Tag tag, float amount, out float amount_consumed, out SimUtil.DiseaseInfo disease_info, out float aggregate_temperature)
				component.ConsumeAndGetDisease(prefabTag, num, out amount_consumed, out diseaseInfo, out temperature);
				Vector3 position = base.transform.GetPosition();
				position.y += 1.8f;
				bool flag = base.GetComponent<Rotatable>().GetOrientation() == Orientation.FlipH;
				position.x += (flag ? -0.2f : 0.2f);
				int num2 = Grid.PosToCell(position) + (flag ? -1 : 1);
				if (Grid.Solid[num2])
				{
					num2 += (flag ? 1 : -1);
				}
				Element element = firstPrimaryElement.Element;
				byte idx = element.idx;
				if (element.IsLiquid)
				{
					FallingWater.instance.AddParticle(num2, idx, num, temperature, diseaseInfo.idx, diseaseInfo.count, true, false, false, false);
					return;
				}
				SimMessages.ModifyCell(num2, (int)idx, temperature, num, diseaseInfo.idx, diseaseInfo.count, SimMessages.ReplaceType.None, false, -1);
			}
		}

		// Token: 0x0200001D RID: 29
		public class States : GameStateMachine<UnfilteredBottleEmptier.States, UnfilteredBottleEmptier.StatesInstance, UnfilteredBottleEmptier>
		{
			// Token: 0x0600004F RID: 79 RVA: 0x000035F4 File Offset: 0x000017F4
			public override void InitializeStates(out StateMachine.BaseState outDefaultState)
			{
				outDefaultState = this.Waitingfordelivery;
				StatusItem statusItem = new StatusItem("UnfilteredBottleEmptier", string.Empty, string.Empty, string.Empty, StatusItem.IconType.Info, NotificationType.Neutral, false, OverlayModes.None.ID, 129022);
				statusItem.resolveStringCallback = delegate(string str, object data)
				{
					if ((UnfilteredBottleEmptier)data == null)
					{
						return str;
					}
					return BUILDING.STATUSITEMS.BOTTLE_EMPTIER.DENIED.NAME;
				};
				statusItem.resolveTooltipCallback = delegate(string str, object data)
				{
					if ((UnfilteredBottleEmptier)data == null)
					{
						return str;
					}
					return BUILDING.STATUSITEMS.BOTTLE_EMPTIER.DENIED.TOOLTIP;
				};
				this._statusItem = statusItem;
				this.root.ToggleStatusItem(this._statusItem, (UnfilteredBottleEmptier.StatesInstance smi) => smi.master);
				this.Unoperational.TagTransition(GameTags.Operational, this.Waitingfordelivery, false).PlayAnim("off");
				this.Waitingfordelivery.TagTransition(GameTags.Operational, this.Unoperational, true).EventTransition(GameHashes.OnStorageChange, this.Emptying, (UnfilteredBottleEmptier.StatesInstance smi) => !smi.GetComponent<Storage>().IsEmpty()).PlayAnim("on");
				this.Emptying.TagTransition(GameTags.Operational, this.Unoperational, true).EventTransition(GameHashes.OnStorageChange, this.Waitingfordelivery, (UnfilteredBottleEmptier.StatesInstance smi) => smi.GetComponent<Storage>().IsEmpty()).Update("Emit", delegate(UnfilteredBottleEmptier.StatesInstance smi, float dt)
				{
					smi.Emit(dt);
				}, UpdateRate.SIM_200ms, false).PlayAnim("working_loop", KAnim.PlayMode.Loop);
			}

			// Token: 0x04000016 RID: 22
			private StatusItem _statusItem;

			// Token: 0x04000017 RID: 23
			public GameStateMachine<UnfilteredBottleEmptier.States, UnfilteredBottleEmptier.StatesInstance, UnfilteredBottleEmptier, object>.State Emptying;

			// Token: 0x04000018 RID: 24
			public GameStateMachine<UnfilteredBottleEmptier.States, UnfilteredBottleEmptier.StatesInstance, UnfilteredBottleEmptier, object>.State Unoperational;

			// Token: 0x04000019 RID: 25
			public GameStateMachine<UnfilteredBottleEmptier.States, UnfilteredBottleEmptier.StatesInstance, UnfilteredBottleEmptier, object>.State Waitingfordelivery;
		}
	}
}
