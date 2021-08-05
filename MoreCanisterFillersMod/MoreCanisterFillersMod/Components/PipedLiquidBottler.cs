#region

using MoreCanisterFillersMod.Components;
using UnityEngine;

#endregion

// Token: 0x02000528 RID: 1320
[AddComponentMenu("KMonoBehaviour/Workable/PipedLiquidBottler")]
public class PipedLiquidBottler : Workable
{
    // Token: 0x06002015 RID: 8213 RVA: 0x000A7E1A File Offset: 0x000A601A
    protected override void OnSpawn()
    {
        base.OnSpawn();
        this.smi = new Controller.Instance(this);
        this.smi.StartSM();
        this.UpdateStoredItemState();
    }

    // Token: 0x06002016 RID: 8214 RVA: 0x000A7E3F File Offset: 0x000A603F
    protected override void OnCleanUp()
    {
        if (this.smi != null)
        {
            this.smi.StopSM("OnCleanUp");
        }

        base.OnCleanUp();
    }

    // Token: 0x06002017 RID: 8215 RVA: 0x000A7E60 File Offset: 0x000A6060
    private void UpdateStoredItemState()
    {
        this.Storage.allowItemRemoval = (this.smi != null && this.smi.GetCurrentState() == this.smi.sm.ready);
        foreach (var gameObject in this.Storage.items)
        {
            if (gameObject != null)
            {
                gameObject.Trigger((int)GameHashes.OnStorageInteracted, this.Storage);
            }
        }
    }

    // Token: 0x0400121F RID: 4639
    public Storage Storage;

    // Token: 0x04001220 RID: 4640
    private Controller.Instance smi;

    // Token: 0x02000FF5 RID: 4085
    private class Controller : GameStateMachine<Controller, Controller.Instance, PipedLiquidBottler>
    {
        // Token: 0x060069D7 RID: 27095 RVA: 0x00264C48 File Offset: 0x00262E48
        public override void InitializeStates(out BaseState default_state)
        {
            default_state = this.empty;
            this.empty.PlayAnim("off").EventTransition(GameHashes.OnStorageChange, this.filling, smi => smi.master.Storage.IsFull());
            this.filling.PlayAnim("working").OnAnimQueueComplete(this.ready);
            this.ready.EventTransition(GameHashes.OnStorageChange, this.pickup, smi => !smi.master.Storage.IsFull()).Enter(delegate (Instance smi)
            {
                Debug.Log("StorageChanged-State: is ready");
                smi.master.Storage.allowItemRemoval = true;
                foreach (GameObject go in smi.master.Storage.items)
                {
                    go.Trigger(-778359855, smi.master.Storage);
                }
            }).Exit(delegate (Instance smi)
            {
                smi.master.Storage.allowItemRemoval = false;
                foreach (GameObject go in smi.master.Storage.items)
                {
                    go.Trigger(-778359855, smi.master.Storage);
                }
            });
            this.pickup.PlayAnim("pick_up").OnAnimQueueComplete(this.empty);
        }

        // Token: 0x04005198 RID: 20888
        public State empty;

        // Token: 0x04005199 RID: 20889
        public State filling;

        // Token: 0x0400519A RID: 20890
        public State ready;

        // Token: 0x0400519B RID: 20891
        public State pickup;

        // Token: 0x02001BE9 RID: 7145
        public new class Instance : GameInstance
        {
            // Token: 0x06008BEB RID: 35819 RVA: 0x002D3170 File Offset: 0x002D1370
            public Instance(PipedLiquidBottler master) : base(master)
            {
            }
        }
    }
}