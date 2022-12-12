using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Blueprints.Root;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using MartialExcellence.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using static Kingmaker.UnitLogic.FactLogic.AddMechanicsFeature;

namespace MartialExcellence.Races.Skinwalker.Heritages
{
    class SkinwalkerScaleheart
    {
        private static readonly string SkinwalkerScareName = "SkinwalkerScare";

        private static readonly string SkinwalkerHeritageScaleheartName = "SkinwalkerHeritageScaleheart";
        private static readonly string SkinwalkerHeritageScaleheartChangeShapeBaseName = "SkinwalkerHeritageScaleheartChangeShapeBase";
        private static readonly string SkinwalkerHeritageScaleheartChangeShapeRevertName = "SkinwalkerHeritageScaleheartChangeShapeRevert";

        private static readonly string SkinwalkerHeritageScaleheartChangeShapeBiteAbilityName = "SkinwalkerHeritageScaleheartChangeShapeBiteAbility";
        private static readonly string SkinwalkerHeritageScaleheartChangeShapeBiteBuffName = "SkinwalkerHeritageScaleheartChangeShapeBiteBuff";
        private static readonly string SkinwalkerHeritageScaleheartChangeShapeArmorAbilityName = "SkinwalkerHeritageScaleheartChangeShapeArmorAbility";
        private static readonly string SkinwalkerHeritageScaleheartChangeShapeArmorBuffName = "SkinwalkerHeritageScaleheartChangeShapeArmorBuff";
        private static readonly string SkinwalkerHeritageScaleheartChangeShapeInitiativeAbilityName = "SkinwalkerHeritageScaleheartChangeShapeInitiativeAbility";
        private static readonly string SkinwalkerHeritageScaleheartChangeShapeInitiativeBuffName = "SkinwalkerHeritageScaleheartChangeShapeInitiativeBuff";
        private static readonly string SkinwalkerHeritageScaleheartChangeShapeFerocityAbilityName = "SkinwalkerHeritageScaleheartChangeShapeFerocityAbility";
        private static readonly string SkinwalkerHeritageScaleheartChangeShapeFerocityBuffName = "SkinwalkerHeritageScaleheartChangeShapeFerocityBuff";

        internal const string HeritageScaleheartDisplayName = "Skinwalker.Heritage.Scaleheart.Name";
        private static readonly string HeritageScaleheartDescription = "Skinwalker.Heritage.Scaleheart.Description";
        internal const string HeritageScaleheartChangeShapeBaseDisplayName = "Skinwalker.Heritage.Scaleheart.ChangeShapeBase.Name";
        private static readonly string HeritageScaleheartChangeShapeBaseDescription = "Skinwalker.Heritage.Scaleheart.ChangeShapeBase.Description";
        internal const string HeritageScaleheartChangeShapeBiteDisplayName = "Skinwalker.Heritage.Scaleheart.ChangeShapeBite.Name";
        private static readonly string HeritageScaleheartChangeShapeBiteDescription = "Skinwalker.Heritage.Scaleheart.ChangeShapeBite.Description";
        internal const string HeritageScaleheartChangeShapeArmorDisplayName = "Skinwalker.Heritage.Scaleheart.ChangeShapeArmor.Name";
        private static readonly string HeritageScaleheartChangeShapeArmorDescription = "Skinwalker.Heritage.Scaleheart.ChangeShapeArmor.Description";
        internal const string HeritageScaleheartChangeShapeInitiativeDisplayName = "Skinwalker.Heritage.Scaleheart.ChangeShapeInitiative.Name";
        private static readonly string HeritageScaleheartChangeShapeInitiativeDescription = "Skinwalker.Heritage.Scaleheart.ChangeShapeInitiative.Description";
        internal const string HeritageScaleheartChangeShapeFerocityDisplayName = "Skinwalker.Heritage.Scaleheart.ChangeShapeFerocity.Name";
        private static readonly string HeritageScaleheartChangeShapeFerocityDescription = "Skinwalker.Heritage.Scaleheart.ChangeShapeFerocity.Description";

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";

        private static readonly string ScaleheartIcon = "assets/icons/skinwalkerscaleheart.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string BiteIcon = "assets/icons/changeshapebite.jpg";
        private static readonly string ArmorIcon = "assets/icons/changeshapearmor.jpg";
        private static readonly string InitiativeIcon = "assets/icons/changeshapeinitiative.jpg";
        private static readonly string FerocityIcon = "assets/icons/changeshapeferocity.jpg";
        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);


