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
        private static readonly string FeatAbilityStandardRageName = "RagingBrutalityFeatAbilityStandardRage";
        private static readonly string FeatAbilityFocusedRageName = "RagingBrutalityFeatAbilityFocusedRage";
        private static readonly string FeatAbilityBloodragerRageName = "RagingBrutalityFeatAbilityBloodragerRage";


        internal const string DisplayName = "RagingBrutality.Name";
        internal const string StandardRageAbilityName = "RagingBrutality.StandardRage.Name";
        internal const string FocusedRageAbilityName = "RagingBrutality.FocusedRage.Name";
        internal const string BloodragerRageAbilityName = "RagingBrutality.BloodragerRage.Name";

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

            List<Blueprint<BlueprintBuffReference>> reqStandardBuffs = new List<Blueprint<BlueprintBuffReference>>();
            reqStandardBuffs.Add(BuffRefs.StandartRageBuff.ToString());
            reqStandardBuffs.Add(BuffRefs.PowerAttackBuff.ToString());

            List<Blueprint<BlueprintBuffReference>> reqBloodBuffs = new List<Blueprint<BlueprintBuffReference>>();
            reqBloodBuffs.Add(BuffRefs.BloodragerStandartRageBuff.ToString());
            reqBloodBuffs.Add(BuffRefs.PowerAttackBuff.ToString());

            List<Blueprint<BlueprintBuffReference>> reqFocusedBuffs = new List<Blueprint<BlueprintBuffReference>>();
            reqFocusedBuffs.Add(BuffRefs.StandartFocusedRageBuff.ToString());
            reqFocusedBuffs.Add(BuffRefs.PowerAttackBuff.ToString());

            var abilityStandardRage =
                AbilityConfigurator.New(FeatAbilityStandardRageName, Guids.RagingBrutalityAbilityStandardRageGuid)
                    .SetDisplayName(StandardRageAbilityName)
                    .SetDescription(Description)
                    .SetType(AbilityType.Extraordinary)
                    .AddAbilityResourceLogic(3, isSpendResource: true, requiredResource: AbilityResourceRefs.RageResourse.ToString())
                    .SetActionType(UnitCommand.CommandType.Swift)
                    .AddTargetHasBuffsFromCaster(reqStandardBuffs, requireAllBuffs: true)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New().ApplyBuffWithDurationSeconds(buff, 6, isNotDispelable: true))
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(Icon)
                    .Configure();

            var abilityFocusedRage =
                AbilityConfigurator.New(FeatAbilityFocusedRageName, Guids.RagingBrutalityAbilityFocusedRageGuid)
                    .SetDisplayName(FocusedRageAbilityName)
                    .SetDescription(Description)
                    .SetType(AbilityType.Extraordinary)
                    .AddAbilityResourceLogic(3, isSpendResource: true, requiredResource: AbilityResourceRefs.FocusedRageResourse.ToString())
                    .SetActionType(UnitCommand.CommandType.Swift)
                    .AddTargetHasBuffsFromCaster(reqFocusedBuffs, requireAllBuffs: true)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New().ApplyBuffWithDurationSeconds(buff, 6, isNotDispelable: true))
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(Icon)
                    .Configure();

            var abilityBloodragerRage =
                AbilityConfigurator.New(FeatAbilityBloodragerRageName, Guids.RagingBrutalityAbilityBloodragerRageGuid)
                    .SetDisplayName(BloodragerRageAbilityName)
                    .SetDescription(Description)
                    .SetType(AbilityType.Extraordinary)
                    .AddAbilityResourceLogic(3, isSpendResource: true, requiredResource: AbilityResourceRefs.BloodragerRageResource.ToString())
                    .SetActionType(UnitCommand.CommandType.Swift)
                    .AddTargetHasBuffsFromCaster(reqBloodBuffs, requireAllBuffs: true)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New().ApplyBuffWithDurationSeconds(buff, 6, isNotDispelable: true))
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(Icon)
                    .Configure();

            List<Blueprint<BlueprintFeatureReference>> rageFeatures = new List<Blueprint<BlueprintFeatureReference>>();
            rageFeatures.Add(FeatureRefs.RageFeature.ToString());
            rageFeatures.Add(FeatureRefs.BloodragerRageFeature.ToString());
            rageFeatures.Add(FeatureRefs.FocusedRageFeature.ToString());

            FeatureConfigurator.New(FeatName, Guids.RagingBrutalityGuid, FeatureGroup.CombatFeat, FeatureGroup.Feat, FeatureGroup.RangerStyle)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
                .AddPrerequisiteFeaturesFromList(rageFeatures)
                .AddPrerequisiteStatValue(StatType.BaseAttackBonus, 12)
                .AddPrerequisiteStatValue(StatType.Strength, 13)
                .AddFeatureTagsComponent(FeatureTag.Melee | FeatureTag.Damage | FeatureTag.ClassSpecific)
                .AddFacts(new() { abilityStandardRage, abilityFocusedRage, abilityBloodragerRage })
                .SetIcon(Icon)
                .Configure(delayed: true);
        }
    }
}

