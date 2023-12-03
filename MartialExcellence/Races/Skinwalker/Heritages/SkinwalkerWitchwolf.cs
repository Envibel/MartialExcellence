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
using CodexLib;

namespace MartialExcellence.Races.Skinwalker.Heritages
{
    class SkinwalkerWitchwolf
    {
        private static readonly string SkinwalkerHeritageWitchwolfName = "SkinwalkerHeritageWitchwolf";
        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeBaseName = "SkinwalkerHeritageWitchwolfChangeShapeBase";
        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeRevertName = "SkinwalkerHeritageWitchwolfChangeShapeRevert";

        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeBiteAbilityName = "SkinwalkerHeritageWitchwolfChangeShapeBiteAbility";
        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeBiteBuffName = "SkinwalkerHeritageWitchwolfChangeShapeBiteBuff";
        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeClawsAbilityName = "SkinwalkerHeritageWitchwolfChangeShapeClawsAbility";
        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeClawsBuffName = "SkinwalkerHeritageWitchwolfChangeShapeClawsBuff";
        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeSavingThrowsAbilityName = "SkinwalkerHeritageWitchwolfChangeShapeSavingThrowsAbility";
        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeSavingThrowsBuffName = "SkinwalkerHeritageWitchwolfChangeShapeSavingThrowsBuff";
        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeScentAbilityName = "SkinwalkerHeritageWitchwolfChangeShapeScentAbility";
        private static readonly string SkinwalkerHeritageWitchwolfChangeShapeScentBuffName = "SkinwalkerHeritageWitchwolfChangeShapeScentBuff";

        internal const string HeritageWitchwolfDisplayName = "Skinwalker.Heritage.Witchwolf.Name";
        private static readonly string HeritageWitchwolfDescription = "Skinwalker.Heritage.Witchwolf.Description";
        internal const string HeritageWitchwolfChangeShapeBaseDisplayName = "Skinwalker.Heritage.Witchwolf.ChangeShapeBase.Name";
        private static readonly string HeritageWitchwolfChangeShapeBaseDescription = "Skinwalker.Heritage.Witchwolf.ChangeShapeBase.Description";
        internal const string HeritageWitchwolfChangeShapeBiteDisplayName = "Skinwalker.Heritage.Witchwolf.ChangeShapeBite.Name";
        private static readonly string HeritageWitchwolfChangeShapeBiteDescription = "Skinwalker.Heritage.Witchwolf.ChangeShapeBite.Description";
        internal const string HeritageWitchwolfChangeShapeClawsDisplayName = "Skinwalker.Heritage.Witchwolf.ChangeShapeClaws.Name";
        private static readonly string HeritageWitchwolfChangeShapeClawsDescription = "Skinwalker.Heritage.Witchwolf.ChangeShapeClaws.Description";
        internal const string HeritageWitchwolfChangeShapeSavingThrowsDisplayName = "Skinwalker.Heritage.Witchwolf.ChangeShapeSavingThrows.Name";
        private static readonly string HeritageWitchwolfChangeShapeSavingThrowsDescription = "Skinwalker.Heritage.Witchwolf.ChangeShapeSavingThrows.Description";
        internal const string HeritageWitchwolfChangeShapeScentDisplayName = "Skinwalker.Heritage.Witchwolf.ChangeShapeScent.Name";
        private static readonly string HeritageWitchwolfChangeShapeScentDescription = "Skinwalker.Heritage.Witchwolf.ChangeShapeScent.Description";

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";

        private static readonly string WitchwolfIcon = "assets/icons/skinwalkerwitchwolf.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string BiteIcon = "assets/icons/changeshapebite.jpg";
        private static readonly string ClawsIcon = "assets/icons/changeshapeclaws.jpg";
        private static readonly string SavingThrowsIcon = "assets/icons/changeshapesavingthrows.jpg";
        private static readonly string ScentIcon = "assets/icons/changeshapescent.jpg";
        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);


