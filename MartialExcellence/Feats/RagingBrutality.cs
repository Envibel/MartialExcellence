using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Commands.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using MartialExcellence.Util;
using System.Collections.Generic;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;

namespace MartialExcellence.Feats
{
    /// <summary>
    /// Creates the Raging Brutality feat.
    /// </summary>
    public class RagingBrutality
    {
        private static readonly string FeatName = "RagingBrutalityFeat";
        private static readonly string FeatBuffName = "RagingBrutalityFeatBuff";
        private static readonly string FeatAbilityName = "RagingBrutalityFeatAbility";

        internal const string DisplayName = "RagingBrutality.Name";
        private static readonly string Description = "RagingBrutality.Description";
        private static readonly string Icon = "assets/icons/ragingbrutality.jpg";

        public static void Configure()
        {
            var buff =
                BuffConfigurator.New(FeatBuffName, Guids.RagingBrutalityBuffGuid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .AddContextStatBonus(StatType.AdditionalDamage, ContextValues.Rank())
                    .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Constitution))
                    .SetIcon(Icon)
                    .Configure();

            List<Blueprint<BlueprintBuffReference>> reqBuffs = new List<Blueprint<BlueprintBuffReference>>();
            reqBuffs.Add(BuffRefs.StandartRageBuff.ToString());
            reqBuffs.Add(BuffRefs.PowerAttackBuff.ToString());

            var ability =
                AbilityConfigurator.New(FeatAbilityName, Guids.RagingBrutalityAbilityGuid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetType(AbilityType.Extraordinary)
                    .AddAbilityResourceLogic(3, isSpendResource: true, requiredResource: AbilityResourceRefs.RageResourse.ToString())
                    .SetActionType(UnitCommand.CommandType.Swift)
                    .AddTargetHasBuffsFromCaster(reqBuffs, requireAllBuffs: true)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New().ApplyBuffWithDurationSeconds(buff, 6, isNotDispelable: true)
                    )
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(Icon)
                    .Configure();

            FeatureConfigurator.New(FeatName, Guids.RagingBrutalityGuid, FeatureGroup.CombatFeat, FeatureGroup.Feat, FeatureGroup.RangerStyle)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
                .AddPrerequisiteFeature(FeatureRefs.RageFeature.ToString())
                .AddPrerequisiteStatValue(StatType.BaseAttackBonus, 12)
                .AddPrerequisiteStatValue(StatType.Strength, 13)
                .AddFeatureTagsComponent(FeatureTag.Melee | FeatureTag.Damage | FeatureTag.ClassSpecific)
                .AddFacts(new() { ability })
                .SetIcon(Icon)
                .Configure(delayed: true);
        }
    }
}

