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

namespace MartialExcellence.Races
{
    class Skinwalker
    {
        private static readonly string SkinwalkerName = "SkinwalkerRace";
        private static readonly string SkinwalkerHeritageSelectionName = "SkinwalkerHeritageSelection";

        private static readonly string SkinwalkerSpellLikeResourceName = "SkinwalkerSpellLikeResource";
        private static readonly string SkinwalkerChangeShapeRevertResourceName = "SkinwalkerChangeShapeRevertResource";
        private static readonly string SkinwalkerChangeShapeResourceName = "SkinwalkerChangeShapeResource";
        private static readonly string SkinwalkerAnimalAspectName = "SkinwalkerAnimalAspect";
        private static readonly string SkinwalkerAnimalAspectGorillaName = "SkinwalkerAnimalAspectGorilla";



        private static readonly string SkinwalkerHeritageClassicName = "SkinwalkerHeritageClassic";
        private static readonly string SkinwalkerHeritageClassicChangeShapeBaseName = "SkinwalkerHeritageClassicChangeShapeBase";
        private static readonly string SkinwalkerHeritageClassicChangeShapeRevertName = "SkinwalkerHeritageClassicChangeShapeRevert";

        private static readonly string SkinwalkerHeritageClassicChangeShapeClawsAbilityName = "SkinwalkerHeritageClassicChangeShapeClawsAbility";
        private static readonly string SkinwalkerHeritageClassicChangeShapeClawsBuffName = "SkinwalkerHeritageClassicChangeShapeClawsBuff";
        private static readonly string SkinwalkerHeritageClassicChangeShapeArmorAbilityName = "SkinwalkerHeritageClassicChangeShapeArmorAbility";
        private static readonly string SkinwalkerHeritageClassicChangeShapeArmorBuffName = "SkinwalkerHeritageClassicChangeShapeArmorBuff";
        private static readonly string SkinwalkerHeritageClassicChangeShapePerceptionAbilityName = "SkinwalkerHeritageClassicChangeShapePerceptionAbility";
        private static readonly string SkinwalkerHeritageClassicChangeShapePerceptionBuffName = "SkinwalkerHeritageClassicChangeShapePerceptionBuff";
        private static readonly string SkinwalkerHeritageSelectionClassicStrengthName = "SkinwalkerHeritageClassicStrengthSelection";
        private static readonly string SkinwalkerHeritageSelectionClassicDexterityName = "SkinwalkerHeritageClassicDexteritySelection";
        private static readonly string SkinwalkerHeritageSelectionClassicConstitutionName = "SkinwalkerHeritageClassicConstitutionSelection";


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


        internal const string SkinwalkerDisplayName = "Skinwalker.Name";
        private static readonly string SkinwalkerDescription = "Skinwalker.Description";

        internal const string HeritageSelectionDisplayName = "Skinwalker.HeritageSelection.Name";
        private static readonly string HeritageSelectionDescription = "Skinwalker.HeritageSelection.Description";


        internal const string HeritageClassicDisplayName = "Skinwalker.Heritage.Classic.Name";
        private static readonly string HeritageClassicDescription = "Skinwalker.Heritage.Classic.Description";
        internal const string HeritageClassicChangeShapeBaseDisplayName = "Skinwalker.Heritage.Classic.ChangeShapeBase.Name";
        private static readonly string HeritageClassicChangeShapeBaseDescription = "Skinwalker.Heritage.Classic.ChangeShapeBase.Description";
        internal const string HeritageClassicChangeShapeClawsDisplayName = "Skinwalker.Heritage.Classic.ChangeShapeClaws.Name";
        private static readonly string HeritageClassicChangeShapeClawsDescription = "Skinwalker.Heritage.Classic.ChangeShapeClaws.Description";
        internal const string HeritageClassicChangeShapeArmorDisplayName = "Skinwalker.Heritage.Classic.ChangeShapeArmor.Name";
        private static readonly string HeritageClassicChangeShapeArmorDescription = "Skinwalker.Heritage.Classic.ChangeShapeArmor.Description";
        internal const string HeritageClassicChangeShapePerceptionDisplayName = "Skinwalker.Heritage.Classic.ChangeShapePerception.Name";
        private static readonly string HeritageClassicChangeShapePerceptionDescription = "Skinwalker.Heritage.Classic.ChangeShapePerception.Description";
        internal const string HeritageSelectionClassicStrengthDisplayName = "Skinwalker.HeritageSelectionClassicStrength.Name";
        private static readonly string HeritageSelectionClassicStrengthDescription = "Skinwalker.HeritageSelectionClassicStrength.Description";
        internal const string HeritageSelectionClassicDexterityDisplayName = "Skinwalker.HeritageSelectionClassicDexterity.Name";
        private static readonly string HeritageSelectionClassicDexterityDescription = "Skinwalker.HeritageSelectionClassicDexterity.Description";
        internal const string HeritageSelectionClassicConstitutionDisplayName = "Skinwalker.HeritageSelectionClassicConstitution.Name";
        private static readonly string HeritageSelectionClassicConstitutionDescription = "Skinwalker.HeritageSelectionClassicConstitution.Description";


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

