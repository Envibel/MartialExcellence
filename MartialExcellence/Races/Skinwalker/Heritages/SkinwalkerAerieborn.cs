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
    class SkinwalkerAerieborn
    {
        private static readonly string SkinwalkerFeatherStepName = "SkinwalkerFeatherStep";

        private static readonly string SkinwalkerHeritageAeriebornName = "SkinwalkerHeritageAerieborn";
        private static readonly string SkinwalkerHeritageAeriebornChangeShapeBaseName = "SkinwalkerHeritageAeriebornChangeShapeBase";
        private static readonly string SkinwalkerHeritageAeriebornChangeShapeRevertName = "SkinwalkerHeritageAeriebornChangeShapeRevert";

        private static readonly string SkinwalkerHeritageAeriebornChangeShapeBiteAbilityName = "SkinwalkerHeritageAeriebornChangeShapeBiteAbility";
        private static readonly string SkinwalkerHeritageAeriebornChangeShapeBiteBuffName = "SkinwalkerHeritageAeriebornChangeShapeBiteBuff";
        private static readonly string SkinwalkerHeritageAeriebornChangeShapePerceptionAbilityName = "SkinwalkerHeritageAeriebornChangeShapePerceptionAbility";
        private static readonly string SkinwalkerHeritageAeriebornChangeShapePerceptionBuffName = "SkinwalkerHeritageAeriebornChangeShapePerceptionBuff";
        private static readonly string SkinwalkerHeritageAeriebornChangeShapeTalonsAbilityName = "SkinwalkerHeritageAeriebornChangeShapeTalonsAbility";
        private static readonly string SkinwalkerHeritageAeriebornChangeShapeTalonsBuffName = "SkinwalkerHeritageAeriebornChangeShapeTalonsBuff";
        private static readonly string SkinwalkerHeritageAeriebornChangeShapeDodgeAbilityName = "SkinwalkerHeritageAeriebornChangeShapeDodgeAbility";
        private static readonly string SkinwalkerHeritageAeriebornChangeShapeDodgeBuffName = "SkinwalkerHeritageAeriebornChangeShapeDodgeBuff";

        internal const string HeritageAeriebornDisplayName = "Skinwalker.Heritage.Aerieborn.Name";
        private static readonly string HeritageAeriebornDescription = "Skinwalker.Heritage.Aerieborn.Description";
        internal const string HeritageAeriebornChangeShapeBaseDisplayName = "Skinwalker.Heritage.Aerieborn.ChangeShapeBase.Name";
        private static readonly string HeritageAeriebornChangeShapeBaseDescription = "Skinwalker.Heritage.Aerieborn.ChangeShapeBase.Description";
        internal const string HeritageAeriebornChangeShapeBiteDisplayName = "Skinwalker.Heritage.Aerieborn.ChangeShapeBite.Name";
        private static readonly string HeritageAeriebornChangeShapeBiteDescription = "Skinwalker.Heritage.Aerieborn.ChangeShapeBite.Description";
        internal const string HeritageAeriebornChangeShapePerceptionDisplayName = "Skinwalker.Heritage.Aerieborn.ChangeShapePerception.Name";
        private static readonly string HeritageAeriebornChangeShapePerceptionDescription = "Skinwalker.Heritage.Aerieborn.ChangeShapePerception.Description";
        internal const string HeritageAeriebornChangeShapeTalonsDisplayName = "Skinwalker.Heritage.Aerieborn.ChangeShapeTalons.Name";
        private static readonly string HeritageAeriebornChangeShapeTalonsDescription = "Skinwalker.Heritage.Aerieborn.ChangeShapeTalons.Description";
        internal const string HeritageAeriebornChangeShapeDodgeDisplayName = "Skinwalker.Heritage.Aerieborn.ChangeShapeDodge.Name";
        private static readonly string HeritageAeriebornChangeShapeDodgeDescription = "Skinwalker.Heritage.Aerieborn.ChangeShapeDodge.Description";

        internal const string ChangeShapeRevertDisplayName = "Skinwalker.ChangeShapeRevert.Name";
        private static readonly string ChangeShapeRevertDescription = "Skinwalker.ChangeShapeRevert.Description";

        private static readonly string AeriebornIcon = "assets/icons/skinwalkeraerieborn.jpg";
        private static readonly string ChangeShapeIcon = "assets/icons/changeshape.jpg";
        private static readonly string RevertIcon = "assets/icons/changeshaperevert.jpg";
        private static readonly string BiteIcon = "assets/icons/changeshapebite.jpg";
        private static readonly string PerceptionIcon = "assets/icons/changeshapeperception.jpg";
        private static readonly string TalonsIcon = "assets/icons/changeshapetalons.jpg";
        private static readonly string DodgeIcon = "assets/icons/changeshapedodge.jpg";
        public static void Configure()
        {
            var changeShapeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeResourceGuid);
            var changeShapeRevertResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerChangeShapeRevertResourceGuid);
            var skinwalkerSpellLikeResource = BlueprintTool.Get<BlueprintAbilityResource>(Guids.SkinwalkerSpellLikeResourceGuid);


            var heritageAeriebornChangeShapeBaseBiteBuff =
                BuffConfigurator.New(SkinwalkerHeritageAeriebornChangeShapeBiteBuffName, Guids.SkinwalkerHeritageAeriebornChangeShapeBiteBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageAeriebornChangeShapeBaseBiteBuff)
                .SetDisplayName(HeritageAeriebornChangeShapeBiteDisplayName)
                .SetDescription(HeritageAeriebornChangeShapeBiteDescription)
                .AddAdditionalLimb(ItemWeaponRefs.Bite1d6.ToString())
                .SetIcon(BiteIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageAeriebornChangeShapeBaseBiteBuff))
                .Configure();


            var heritageAeriebornChangeShapeBasePerceptionBuff =
                BuffConfigurator.New(SkinwalkerHeritageAeriebornChangeShapePerceptionBuffName, Guids.SkinwalkerHeritageAeriebornChangeShapePerceptionBuffGuid)
                    .Configure();

            BuffConfigurator.For(heritageAeriebornChangeShapeBasePerceptionBuff)
                .SetDisplayName(HeritageAeriebornChangeShapePerceptionDisplayName)
                .SetDescription(HeritageAeriebornChangeShapePerceptionDescription)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.SkillPerception, value: 4)
                .SetIcon(PerceptionIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageAeriebornChangeShapeBasePerceptionBuff))
                .Configure();

            var heritageAeriebornChangeShapeBaseTalonsBuff =
                BuffConfigurator.New(SkinwalkerHeritageAeriebornChangeShapeTalonsBuffName, Guids.SkinwalkerHeritageAeriebornChangeShapeTalonsBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageAeriebornChangeShapeBaseTalonsBuff)
                .SetDisplayName(HeritageAeriebornChangeShapeTalonsDisplayName)
                .SetDescription(HeritageAeriebornChangeShapeTalonsDescription)
                .AddEmptyHandWeaponOverride(weapon: ItemWeaponRefs.Talon1d4.ToString())
                .SetIcon(TalonsIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageAeriebornChangeShapeBaseTalonsBuff))
                .Configure();

            var heritageAeriebornChangeShapeBaseDodgeBuff =
                BuffConfigurator.New(SkinwalkerHeritageAeriebornChangeShapeDodgeBuffName, Guids.SkinwalkerHeritageAeriebornChangeShapeDodgeBuffGuid)
                .Configure();

            BuffConfigurator.For(heritageAeriebornChangeShapeBaseDodgeBuff)
                .SetDisplayName(HeritageAeriebornChangeShapeDodgeDisplayName)
                .SetDescription(HeritageAeriebornChangeShapeDodgeDescription)
                .AddStatBonus(ModifierDescriptor.Dodge, stat: StatType.AC, value: 1)
                .SetIcon(DodgeIcon)
                .AddRestTrigger(
                    ActionsBuilder.New().RemoveBuff(heritageAeriebornChangeShapeBaseDodgeBuff))
                .Configure();

            var heritageAeriebornChangeShapeBaseBiteAbility =
                AbilityConfigurator.New(SkinwalkerHeritageAeriebornChangeShapeBiteAbilityName, Guids.SkinwalkerHeritageAeriebornChangeShapeBiteAbilityGuid)
                    .SetDisplayName(HeritageAeriebornChangeShapeBiteDisplayName)
                    .SetDescription(HeritageAeriebornChangeShapeBiteDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageAeriebornChangeShapeBaseBiteBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageAeriebornChangeShapeBaseBiteBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(BiteIcon)
                    .Configure();

            var heritageAeriebornChangeShapeBasePerceptionAbility =
                AbilityConfigurator.New(SkinwalkerHeritageAeriebornChangeShapePerceptionAbilityName, Guids.SkinwalkerHeritageAeriebornChangeShapePerceptionAbilityGuid)
                .SetDisplayName(HeritageAeriebornChangeShapePerceptionDisplayName)
                .SetDescription(HeritageAeriebornChangeShapePerceptionDescription)
                .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                .AddAbilityEffectRunAction(
                    ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(heritageAeriebornChangeShapeBasePerceptionBuff),
                            ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageAeriebornChangeShapeBasePerceptionBuff, isNotDispelable: true))
                        .RestoreResource(changeShapeRevertResource, 1))
                .SetRange(AbilityRange.Personal)
                .SetActionType(CommandType.Move)
                .SetIcon(PerceptionIcon)
                .Configure();

            var heritageAeriebornChangeShapeBaseTalonsAbility =
                AbilityConfigurator.New(SkinwalkerHeritageAeriebornChangeShapeTalonsAbilityName, Guids.SkinwalkerHeritageAeriebornChangeShapeTalonsAbilityGuid)
                    .SetDisplayName(HeritageAeriebornChangeShapeTalonsDisplayName)
                    .SetDescription(HeritageAeriebornChangeShapeTalonsDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageAeriebornChangeShapeBaseTalonsBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageAeriebornChangeShapeBaseTalonsBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(TalonsIcon)
                    .Configure();

            var heritageAeriebornChangeShapeBaseDodgeAbility =
                AbilityConfigurator.New(SkinwalkerHeritageAeriebornChangeShapeDodgeAbilityName, Guids.SkinwalkerHeritageAeriebornChangeShapeDodgeAbilityGuid)
                    .SetDisplayName(HeritageAeriebornChangeShapeDodgeDisplayName)
                    .SetDescription(HeritageAeriebornChangeShapeDodgeDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageAeriebornChangeShapeBaseDodgeBuff),
                                ifFalse: ActionsBuilder.New().ApplyBuffPermanent(heritageAeriebornChangeShapeBaseDodgeBuff, isNotDispelable: true))
                            .RestoreResource(changeShapeRevertResource, 1))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Move)
                    .SetIcon(DodgeIcon)
                    .Configure();

            List<Blueprint<BlueprintAbilityReference>> heritageAeriebornChangeShapeList = new List<Blueprint<BlueprintAbilityReference>>();
            heritageAeriebornChangeShapeList.Add(heritageAeriebornChangeShapeBaseBiteAbility);
            heritageAeriebornChangeShapeList.Add(heritageAeriebornChangeShapeBasePerceptionAbility);
            heritageAeriebornChangeShapeList.Add(heritageAeriebornChangeShapeBaseTalonsAbility);
            heritageAeriebornChangeShapeList.Add(heritageAeriebornChangeShapeBaseDodgeAbility);


            var heritageAeriebornChangeShapeBaseAbility =
                AbilityConfigurator.New(SkinwalkerHeritageAeriebornChangeShapeBaseName, Guids.SkinwalkerHeritageAeriebornChangeShapeAbilityGuid)
                    .SetDisplayName(HeritageAeriebornChangeShapeBaseDisplayName)
                    .SetDescription(HeritageAeriebornChangeShapeBaseDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeResource)
                    .AddAbilityVariants(heritageAeriebornChangeShapeList)
                    .SetRange(AbilityRange.Personal)
                    .SetIcon(ChangeShapeIcon)
                .Configure();

            var heritageAeriebornChangeShapeRevertAbility =
                AbilityConfigurator.New(SkinwalkerHeritageAeriebornChangeShapeRevertName, Guids.SkinwalkerHeritageAeriebornChangeShapeRevertAbilityGuid)
                    .SetDisplayName(ChangeShapeRevertDisplayName)
                    .SetDescription(ChangeShapeRevertDescription)
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: changeShapeRevertResource)
                     .AddAbilityEffectRunAction(
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageAeriebornChangeShapeBaseBiteBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageAeriebornChangeShapeBaseBiteBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageAeriebornChangeShapeBasePerceptionBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageAeriebornChangeShapeBasePerceptionBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageAeriebornChangeShapeBaseTalonsBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageAeriebornChangeShapeBaseTalonsBuff))
                            .Conditional(
                                ConditionsBuilder.New().HasFact(heritageAeriebornChangeShapeBaseDodgeBuff),
                                ifTrue: ActionsBuilder.New().RemoveBuff(heritageAeriebornChangeShapeBaseDodgeBuff))
                            .RestoreResource(changeShapeResource, 4))
                    .SetRange(AbilityRange.Personal)
                    .SetActionType(CommandType.Swift)
                    .SetIcon(RevertIcon)
                .Configure();

            var skinwalkerFeatherStep =
                AbilityConfigurator.New(SkinwalkerFeatherStepName, Guids.SkinwalkerFeatherStepGuid)
                    .CopyFrom(AbilityRefs.FeatherStep, typeof(SpellComponent), typeof(SpellListComponent), typeof(AbilityEffectRunAction), typeof(ContextActionApplyBuff))
                    .AddContextRankConfig(ContextRankConfigs.CharacterLevel())
                    .AddAbilityResourceLogic(1, isSpendResource: true, requiredResource: skinwalkerSpellLikeResource)
                    .Configure();

            var mythic = Helper.ToRef<BlueprintUnitFactReference>("325f078c584318849bfe3da9ea245b9d").ObjToArray();

            var heritageAerieborn =
                FeatureConfigurator.New(SkinwalkerHeritageAeriebornName, Guids.SkinwalkerHeritageAeriebornGuid)
                    .SetDisplayName(HeritageAeriebornDisplayName)
                    .SetDescription(HeritageAeriebornDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .AddFacts(new() { heritageAeriebornChangeShapeBaseAbility, heritageAeriebornChangeShapeRevertAbility, skinwalkerFeatherStep })
                    .AddAbilityResources(resource: changeShapeResource, restoreOnLevelUp: false)
                    .AddAbilityResources(resource: changeShapeRevertResource, restoreOnLevelUp: false, amount: 0, restoreAmount: false)
                    .AddAbilityResources(resource: skinwalkerSpellLikeResource, restoreOnLevelUp: false, restoreAmount: false)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.CheckDiplomacy, value: 2)
                    .AddStatBonus(ModifierDescriptor.UntypedStackable, stat: StatType.SkillPerception, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: 2)
                    .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Dexterity, value: 2)
                    .AddComponent(new AddStatBonusIfHasFact
                    {
                        Descriptor = ModifierDescriptor.Racial,
                        Stat = StatType.Charisma,
                        Value = -2,
                        InvertCondition = true,
                        m_CheckedFacts = mythic
                    })
                    .SetIcon(AeriebornIcon)
                    .Configure();

        }

    }
}
