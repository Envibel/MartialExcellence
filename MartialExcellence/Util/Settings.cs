//using BlueprintCore.Utils;
//using MartialExcellence.Feats;
//using Kingmaker.Blueprints;
//using Kingmaker.Localization;
//using ModMenu.Settings;
//using System.Linq;
//using UnityEngine;
//using UnityModManagerNet;
//using System.Collections;
//using static UnityModManagerNet.UnityModManager.ModEntry;
//using Menu = ModMenu.ModMenu;

//namespace MartialExcellence.Util
//{
//    internal static class Settings
//    {
//        private static readonly string RootKey = "me.settings";

//        private static readonly ModLogger Logger = Logging.GetLogger(nameof(Settings));

//        internal static bool IsEnabled(string key)
//        {
//            return Menu.GetSettingValue<bool>(GetKey(key));
//        }

//        //internal static bool IsTTTBaseEnabled()
//        //{
//        //    return UnityModManager.modEntries.Where(
//        //        mod => mod.Info.Id.Equals("TabletopTweaks-Base") && mod.Enabled && !mod.ErrorOnLoading)
//        //      .Any();
//        //}

//        internal static void Init()
//        {
//            Logger.Log("Initializing settings.");
//            var settings =
//              SettingsBuilder.New(RootKey, GetString("MartialExcellence.Settings.Title"))
//                //.AddImage(
//                  //ResourcesLibrary.TryGetResource<Sprite>("assets/illustrations/wolfie.png"), height: 200, imageScale: 0.75f)
//                .AddDefaultButton(OnDefaultsApplied);

//            //settings.AddSubHeader(GetString("Settings.Homebrew.Title"), startExpanded: true)
//            //  .AddToggle(
//            //    Toggle.New(
//            //      GetKey(GloriousHeat.OriginalFeatSetting),
//            //      defaultValue: false,
//            //      GetString("Settings.Homebrew.GloriousHeat"))
//            //    .WithLongDescription(GetString("Settings.Homebrew.GloriousHeat.Description")));

//            //settings.AddSubHeader(GetString("Settings.Fixes.Title"), startExpanded: false);
//            //foreach (var (key, name, description) in BugFixes.Entries)
//            //{
//            //    settings.AddToggle(
//            //      Toggle.New(GetKey(key), defaultValue: true, GetString(name))
//            //        .WithLongDescription(GetString(description)));
//            //}

//            //settings.AddSubHeader(GetString("Settings.Archetypes.Title"));
//            //foreach (var (guid, name) in Guids.Archetypes)
//            //{
//            //    settings.AddToggle(
//            //      Toggle.New(GetKey(guid), defaultValue: true, GetString(name))
//            //        .WithLongDescription(GetString("Settings.EnableFeature")));
//            //}

//            //settings.AddSubHeader(GetString("Settings.ClassFeatures.Title"));
//            //foreach (var (guid, name) in Guids.ClassFeatures)
//            //{
//            //    settings.AddToggle(
//            //      Toggle.New(GetKey(guid), defaultValue: true, GetString(name))
//            //        .WithLongDescription(GetString("Settings.EnableFeature")));
//            //}

//            settings.AddSubHeader(GetString("MartialExcellence.Settings.Feats.Title"));
//            foreach (var (guid, name) in Guids.Feats)
//            {
//                settings.AddToggle(
//                  Toggle.New(GetKey(guid), defaultValue: true, GetString(name))
//                    .WithLongDescription(GetString("MartialExcellence.Settings.EnableFeature")));
//            }

//            settings.AddSubHeader(GetString("MartialExcellence.Settings.RagePowers.Title"));
//            foreach (var (guid, name) in Guids.RagePowers)
//            {
//                settings.AddToggle(
//                  Toggle.New(GetKey(guid), defaultValue: true, GetString(name))
//                    .WithLongDescription(GetString("MartialExcellence.Settings.EnableFeature")));
//            }

//            Menu.AddSettings(settings);
//        }

//        private static void OnDefaultsApplied()
//        {
//            Logger.Log($"Default settings restored.");
//        }

//        private static LocalizedString GetString(string key)
//        {
//            return LocalizationTool.GetString(key);
//        }

//        private static string GetKey(string partialKey)
//        {
//            return $"{RootKey}.{partialKey}";
//        }
//    }
//}