        private static readonly string ClassicIcon = "assets/icons/skinwalkerclassic.jpg";
        private static readonly string RagebredIcon = "assets/icons/skinwalkerragebred.jpg";
        private static readonly string HeritageIcon = "assets/icons/skinwalkerheritage.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string ArmorIcon = "assets/icons/changeshapearmor.jpg";
        private static readonly string ClawsIcon = "assets/icons/changeshapeclaws.jpg";
        private static readonly string PerceptionIcon = "assets/icons/changeshapeperception.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string SpeedIcon = "assets/icons/changeshapespeed.jpg";
        private static readonly string GoreIcon = "assets/icons/changeshapegore.jpg";
        private static readonly string HoovesIcon = "assets/icons/changeshapehooves.jpg";
        private static readonly string ScentIcon = "assets/icons/changeshapescent.jpg";

        private static readonly LogWrapper Logger = LogWrapper.Get("MartialExcellence");

        public static void Configure()
        {
            var changeShapeRevertResource =
                AbilityResourceConfigurator.New(SkinwalkerChangeShapeRevertResourceName, Guids.SkinwalkerChangeShapeRevertResourceGuid)
                    .SetMaxAmount(ResourceAmountBuilder.New(1))
                    .Configure();

            var changeShapeResource =
                AbilityResourceConfigurator.New(SkinwalkerChangeShapeResourceName, Guids.SkinwalkerChangeShapeResourceGuid)
                    .SetMaxAmount(ResourceAmountBuilder.New(1))
                    .Configure();

            var skinwalkerSpellLikeResource =
                AbilityResourceConfigurator.New(SkinwalkerSpellLikeResourceName, Guids.SkinwalkerSpellLikeResourceGuid)
                .SetMaxAmount(ResourceAmountBuilder.New(1))
                .Configure();

            #region ragebred

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

            #endregion

            #region classic skinwalker

            var heritageClassicChangeShapeBaseClawsBuff =
                BuffConfigurator.New(SkinwalkerHeritageClassicChangeShapeClawsBuffName, Guids.SkinwalkerHeritageClassicChangeShapeClawsBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageClassicChangeShapeBaseClawsBuff)
                .SetDisplayName(HeritageClassicChangeShapeClawsDisplayName)
                .SetDescription(HeritageClassicChangeShapeClawsDescription)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d4.ToString())
                .SetIcon(ClawsIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageClassicChangeShapeBaseClawsBuff))
                .Configure();


