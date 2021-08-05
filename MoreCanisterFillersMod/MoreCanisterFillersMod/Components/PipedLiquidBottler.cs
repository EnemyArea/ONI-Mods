using System;
using UnityEngine;

namespace MoreCanisterFillersMod.Components
{
	// Token: 0x02000007 RID: 7
	public class PipedLiquidBottler : Workable
	{
		// Token: 0x0600000A RID: 10 RVA: 0x000022D4 File Offset: 0x000004D4
		protected override void OnSpawn()
		{
			base.OnSpawn();
			this.Smi = new PipedLiquidBottler.Controller.Instance(this);
			this.Smi.StartSM();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000022F4 File Offset: 0x000004F4
		protected override void OnCleanUp()
		{
			var smi = this.Smi;
			if (smi != null)
			{
				smi.StopSM("OnCleanUp");
			}
			base.OnCleanUp();
		}

		// Token: 0x04000003 RID: 3
		public PipedLiquidBottler.Controller.Instance Smi;

		// Token: 0x04000004 RID: 4
		public Storage Storage;

		// Token: 0x0200001E RID: 30
		public class Controller : GameStateMachine<PipedLiquidBottler.Controller, PipedLiquidBottler.Controller.Instance, PipedLiquidBottler>
		{
			// Token: 0x06000051 RID: 81 RVA: 0x000037C0 File Offset: 0x000019C0
			public override void InitializeStates(out StateMachine.BaseState outDefaultState)
			{
				outDefaultState = this.Empty;
				this.Empty.PlayAnim("off").EventTransition(GameHashes.OnStorageChange, this.Filling, (PipedLiquidBottler.Controller.Instance smi) => smi.master.Storage.IsFull());
				this.Filling.PlayAnim("working").OnAnimQueueComplete(this.Ready);
				this.Ready.EventTransition(GameHashes.OnStorageChange, this.Pickup, (PipedLiquidBottler.Controller.Instance smi) => !smi.master.Storage.IsFull()).Enter(new StateMachine<PipedLiquidBottler.Controller, PipedLiquidBottler.Controller.Instance, PipedLiquidBottler, object>.State.Callback(PipedLiquidBottler.Controller.EventEnterExit)).Exit(new StateMachine<PipedLiquidBottler.Controller, PipedLiquidBottler.Controller.Instance, PipedLiquidBottler, object>.State.Callback(PipedLiquidBottler.Controller.EventEnterExit));
				this.Pickup.PlayAnim("pick_up").OnAnimQueueComplete(this.Empty);
			}

			// Token: 0x06000052 RID: 82 RVA: 0x000038B0 File Offset: 0x00001AB0
			private static void EventEnterExit(PipedLiquidBottler.Controller.Instance smi)
			{
				smi.master.Storage.allowItemRemoval = true;
				foreach (var go in smi.master.Storage.items)
				{
					go.Trigger(-778359855, smi.master.Storage);
				}
			}

			// Token: 0x0400001A RID: 26
			public GameStateMachine<PipedLiquidBottler.Controller, PipedLiquidBottler.Controller.Instance, PipedLiquidBottler, object>.State Empty;

			// Token: 0x0400001B RID: 27
			public GameStateMachine<PipedLiquidBottler.Controller, PipedLiquidBottler.Controller.Instance, PipedLiquidBottler, object>.State Filling;

			// Token: 0x0400001C RID: 28
			public GameStateMachine<PipedLiquidBottler.Controller, PipedLiquidBottler.Controller.Instance, PipedLiquidBottler, object>.State Pickup;

			// Token: 0x0400001D RID: 29
			public GameStateMachine<PipedLiquidBottler.Controller, PipedLiquidBottler.Controller.Instance, PipedLiquidBottler, object>.State Ready;

			// Token: 0x02000025 RID: 37
			public new class Instance : GameStateMachine<PipedLiquidBottler.Controller, PipedLiquidBottler.Controller.Instance, PipedLiquidBottler, object>.GameInstance
			{
				// Token: 0x06000061 RID: 97 RVA: 0x00003A0C File Offset: 0x00001C0C
				public Instance(PipedLiquidBottler master) : base(master)
				{
				}
			}
		}
	}
}
