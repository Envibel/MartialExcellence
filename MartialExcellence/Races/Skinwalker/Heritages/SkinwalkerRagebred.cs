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

namespace MartialExcellence.Races.Skinwalker.Heritages
{
    class SkinwalkerRagebred
    {
        private static readonly string SkinwalkerAnimalAspectGorillaName = "SkinwalkerAnimalAspectGorilla";

        private static readonly string SkinwalkerHeritageRagebredName = "SkinwalkerHeritageRagebred";
        private static readonly string SkinwalkerHeritageRagebredChangeShapeBaseName = "SkinwalkerHeritageRagebredChangeShapeBase";
        private static readonly string SkinwalkerHeritageRagebredChangeShapeRevertName = "SkinwalkerHeritageRagebredChangeShapeRevert";

        private static readonly string SkinwalkerHeritageRagebredChangeShapeSpeedAbilityName = "SkinwalkerHeritageRagebredChangeShapeSpeedAbility";
        private static readonly string SkinwalkerHeritageRagebredChangeShapeSpeedBuffName = "SkinwalkerHeritageRagebredChangeShapeSpeedBuff";
        private static readonly string SkinwalkerHeritageRagebredChangeShapeGoreAbilityName = "SkinwalkerHeritageRagebredChangeShapeGoreAbility";
        private static readonly string SkinwalkerHeritageRagebredChangeShapeGoreBuffName = "SkinwalkerHeritageRagebredChangeShapeGoreBuff";
        private static readonly string SkinwalkerHeritageRagebredChangeShapeHoovesAbilityName = "SkinwalkerHeritageRagebredChangeShapeHoovesAbility";
        private static readonly string SkinwalkerHeritageRagebredChangeShapeHoovesBuffName = "SkinwalkerHeritageRagebredChangeShapeHoovesBuff";
        private static readonly string SkinwalkerHeritageRagebredChangeShapeScentAbilityName = "SkinwalkerHeritageRagebredChangeShapeScentAbility";
        private static readonly string SkinwalkerHeritageRagebredChangeShapeScentBuffName = "SkinwalkerHeritageRagebredChangeShapeScentBuff";

        internal const string HeritageRagebredDisplayName = "Skinwalker.Heritage.Ragebred.Name";
        private static readonly string HeritageRagebredDescription = "Skinwalker.Heritage.Ragebred.Description";
        internal const string HeritageRagebredChangeShapeBaseDisplayName = "Skinwalker.Heritage.Ragebred.ChangeShapeBase.Name";
        private static readonly string HeritageRagebredChangeShapeBaseDescription = "Skinwalker.Heritage.Ragebred.ChangeShapeBase.Description";
        internal const string HeritageRagebredChangeShapeSpeedDisplayName = "Skinwalker.Heritage.Ragebred.ChangeShapeSpeed.Name";
        private static readonly string HeritageRagebredChangeShapeSpeedDescription = "Skinwalker.Heritage.Ragebred.ChangeShapeSpeed.Description";
        internal const string HeritageRagebredChangeShapeGoreDisplayName = "Skinwalker.Heritage.Ragebred.ChangeShapeGore.Name";
        private static readonly string HeritageRagebredChangeShapeGoreDescription = "Skinwalker.Heritage.Ragebred.ChangeShapeGore.Description";
        internal const string HeritageRagebredChangeShapeHoovesDisplayName = "Skinwalker.Heritage.Ragebred.ChangeShapeHooves.Name";
        private static readonly string HeritageRagebredChangeShapeHoovesDescription = "Skinwalker.Heritage.Ragebred.ChangeShapeHooves.Description";
        internal const string HeritageRagebredChangeShapeScentDisplayName = "Skinwalker.Heritage.Ragebred.ChangeShapeScent.Name";
        private static readonly string HeritageRagebredChangeShapeScentDescription = "Skinwalker.Heritage.Ragebred.ChangeShapeScent.Description";

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";

        private static readonly string RagebredIcon = "assets/icons/skinwalkerragebred.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string SpeedIcon = "assets/icons/changeshapespeed.jpg";
        private static readonly string GoreIcon = "assets/icons/changeshapegore.jpg";
        private static readonly string HoovesIcon = "assets/icons/changeshapehooves.jpg";
        private static readonly string ScentIcon = "assets/icons/changeshapescent.jpg";
        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);