            var heritageClassicChangeShapeBaseArmorBuff =
                BuffConfigurator.New(SkinwalkerHeritageClassicChangeShapeArmorBuffName, Guids.SkinwalkerHeritageClassicChangeShapeArmorBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageClassicChangeShapeBaseArmorBuff)
                .SetDisplayName(HeritageClassicChangeShapeArmorDisplayName)
                .SetDescription(HeritageClassicChangeShapeArmorDescription)
                .AddStatBonus(ModifierDescriptor.NaturalArmor, stat: StatType.AC, value: 1)
                .SetIcon(ArmorIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageClassicChangeShapeBaseArmorBuff))
                .Configure();

            var heritageClassicChangeShapeBasePerceptionBuff =
                BuffConfigurator.New(SkinwalkerHeritageClassicChangeShapePerceptionBuffName, Guids.SkinwalkerHeritageClassicChangeShapePerceptionBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageClassicChangeShapeBasePerceptionBuff)
                .SetDisplayName(HeritageClassicChangeShapePerceptionDisplayName)
                .SetDescription(HeritageClassicChangeShapePerceptionDescription)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillPerception, value: 2)
                .SetIcon(PerceptionIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageClassicChangeShapeBasePerceptionBuff))
                .Configure();

            var heritageClassicChangeShapeBaseClawsAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapeClawsAbilityName, Guids.SkinwalkerHeritageClassicChangeShapeClawsAbilityGuid)
                    .SetDisplayName(HeritageClassicChangeShapeClawsDisplayName)
                    .SetDescription(HeritageClassicChangeShapeClawsDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageClassicChangeShapeBaseClawsBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageClassicChangeShapeBaseClawsBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(ClawsIcon)
                    .Configure();

            var heritageClassicChangeShapeBaseArmorAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapeArmorAbilityName, Guids.SkinwalkerHeritageClassicChangeShapeArmorAbilityGuid)
                .SetDisplayName(HeritageClassicChangeShapeArmorDisplayName)
                .SetDescription(HeritageClassicChangeShapeArmorDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageClassicChangeShapeBaseArmorBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageClassicChangeShapeBaseArmorBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(ArmorIcon)
                .Configure();

            var heritageClassicChangeShapeBasePerceptionAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapePerceptionAbilityName, Guids.SkinwalkerHeritageClassicChangeShapePerceptionAbilityGuid)
                    .SetDisplayName(HeritageClassicChangeShapePerceptionDisplayName)
                    .SetDescription(HeritageClassicChangeShapePerceptionDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageClassicChangeShapeBasePerceptionBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageClassicChangeShapeBasePerceptionBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(PerceptionIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageClassicChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageClassicChangeShapeList.Add(heritageClassicChangeShapeBaseClawsAbility);
            heritageClassicChangeShapeList.Add(heritageClassicChangeShapeBaseArmorAbility);
            heritageClassicChangeShapeList.Add(heritageClassicChangeShapeBasePerceptionAbility);


            var heritageClassicChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapeBaseName, Guids.SkinwalkerHeritageClassicChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageClassicChangeShapeBaseDisplayName)
                    .SetDescription(HeritageClassicChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageClassicChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageClassicChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapeRevertName, Guids.SkinwalkerHeritageClassicChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageClassicChangeShapeBaseClawsBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageClassicChangeShapeBaseClawsBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageClassicChangeShapeBaseArmorBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageClassicChangeShapeBaseArmorBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageClassicChangeShapeBasePerceptionBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageClassicChangeShapeBasePerceptionBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerAnimalAspect =
                AbilityConfigurator.New(SkinwalkerAnimalAspectName, Guids.SkinwalkerAnimalAspectGuid)
                    .CopyFrom(AbilityRefs.AnimalAspectBase, typeof(AbilityVariants), typeof(SpellComponent), typeof(SpellDescriptorComponent))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();


            var hertiageClassicStrength =
                FeatureConfigurator.New(SkinwalkerHeritageSelectionClassicStrengthName, Guids.SkinwalkerHeritageSelectionClassicStrengthGuid)
                    .SetDisplayName(HeritageSelectionClassicStrengthDisplayName)
                    .SetDescription(HeritageSelectionClassicStrengthDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageClassicChangeShapeBaseAbility, heritageClassicChangeShapeRevertAbility, skinwalkerAnimalAspect })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Strength, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Intelligence, value: -2)
                    .SetIcon(ClassicIcon)
                    .Configure();

            var hertiageClassicDexterity =
                FeatureConfigurator.New(SkinwalkerHeritageSelectionClassicDexterityName, Guids.SkinwalkerHeritageSelectionClassicDexterityGuid)
                    .SetDisplayName(HeritageSelectionClassicDexterityDisplayName)
                    .SetDescription(HeritageSelectionClassicDexterityDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageClassicChangeShapeBaseAbility, heritageClassicChangeShapeRevertAbility, skinwalkerAnimalAspect })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Dexterity, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Intelligence, value: -2)
                    .SetIcon(ClassicIcon)
                    .Configure();

            var hertiageClassicConstitution =
                FeatureConfigurator.New(SkinwalkerHeritageSelectionClassicConstitutionName, Guids.SkinwalkerHeritageSelectionClassicConstitutionGuid)
                    .SetDisplayName(HeritageSelectionClassicConstitutionDisplayName)
                    .SetDescription(HeritageSelectionClassicConstitutionDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageClassicChangeShapeBaseAbility, heritageClassicChangeShapeRevertAbility, skinwalkerAnimalAspect })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Constitution, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Intelligence, value: -2)
                    .SetIcon(ClassicIcon)
                    .Configure();

            Blueprint<BlueprintFeatureReference>[] heritageClassicList = new Blueprint<BlueprintFeatureReference>[] { hertiageClassicStrength, hertiageClassicDexterity, hertiageClassicConstitution };

            var heritageClassic =
                FeatureSelectionConfigurator.New(SkinwalkerHeritageClassicName, Guids.SkinwalkerHeritageClassicGuid)
                    .SetDisplayName(HeritageClassicDisplayName)
                    .SetDescription(HeritageClassicDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .SetAllFeatures(heritageClassicList)
                    .SetIcon(ClassicIcon)
                    .Configure();

            #endregion

            Blueprint<BlueprintFeatureReference>[] heritageList = new Blueprint<BlueprintFeatureReference>[] { heritageClassic, heritageRagebred };

            var hertiageSelection =
                FeatureSelectionConfigurator.New(SkinwalkerHeritageSelectionName, Guids.SkinwalkerHeritageSelectionGuid)
                    .SetDisplayName(HeritageSelectionDisplayName)
                    .SetDescription(HeritageSelectionDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .SetAllFeatures(heritageList)
                    .SetIcon(HeritageIcon)
                    .Configure();


            var race =
            RaceConfigurator.New(SkinwalkerName, Guids.SkinwalkerGuid)
                .CopyFrom(RaceRefs.HumanRace)
                .SetDisplayName(SkinwalkerDisplayName)
                .SetDescription(SkinwalkerDescription)
                .SetSelectableRaceStat(false)
                .SetFeatures(hertiageSelection)
                .SetIcon(ClassicIcon)
                .SetRaceId(Race.HalfElf)
                .Configure(delayed: true);


            // Add race to race list
            var raceRef = race.ToReference<BlueprintRaceReference>();
            ref var races = ref BlueprintRoot.Instance.Progression.m_CharacterRaces;

            var length = races.Length;
            Array.Resize(ref races, length + 1);
            races[length] = raceRef;
        }
    }
}
