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
    class SkinwalkerFanglord
    {
        private static readonly string SkinwalkerMagicFangName = "SkinwalkerMagicFang";

        private static readonly string SkinwalkerHeritageFanglordName = "SkinwalkerHeritageFanglord";
        private static readonly string SkinwalkerHeritageFanglordChangeShapeBaseName = "SkinwalkerHeritageFanglordChangeShapeBase";
        private static readonly string SkinwalkerHeritageFanglordChangeShapeRevertName = "SkinwalkerHeritageFanglordChangeShapeRevert";

        private static readonly string SkinwalkerHeritageFanglordChangeShapeBiteAbilityName = "SkinwalkerHeritageFanglordChangeShapeBiteAbility";
        private static readonly string SkinwalkerHeritageFanglordChangeShapeBiteBuffName = "SkinwalkerHeritageFanglordChangeShapeBiteBuff";
        private static readonly string SkinwalkerHeritageFanglordChangeShapeClawsAbilityName = "SkinwalkerHeritageFanglordChangeShapeClawsAbility";
        private static readonly string SkinwalkerHeritageFanglordChangeShapeClawsBuffName = "SkinwalkerHeritageFanglordChangeShapeClawsBuff";
        private static readonly string SkinwalkerHeritageFanglordChangeShapeSpeedAbilityName = "SkinwalkerHeritageFanglordChangeShapeSpeedAbility";
        private static readonly string SkinwalkerHeritageFanglordChangeShapeSpeedBuffName = "SkinwalkerHeritageFanglordChangeShapeSpeedBuff";
        private static readonly string SkinwalkerHeritageFanglordChangeShapeScentAbilityName = "SkinwalkerHeritageFanglordChangeShapeScentAbility";
        private static readonly string SkinwalkerHeritageFanglordChangeShapeScentBuffName = "SkinwalkerHeritageFanglordChangeShapeScentBuff";

        internal const string HeritageFanglordDisplayName = "Skinwalker.Heritage.Fanglord.Name";
        private static readonly string HeritageFanglordDescription = "Skinwalker.Heritage.Fanglord.Description";
        internal const string HeritageFanglordChangeShapeBaseDisplayName = "Skinwalker.Heritage.Fanglord.ChangeShapeBase.Name";
        private static readonly string HeritageFanglordChangeShapeBaseDescription = "Skinwalker.Heritage.Fanglord.ChangeShapeBase.Description";
        internal const string HeritageFanglordChangeShapeBiteDisplayName = "Skinwalker.Heritage.Fanglord.ChangeShapeBite.Name";
        private static readonly string HeritageFanglordChangeShapeBiteDescription = "Skinwalker.Heritage.Fanglord.ChangeShapeBite.Description";
        internal const string HeritageFanglordChangeShapeClawsDisplayName = "Skinwalker.Heritage.Fanglord.ChangeShapeClaws.Name";
        private static readonly string HeritageFanglordChangeShapeClawsDescription = "Skinwalker.Heritage.Fanglord.ChangeShapeClaws.Description";
        internal const string HeritageFanglordChangeShapeSpeedDisplayName = "Skinwalker.Heritage.Fanglord.ChangeShapeSpeed.Name";
        private static readonly string HeritageFanglordChangeShapeSpeedDescription = "Skinwalker.Heritage.Fanglord.ChangeShapeSpeed.Description";
        internal const string HeritageFanglordChangeShapeScentDisplayName = "Skinwalker.Heritage.Fanglord.ChangeShapeScent.Name";
        private static readonly string HeritageFanglordChangeShapeScentDescription = "Skinwalker.Heritage.Fanglord.ChangeShapeScent.Description";

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";

        private static readonly string FanglordIcon = "assets/icons/skinwalkerfanglord.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string BiteIcon = "assets/icons/changeshapebite.jpg";
        private static readonly string ClawsIcon = "assets/icons/changeshapeclaws.jpg";
        private static readonly string SpeedIcon = "assets/icons/changeshapespeed.jpg";
        private static readonly string ScentIcon = "assets/icons/changeshapescent.jpg";
        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);


            var heritageFanglordChangeShapeBaseBiteBuff =
                BuffConfigurator.New(SkinwalkerHeritageFanglordChangeShapeBiteBuffName, Guids.SkinwalkerHeritageFanglordChangeShapeBiteBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageFanglordChangeShapeBaseBiteBuff)
                .SetDisplayName(HeritageFanglordChangeShapeBiteDisplayName)
                .SetDescription(HeritageFanglordChangeShapeBiteDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .SetIcon(BiteIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageFanglordChangeShapeBaseBiteBuff))
                .Configure();


            var heritageFanglordChangeShapeBaseClawsBuff =
                BuffConfigurator.New(SkinwalkerHeritageFanglordChangeShapeClawsBuffName, Guids.SkinwalkerHeritageFanglordChangeShapeClawsBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageFanglordChangeShapeBaseClawsBuff)
                .SetDisplayName(HeritageFanglordChangeShapeClawsDisplayName)
                .SetDescription(HeritageFanglordChangeShapeClawsDescription)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Claw1d4.ToString())
                .SetIcon(ClawsIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageFanglordChangeShapeBaseClawsBuff))
                .Configure();

            var heritageFanglordChangeShapeBaseSpeedBuff =
                BuffConfigurator.New(SkinwalkerHeritageFanglordChangeShapeSpeedBuffName, Guids.SkinwalkerHeritageFanglordChangeShapeSpeedBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageFanglordChangeShapeBaseSpeedBuff)
                .SetDisplayName(HeritageFanglordChangeShapeSpeedDisplayName)
                .SetDescription(HeritageFanglordChangeShapeSpeedDescription)
                .AddBuffMovementSpeed(value: 10, descriptor: ModifierDescriptor.Racial)
                .SetIcon(SpeedIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageFanglordChangeShapeBaseSpeedBuff))
                .Configure();

            var heritageFanglordChangeShapeBaseScentBuff =
                BuffConfigurator.New(SkinwalkerHeritageFanglordChangeShapeScentBuffName, Guids.SkinwalkerHeritageFanglordChangeShapeScentBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageFanglordChangeShapeBaseScentBuff)
                .SetDisplayName(HeritageFanglordChangeShapeScentDisplayName)
                .SetDescription(HeritageFanglordChangeShapeScentDescription)
                .AddBlindsense(range: new Kingmaker.Utility.Feet(30))
                .SetIcon(ScentIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageFanglordChangeShapeBaseScentBuff))
                .Configure();

            var heritageFanglordChangeShapeBaseBiteAbility =
                AbilityConfigurator.New(SkinwalkerHeritageFanglordChangeShapeBiteAbilityName, Guids.SkinwalkerHeritageFanglordChangeShapeBiteAbilityGuid)
                    .SetDisplayName(HeritageFanglordChangeShapeBiteDisplayName)
                    .SetDescription(HeritageFanglordChangeShapeBiteDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageFanglordChangeShapeBaseBiteBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageFanglordChangeShapeBaseBiteBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(BiteIcon)
                    .Configure();

            var heritageFanglordChangeShapeBaseClawsAbility =
                AbilityConfigurator.New(SkinwalkerHeritageFanglordChangeShapeClawsAbilityName, Guids.SkinwalkerHeritageFanglordChangeShapeClawsAbilityGuid)
                .SetDisplayName(HeritageFanglordChangeShapeClawsDisplayName)
                .SetDescription(HeritageFanglordChangeShapeClawsDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageFanglordChangeShapeBaseClawsBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageFanglordChangeShapeBaseClawsBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(ClawsIcon)
                .Configure();

            var heritageFanglordChangeShapeBaseSpeedAbility =
                AbilityConfigurator.New(SkinwalkerHeritageFanglordChangeShapeSpeedAbilityName, Guids.SkinwalkerHeritageFanglordChangeShapeSpeedAbilityGuid)
                    .SetDisplayName(HeritageFanglordChangeShapeSpeedDisplayName)
                    .SetDescription(HeritageFanglordChangeShapeSpeedDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageFanglordChangeShapeBaseSpeedBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageFanglordChangeShapeBaseSpeedBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(SpeedIcon)
                    .Configure();

            var heritageFanglordChangeShapeBaseScentAbility =
                AbilityConfigurator.New(SkinwalkerHeritageFanglordChangeShapeScentAbilityName, Guids.SkinwalkerHeritageFanglordChangeShapeScentAbilityGuid)
                    .SetDisplayName(HeritageFanglordChangeShapeScentDisplayName)
                    .SetDescription(HeritageFanglordChangeShapeScentDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageFanglordChangeShapeBaseScentBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageFanglordChangeShapeBaseScentBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(ScentIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageFanglordChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageFanglordChangeShapeList.Add(heritageFanglordChangeShapeBaseBiteAbility);
            heritageFanglordChangeShapeList.Add(heritageFanglordChangeShapeBaseClawsAbility);
            heritageFanglordChangeShapeList.Add(heritageFanglordChangeShapeBaseSpeedAbility);
            heritageFanglordChangeShapeList.Add(heritageFanglordChangeShapeBaseScentAbility);


            var heritageFanglordChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageFanglordChangeShapeBaseName, Guids.SkinwalkerHeritageFanglordChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageFanglordChangeShapeBaseDisplayName)
                    .SetDescription(HeritageFanglordChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageFanglordChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageFanglordChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageFanglordChangeShapeRevertName, Guids.SkinwalkerHeritageFanglordChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageFanglordChangeShapeBaseBiteBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageFanglordChangeShapeBaseBiteBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageFanglordChangeShapeBaseClawsBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageFanglordChangeShapeBaseClawsBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageFanglordChangeShapeBaseSpeedBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageFanglordChangeShapeBaseSpeedBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageFanglordChangeShapeBaseScentBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageFanglordChangeShapeBaseScentBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerMagicFang =
                AbilityConfigurator.New(SkinwalkerMagicFangName, Guids.SkinwalkerMagicFangGuid)
                    .CopyFrom(AbilityRefs.MagicFang, typeof(SpellComponent), typeof(SpellListComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff), typeof(AbilitySpawnFx), typeof(EnhanceWeapon))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var mythic = Helper.ToRef<BlueprintUnitFactReference>("325f078c584318849bfe3da9ea245b9d").ObjToArray();

            var heritageFanglord =
                FeatureConfigurator.New(SkinwalkerHeritageFanglordName, Guids.SkinwalkerHeritageFanglordGuid)
                    .SetDisplayName(HeritageFanglordDisplayName)
                    .SetDescription(HeritageFanglordDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageFanglordChangeShapeBaseAbility, heritageFanglordChangeShapeRevertAbility, skinwalkerMagicFang })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillMobility, value: 2)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillPerception, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Dexterity, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Charisma, value: 2)
                    .AddComponent(new AddStatBonusIfHasFact
                    {
                        Descriptor = ModifierDescriptor.Racial,
                        Stat = StatType.Wisdom,
                        Value = -2,
                        InvertCondition = true,
                        m_CheckedFacts = mythic
                    })
                    .SetIcon(FanglordIcon)
                    .Configure();

        }

    }
}
