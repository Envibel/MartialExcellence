using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.CustomConfigurators;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
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
using CodexLib;
using Kingmaker.Designers.Mechanics.Buffs;

namespace MartialExcellence.Races.Skinwalker.Heritages
{
    class SkinwalkerClassic
    {
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

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";
        private static readonly string SkinwalkerAnimalAspectName = "SkinwalkerAnimalAspect";


        private static readonly string ClassicIcon = "assets/icons/skinwalkerclassic.jpg";
        // private static readonly string HeritageIcon = "assets/icons/skinwalkerheritage.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string ArmorIcon = "assets/icons/changeshapearmor.jpg";
        private static readonly string ClawsIcon = "assets/icons/changeshapeclaws.jpg";
        private static readonly string PerceptionIcon = "assets/icons/changeshapeperception.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";


        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);



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

            var mythic = Helper.ToRef<BlueprintUnitFactReference>("325f078c584318849bfe3da9ea245b9d").ObjToArray();

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
                    .AddComponent(new AddStatBonusIfHasFact
                    {
                        Descriptor = ModifierDescriptor.Racial,
                        Stat = StatType.Intelligence,
                        Value = -2,
                        InvertCondition = true,
                        m_CheckedFacts = mythic
                    })
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
                    .AddComponent(new AddStatBonusIfHasFact
                    {
                        Descriptor = ModifierDescriptor.Racial,
                        Stat = StatType.Intelligence,
                        Value = -2,
                        InvertCondition = true,
                        m_CheckedFacts = mythic
                    })
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
                    .AddComponent(new AddStatBonusIfHasFact
                    {
                        Descriptor = ModifierDescriptor.Racial,
                        Stat = StatType.Intelligence,
                        Value = -2,
                        InvertCondition = true,
                        m_CheckedFacts = mythic
                    })
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

        }

    }
}
