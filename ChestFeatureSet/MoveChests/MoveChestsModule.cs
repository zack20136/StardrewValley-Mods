using ChestFeatureSet.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewValley;
using StardewValley.Objects;

namespace ChestFeatureSet.MoveChests
{
    public class MoveChestsModule : Module
    {
        public MoveChestsModule(ModEntry modEntry) : base(modEntry) { }

        private readonly string TempChestName = "*6uQmx.a@!H=wDrF@=+=9pf=dRyaa.R5";
        private Chest HeldChest { get; set; }

        public override void Activate()
        {
            this.IsActive = true;

            this.Events.Input.ButtonPressed += OnButtonPressed;
            this.Events.Input.ButtonReleased += OnButtonReleased;
        }

        public override void Deactivate()
        {
            this.IsActive = false;

            this.Events.Input.ButtonPressed -= OnButtonPressed;
            this.Events.Input.ButtonReleased -= OnButtonReleased;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsPlayerFree)
                return;

            if (e.Button == Config.MoveChestKey)
                this.Events.Input.ButtonPressed += OnMouseClicked;
        }

        private void OnButtonReleased(object sender, ButtonReleasedEventArgs e)
        {
            if (!Context.IsPlayerFree)
                return;

            if (e.Button == Config.MoveChestKey)
                this.Events.Input.ButtonPressed -= OnMouseClicked;
        }

        private void OnMouseClicked(object sender, ButtonPressedEventArgs e)
        {
            if (!Context.IsPlayerFree)
                return;

            if (e.Button == SButton.MouseLeft)
            {
                if (Game1.player.CurrentItem != null)
                    return;

                if (this.HeldChest != null)
                {
                    Game1.showRedMessage("Can only pick up one chest.");
                    return;
                }

                var nearbyChests = ChestExtension.GetNearbyChests(Game1.player, 2);

                if (!nearbyChests.Any())
                    return;

                this.ModEntry.Helper.Input.Suppress(e.Button);

                foreach (var chest in nearbyChests)
                {
                    if (chest.TileLocation == e.Cursor.Tile)
                    {
                        this.HeldChest = chest;

                        for (int i = 0; i < Game1.player.Items.Count; i++)
                        {
                            if (Game1.player.Items[i] != null)
                                continue;

                            Game1.player.addItemToInventory(new Chest(true), i);
                            Game1.player.Items[i].Name = this.TempChestName;

                            // LockItems
                            this.ModEntry.LockItems?.CFSItemController.AddItem(Game1.player.Items[i]);

                            this.HeldChest.Location.objects.Remove(this.HeldChest.TileLocation);

                            this.Events.World.ObjectListChanged += this.OnObjectListChanged;
                            return;
                        }
                    }
                }
            }
        }

        private void OnObjectListChanged(object sender, ObjectListChangedEventArgs e)
        {
            if (!Context.IsPlayerFree || this.HeldChest == null)
                return;

            var chest = e.Added.Select(p => p.Value).OfType<Chest>().LastOrDefault();
            if (chest != null && chest.Name == this.TempChestName)
            {
                chest = this.CopyChestData(chest, this.HeldChest);

                this.HeldChest = null;
                this.Events.World.ObjectListChanged -= this.OnObjectListChanged;
            }
        }

        private Chest CopyChestData(Chest newChest, Chest CopyFrom)
        {
            // Orginal Data
            newChest.Name = CopyFrom.Name;
            newChest.playerChoiceColor.Value = CopyFrom.playerChoiceColor.Value;
            newChest.heldObject.Value = CopyFrom.heldObject.Value;
            newChest.MinutesUntilReady = CopyFrom.MinutesUntilReady;
            for (int i = 0; i < CopyFrom.Items.Count; i++)
            {
                if (CopyFrom.Items[i] == null) break;
                newChest.Items.Add(CopyFrom.Items[i]);
            }
            foreach (var modData in CopyFrom.modData)
                newChest.modData.CopyFrom(modData);

            // StashToChestsData
            var stashCFSController = this.ModEntry.StashToChests != null ? this.ModEntry.StashToChests.CFSChestController : null;
            if (stashCFSController != null && stashCFSController.GetChests().Contains(CopyFrom))
            {
                stashCFSController.RemoveChest(CopyFrom);
                stashCFSController.AddChest(newChest);
            }

            // CraftFromChestsData
            var craftCFSController = this.ModEntry.CraftFromChests != null ? this.ModEntry.CraftFromChests.CFSChestController : null;
            if (craftCFSController != null && craftCFSController.GetChests().Contains(CopyFrom))
            {
                craftCFSController.RemoveChest(CopyFrom);
                craftCFSController.AddChest(newChest);
            }

            return newChest;
        }
    }
}