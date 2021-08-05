using System;
using KSerialization;
using UnityEngine;

namespace MoreCanisterFillersMod.Components
{
	// Token: 0x02000006 RID: 6
	internal class AutoDropInv : KMonoBehaviour
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002170 File Offset: 0x00000370
        protected override void OnSpawn()
        {
            base.OnSpawn();
            this.Subscribe(493375141, this.OnRefresh);
        }

        //	this.Subscribe(-1697596308, this.StorageChanged);
		//}

		//// Token: 0x06000006 RID: 6 RVA: 0x000021B8 File Offset: 0x000003B8
		//public void StorageChanged(object data)
		//{
		//	if (!this.AutoDrop)
		//	{
		//		return;
		//	}
		//	var component = this.GetComponent<Storage>();
		//	if ((double)component.RemainingCapacity() < 0.05)
		//	{
		//		component.DropAll();
		//	}
		//}

		// Token: 0x06000007 RID: 7 RVA: 0x00002204 File Offset: 0x00000404
		public void OnRefresh(object _)
		{
			var text = this.AutoDrop ? "Disable Auto-Drop" : "Enable Auto-Drop";
			var tooltipText = this.AutoDrop ? "Disable automatic dropping of bottles when full" : "Enable automatic dropping of bottles when full";
			var button = new KIconButtonMenu.ButtonInfo("action_building_disabled", text, this.OnChangeAutoDrop, Action.CinemaZoomSpeedMinus, null, null, null, tooltipText);
			Game.Instance.userMenu.AddButton(this.gameObject, button);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002288 File Offset: 0x00000488
		private void OnChangeAutoDrop()
		{
			this.AutoDrop = !this.AutoDrop;
        }

		// Token: 0x04000002 RID: 2
		[Serialize]
		public bool AutoDrop;
	}
}
