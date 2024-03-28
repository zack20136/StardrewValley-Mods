namespace ChestFeatureSet.PickUpChests
{
    public class MoveChestsModule : Module
    {
        public MoveChestsModule(ModEntry modEntry) : base(modEntry) { }

        public override void Activate()
        {
            this.IsActive = true;


        }

        public override void Deactivate()
        {
            this.IsActive = false;
        }
    }
}

/// 對要移動的箱子 空手shift + 右鍵，會得到一個暫時的箱子(原本的箱子還會在原地，但可能改個顏色甚麼的)，然後將暫時的箱子放下時，轉移箱子然後刪除原本的箱子。