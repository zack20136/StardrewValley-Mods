﻿using ChestFeatureSet.API;
using StardewModdingAPI;

namespace ChestFeatureSet
{
    public class ConfigMenu
    {
        public static void StartConfigMenu(IModHelper helper, IManifest manifest, ModConfig config)
        {
            // get Generic Mod Config Menu's API (if it's installed)
            var configMenu = helper.ModRegistry.GetApi<IGenericModConfigMenuApi>("spacechase0.GenericModConfigMenu");
            if (configMenu == null)
                return;

            // register mod
            configMenu.Register(
                mod: manifest,
                reset: () => config = new ModConfig(),
                save: () => helper.WriteConfig(config)
            );

            // StashToChests
            configMenu.AddSectionTitle(
                mod: manifest,
                text: () => "StashToChests"
                );
            configMenu.AddBoolOption(
                mod: manifest,
                name: () => "StashToChests",
                tooltip: () => "Open the feature of StashToChests. (If changed, please go back to Title and load agian.)",
                getValue: () => config.StashToChests,
                setValue: value => config.StashToChests = value
            );
            configMenu.AddBoolOption(
                mod: manifest,
                name: () => "OnlyStashToExistingStacks",
                tooltip: () => "Only stash to existing stacks.",
                getValue: () => config.OnlyStashToExistingStacks,
                setValue: value => config.OnlyStashToExistingStacks = value
            );
            configMenu.AddTextOption(
                mod: manifest,
                name: () => "StashLocationSetting",
                tooltip: () => "Can stash to chests at these {lcations}.\n Default: only the location you are.\n AllFramBuilding: all the location inside the farm(include).\n Anywhere: all the world's location.",
                getValue: () => config.StashLocationSetting,
                setValue: value => config.StashLocationSetting = value,
                allowedValues: new string[] { "Default", "AllFramBuilding", "Anywhere" }
            );
            configMenu.AddNumberOption(
                mod: manifest,
                name: () => "StashRadius (-1 is Unlimited)",
                tooltip: () => "The distance can be stashed to chests.",
                getValue: () => config.StashRadius,
                setValue: value => config.StashRadius = value
            );
            configMenu.AddKeybind(
                mod: manifest,
                name: () => "StashKey",
                tooltip: () => "StashKey Keybind.",
                getValue: () => config.StashKey,
                setValue: value => config.StashKey = value
            );

            // LockItems
            configMenu.AddSectionTitle(
                mod: manifest,
                text: () => "LockItems"
                );
            configMenu.AddBoolOption(
                mod: manifest,
                name: () => "LockItems (Needed StashToChests)",
                tooltip: () => "Open the feature of LockItems. (If changed, please go back to Title and load agian.)",
                getValue: () => config.LockItems,
                setValue: value => config.LockItems = value
            );
            configMenu.AddKeybind(
                mod: manifest,
                name: () => "LockItemKey",
                tooltip: () => "LockItemKey Keybind.",
                getValue: () => config.LockItemKey,
                setValue: value => config.LockItemKey = value
            );
            configMenu.AddKeybind(
                mod: manifest,
                name: () => "ResetLockItemKey",
                tooltip: () => "ResetLockItemKey Keybind.",
                getValue: () => config.ResetLockItemKey,
                setValue: value => config.ResetLockItemKey = value
            );

            // CraftFromChests
            configMenu.AddSectionTitle(
                mod: manifest,
                text: () => "CraftFromChests"
                );
            configMenu.AddBoolOption(
                mod: manifest,
                name: () => "CraftFromChests",
                tooltip: () => "Open the feature of CraftFromChests. (If changed, please go back to Title and load agian.)",
                getValue: () => config.CraftFromChests,
                setValue: value => config.CraftFromChests = value
            );
            configMenu.AddTextOption(
                mod: manifest,
                name: () => "CraftLocationSetting",
                tooltip: () => "Can stash to chests at these {lcations}.\n Default: only the location you are.\n AllFramBuilding: all the location inside the farm(include).\n Anywhere: all the world's location.",
                getValue: () => config.CraftLocationSetting,
                setValue: value => config.CraftLocationSetting = value,
                allowedValues: new string[] { "Default", "AllFramBuilding", "Anywhere" }
            );
            configMenu.AddNumberOption(
                mod: manifest,
                name: () => "CraftRadius (-1 is Unlimited)",
                tooltip: () => "The distance can be crafted to chests.",
                getValue: () => config.CraftRadius,
                setValue: value => config.CraftRadius = value
            );
            configMenu.AddKeybind(
                mod: manifest,
                name: () => "OpenCraftingPageKey",
                tooltip: () => "OpenCraftingPageKey Keybind.",
                getValue: () => config.OpenCraftingPageKey,
                setValue: value => config.OpenCraftingPageKey = value
            );

            // PickUpChests
            configMenu.AddSectionTitle(
                mod: manifest,
                text: () => "MoveChests"
                );
            configMenu.AddBoolOption(
                mod: manifest,
                name: () => "MoveChests",
                tooltip: () => "Open the feature of MoveChests. (If changed, please go back to Title and load agian.)",
                getValue: () => config.MoveChests,
                setValue: value => config.MoveChests = value
            );
            configMenu.AddKeybind(
                mod: manifest,
                name: () => "PickUpChestKey",
                tooltip: () => "PickUpChestKey Keybind.",
                getValue: () => config.MoveChestKey,
                setValue: value => config.MoveChestKey = value
            );
        }
    }
}
