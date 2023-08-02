using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.Configurators.UnitLogic.Properties;
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
using Kingmaker.Blueprints.Items.Weapons;
using Kingmaker.Blueprints.Root;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.Base;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Kingmaker.UnitLogic.Mechanics.Properties;
using MartialExcellence.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using CodexLib;

namespace MartialExcellence.Races.Skinwalker.Heritages
{
    class SkinwalkerNightskulk
    {
        private static readonly string SkinwalkerAnimalAspectRaccoonName = "SkinwalkerAnimalAspectRaccoon";

        private static readonly string SkinwalkerHeritageNightskulkName = "SkinwalkerHeritageNightskulk";
        private static readonly string SkinwalkerHeritageNightskulkChangeShapeBaseName = "SkinwalkerHeritageNightskulkChangeShapeBase";
        private static readonly string SkinwalkerHeritageNightskulkChangeShapeRevertName = "SkinwalkerHeritageNightskulkChangeShapeRevert";

        private static readonly string SkinwalkerHeritageNightskulkChangeShapeBiteAbilityName = "SkinwalkerHeritageNightskulkChangeShapeBiteAbility";
        private static readonly string SkinwalkerHeritageNightskulkChangeShapeBiteBuffName = "SkinwalkerHeritageNightskulkChangeShapeBiteBuff";
        private static readonly string SkinwalkerHeritageNightskulkChangeShapeAthleticsAbilityName = "SkinwalkerHeritageNightskulkChangeShapeAthleticsAbility";
        private static readonly string SkinwalkerHeritageNightskulkChangeShapeAthleticsBuffName = "SkinwalkerHeritageNightskulkChangeShapeAthleticsBuff";
        private static readonly string SkinwalkerHeritageNightskulkChangeShapeDistractionAbilityName = "SkinwalkerHeritageNightskulkChangeShapeDistractionAbility";
        private static readonly string SkinwalkerHeritageNightskulkChangeShapeDistractionBuffName = "SkinwalkerHeritageNightskulkChangeShapeDistractionBuff";
        private static readonly string SkinwalkerHeritageNightskulkChangeShapeScentAbilityName = "SkinwalkerHeritageNightskulkChangeShapeScentAbility";
        private static readonly string SkinwalkerHeritageNightskulkChangeShapeScentBuffName = "SkinwalkerHeritageNightskulkChangeShapeScentBuff";

        internal const string HeritageNightskulkDisplayName = "Skinwalker.Heritage.Nightskulk.Name";
        private static readonly string HeritageNightskulkDescription = "Skinwalker.Heritage.Nightskulk.Description";
        internal const string HeritageNightskulkChangeShapeBaseDisplayName = "Skinwalker.Heritage.Nightskulk.ChangeShapeBase.Name";
        private static readonly string HeritageNightskulkChangeShapeBaseDescription = "Skinwalker.Heritage.Nightskulk.ChangeShapeBase.Description";
        internal const string HeritageNightskulkChangeShapeBiteDisplayName = "Skinwalker.Heritage.Nightskulk.ChangeShapeBite.Name";
        private static readonly string HeritageNightskulkChangeShapeBiteDescription = "Skinwalker.Heritage.Nightskulk.ChangeShapeBite.Description";
        internal const string HeritageNightskulkChangeShapeAthleticsDisplayName = "Skinwalker.Heritage.Nightskulk.ChangeShapeAthletics.Name";
        private static readonly string HeritageNightskulkChangeShapeAthleticsDescription = "Skinwalker.Heritage.Nightskulk.ChangeShapeAthletics.Description";
        internal const string HeritageNightskulkChangeShapeDistractionDisplayName = "Skinwalker.Heritage.Nightskulk.ChangeShapeDistraction.Name";
        private static readonly string HeritageNightskulkChangeShapeDistractionDescription = "Skinwalker.Heritage.Nightskulk.ChangeShapeDistraction.Description";
        internal const string HeritageNightskulkChangeShapeScentDisplayName = "Skinwalker.Heritage.Nightskulk.ChangeShapeScent.Name";
        private static readonly string HeritageNightskulkChangeShapeScentDescription = "Skinwalker.Heritage.Nightskulk.ChangeShapeScent.Description";

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";

