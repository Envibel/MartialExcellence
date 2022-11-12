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
using System;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace MartialExcellence.Feats
{
    /// <summary>
    /// Creates a feat that does nothing but show up.
    /// </summary>
    public class DazingAssault
    {
        private static readonly string FeatName = "DazingAssaultFeat";
        private static readonly string FeatBuffName = "DazingAssaultFeatBuff";
        private static readonly string FeatAbilityName = "DazingAssaultFeatAbility";

        internal const string DisplayName = "DazingAssault.Name";
        private static readonly string Description = "DazingAssault.Description";
        private static readonly string Icon = "assets/icons/dazingassault.jpg";
        //private static readonly ModLogger Logger = Logging.GetLogger(nameof(Settings));

        //internal static void Configure()
        //{
        //    try
        //    {
        //        if (Settings.IsEnabled(Guids.DazingAssaultGuid))
        //            ConfigureEnabled();
        //        else
        //            ConfigureDisabled();
        //    }
        //    catch (Exception e)
        //    {
        //        Logger.LogException("DazingAssault.Configure", e);
        //    }
        //}

        //private static void ConfigureDisabled()
        //{
        //    Logger.Log($"Configuring {FeatName} (disabled)");

        //    FeatureConfigurator.New(FeatName, Guids.DazingAssaultGuid)
        //      .SetDisplayName(DisplayName)
        //      .SetDescription(Description)
        //      .SetIcon(Icon)
        //      .Configure();
        //}

        public static void Configure()
        {
            var buff =
                BuffConfigurator.New(FeatBuffName, Guids.DazingAssaultBuffGuid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIcon(Icon)
                    .AddWeaponParametersAttackBonus(-5, ranged: false)
                    .AddContextCalculateAbilityParams(statType: StatType.BaseAttackBonus, replaceCasterLevel: true, replaceSpellLevel: true, statTypeFromCustomProperty: false, useKineticistMainStat: false)
                    .AddInitiatorAttackWithWeaponTrigger(
                        onlyHit: true,
                        rangeType: Kingmaker.Enums.WeaponRangeType.Melee,
                        action:
                            ActionsBuilder.New()
                                        .SavingThrow(SavingThrowType.Fortitude,
                                        onResult:
                                        ActionsBuilder.New()
                                        .ConditionalSaved(
                                            failed:
                                                ActionsBuilder.New()
                                                    .ApplyBuff(
                                                        BuffRefs.DazeBuff.Reference.Get(),
                                                            ContextDuration.Fixed(1)))))
                    .Configure();

            var ability =
                ActivatableAbilityConfigurator.New(FeatAbilityName, Guids.DazingAssaultAbilityGuid)
                    .SetDisplayName(DisplayName)
                    .SetDescription(Description)
                    .SetIcon(Icon)
                    .SetBuff(buff)
                    .Configure();

            FeatureConfigurator.New(FeatName, Guids.DazingAssaultGuid, FeatureGroup.CombatFeat, FeatureGroup.Feat)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFeatureTagsComponent(FeatureTag.Melee | FeatureTag.Attack)
                .AddPrerequisiteStatValue(StatType.Strength, 13, group: GroupType.Any)
                .AddPrerequisiteFeature(FeatureRefs.PowerAttackFeature.ToString())
                .AddPrerequisiteStatValue(StatType.BaseAttackBonus, 11)
                .AddFacts(new() { ability })
                .SetIcon(Icon)
                .Configure(delayed: true);
        }
    }
}

