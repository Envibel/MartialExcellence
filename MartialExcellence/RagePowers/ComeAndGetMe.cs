using System.Linq;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Kingmaker;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.PubSubSystem;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using MartialExcellence.Util;

namespace MartialExcellence.RagePowers
{
    public class ComeAndGetMe
    {
        private static readonly string RagePowerName = "ComeAndGetMeRagePower";
        private static readonly string SwitchBuffName = "ComeAndGetMeSwitchBuff";
        private static readonly string EffectBuffName = "ComeAndGetMeEffectBuff";
        private static readonly string AbilityName = "ComeAndGetMeAbility";
        internal const string DisplayName = "ComeAndGetMe.Name";
        private static readonly string Description = "ComeAndGetMe.Description";
        private static readonly string Icon = "assets/icons/comeandgetme.jpg";
        private static readonly int ComeAndGetMeACPenalty = -4;
        private static readonly int ComeAndGetMeDamageBonus = 4;

        public static void Configure()
        {
            // this buff provides the mechanical benefits of Come and Get Me!
            BuffConfigurator.New(EffectBuffName, Guids.ComeAndGetMeEffectBuffGuid)
                .SetDisplayName("ComeAndGetMe.Name")
                .SetDescription("ComeAndGetMe.Description")
                .AddComponent<ComeAndGetMeTrigger>()
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            // If the player actives rage on a character with this buff then the character is given a hidden buff with
            // the actual mechanical effts of Come and Get Me!
            var switchbuff =
                BuffConfigurator.New(SwitchBuffName, Guids.ComeAndGetMeSwitchBuffGuid)
                    .SetDisplayName("ComeAndGetMe.Name")
                    .SetDescription("ComeAndGetMe.Description")
                    .SetIcon(Icon)
                .Configure();

            // The ability that appears on the action bar and gives the character the SwitchBuffName
            var ability =
                ActivatableAbilityConfigurator.New(AbilityName, Guids.ComeAndGetMeAbilityGuid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIcon(Icon)
                    .SetBuff(switchbuff)
                    .Configure();

            FeatureConfigurator.New(RagePowerName, Guids.ComeAndGetMeGuid, FeatureGroup.RagePower)
                .AddPrerequisiteClassLevel(CharacterClassRefs.BarbarianClass.ToString(), 12, group: Prerequisite.GroupType.Any)
                .AddPrerequisiteArchetypeLevel(ArchetypeRefs.PrimalistArchetype.ToString(), CharacterClassRefs.BloodragerClass.ToString(), level: 12, group: Prerequisite.GroupType.Any)
                .AddPrerequisiteClassLevel(CharacterClassRefs.SkaldClass.ToString(), 12, group: Prerequisite.GroupType.Any)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddFacts(new() { ability })
                .Configure();

            // Allow regular rage to proc Come and Get Me!
            BuffConfigurator.For(BuffRefs.StandartRageBuff)
                .AddFactContextActions(
                    activated:
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasBuff(SwitchBuffName),
                                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(EffectBuffName, isNotDispelable: true)))
                .Configure();

            //Allow focused rage to proc Come and Get Me!
            BuffConfigurator.For(BuffRefs.StandartFocusedRageBuff)
                .AddFactContextActions(
                    activated:
                        ActionsBuilder.New()
                            .Conditional(
                                ConditionsBuilder.New().HasFact(SwitchBuffName),
                                ifTrue: ActionsBuilder.New().ApplyBuffPermanent(EffectBuffName, isNotDispelable: true)))
                .Configure();

            // Allow bloodrage to proc Come and Get Me!
            BuffConfigurator.For(BuffRefs.BloodragerStandartRageBuff)
                .AddFactContextActions(
                    activated:
                        ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(SwitchBuffName),
                            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(EffectBuffName, isNotDispelable: true)))
                .Configure();

            // Allow inspired rage to proc Come and Get Me!
            BuffConfigurator.For(BuffRefs.InspiredRageBuff)
                .AddFactContextActions(
                    activated:
                        ActionsBuilder.New()
                        .Conditional(
                            ConditionsBuilder.New().HasFact(SwitchBuffName),
                            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(EffectBuffName, isNotDispelable: true)))
                .Configure();
        }

        [TypeId("3D36DAB2-0A0D-473A-84E9-1C71243818CF")]
        private class ComeAndGetMeTrigger : UnitFactComponentDelegate, ITargetRulebookHandler<RuleDealDamage>, ITargetRulebookHandler<RuleAttackWithWeapon>, ITargetRulebookHandler<RuleCalculateAC>
        {
            public void OnEventAboutToTrigger(RuleCalculateAC evt)
            {

                evt.AddModifier(ComeAndGetMeACPenalty, this.Fact, descriptor: Kingmaker.Enums.ModifierDescriptor.UntypedStackable);
            }

            public void OnEventDidTrigger(RuleCalculateAC evt)
            {
            }


            public void OnEventAboutToTrigger(RuleDealDamage evt)
            {
                if (evt.DamageBundle.Count() > 0 && evt.Reason.Rule is RuleAttackWithWeapon)
                {
                    evt.DamageBundle.ElementAt(0).AddModifier(ComeAndGetMeDamageBonus, this.Fact);
                }

            }
            public void OnEventDidTrigger(RuleDealDamage evt)
            {
            }

            public void OnEventAboutToTrigger(RuleAttackWithWeapon evt)
            {

            }

            public void OnEventDidTrigger(RuleAttackWithWeapon evt)
            {
                if (this.Owner.Body.PrimaryHand.MaybeWeapon != null && this.Owner.Body.PrimaryHand.MaybeWeapon.Blueprint.IsMelee && evt.Weapon.Blueprint.IsMelee && this.Owner.CombatState.IsEngage(evt.Initiator))
                {
                    Game.Instance.CombatEngagementController.ForceAttackOfOpportunity(this.Owner, evt.Initiator);
                }
            }
        }

    }
}