            var heritageRagebredChangeShapeBaseSpeedBuff =
                BuffConfigurator.New(SkinwalkerHeritageRagebredChangeShapeSpeedBuffName, Guids.SkinwalkerHeritageRagebredChangeShapeSpeedBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageRagebredChangeShapeBaseSpeedBuff)
                .SetDisplayName(HeritageRagebredChangeShapeSpeedDisplayName)
                .SetDescription(HeritageRagebredChangeShapeSpeedDescription)
                .AddBuffMovementSpeed(value: 10, descriptor: ModifierDescriptor.Racial)
                .SetIcon(SpeedIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageRagebredChangeShapeBaseSpeedBuff))
                .Configure();


            var heritageRagebredChangeShapeBaseGoreBuff =
                BuffConfigurator.New(SkinwalkerHeritageRagebredChangeShapeGoreBuffName, Guids.SkinwalkerHeritageRagebredChangeShapeGoreBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageRagebredChangeShapeBaseGoreBuff)
                .SetDisplayName(HeritageRagebredChangeShapeGoreDisplayName)
                .SetDescription(HeritageRagebredChangeShapeGoreDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Gore1d6.ToString())
                .SetIcon(GoreIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageRagebredChangeShapeBaseGoreBuff))
                .Configure();

            var heritageRagebredChangeShapeBaseHoovesBuff =
                BuffConfigurator.New(SkinwalkerHeritageRagebredChangeShapeHoovesBuffName, Guids.SkinwalkerHeritageRagebredChangeShapeHoovesBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageRagebredChangeShapeBaseHoovesBuff)
                .SetDisplayName(HeritageRagebredChangeShapeHoovesDisplayName)
                .SetDescription(HeritageRagebredChangeShapeHoovesDescription)
                .AddSecondaryAttacks(ItemWeaponRefs.Hoof1d4.ToString())
                .AddSecondaryAttacks(ItemWeaponRefs.Hoof1d4.ToString())
                .SetIcon(HoovesIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageRagebredChangeShapeBaseHoovesBuff))
                .Configure();

            var heritageRagebredChangeShapeBaseScentBuff =
                BuffConfigurator.New(SkinwalkerHeritageRagebredChangeShapeScentBuffName, Guids.SkinwalkerHeritageRagebredChangeShapeScentBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageRagebredChangeShapeBaseScentBuff)
                .SetDisplayName(HeritageRagebredChangeShapeScentDisplayName)
                .SetDescription(HeritageRagebredChangeShapeScentDescription)
                .AddBlindsense(range: new Kingmaker.Utility.Feet(30))
                .SetIcon(ScentIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageRagebredChangeShapeBaseScentBuff))
                .Configure();

            var heritageRagebredChangeShapeBaseSpeedAbility =
                AbilityConfigurator.New(SkinwalkerHeritageRagebredChangeShapeSpeedAbilityName, Guids.SkinwalkerHeritageRagebredChangeShapeSpeedAbilityGuid)
                    .SetDisplayName(HeritageRagebredChangeShapeSpeedDisplayName)
                    .SetDescription(HeritageRagebredChangeShapeSpeedDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageRagebredChangeShapeBaseSpeedBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageRagebredChangeShapeBaseSpeedBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(SpeedIcon)
                    .Configure();

            var heritageRagebredChangeShapeBaseGoreAbility =
                AbilityConfigurator.New(SkinwalkerHeritageRagebredChangeShapeGoreAbilityName, Guids.SkinwalkerHeritageRagebredChangeShapeGoreAbilityGuid)
                .SetDisplayName(HeritageRagebredChangeShapeGoreDisplayName)
                .SetDescription(HeritageRagebredChangeShapeGoreDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageRagebredChangeShapeBaseGoreBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageRagebredChangeShapeBaseGoreBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(GoreIcon)
                .Configure();

            var heritageRagebredChangeShapeBaseHoovesAbility =
                AbilityConfigurator.New(SkinwalkerHeritageRagebredChangeShapeHoovesAbilityName, Guids.SkinwalkerHeritageRagebredChangeShapeHoovesAbilityGuid)
                    .SetDisplayName(HeritageRagebredChangeShapeHoovesDisplayName)
                    .SetDescription(HeritageRagebredChangeShapeHoovesDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageRagebredChangeShapeBaseHoovesBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageRagebredChangeShapeBaseHoovesBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(HoovesIcon)
                    .Configure();

            var heritageRagebredChangeShapeBaseScentAbility =
                AbilityConfigurator.New(SkinwalkerHeritageRagebredChangeShapeScentAbilityName, Guids.SkinwalkerHeritageRagebredChangeShapeScentAbilityGuid)
                    .SetDisplayName(HeritageRagebredChangeShapeScentDisplayName)
                    .SetDescription(HeritageRagebredChangeShapeScentDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageRagebredChangeShapeBaseScentBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageRagebredChangeShapeBaseScentBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(ScentIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageRagebredChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageRagebredChangeShapeList.Add(heritageRagebredChangeShapeBaseSpeedAbility);
            heritageRagebredChangeShapeList.Add(heritageRagebredChangeShapeBaseGoreAbility);
            heritageRagebredChangeShapeList.Add(heritageRagebredChangeShapeBaseHoovesAbility);
            heritageRagebredChangeShapeList.Add(heritageRagebredChangeShapeBaseScentAbility);


            var heritageRagebredChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageRagebredChangeShapeBaseName, Guids.SkinwalkerHeritageRagebredChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageRagebredChangeShapeBaseDisplayName)
                    .SetDescription(HeritageRagebredChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageRagebredChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageRagebredChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageRagebredChangeShapeRevertName, Guids.SkinwalkerHeritageRagebredChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageRagebredChangeShapeBaseSpeedBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageRagebredChangeShapeBaseSpeedBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageRagebredChangeShapeBaseGoreBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageRagebredChangeShapeBaseGoreBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageRagebredChangeShapeBaseHoovesBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageRagebredChangeShapeBaseHoovesBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageRagebredChangeShapeBaseScentBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageRagebredChangeShapeBaseScentBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerAnimalAspectGorilla =
                AbilityConfigurator.New(SkinwalkerAnimalAspectGorillaName, Guids.SkinwalkerAnimalAspectGorillaGuid)
                    .CopyFrom(AbilityRefs.AnimalAspectGorilla, typeof(SpellComponent), typeof(SpellDescriptorComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff), typeof(AbilitySpawnFx), typeof(SpellDescriptorComponent), typeof(AbilityExecuteActionOnCast), typeof(ContextActionRemoveBuffsByDescriptor))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var heritageRagebred =
                FeatureConfigurator.New(SkinwalkerHeritageRagebredName, Guids.SkinwalkerHeritageRagebredGuid)
                    .SetDisplayName(HeritageRagebredDisplayName)
                    .SetDescription(HeritageRagebredDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageRagebredChangeShapeBaseAbility, heritageRagebredChangeShapeRevertAbility, skinwalkerAnimalAspectGorilla })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillPerception, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Constitution, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Strength, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Charisma, value: -2)
                    .SetIcon(RagebredIcon)
                    .Configure();

        }

    }
}
