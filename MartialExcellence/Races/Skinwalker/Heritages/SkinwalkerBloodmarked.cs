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
    class SkinwalkerBloodmarked
    {
        private static readonly string SkinwalkerInvisibilityName = "SkinwalkerInvisibility";

        private static readonly string SkinwalkerHeritageBloodmarkedName = "SkinwalkerHeritageBloodmarked";
        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapeBaseName = "SkinwalkerHeritageBloodmarkedChangeShapeBase";
        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapeRevertName = "SkinwalkerHeritageBloodmarkedChangeShapeRevert";

        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapeBiteAbilityName = "SkinwalkerHeritageBloodmarkedChangeShapeBiteAbility";
        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapeBiteBuffName = "SkinwalkerHeritageBloodmarkedChangeShapeBiteBuff";
        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapePerceptionAbilityName = "SkinwalkerHeritageBloodmarkedChangeShapePerceptionAbility";
        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapePerceptionBuffName = "SkinwalkerHeritageBloodmarkedChangeShapePerceptionBuff";
        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityAbilityName = "SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityAbility";
        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityBuffName = "SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityBuff";
        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapeScentAbilityName = "SkinwalkerHeritageBloodmarkedChangeShapeScentAbility";
        private static readonly string SkinwalkerHeritageBloodmarkedChangeShapeScentBuffName = "SkinwalkerHeritageBloodmarkedChangeShapeScentBuff";

        internal const string HeritageBloodmarkedDisplayName = "Skinwalker.Heritage.Bloodmarked.Name";
        private static readonly string HeritageBloodmarkedDescription = "Skinwalker.Heritage.Bloodmarked.Description";
        internal const string HeritageBloodmarkedChangeShapeBaseDisplayName = "Skinwalker.Heritage.Bloodmarked.ChangeShapeBase.Name";
        private static readonly string HeritageBloodmarkedChangeShapeBaseDescription = "Skinwalker.Heritage.Bloodmarked.ChangeShapeBase.Description";
        internal const string HeritageBloodmarkedChangeShapeBiteDisplayName = "Skinwalker.Heritage.Bloodmarked.ChangeShapeBite.Name";
        private static readonly string HeritageBloodmarkedChangeShapeBiteDescription = "Skinwalker.Heritage.Bloodmarked.ChangeShapeBite.Description";
        internal const string HeritageBloodmarkedChangeShapePerceptionDisplayName = "Skinwalker.Heritage.Bloodmarked.ChangeShapePerception.Name";
        private static readonly string HeritageBloodmarkedChangeShapePerceptionDescription = "Skinwalker.Heritage.Bloodmarked.ChangeShapePerception.Description";
        internal const string HeritageBloodmarkedChangeShapeGroundImmunityDisplayName = "Skinwalker.Heritage.Bloodmarked.ChangeShapeGroundImmunity.Name";
        private static readonly string HeritageBloodmarkedChangeShapeGroundImmunityDescription = "Skinwalker.Heritage.Bloodmarked.ChangeShapeGroundImmunity.Description";
        internal const string HeritageBloodmarkedChangeShapeScentDisplayName = "Skinwalker.Heritage.Bloodmarked.ChangeShapeScent.Name";
        private static readonly string HeritageBloodmarkedChangeShapeScentDescription = "Skinwalker.Heritage.Bloodmarked.ChangeShapeScent.Description";

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";

        private static readonly string BloodmarkedIcon = "assets/icons/skinwalkerbloodmarked.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string BiteIcon = "assets/icons/changeshapebite.jpg";
        private static readonly string PerceptionIcon = "assets/icons/changeshapeperception.jpg";
        private static readonly string GroundImmunityIcon = "assets/icons/changeshapegroundimmunity.jpg";
        private static readonly string ScentIcon = "assets/icons/changeshapescent.jpg";
        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);


            var heritageBloodmarkedChangeShapeBaseBiteBuff =
                BuffConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapeBiteBuffName, Guids.SkinwalkerHeritageBloodmarkedChangeShapeBiteBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageBloodmarkedChangeShapeBaseBiteBuff)
                .SetDisplayName(HeritageBloodmarkedChangeShapeBiteDisplayName)
                .SetDescription(HeritageBloodmarkedChangeShapeBiteDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .SetIcon(BiteIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageBloodmarkedChangeShapeBaseBiteBuff))
                .Configure();


            var heritageBloodmarkedChangeShapeBasePerceptionBuff =
                BuffConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapePerceptionBuffName, Guids.SkinwalkerHeritageBloodmarkedChangeShapePerceptionBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageBloodmarkedChangeShapeBasePerceptionBuff)
                .SetDisplayName(HeritageBloodmarkedChangeShapePerceptionDisplayName)
                .SetDescription(HeritageBloodmarkedChangeShapePerceptionDescription)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillPerception, value: 4)
                .SetIcon(PerceptionIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageBloodmarkedChangeShapeBasePerceptionBuff))
                .Configure();

            var heritageBloodmarkedChangeShapeBaseGroundImmunityBuff =
                BuffConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityBuffName, Guids.SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageBloodmarkedChangeShapeBaseGroundImmunityBuff)
                .SetDisplayName(HeritageBloodmarkedChangeShapeGroundImmunityDisplayName)
                .SetDescription(HeritageBloodmarkedChangeShapeGroundImmunityDescription)
                .AddBuffDescriptorImmunity(descriptor: new SpellDescriptorWrapper(SpellDescriptor.Ground))
                .AddSpellImmunityToSpellDescriptor(descriptor: new SpellDescriptorWrapper(SpellDescriptor.Ground))
                .SetIcon(GroundImmunityIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageBloodmarkedChangeShapeBaseGroundImmunityBuff))
                .Configure();

            var heritageBloodmarkedChangeShapeBaseScentBuff =
                BuffConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapeScentBuffName, Guids.SkinwalkerHeritageBloodmarkedChangeShapeScentBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageBloodmarkedChangeShapeBaseScentBuff)
                .SetDisplayName(HeritageBloodmarkedChangeShapeScentDisplayName)
                .SetDescription(HeritageBloodmarkedChangeShapeScentDescription)
                .AddBlindsense(range: new Kingmaker.Utility.Feet(30))
                .SetIcon(ScentIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageBloodmarkedChangeShapeBaseScentBuff))
                .Configure();

            var heritageBloodmarkedChangeShapeBaseBiteAbility =
                AbilityConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapeBiteAbilityName, Guids.SkinwalkerHeritageBloodmarkedChangeShapeBiteAbilityGuid)
                    .SetDisplayName(HeritageBloodmarkedChangeShapeBiteDisplayName)
                    .SetDescription(HeritageBloodmarkedChangeShapeBiteDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageBloodmarkedChangeShapeBaseBiteBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageBloodmarkedChangeShapeBaseBiteBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(BiteIcon)
                    .Configure();

            var heritageBloodmarkedChangeShapeBasePerceptionAbility =
                AbilityConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapePerceptionAbilityName, Guids.SkinwalkerHeritageBloodmarkedChangeShapePerceptionAbilityGuid)
                .SetDisplayName(HeritageBloodmarkedChangeShapePerceptionDisplayName)
                .SetDescription(HeritageBloodmarkedChangeShapePerceptionDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageBloodmarkedChangeShapeBasePerceptionBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageBloodmarkedChangeShapeBasePerceptionBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(PerceptionIcon)
                .Configure();

            var heritageBloodmarkedChangeShapeBaseGroundImmunityAbility =
                AbilityConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityAbilityName, Guids.SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityAbilityGuid)
                    .SetDisplayName(HeritageBloodmarkedChangeShapeGroundImmunityDisplayName)
                    .SetDescription(HeritageBloodmarkedChangeShapeGroundImmunityDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageBloodmarkedChangeShapeBaseGroundImmunityBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageBloodmarkedChangeShapeBaseGroundImmunityBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(GroundImmunityIcon)
                    .Configure();

            var heritageBloodmarkedChangeShapeBaseScentAbility =
                AbilityConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapeScentAbilityName, Guids.SkinwalkerHeritageBloodmarkedChangeShapeScentAbilityGuid)
                    .SetDisplayName(HeritageBloodmarkedChangeShapeScentDisplayName)
                    .SetDescription(HeritageBloodmarkedChangeShapeScentDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageBloodmarkedChangeShapeBaseScentBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageBloodmarkedChangeShapeBaseScentBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(ScentIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageBloodmarkedChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageBloodmarkedChangeShapeList.Add(heritageBloodmarkedChangeShapeBaseBiteAbility);
            heritageBloodmarkedChangeShapeList.Add(heritageBloodmarkedChangeShapeBasePerceptionAbility);
            heritageBloodmarkedChangeShapeList.Add(heritageBloodmarkedChangeShapeBaseGroundImmunityAbility);
            heritageBloodmarkedChangeShapeList.Add(heritageBloodmarkedChangeShapeBaseScentAbility);


            var heritageBloodmarkedChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapeBaseName, Guids.SkinwalkerHeritageBloodmarkedChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageBloodmarkedChangeShapeBaseDisplayName)
                    .SetDescription(HeritageBloodmarkedChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageBloodmarkedChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageBloodmarkedChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageBloodmarkedChangeShapeRevertName, Guids.SkinwalkerHeritageBloodmarkedChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageBloodmarkedChangeShapeBaseBiteBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageBloodmarkedChangeShapeBaseBiteBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageBloodmarkedChangeShapeBasePerceptionBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageBloodmarkedChangeShapeBasePerceptionBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageBloodmarkedChangeShapeBaseGroundImmunityBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageBloodmarkedChangeShapeBaseGroundImmunityBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageBloodmarkedChangeShapeBaseScentBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageBloodmarkedChangeShapeBaseScentBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerInvisibility =
                AbilityConfigurator.New(SkinwalkerInvisibilityName, Guids.SkinwalkerInvisibilityGuid)
                    .CopyFrom(AbilityRefs.Invisibility, typeof(SpellComponent), typeof(SpellListComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var heritageBloodmarked =
                FeatureConfigurator.New(SkinwalkerHeritageBloodmarkedName, Guids.SkinwalkerHeritageBloodmarkedGuid)
                    .SetDisplayName(HeritageBloodmarkedDisplayName)
                    .SetDescription(HeritageBloodmarkedDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageBloodmarkedChangeShapeBaseAbility, heritageBloodmarkedChangeShapeRevertAbility, skinwalkerInvisibility })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillMobility, value: 2)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillPerception, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Intelligence, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Dexterity, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: -2)
                    .SetIcon(BloodmarkedIcon)
                    .Configure();

        }

    }
}
