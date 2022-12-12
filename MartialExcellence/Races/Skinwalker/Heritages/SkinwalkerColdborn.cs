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

namespace MartialExcellence.Races.Skinwalker.Heritages
{
    class SkinwalkerColdborn
    {
        private static readonly string SkinwalkerSummonNatureAllySingleName = "SkinwalkerSummonNatureAllySingle";
        private static readonly string SkinwalkerSummonNatureAllyd3Name = "SkinwalkerSummonNatureAllyd3";
        private static readonly string SkinwalkerSummonNatureAllyd4plus1Name = "SkinwalkerSummonNatureAllyd4plus1";

        private static readonly string SkinwalkerHeritageColdbornName = "SkinwalkerHeritageColdborn";
        private static readonly string SkinwalkerHeritageColdbornChangeShapeBaseName = "SkinwalkerHeritageColdbornChangeShapeBase";
        private static readonly string SkinwalkerHeritageColdbornChangeShapeRevertName = "SkinwalkerHeritageColdbornChangeShapeRevert";

        private static readonly string SkinwalkerHeritageColdbornChangeShapeBiteAbilityName = "SkinwalkerHeritageColdbornChangeShapeBiteAbility";
        private static readonly string SkinwalkerHeritageColdbornChangeShapeBiteBuffName = "SkinwalkerHeritageColdbornChangeShapeBiteBuff";
        private static readonly string SkinwalkerHeritageColdbornChangeShapeClawsAbilityName = "SkinwalkerHeritageColdbornChangeShapeClawsAbility";
        private static readonly string SkinwalkerHeritageColdbornChangeShapeClawsBuffName = "SkinwalkerHeritageColdbornChangeShapeClawsBuff";
        private static readonly string SkinwalkerHeritageColdbornChangeShapeAthleticsAbilityName = "SkinwalkerHeritageColdbornChangeShapeAthleticsAbility";
        private static readonly string SkinwalkerHeritageColdbornChangeShapeAthleticsBuffName = "SkinwalkerHeritageColdbornChangeShapeAthleticsBuff";
        private static readonly string SkinwalkerHeritageColdbornChangeShapeScentAbilityName = "SkinwalkerHeritageColdbornChangeShapeScentAbility";
        private static readonly string SkinwalkerHeritageColdbornChangeShapeScentBuffName = "SkinwalkerHeritageColdbornChangeShapeScentBuff";

        internal const string HeritageColdbornDisplayName = "Skinwalker.Heritage.Coldborn.Name";
        private static readonly string HeritageColdbornDescription = "Skinwalker.Heritage.Coldborn.Description";
        internal const string HeritageColdbornChangeShapeBaseDisplayName = "Skinwalker.Heritage.Coldborn.ChangeShapeBase.Name";
        private static readonly string HeritageColdbornChangeShapeBaseDescription = "Skinwalker.Heritage.Coldborn.ChangeShapeBase.Description";
        internal const string HeritageColdbornChangeShapeBiteDisplayName = "Skinwalker.Heritage.Coldborn.ChangeShapeBite.Name";
        private static readonly string HeritageColdbornChangeShapeBiteDescription = "Skinwalker.Heritage.Coldborn.ChangeShapeBite.Description";
        internal const string HeritageColdbornChangeShapeClawsDisplayName = "Skinwalker.Heritage.Coldborn.ChangeShapeClaws.Name";
        private static readonly string HeritageColdbornChangeShapeClawsDescription = "Skinwalker.Heritage.Coldborn.ChangeShapeClaws.Description";
        internal const string HeritageColdbornChangeShapeAthleticsDisplayName = "Skinwalker.Heritage.Coldborn.ChangeShapeAthletics.Name";
        private static readonly string HeritageColdbornChangeShapeAthleticsDescription = "Skinwalker.Heritage.Coldborn.ChangeShapeAthletics.Description";
        internal const string HeritageColdbornChangeShapeScentDisplayName = "Skinwalker.Heritage.Coldborn.ChangeShapeScent.Name";
        private static readonly string HeritageColdbornChangeShapeScentDescription = "Skinwalker.Heritage.Coldborn.ChangeShapeScent.Description";

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";

