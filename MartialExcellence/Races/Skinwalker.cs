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
using Kingmaker.UnitLogic.Mechanics;
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
        private static readonly string SkinwalkerAnimalAspectName = "SkinwalkerAnimalAspect";


        private static readonly string SkinwalkerHeritageClassicName = "SkinwalkerHeritageClassic";
        private static readonly string SkinwalkerHeritageClassicChangeShapeBaseName = "SkinwalkerHeritageClassicChangeShapeBase";
        private static readonly string SkinwalkerHeritageClassicChangeShapeRevertName = "SkinwalkerHeritageClassicChangeShapeRevert";
        private static readonly string SkinwalkerHeritageClassicChangeShapeRevertResourceName = "SkinwalkerHeritageClassicChangeShapeRevertResource";
        private static readonly string SkinwalkerHeritageClassicChangeShapeResourceName = "SkinwalkerHeritageClassicChangeShapeResource";
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



        private static readonly string Icon = "assets/icons/skinwalker.jpg";

        private static readonly LogWrapper Logger = LogWrapper.Get("MartialExcellence");

        public static void Configure()
        {

            var heritageRagebred =
                FeatureConfigurator.New(SkinwalkerHeritageRagebredName, Guids.SkinwalkerHeritageRagebredGuid)
                    .SetDisplayName(HeritageRagebredDisplayName)
                    .SetDescription(HeritageRagebredDescription)
                    .AddToGroups(FeatureGroup.Racial)
                .Configure();

            var heritageClassicChangeShapeRevertResource =
                AbilityResourceConfigurator.New(SkinwalkerHeritageClassicChangeShapeRevertResourceName, Guids.SkinwalkerHeritageClassicChangeShapeRevertResourceGuid)
                    .SetMaxAmount(ResourceAmountBuilder.New(1))
                    .Configure();

            var heritageClassicChangeShapeResource =
                AbilityResourceConfigurator.New(SkinwalkerHeritageClassicChangeShapeResourceName, Guids.SkinwalkerHeritageClassicChangeShapeResourceGuid)
                    .SetMaxAmount(ResourceAmountBuilder.New(2))
                    .Configure();

            var skinwalkerSpellLikeResource =
                AbilityResourceConfigurator.New(SkinwalkerSpellLikeResourceName, Guids.SkinwalkerSpellLikeResourceGuid)
                .SetMaxAmount(ResourceAmountBuilder.New(1))
                .Configure();

            var heritageClassicChangeShapeBaseClawsBuff =
                BuffConfigurator.New(SkinwalkerHeritageClassicChangeShapeClawsBuffName, Guids.SkinwalkerHeritageClassicChangeShapeClawsBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageClassicChangeShapeBaseClawsBuff)
                .SetDisplayName(HeritageClassicChangeShapeClawsDisplayName)
                .SetDescription(HeritageClassicChangeShapeClawsDescription)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d4.ToString())
                //.SetIcon(IconSelf)
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
                //.SetIcon(IconSelf)
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
                //.SetIcon(IconSelf)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageClassicChangeShapeBasePerceptionBuff))
                .Configure();

            var heritageClassicChangeShapeBaseClawsAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapeClawsAbilityName, Guids.SkinwalkerHeritageClassicChangeShapeClawsAbilityGuid)
                    .SetDisplayName(HeritageClassicChangeShapeClawsDisplayName)
                    .SetDescription(HeritageClassicChangeShapeClawsDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: heritageClassicChangeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageClassicChangeShapeBaseClawsBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageClassicChangeShapeBaseClawsBuff, isNotDispelable: true))
                            .RestoreResource(heritageClassicChangeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    //.SetIcon(Icon)
                    .Configure();

            var heritageClassicChangeShapeBaseArmorAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapeArmorAbilityName, Guids.SkinwalkerHeritageClassicChangeShapeArmorAbilityGuid)
                .SetDisplayName(HeritageClassicChangeShapeArmorDisplayName)
                .SetDescription(HeritageClassicChangeShapeArmorDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: heritageClassicChangeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageClassicChangeShapeBaseArmorBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageClassicChangeShapeBaseArmorBuff, isNotDispelable: true))
                        .RestoreResource(heritageClassicChangeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                //.SetIcon(Icon)
                .Configure();

            var heritageClassicChangeShapeBasePerceptionAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapePerceptionAbilityName, Guids.SkinwalkerHeritageClassicChangeShapePerceptionAbilityGuid)
                    .SetDisplayName(HeritageClassicChangeShapePerceptionDisplayName)
                    .SetDescription(HeritageClassicChangeShapePerceptionDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: heritageClassicChangeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageClassicChangeShapeBasePerceptionBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageClassicChangeShapeBasePerceptionBuff, isNotDispelable: true))
                            .RestoreResource(heritageClassicChangeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    //.SetIcon(Icon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageClassicChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageClassicChangeShapeList.Add(heritageClassicChangeShapeBaseClawsAbility);
            heritageClassicChangeShapeList.Add(heritageClassicChangeShapeBaseArmorAbility);
            heritageClassicChangeShapeList.Add(heritageClassicChangeShapeBasePerceptionAbility);


            var heritageClassicChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapeBaseName, Guids.SkinwalkerHeritageClassicChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageClassicChangeShapeBaseDisplayName)
                    .SetDescription(HeritageClassicChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: heritageClassicChangeShapeResource)
                    .AddAbilityVariants(heritageClassicChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                .Configure();

            var heritageClassicChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageClassicChangeShapeRevertName, Guids.SkinwalkerHeritageClassicChangeShapeRevertAbilityGuid)
                    .SetDisplayName(HeritageClassicChangeShapeBaseDisplayName)
                    .SetDescription(HeritageClassicChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: heritageClassicChangeShapeRevertResource)
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
                            .RestoreResource(heritageClassicChangeShapeResource))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
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
                    .AddAbilityResources(resource: heritageClassicChangeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: heritageClassicChangeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Strength, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Intelligence, value: -2)
                    .Configure();

            var hertiageClassicDexterity =
                FeatureConfigurator.New(SkinwalkerHeritageSelectionClassicDexterityName, Guids.SkinwalkerHeritageSelectionClassicDexterityGuid)
                    .SetDisplayName(HeritageSelectionClassicDexterityDisplayName)
                    .SetDescription(HeritageSelectionClassicDexterityDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageClassicChangeShapeBaseAbility, heritageClassicChangeShapeRevertAbility, skinwalkerAnimalAspect })
                    .AddAbilityResources(resource: heritageClassicChangeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: heritageClassicChangeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Dexterity, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Intelligence, value: -2)
                    .Configure();

            var hertiageClassicConstitution =
                FeatureConfigurator.New(SkinwalkerHeritageSelectionClassicConstitutionName, Guids.SkinwalkerHeritageSelectionClassicConstitutionGuid)
                    .SetDisplayName(HeritageSelectionClassicConstitutionDisplayName)
                    .SetDescription(HeritageSelectionClassicConstitutionDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageClassicChangeShapeBaseAbility, heritageClassicChangeShapeRevertAbility, skinwalkerAnimalAspect })
                    .AddAbilityResources(resource: heritageClassicChangeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: heritageClassicChangeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Constitution, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Intelligence, value: -2)
                    .Configure();

            Blueprint<BlueprintFeatureReference>[] heritageClassicList = new Blueprint<BlueprintFeatureReference>[] { hertiageClassicStrength, hertiageClassicDexterity, hertiageClassicConstitution };

            var heritageClassic =
                FeatureSelectionConfigurator.New(SkinwalkerHeritageClassicName, Guids.SkinwalkerHeritageClassicGuid)
                    .SetDisplayName(HeritageClassicDisplayName)
                    .SetDescription(HeritageClassicDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .SetAllFeatures(heritageClassicList)
                    .Configure();

            Blueprint<BlueprintFeatureReference>[] heritageList = new Blueprint<BlueprintFeatureReference>[] { heritageClassic, heritageRagebred };

            var hertiageSelection =
                FeatureSelectionConfigurator.New(SkinwalkerHeritageSelectionName, Guids.SkinwalkerHeritageSelectionGuid)
                    .SetDisplayName(HeritageSelectionDisplayName)
                    .SetDescription(HeritageSelectionDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .SetAllFeatures(heritageList)
                    .Configure();


            var race =
            RaceConfigurator.New(SkinwalkerName, Guids.SkinwalkerGuid)
                .CopyFrom(RaceRefs.HumanRace)
                .SetDisplayName(SkinwalkerDisplayName)
                .SetDescription(SkinwalkerDescription)
                .SetSelectableRaceStat(false)
                .SetFeatures(hertiageSelection)
                .Configure(delayed: false);

            // MAKE NEW CHARACTER AND VERIFY RESOURCE VALUES



            // Add race to race list
            var raceRef = race.ToReference<BlueprintRaceReference>();
            ref var races = ref BlueprintRoot.Instance.Progression.m_CharacterRaces;

            var length = races.Length;
            Array.Resize(ref races, length + 1);
            races[length] = raceRef;
        }
    }
}