            var heritageWitchwolfChangeShapeBaseBiteBuff =
                BuffConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeBiteBuffName, Guids.SkinwalkerHeritageWitchwolfChangeShapeBiteBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageWitchwolfChangeShapeBaseBiteBuff)
                .SetDisplayName(HeritageWitchwolfChangeShapeBiteDisplayName)
                .SetDescription(HeritageWitchwolfChangeShapeBiteDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .SetIcon(BiteIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageWitchwolfChangeShapeBaseBiteBuff))
                .Configure();


            var heritageWitchwolfChangeShapeBaseClawsBuff =
                BuffConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeClawsBuffName, Guids.SkinwalkerHeritageWitchwolfChangeShapeClawsBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageWitchwolfChangeShapeBaseClawsBuff)
                .SetDisplayName(HeritageWitchwolfChangeShapeClawsDisplayName)
                .SetDescription(HeritageWitchwolfChangeShapeClawsDescription)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d4.ToString())
                .SetIcon(ClawsIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageWitchwolfChangeShapeBaseClawsBuff))
                .Configure();

            var heritageWitchwolfChangeShapeBaseSavingThrowsBuff =
                BuffConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeSavingThrowsBuffName, Guids.SkinwalkerHeritageWitchwolfChangeShapeSavingThrowsBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageWitchwolfChangeShapeBaseSavingThrowsBuff)
                .SetDisplayName(HeritageWitchwolfChangeShapeSavingThrowsDisplayName)
                .SetDescription(HeritageWitchwolfChangeShapeSavingThrowsDescription)
                .AddStatBonus(stat: StatType.SaveFortitude, descriptor: ModifierDescriptor.Racial, value: 2)
                .AddStatBonus(stat: StatType.SaveWill, descriptor: ModifierDescriptor.Racial, value: 2)
                .AddStatBonus(stat: StatType.SaveReflex, descriptor: ModifierDescriptor.Racial, value: 2)
                .SetIcon(SavingThrowsIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageWitchwolfChangeShapeBaseSavingThrowsBuff))
                .Configure();

            var heritageWitchwolfChangeShapeBaseScentBuff =
                BuffConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeScentBuffName, Guids.SkinwalkerHeritageWitchwolfChangeShapeScentBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageWitchwolfChangeShapeBaseScentBuff)
                .SetDisplayName(HeritageWitchwolfChangeShapeScentDisplayName)
                .SetDescription(HeritageWitchwolfChangeShapeScentDescription)
                .AddBlindsense(range: new Kingmaker.Utility.Feet(30))
                .SetIcon(ScentIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageWitchwolfChangeShapeBaseScentBuff))
                .Configure();

            var heritageWitchwolfChangeShapeBaseBiteAbility =
                AbilityConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeBiteAbilityName, Guids.SkinwalkerHeritageWitchwolfChangeShapeBiteAbilityGuid)
                    .SetDisplayName(HeritageWitchwolfChangeShapeBiteDisplayName)
                    .SetDescription(HeritageWitchwolfChangeShapeBiteDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageWitchwolfChangeShapeBaseBiteBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageWitchwolfChangeShapeBaseBiteBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(BiteIcon)
                    .Configure();

            var heritageWitchwolfChangeShapeBaseClawsAbility =
                AbilityConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeClawsAbilityName, Guids.SkinwalkerHeritageWitchwolfChangeShapeClawsAbilityGuid)
                .SetDisplayName(HeritageWitchwolfChangeShapeClawsDisplayName)
                .SetDescription(HeritageWitchwolfChangeShapeClawsDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageWitchwolfChangeShapeBaseClawsBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageWitchwolfChangeShapeBaseClawsBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(ClawsIcon)
                .Configure();

            var heritageWitchwolfChangeShapeBaseSavingThrowsAbility =
                AbilityConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeSavingThrowsAbilityName, Guids.SkinwalkerHeritageWitchwolfChangeShapeSavingThrowsAbilityGuid)
                    .SetDisplayName(HeritageWitchwolfChangeShapeSavingThrowsDisplayName)
                    .SetDescription(HeritageWitchwolfChangeShapeSavingThrowsDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageWitchwolfChangeShapeBaseSavingThrowsBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageWitchwolfChangeShapeBaseSavingThrowsBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(SavingThrowsIcon)
                    .Configure();

            var heritageWitchwolfChangeShapeBaseScentAbility =
                AbilityConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeScentAbilityName, Guids.SkinwalkerHeritageWitchwolfChangeShapeScentAbilityGuid)
                    .SetDisplayName(HeritageWitchwolfChangeShapeScentDisplayName)
                    .SetDescription(HeritageWitchwolfChangeShapeScentDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageWitchwolfChangeShapeBaseScentBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageWitchwolfChangeShapeBaseScentBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(ScentIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageWitchwolfChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageWitchwolfChangeShapeList.Add(heritageWitchwolfChangeShapeBaseBiteAbility);
            heritageWitchwolfChangeShapeList.Add(heritageWitchwolfChangeShapeBaseClawsAbility);
            heritageWitchwolfChangeShapeList.Add(heritageWitchwolfChangeShapeBaseSavingThrowsAbility);
            heritageWitchwolfChangeShapeList.Add(heritageWitchwolfChangeShapeBaseScentAbility);


            var heritageWitchwolfChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeBaseName, Guids.SkinwalkerHeritageWitchwolfChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageWitchwolfChangeShapeBaseDisplayName)
                    .SetDescription(HeritageWitchwolfChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageWitchwolfChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageWitchwolfChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageWitchwolfChangeShapeRevertName, Guids.SkinwalkerHeritageWitchwolfChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageWitchwolfChangeShapeBaseBiteBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageWitchwolfChangeShapeBaseBiteBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageWitchwolfChangeShapeBaseClawsBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageWitchwolfChangeShapeBaseClawsBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageWitchwolfChangeShapeBaseSavingThrowsBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageWitchwolfChangeShapeBaseSavingThrowsBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageWitchwolfChangeShapeBaseScentBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageWitchwolfChangeShapeBaseScentBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerMagicFang = BlueprintTool.Get<BlueprintAbility>(Guids.SkinwalkerMagicFangGuid);

            var mythic = Helper.ToRef<BlueprintUnitFactReference>("325f078c584318849bfe3da9ea245b9d").ObjToArray();

            var heritageWitchwolf =
                FeatureConfigurator.New(SkinwalkerHeritageWitchwolfName, Guids.SkinwalkerHeritageWitchwolfGuid)
                    .SetDisplayName(HeritageWitchwolfDisplayName)
                    .SetDescription(HeritageWitchwolfDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageWitchwolfChangeShapeBaseAbility, heritageWitchwolfChangeShapeRevertAbility, skinwalkerMagicFang })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillPerception, value: 2)
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
                    .SetIcon(WitchwolfIcon)
                    .Configure();

        }

    }
}
