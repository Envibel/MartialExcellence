using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using MartialExcellence.Util;
using System;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace MartialExcellence.Feats
{
    /// <summary>
    /// Creates the Extra Feature feat.
    /// </summary>
    public class ExtraFeature
    {
        private static readonly string FeatName = "ExtraFeatureFeat";

        internal const string DisplayName = "ExtraFeature.Name";
        private static readonly string Description = "ExtraFeature.Description";
        private static readonly string Icon = "assets/icons/extrafeature.jpg";
        //private static readonly ModLogger Logger = Logging.GetLogger(nameof(Settings));

        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.ExtraFeatureGuid, FeatureGroup.CombatFeat, FeatureGroup.Feat)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddPrerequisiteStatValue(StatType.Constitution, 13, group: GroupType.Any)
                .AddPrerequisiteFeature(BlueprintTool.Get<BlueprintRace>(Guids.SkinwalkerGuid))
                .AddIncreaseResourceAmount(BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid), 1)
                .SetRanks(3)
                .SetIcon(Icon)
                .Configure(delayed: true);
        }
    }
}

