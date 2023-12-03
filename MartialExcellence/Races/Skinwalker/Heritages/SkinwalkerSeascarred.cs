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
using CodexLib;

namespace MartialExcellence.Races.Skinwalker.Heritages
{
    class SkinwalkerSeascarred
    {
        private static readonly string SkinwalkerResistEnergyColdName = "SkinwalkerResistEnergyCold";

        private static readonly string SkinwalkerHeritageSeascarredName = "SkinwalkerHeritageSeascarred";
        private static readonly string SkinwalkerHeritageSeascarredChangeShapeBaseName = "SkinwalkerHeritageSeascarredChangeShapeBase";
        private static readonly string SkinwalkerHeritageSeascarredChangeShapeRevertName = "SkinwalkerHeritageSeascarredChangeShapeRevert";

        private static readonly string SkinwalkerHeritageSeascarredChangeShapeBiteAbilityName = "SkinwalkerHeritageSeascarredChangeShapeBiteAbility";
        private static readonly string SkinwalkerHeritageSeascarredChangeShapeBiteBuffName = "SkinwalkerHeritageSeascarredChangeShapeBiteBuff";
        private static readonly string SkinwalkerHeritageSeascarredChangeShapeInitiativeAbilityName = "SkinwalkerHeritageSeascarredChangeShapeInitiativeAbility";
        private static readonly string SkinwalkerHeritageSeascarredChangeShapeInitiativeBuffName = "SkinwalkerHeritageSeascarredChangeShapeInitiativeBuff";
        private static readonly string SkinwalkerHeritageSeascarredChangeShapeFerocityAbilityName = "SkinwalkerHeritageSeascarredChangeShapeFerocityAbility";
        private static readonly string SkinwalkerHeritageSeascarredChangeShapeFerocityBuffName = "SkinwalkerHeritageSeascarredChangeShapeFerocityBuff";
        private static readonly string SkinwalkerHeritageSeascarredChangeShapeScentAbilityName = "SkinwalkerHeritageSeascarredChangeShapeScentAbility";
        private static readonly string SkinwalkerHeritageSeascarredChangeShapeScentBuffName = "SkinwalkerHeritageSeascarredChangeShapeScentBuff";

        internal const string HeritageSeascarredDisplayName = "Skinwalker.Heritage.Seascarred.Name";
        private static readonly string HeritageSeascarredDescription = "Skinwalker.Heritage.Seascarred.Description";
        internal const string HeritageSeascarredChangeShapeBaseDisplayName = "Skinwalker.Heritage.Seascarred.ChangeShapeBase.Name";
        private static readonly string HeritageSeascarredChangeShapeBaseDescription = "Skinwalker.Heritage.Seascarred.ChangeShapeBase.Description";
        internal const string HeritageSeascarredChangeShapeBiteDisplayName = "Skinwalker.Heritage.Seascarred.ChangeShapeBite.Name";
        private static readonly string HeritageSeascarredChangeShapeBiteDescription = "Skinwalker.Heritage.Seascarred.ChangeShapeBite.Description";
        internal const string HeritageSeascarredChangeShapeInitiativeDisplayName = "Skinwalker.Heritage.Seascarred.ChangeShapeInitiative.Name";
        private static readonly string HeritageSeascarredChangeShapeInitiativeDescription = "Skinwalker.Heritage.Seascarred.ChangeShapeInitiative.Description";
        internal const string HeritageSeascarredChangeShapeFerocityDisplayName = "Skinwalker.Heritage.Seascarred.ChangeShapeFerocity.Name";
        private static readonly string HeritageSeascarredChangeShapeFerocityDescription = "Skinwalker.Heritage.Seascarred.ChangeShapeFerocity.Description";
        internal const string HeritageSeascarredChangeShapeScentDisplayName = "Skinwalker.Heritage.Seascarred.ChangeShapeScent.Name";
        private static readonly string HeritageSeascarredChangeShapeScentDescription = "Skinwalker.Heritage.Seascarred.ChangeShapeScent.Description";

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";

        private static readonly string SeascarredIcon = "assets/icons/skinwalkerseascarred.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string BiteIcon = "assets/icons/changeshapebite.jpg";
        private static readonly string InitiativeIcon = "assets/icons/changeshapeinitiative.jpg";
        private static readonly string FerocityIcon = "assets/icons/changeshapeferocity.jpg";
        private static readonly string ScentIcon = "assets/icons/changeshapescent.jpg";
        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);