            var heritageScaleheartChangeShapeBaseBiteBuff =
                BuffConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeBiteBuffName, Guids.SkinwalkerHeritageScaleheartChangeShapeBiteBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageScaleheartChangeShapeBaseBiteBuff)
                .SetDisplayName(HeritageScaleheartChangeShapeBiteDisplayName)
                .SetDescription(HeritageScaleheartChangeShapeBiteDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .SetIcon(BiteIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageScaleheartChangeShapeBaseBiteBuff))
                .Configure();


            var heritageScaleheartChangeShapeBaseArmorBuff =
                BuffConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeArmorBuffName, Guids.SkinwalkerHeritageScaleheartChangeShapeArmorBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageScaleheartChangeShapeBaseArmorBuff)
                .SetDisplayName(HeritageScaleheartChangeShapeArmorDisplayName)
                .SetDescription(HeritageScaleheartChangeShapeArmorDescription)
                .AddStatBonus(ModifierDescriptor.NaturalArmor, stat: StatType.AC, value: 1)
                .SetIcon(ArmorIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageScaleheartChangeShapeBaseArmorBuff))
                .Configure();

            var heritageScaleheartChangeShapeBaseInitiativeBuff =
                BuffConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeInitiativeBuffName, Guids.SkinwalkerHeritageScaleheartChangeShapeInitiativeBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageScaleheartChangeShapeBaseInitiativeBuff)
                .SetDisplayName(HeritageScaleheartChangeShapeInitiativeDisplayName)
                .SetDescription(HeritageScaleheartChangeShapeInitiativeDescription)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Initiative, value: 2)
                .SetIcon(InitiativeIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageScaleheartChangeShapeBaseInitiativeBuff))
                .Configure();

            var heritageScaleheartChangeShapeBaseFerocityBuff =
                BuffConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeFerocityBuffName, Guids.SkinwalkerHeritageScaleheartChangeShapeFerocityBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageScaleheartChangeShapeBaseFerocityBuff)
                .SetDisplayName(HeritageScaleheartChangeShapeFerocityDisplayName)
                .SetDescription(HeritageScaleheartChangeShapeFerocityDescription)
                .AddMechanicsFeature(MechanicsFeatureType.Ferocity)
                .SetIcon(FerocityIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageScaleheartChangeShapeBaseFerocityBuff))
                .Configure();

            var heritageScaleheartChangeShapeBaseBiteAbility =
                AbilityConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeBiteAbilityName, Guids.SkinwalkerHeritageScaleheartChangeShapeBiteAbilityGuid)
                    .SetDisplayName(HeritageScaleheartChangeShapeBiteDisplayName)
                    .SetDescription(HeritageScaleheartChangeShapeBiteDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageScaleheartChangeShapeBaseBiteBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageScaleheartChangeShapeBaseBiteBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(BiteIcon)
                    .Configure();

            var heritageScaleheartChangeShapeBaseArmorAbility =
                AbilityConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeArmorAbilityName, Guids.SkinwalkerHeritageScaleheartChangeShapeArmorAbilityGuid)
                .SetDisplayName(HeritageScaleheartChangeShapeArmorDisplayName)
                .SetDescription(HeritageScaleheartChangeShapeArmorDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageScaleheartChangeShapeBaseArmorBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageScaleheartChangeShapeBaseArmorBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(ArmorIcon)
                .Configure();

            var heritageScaleheartChangeShapeBaseInitiativeAbility =
                AbilityConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeInitiativeAbilityName, Guids.SkinwalkerHeritageScaleheartChangeShapeInitiativeAbilityGuid)
                    .SetDisplayName(HeritageScaleheartChangeShapeInitiativeDisplayName)
                    .SetDescription(HeritageScaleheartChangeShapeInitiativeDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageScaleheartChangeShapeBaseInitiativeBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageScaleheartChangeShapeBaseInitiativeBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(InitiativeIcon)
                    .Configure();

            var heritageScaleheartChangeShapeBaseFerocityAbility =
                AbilityConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeFerocityAbilityName, Guids.SkinwalkerHeritageScaleheartChangeShapeFerocityAbilityGuid)
                    .SetDisplayName(HeritageScaleheartChangeShapeFerocityDisplayName)
                    .SetDescription(HeritageScaleheartChangeShapeFerocityDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageScaleheartChangeShapeBaseFerocityBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageScaleheartChangeShapeBaseFerocityBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(FerocityIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageScaleheartChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageScaleheartChangeShapeList.Add(heritageScaleheartChangeShapeBaseBiteAbility);
            heritageScaleheartChangeShapeList.Add(heritageScaleheartChangeShapeBaseArmorAbility);
            heritageScaleheartChangeShapeList.Add(heritageScaleheartChangeShapeBaseInitiativeAbility);
            heritageScaleheartChangeShapeList.Add(heritageScaleheartChangeShapeBaseFerocityAbility);


            var heritageScaleheartChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeBaseName, Guids.SkinwalkerHeritageScaleheartChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageScaleheartChangeShapeBaseDisplayName)
                    .SetDescription(HeritageScaleheartChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageScaleheartChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageScaleheartChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageScaleheartChangeShapeRevertName, Guids.SkinwalkerHeritageScaleheartChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageScaleheartChangeShapeBaseBiteBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageScaleheartChangeShapeBaseBiteBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageScaleheartChangeShapeBaseArmorBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageScaleheartChangeShapeBaseArmorBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageScaleheartChangeShapeBaseInitiativeBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageScaleheartChangeShapeBaseInitiativeBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageScaleheartChangeShapeBaseFerocityBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageScaleheartChangeShapeBaseFerocityBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerScare =
                AbilityConfigurator.New(SkinwalkerScareName, Guids.SkinwalkerScareGuid)
                    .CopyFrom(AbilityRefs.Scare, typeof(SpellComponent), typeof(SpellListComponent), typeof(SpellDescriptorComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff), typeof(AbilityTargetsAround))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var heritageScaleheart =
                FeatureConfigurator.New(SkinwalkerHeritageScaleheartName, Guids.SkinwalkerHeritageScaleheartGuid)
                    .SetDisplayName(HeritageScaleheartDisplayName)
                    .SetDescription(HeritageScaleheartDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageScaleheartChangeShapeBaseAbility, heritageScaleheartChangeShapeRevertAbility, skinwalkerScare })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillStealth, value: 2)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Constitution, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Strength, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: -2)
                    .SetIcon(ScaleheartIcon)
                    .Configure();

        }

    }
}
