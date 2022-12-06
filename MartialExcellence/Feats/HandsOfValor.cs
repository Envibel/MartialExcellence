using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators;
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
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
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
    /// Creates the Hands of Valor feat.
    /// </summary>
    public class HandsOfValor
    {
        private static readonly string FeatName = "HandsOfValorFeat";
        private static readonly string FeatBuffName = "HandsOfValorFeatBuff";
        private static readonly string FeatAbilitySelfName = "HandsOfValorFeatAbilitySelf";
        private static readonly string FeatAbilityOthersName = "HandsOfValorFeatAbilityOthers";
        private static readonly string FeatAbilityResourceName = "HandsOfValorFeatAbilityResource";

        internal const string DisplayName = "HandsOfValor.Name";
        internal const string AbilitySelfName = "HandsOfValor.Self.Name";
        internal const string AbilityOthersName = "HandsOfValor.Others.Name";
        private static readonly string Description = "HandsOfValor.Description";
        private static readonly string Icon = "assets/icons/handsofvalor.jpg";
        private static readonly string IconSelf = "assets/icons/handsofvalorself.jpg";

        public static void Configure()
        {
            var buff =
                BuffConfigurator.New(FeatBuffName, Guids.HandsOfValorBuffGuid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .AddSavingThrowBonusAgainstDescriptor(ContextValues.Rank(), modifierDescriptor: ModifierDescriptor.Sacred, spellDescriptor: new SpellDescriptorWrapper(SpellDescriptor.Fear))
                    .AddContextStatBonus(StatType.AdditionalAttackBonus, ContextValues.Rank(), descriptor: ModifierDescriptor.Sacred, minimal: 1)
                    .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                    .SetIcon(IconSelf)
                    .Configure();

            var resource =
                AbilityResourceConfigurator.New(FeatAbilityResourceName, Guids.HandsOfValorAbilityResourceGuid)
                .SetMaxAmount(ResourceAmountBuilder.New(1))
                .Configure();

            var abilityOthers =
                AbilityConfigurator.New(FeatAbilityOthersName, Guids.HandsOfValorAbilityOthersGuid)
                    .CopyFrom(AbilityRefs.LayOnHandsOthers)
                    .SetDisplayName(AbilityOthersName)
                    .SetDescription(Description)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: resource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New().ApplyBuffWithDurationSeconds(buff, 60, isNotDispelable: true))
                    .AddSpellDescriptorComponent(new SpellDescriptorWrapper(SpellDescriptor.Cure))
                    .AddAbilityTargetNotSelf()
                    .SetIcon(Icon)
                    .Configure();

            var abilitySelf =
                AbilityConfigurator.New(FeatAbilitySelfName, Guids.HandsOfValorAbilitySelfGuid)
                    .CopyFrom(AbilityRefs.LayOnHandsSelf)
                    .SetDisplayName(AbilitySelfName)
                    .SetDescription(Description)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: resource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New().ApplyBuffWithDurationSeconds(buff, 60, isNotDispelable: true))
                    .AddSpellDescriptorComponent(new SpellDescriptorWrapper(SpellDescriptor.Cure))
                    .SetIcon(IconSelf)
                    .Configure();

            FeatureConfigurator.New(FeatName, Guids.HandsOfValorGuid, FeatureGroup.Feat)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddPrerequisiteFeature(FeatureRefs.LayOnHandsFeature.ToString())
                .AddPrerequisiteFeature(FeatureRefs.IomedaeFeature.ToString())
                .AddFeatureTagsComponent(FeatureTag.ClassSpecific)
                .AddAbilityResources(resource: resource, restoreAmount: true)
                .AddFacts(new() { abilitySelf, abilityOthers })
                .SetIcon(Icon)
                .Configure(delayed: true);
        }
    }
}