            var heritageSeascarredChangeShapeBaseBiteBuff =
                BuffConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeBiteBuffName, Guids.SkinwalkerHeritageSeascarredChangeShapeBiteBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageSeascarredChangeShapeBaseBiteBuff)
                .SetDisplayName(HeritageSeascarredChangeShapeBiteDisplayName)
                .SetDescription(HeritageSeascarredChangeShapeBiteDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .SetIcon(BiteIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageSeascarredChangeShapeBaseBiteBuff))
                .Configure();


            var heritageSeascarredChangeShapeBaseInitiativeBuff =
                BuffConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeInitiativeBuffName, Guids.SkinwalkerHeritageSeascarredChangeShapeInitiativeBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageSeascarredChangeShapeBaseInitiativeBuff)
                .SetDisplayName(HeritageSeascarredChangeShapeInitiativeDisplayName)
                .SetDescription(HeritageSeascarredChangeShapeInitiativeDescription)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Initiative, value: 2)
                .SetIcon(InitiativeIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageSeascarredChangeShapeBaseInitiativeBuff))
                .Configure();

            var heritageSeascarredChangeShapeBaseFerocityBuff =
                BuffConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeFerocityBuffName, Guids.SkinwalkerHeritageSeascarredChangeShapeFerocityBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageSeascarredChangeShapeBaseFerocityBuff)
                .SetDisplayName(HeritageSeascarredChangeShapeFerocityDisplayName)
                .SetDescription(HeritageSeascarredChangeShapeFerocityDescription)
                .AddMechanicsFeature(MechanicsFeatureType.Ferocity)
                .SetIcon(FerocityIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageSeascarredChangeShapeBaseFerocityBuff))
                .Configure();

            var heritageSeascarredChangeShapeBaseScentBuff =
                BuffConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeScentBuffName, Guids.SkinwalkerHeritageSeascarredChangeShapeScentBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageSeascarredChangeShapeBaseScentBuff)
                .SetDisplayName(HeritageSeascarredChangeShapeScentDisplayName)
                .SetDescription(HeritageSeascarredChangeShapeScentDescription)
                .AddBlindsense(range: new Kingmaker.Utility.Feet(30))
                .SetIcon(ScentIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageSeascarredChangeShapeBaseScentBuff))
                .Configure();

            var heritageSeascarredChangeShapeBaseBiteAbility =
                AbilityConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeBiteAbilityName, Guids.SkinwalkerHeritageSeascarredChangeShapeBiteAbilityGuid)
                    .SetDisplayName(HeritageSeascarredChangeShapeBiteDisplayName)
                    .SetDescription(HeritageSeascarredChangeShapeBiteDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageSeascarredChangeShapeBaseBiteBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageSeascarredChangeShapeBaseBiteBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(BiteIcon)
                    .Configure();

            var heritageSeascarredChangeShapeBaseInitiativeAbility =
                AbilityConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeInitiativeAbilityName, Guids.SkinwalkerHeritageSeascarredChangeShapeInitiativeAbilityGuid)
                .SetDisplayName(HeritageSeascarredChangeShapeInitiativeDisplayName)
                .SetDescription(HeritageSeascarredChangeShapeInitiativeDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageSeascarredChangeShapeBaseInitiativeBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageSeascarredChangeShapeBaseInitiativeBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(InitiativeIcon)
                .Configure();

            var heritageSeascarredChangeShapeBaseFerocityAbility =
                AbilityConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeFerocityAbilityName, Guids.SkinwalkerHeritageSeascarredChangeShapeFerocityAbilityGuid)
                    .SetDisplayName(HeritageSeascarredChangeShapeFerocityDisplayName)
                    .SetDescription(HeritageSeascarredChangeShapeFerocityDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageSeascarredChangeShapeBaseFerocityBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageSeascarredChangeShapeBaseFerocityBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(FerocityIcon)
                    .Configure();

            var heritageSeascarredChangeShapeBaseScentAbility =
                AbilityConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeScentAbilityName, Guids.SkinwalkerHeritageSeascarredChangeShapeScentAbilityGuid)
                    .SetDisplayName(HeritageSeascarredChangeShapeScentDisplayName)
                    .SetDescription(HeritageSeascarredChangeShapeScentDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageSeascarredChangeShapeBaseScentBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageSeascarredChangeShapeBaseScentBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(ScentIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageSeascarredChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageSeascarredChangeShapeList.Add(heritageSeascarredChangeShapeBaseBiteAbility);
            heritageSeascarredChangeShapeList.Add(heritageSeascarredChangeShapeBaseInitiativeAbility);
            heritageSeascarredChangeShapeList.Add(heritageSeascarredChangeShapeBaseFerocityAbility);
            heritageSeascarredChangeShapeList.Add(heritageSeascarredChangeShapeBaseScentAbility);


            var heritageSeascarredChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeBaseName, Guids.SkinwalkerHeritageSeascarredChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageSeascarredChangeShapeBaseDisplayName)
                    .SetDescription(HeritageSeascarredChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageSeascarredChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageSeascarredChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageSeascarredChangeShapeRevertName, Guids.SkinwalkerHeritageSeascarredChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageSeascarredChangeShapeBaseBiteBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageSeascarredChangeShapeBaseBiteBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageSeascarredChangeShapeBaseInitiativeBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageSeascarredChangeShapeBaseInitiativeBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageSeascarredChangeShapeBaseFerocityBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageSeascarredChangeShapeBaseFerocityBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageSeascarredChangeShapeBaseScentBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageSeascarredChangeShapeBaseScentBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerResistEnergyCold =
                AbilityConfigurator.New(SkinwalkerResistEnergyColdName, Guids.SkinwalkerResistEnergyColdGuid)
                    .CopyFrom(AbilityRefs.ResistCold, typeof(SpellComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff), typeof(AbilitySpawnFx))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var mythic = Helper.ToRef<BlueprintUnitFactReference>("325f078c584318849bfe3da9ea245b9d").ObjToArray();

            var heritageSeascarred =
                FeatureConfigurator.New(SkinwalkerHeritageSeascarredName, Guids.SkinwalkerHeritageSeascarredGuid)
                    .SetDisplayName(HeritageSeascarredDisplayName)
                    .SetDescription(HeritageSeascarredDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageSeascarredChangeShapeBaseAbility, heritageSeascarredChangeShapeRevertAbility, skinwalkerResistEnergyCold })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillPerception, value: 2)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillAthletics, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Constitution, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: 2)
                    .AddComponent(new AddStatBonusIfHasFact
                    {
                        Descriptor = ModifierDescriptor.Racial,
                        Stat = StatType.Intelligence,
                        Value = -2,
                        InvertCondition = true,
                        m_CheckedFacts = mythic
                    })
                    .SetIcon(SeascarredIcon)
                    .Configure();

        }

    }
}
