using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.Facts;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using MartialExcellence.Util;


namespace MartialExcellence.Feats
{
    /// <summary>
    /// Creates the Vicious Stomp feat.
    /// </summary>
    public class ViciousStomp
    {
        private static readonly string FeatName = "ViciousStompFeat";

        internal const string DisplayName = "ViciousStomp.Name";
        private static readonly string Description = "ViciousStomp.Description";
        private static readonly string Icon = "assets/icons/viciousstomp.jpg";

        public static void Configure()
        {

            FeatureConfigurator.New(FeatName, Guids.ViciousStompGuid, FeatureGroup.CombatFeat)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFeatureTagsComponent(FeatureTag.Melee | FeatureTag.CombatManeuver)
                .AddPrerequisiteFeature(FeatureRefs.CombatReflexes.ToString())
                .AddPrerequisiteFeature(FeatureRefs.ImprovedUnarmedStrike.ToString())
                .AddFeatureTagsComponent(featureTags: FeatureTag.Melee | FeatureTag.CombatManeuver)
                .AddComponent<ViciousStompTrigger>()
                .SetIcon(Icon)
                .Configure(delayed: true);
        }

        [AllowedOn(typeof(BlueprintUnitFact))]
        public class ViciousStompTrigger : UnitFactComponentDelegate, IKnockOffHandler, IGlobalSubscriber
        {
            public void HandleKnockOff(UnitEntityData initiator, UnitEntityData target)
            {
                if (target == initiator || initiator == null || target == null)
                {
                    return;
                }

                if (!this.Owner.CombatState.IsEngage(target))
                {
                    return;
                }

                if (this.Owner.Body.PrimaryHand?.MaybeWeapon == null)
                {
                    return;
                }

                if (this.Owner.Body.PrimaryHand.Weapon.Blueprint.IsUnarmed)
                {
                    Game.Instance.CombatEngagementController.ForceAttackOfOpportunity(Owner, target);
                }
            }
        }
    }
}