        private static readonly string ColdbornIcon = "assets/icons/skinwalkercoldborn.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string BiteIcon = "assets/icons/changeshapebite.jpg";
        private static readonly string ClawsIcon = "assets/icons/changeshapeclaws.jpg";
        private static readonly string AthleticsIcon = "assets/icons/changeshapeathletics.jpg";
        private static readonly string ScentIcon = "assets/icons/changeshapescent.jpg";
        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);


            var heritageColdbornChangeShapeBaseBiteBuff =
                BuffConfigurator.New(SkinwalkerHeritageColdbornChangeShapeBiteBuffName, Guids.SkinwalkerHeritageColdbornChangeShapeBiteBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageColdbornChangeShapeBaseBiteBuff)
                .SetDisplayName(HeritageColdbornChangeShapeBiteDisplayName)
                .SetDescription(HeritageColdbornChangeShapeBiteDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .SetIcon(BiteIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageColdbornChangeShapeBaseBiteBuff))
                .Configure();


            var heritageColdbornChangeShapeBaseClawsBuff =
                BuffConfigurator.New(SkinwalkerHeritageColdbornChangeShapeClawsBuffName, Guids.SkinwalkerHeritageColdbornChangeShapeClawsBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageColdbornChangeShapeBaseClawsBuff)
                .SetDisplayName(HeritageColdbornChangeShapeClawsDisplayName)
                .SetDescription(HeritageColdbornChangeShapeClawsDescription)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d4.ToString())
                .SetIcon(ClawsIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageColdbornChangeShapeBaseClawsBuff))
                .Configure();

            var heritageColdbornChangeShapeBaseAthleticsBuff =
                BuffConfigurator.New(SkinwalkerHeritageColdbornChangeShapeAthleticsBuffName, Guids.SkinwalkerHeritageColdbornChangeShapeAthleticsBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageColdbornChangeShapeBaseAthleticsBuff)
                .SetDisplayName(HeritageColdbornChangeShapeAthleticsDisplayName)
                .SetDescription(HeritageColdbornChangeShapeAthleticsDescription)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillAthletics, value: 4)
                .SetIcon(AthleticsIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageColdbornChangeShapeBaseAthleticsBuff))
                .Configure();

            var heritageColdbornChangeShapeBaseScentBuff =
                BuffConfigurator.New(SkinwalkerHeritageColdbornChangeShapeScentBuffName, Guids.SkinwalkerHeritageColdbornChangeShapeScentBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageColdbornChangeShapeBaseScentBuff)
                .SetDisplayName(HeritageColdbornChangeShapeScentDisplayName)
                .SetDescription(HeritageColdbornChangeShapeScentDescription)
                .AddBlindsense(range: new Kingmaker.Utility.Feet(30))
                .SetIcon(ScentIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageColdbornChangeShapeBaseScentBuff))
                .Configure();

            var heritageColdbornChangeShapeBaseBiteAbility =
                AbilityConfigurator.New(SkinwalkerHeritageColdbornChangeShapeBiteAbilityName, Guids.SkinwalkerHeritageColdbornChangeShapeBiteAbilityGuid)
                    .SetDisplayName(HeritageColdbornChangeShapeBiteDisplayName)
                    .SetDescription(HeritageColdbornChangeShapeBiteDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageColdbornChangeShapeBaseBiteBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageColdbornChangeShapeBaseBiteBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(BiteIcon)
                    .Configure();

            var heritageColdbornChangeShapeBaseClawsAbility =
                AbilityConfigurator.New(SkinwalkerHeritageColdbornChangeShapeClawsAbilityName, Guids.SkinwalkerHeritageColdbornChangeShapeClawsAbilityGuid)
                .SetDisplayName(HeritageColdbornChangeShapeClawsDisplayName)
                .SetDescription(HeritageColdbornChangeShapeClawsDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageColdbornChangeShapeBaseClawsBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageColdbornChangeShapeBaseClawsBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(ClawsIcon)
                .Configure();

            var heritageColdbornChangeShapeBaseAthleticsAbility =
                AbilityConfigurator.New(SkinwalkerHeritageColdbornChangeShapeAthleticsAbilityName, Guids.SkinwalkerHeritageColdbornChangeShapeAthleticsAbilityGuid)
                    .SetDisplayName(HeritageColdbornChangeShapeAthleticsDisplayName)
                    .SetDescription(HeritageColdbornChangeShapeAthleticsDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageColdbornChangeShapeBaseAthleticsBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageColdbornChangeShapeBaseAthleticsBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(AthleticsIcon)
                    .Configure();

            var heritageColdbornChangeShapeBaseScentAbility =
                AbilityConfigurator.New(SkinwalkerHeritageColdbornChangeShapeScentAbilityName, Guids.SkinwalkerHeritageColdbornChangeShapeScentAbilityGuid)
                    .SetDisplayName(HeritageColdbornChangeShapeScentDisplayName)
                    .SetDescription(HeritageColdbornChangeShapeScentDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageColdbornChangeShapeBaseScentBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageColdbornChangeShapeBaseScentBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(ScentIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageColdbornChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageColdbornChangeShapeList.Add(heritageColdbornChangeShapeBaseBiteAbility);
            heritageColdbornChangeShapeList.Add(heritageColdbornChangeShapeBaseClawsAbility);
            heritageColdbornChangeShapeList.Add(heritageColdbornChangeShapeBaseAthleticsAbility);
            heritageColdbornChangeShapeList.Add(heritageColdbornChangeShapeBaseScentAbility);


            var heritageColdbornChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageColdbornChangeShapeBaseName, Guids.SkinwalkerHeritageColdbornChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageColdbornChangeShapeBaseDisplayName)
                    .SetDescription(HeritageColdbornChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageColdbornChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageColdbornChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageColdbornChangeShapeRevertName, Guids.SkinwalkerHeritageColdbornChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageColdbornChangeShapeBaseBiteBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageColdbornChangeShapeBaseBiteBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageColdbornChangeShapeBaseClawsBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageColdbornChangeShapeBaseClawsBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageColdbornChangeShapeBaseAthleticsBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageColdbornChangeShapeBaseAthleticsBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageColdbornChangeShapeBaseScentBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageColdbornChangeShapeBaseScentBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerSummonNatureAllySingle =
                AbilityConfigurator.New(SkinwalkerSummonNatureAllySingleName, Guids.SkinwalkerSummonNatureAllySingleGuid)
                    .CopyFrom(AbilityRefs.SummonNaturesAllyAasimarSingle, typeof(SpellComponent), typeof(SpellDescriptorComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff), typeof(ContextActionSpawnMonster), typeof(PretendSpellLevel))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var skinwalkerSummonNatureAllyd3 =
                AbilityConfigurator.New(SkinwalkerSummonNatureAllyd3Name, Guids.SkinwalkerSummonNatureAllyd3Guid)
                    .CopyFrom(AbilityRefs.SummonNaturesAllyAasimard3, typeof(SpellComponent), typeof(SpellDescriptorComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff), typeof(ContextActionSpawnMonster), typeof(PretendSpellLevel))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var skinwalkerSummonNatureAllyd4plus1 =
                AbilityConfigurator.New(SkinwalkerSummonNatureAllyd4plus1Name, Guids.SkinwalkerSummonNatureAllyd4plus1Guid)
                    .CopyFrom(AbilityRefs.SummonNaturesAllyAasimard4plus1, typeof(SpellComponent), typeof(SpellDescriptorComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff), typeof(ContextActionSpawnMonster), typeof(PretendSpellLevel))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var heritageColdborn =
                FeatureConfigurator.New(SkinwalkerHeritageColdbornName, Guids.SkinwalkerHeritageColdbornGuid)
                    .SetDisplayName(HeritageColdbornDisplayName)
                    .SetDescription(HeritageColdbornDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageColdbornChangeShapeBaseAbility, heritageColdbornChangeShapeRevertAbility, skinwalkerSummonNatureAllySingle, skinwalkerSummonNatureAllyd3, skinwalkerSummonNatureAllyd4plus1 })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillAthletics, value: 2)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillLoreNature, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Constitution, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Charisma, value: -2)
                    .SetIcon(ColdbornIcon)
                    .Configure();

        }

    }
}
