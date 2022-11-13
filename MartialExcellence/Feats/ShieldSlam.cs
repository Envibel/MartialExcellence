using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.Classes.Selection;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.UnitLogic.Mechanics.Actions;
using MartialExcellence.Util;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;

namespace MartialExcellence.Feats
{
    /// <summary>
    /// Creates the Shield Slam feat.
    /// </summary>
    public class ShieldSlam
    {
        private static readonly string FeatName = "ShieldSlamFeat";
        private static readonly string FeatBuffName = "ShieldSlamFeatBuff";
        private static readonly string FeatAbilityName = "ShieldSlamFeatAbility";

        internal const string DisplayName = "ShieldSlam.Name";
        private static readonly string Description = "ShieldSlam.Description";
        private static readonly string Icon = "assets/icons/shieldslam.jpg";

        public static void Configure()
        {
            var buff =
                BuffConfigurator.New(FeatBuffName, Guids.ShieldSlamBuffGuid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIcon(Icon)
                    // Allows Bull Rush with a heavy shield
                    .AddInitiatorAttackWithWeaponTrigger(
                        checkWeaponCategory: false,
                        weaponType: WeaponTypeRefs.WeaponHeavyShield.ToString(),
                        onlyHit: true,
                        rangeType: Kingmaker.Enums.WeaponRangeType.Melee,
                        action:
                            ActionsBuilder.New()
                                        .CombatManeuver(ActionsBuilder.New(), Kingmaker.RuleSystem.Rules.CombatManeuver.BullRush))
                    // Allows Bull Rush with a light shield
                    .AddInitiatorAttackWithWeaponTrigger(
                        checkWeaponCategory: false,
                        weaponType: WeaponTypeRefs.WeaponLightShield.ToString(),
                        onlyHit: true,
                        rangeType: Kingmaker.Enums.WeaponRangeType.Melee,
                        action:
                            ActionsBuilder.New()
                                        .CombatManeuver(ActionsBuilder.New(), Kingmaker.RuleSystem.Rules.CombatManeuver.BullRush))
                    // Allows Bull Rush with a spiked heavy shield
                    .AddInitiatorAttackWithWeaponTrigger(
                        checkWeaponCategory: false,
                        weaponType: WeaponTypeRefs.SpikedHeavyShield.ToString(),
                        onlyHit: true,
                        rangeType: Kingmaker.Enums.WeaponRangeType.Melee,
                        action:
                            ActionsBuilder.New()
                                        .CombatManeuver(ActionsBuilder.New(), Kingmaker.RuleSystem.Rules.CombatManeuver.BullRush))
                    // Allows Bull Rush with a spiked light shield
                    .AddInitiatorAttackWithWeaponTrigger(
                        checkWeaponCategory: false,
                        weaponType: WeaponTypeRefs.SpikedLightShield.ToString(),
                        onlyHit: true,
                        rangeType: Kingmaker.Enums.WeaponRangeType.Melee,
                        action:
                            ActionsBuilder.New()
                                        .CombatManeuver(ActionsBuilder.New(), Kingmaker.RuleSystem.Rules.CombatManeuver.BullRush))
                    .Configure();

            var ability =
                ActivatableAbilityConfigurator.New(FeatAbilityName, Guids.ShieldSlamAbilityGuid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIcon(Icon)
                    .SetDeactivateImmediately()
                    .SetBuff(buff)
                    .Configure();

            FeatureConfigurator.New(FeatName, Guids.ShieldSlamGuid, FeatureGroup.CombatFeat, FeatureGroup.Feat, FeatureGroup.RangerStyle)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFeatureTagsComponent(FeatureTag.Melee | FeatureTag.CombatManeuver)
                .AddPrerequisiteFeature(FeatureRefs.TwoWeaponFighting.ToString())
                .AddPrerequisiteFeature(FeatureRefs.ShieldBashFeature.ToString())
                .AddPrerequisiteFeature(FeatureRefs.ShieldsProficiency.ToString())
                .AddPrerequisiteStatValue(StatType.BaseAttackBonus, 6)
                .AddToRangerStyles(RangerStyle.Shield2)
                .AddFacts(new() { ability })
                .SetIcon(Icon)
                .Configure(delayed: true);
        }
    }
}

