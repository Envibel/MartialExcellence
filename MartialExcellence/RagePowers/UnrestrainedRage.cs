using System.Linq;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using Kingmaker;
using Kingmaker.Blueprints;
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
    /// <summary>
    /// Creates the Unrestrained Rage rage power.
    /// </summary>
    public class UnrestrainedRage
    {
        private static readonly string RagePowerName = "UnrestrainedRageRagePower";
        private static readonly string EffectBuffName = "UnrestrainedRageEffectBuff";
        internal const string DisplayName = "UnrestrainedRage.Name";
        private static readonly string Description = "UnrestrainedRage.Description";
        private static readonly string Icon = "assets/icons/unrestrainedrage.jpg";

        //private static readonly LogWrapper Logger = LogWrapper.Get("MartialExcellence");


        public static void Configure()
        {
            BuffConfigurator.New(EffectBuffName, Guids.UnrestrainedRageEffectBuffGuid)
                .SetDisplayName("UnrestrainedRage.Name")
                .SetDescription("UnrestrainedRage.Description")
                .AddConditionImmunity(UnitCondition.Paralyzed)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            var feature =
            FeatureConfigurator.New(RagePowerName, Guids.UnrestrainedRageGuid, FeatureGroup.RagePower)
                .AddPrerequisiteClassLevel(CharacterClassRefs.BarbarianClass.ToString(), 12, group: Prerequisite.GroupType.Any)
                .AddPrerequisiteArchetypeLevel(ArchetypeRefs.PrimalistArchetype.ToString(), CharacterClassRefs.BloodragerClass.ToString(), level: 12, group: Prerequisite.GroupType.Any)
                .AddPrerequisiteClassLevel(CharacterClassRefs.SkaldClass.ToString(), 12, group: Prerequisite.GroupType.Any)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .Configure();

            // Activate unrestrained rage for each rage type: standard rage, bloodrager rage, focused rage, and inspired rage
            foreach(var (buffRef, name) in LoopShortcuts.rageTypes)
            {
                BuffConfigurator.For(buffRef)
                    .AddFactContextActions(
                        activated:
                            ActionsBuilder.New()
                                .Conditional(
                                    ConditionsBuilder.New().HasFact(feature),
                                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(EffectBuffName, isNotDispelable: true)))
                    .Configure();
            }
        }
    }
}