        private static readonly string NightskulkIcon = "assets/icons/skinwalkernightskulk.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string BiteIcon = "assets/icons/changeshapebite.jpg";
        private static readonly string AthleticsIcon = "assets/icons/changeshapeathletics.jpg";
        private static readonly string DistractionIcon = "assets/icons/changeshapedistraction.jpg";
        private static readonly string ScentIcon = "assets/icons/changeshapescent.jpg";
        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);


            var heritageNightskulkChangeShapeBaseBiteBuff =
                BuffConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeBiteBuffName, Guids.SkinwalkerHeritageNightskulkChangeShapeBiteBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageNightskulkChangeShapeBaseBiteBuff)
                .SetDisplayName(HeritageNightskulkChangeShapeBiteDisplayName)
                .SetDescription(HeritageNightskulkChangeShapeBiteDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .SetIcon(BiteIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageNightskulkChangeShapeBaseBiteBuff))
                .Configure();


            var heritageNightskulkChangeShapeBaseAthleticsBuff =
                BuffConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeAthleticsBuffName, Guids.SkinwalkerHeritageNightskulkChangeShapeAthleticsBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageNightskulkChangeShapeBaseAthleticsBuff)
                .SetDisplayName(HeritageNightskulkChangeShapeAthleticsDisplayName)
                .SetDescription(HeritageNightskulkChangeShapeAthleticsDescription)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillAthletics, value: 4)
                .SetIcon(AthleticsIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageNightskulkChangeShapeBaseAthleticsBuff))
                .Configure();

            var heritageNightskulkChangeShapeBaseDistractionBuff =
                BuffConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeDistractionBuffName, Guids.SkinwalkerHeritageNightskulkChangeShapeDistractionBuffGuid)
                .Configure();


            BuffConfigurator.For(heritageNightskulkChangeShapeBaseDistractionBuff)
                .SetDisplayName(HeritageNightskulkChangeShapeDistractionDisplayName)
                .SetDescription(HeritageNightskulkChangeShapeDistractionDescription)
                .AddContextCalculateAbilityParams(statType: StatType.Constitution, useKineticistMainStat: false)
                .AddInitiatorAttackWithWeaponTrigger(
                    onlyHit: true,
                    rangeType: WeaponRangeType.Melee,
                    onlyOnFirstHit: true,
                    group: WeaponFighterGroup.Natural,
                    checkWeaponGroup: true,
                    action:
                        ActionsBuilder.New()
                            .SavingThrow(SavingThrowType.Fortitude,
                                onResult:
                                    ActionsBuilder.New()
                                        .ConditionalSaved(
                                            failed:
                                                ActionsBuilder.New()
                                                    .ApplyBuff(
                                                        BuffRefs.DazeBuff.Reference.Get(),
                                                            ContextDuration.Fixed(1)))))
                .SetIcon(DistractionIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageNightskulkChangeShapeBaseDistractionBuff))
                .Configure();

            var heritageNightskulkChangeShapeBaseScentBuff =
                BuffConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeScentBuffName, Guids.SkinwalkerHeritageNightskulkChangeShapeScentBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageNightskulkChangeShapeBaseScentBuff)
                .SetDisplayName(HeritageNightskulkChangeShapeScentDisplayName)
                .SetDescription(HeritageNightskulkChangeShapeScentDescription)
                .AddBlindsense(range: new Kingmaker.Utility.Feet(30))
                .SetIcon(ScentIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageNightskulkChangeShapeBaseScentBuff))
                .Configure();

            var heritageNightskulkChangeShapeBaseBiteAbility =
                AbilityConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeBiteAbilityName, Guids.SkinwalkerHeritageNightskulkChangeShapeBiteAbilityGuid)
                    .SetDisplayName(HeritageNightskulkChangeShapeBiteDisplayName)
                    .SetDescription(HeritageNightskulkChangeShapeBiteDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageNightskulkChangeShapeBaseBiteBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageNightskulkChangeShapeBaseBiteBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(BiteIcon)
                    .Configure();

            var heritageNightskulkChangeShapeBaseAthleticsAbility =
                AbilityConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeAthleticsAbilityName, Guids.SkinwalkerHeritageNightskulkChangeShapeAthleticsAbilityGuid)
                .SetDisplayName(HeritageNightskulkChangeShapeAthleticsDisplayName)
                .SetDescription(HeritageNightskulkChangeShapeAthleticsDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageNightskulkChangeShapeBaseAthleticsBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageNightskulkChangeShapeBaseAthleticsBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(AthleticsIcon)
                .Configure();

            var heritageNightskulkChangeShapeBaseDistractionAbility =
                AbilityConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeDistractionAbilityName, Guids.SkinwalkerHeritageNightskulkChangeShapeDistractionAbilityGuid)
                    .SetDisplayName(HeritageNightskulkChangeShapeDistractionDisplayName)
                    .SetDescription(HeritageNightskulkChangeShapeDistractionDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddContextCalculateAbilityParams(statType: StatType.Constitution, useKineticistMainStat: false)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageNightskulkChangeShapeBaseDistractionBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageNightskulkChangeShapeBaseDistractionBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(DistractionIcon)
                    .Configure();

            var heritageNightskulkChangeShapeBaseScentAbility =
                AbilityConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeScentAbilityName, Guids.SkinwalkerHeritageNightskulkChangeShapeScentAbilityGuid)
                    .SetDisplayName(HeritageNightskulkChangeShapeScentDisplayName)
                    .SetDescription(HeritageNightskulkChangeShapeScentDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageNightskulkChangeShapeBaseScentBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageNightskulkChangeShapeBaseScentBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(ScentIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageNightskulkChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageNightskulkChangeShapeList.Add(heritageNightskulkChangeShapeBaseBiteAbility);
            heritageNightskulkChangeShapeList.Add(heritageNightskulkChangeShapeBaseAthleticsAbility);
            heritageNightskulkChangeShapeList.Add(heritageNightskulkChangeShapeBaseDistractionAbility);
            heritageNightskulkChangeShapeList.Add(heritageNightskulkChangeShapeBaseScentAbility);


            var heritageNightskulkChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeBaseName, Guids.SkinwalkerHeritageNightskulkChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageNightskulkChangeShapeBaseDisplayName)
                    .SetDescription(HeritageNightskulkChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageNightskulkChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageNightskulkChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageNightskulkChangeShapeRevertName, Guids.SkinwalkerHeritageNightskulkChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageNightskulkChangeShapeBaseBiteBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageNightskulkChangeShapeBaseBiteBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageNightskulkChangeShapeBaseAthleticsBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageNightskulkChangeShapeBaseAthleticsBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageNightskulkChangeShapeBaseDistractionBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageNightskulkChangeShapeBaseDistractionBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageNightskulkChangeShapeBaseScentBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageNightskulkChangeShapeBaseScentBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerAnimalAspectRaccoon =
                AbilityConfigurator.New(SkinwalkerAnimalAspectRaccoonName, Guids.SkinwalkerAnimalAspectRaccoonGuid)
                    .CopyFrom(AbilityRefs.AnimalAspectRacoon, typeof(SpellComponent), typeof(SpellListComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var mythic = Helper.ToRef<BlueprintUnitFactReference>("325f078c584318849bfe3da9ea245b9d").ObjToArray();

            var heritageNightskulk =
                FeatureConfigurator.New(SkinwalkerHeritageNightskulkName, Guids.SkinwalkerHeritageNightskulkGuid)
                    .SetDisplayName(HeritageNightskulkDisplayName)
                    .SetDescription(HeritageNightskulkDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageNightskulkChangeShapeBaseAbility, heritageNightskulkChangeShapeRevertAbility, skinwalkerAnimalAspectRaccoon })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillStealth, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Intelligence, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Dexterity, value: 2)
                    .AddComponent(new AddStatBonusIfHasFact
                    {
                        Descriptor = ModifierDescriptor.Racial,
                        Stat = StatType.Strength,
                        Value = -2,
                        InvertCondition = true,
                        m_CheckedFacts = mythic
                    })
                    .SetIcon(NightskulkIcon)
                    .Configure();

        }

    }
}
