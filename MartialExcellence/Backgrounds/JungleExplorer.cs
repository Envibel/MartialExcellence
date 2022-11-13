using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using MartialExcellence.Util;
using System;
using System.Collections.Generic;
using static Kingmaker.Blueprints.Classes.Prerequisites.Prerequisite;
using static UnityModManagerNet.UnityModManager.ModEntry;

namespace MartialExcellence.Backgrounds
{
    /// <summary>
    /// Creates the Jungle Explorer background.
    /// </summary>
    public class JungleExplorer
    {
        private static readonly string FeatName = "JungleExplorerFeat";

        internal const string DisplayName = "JungleExplorer.Name";
        private static readonly string Description = "JungleExplorer.Description";
        //private static readonly ModLogger Logger = Logging.GetLogger(nameof(Settings));

        public static void Configure()
        {
            //List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>> profList = new List<BlueprintCore.Utils.Blueprint<Kingmaker.Blueprints.BlueprintUnitFactReference>>();
            //profList.Add(WeaponTypeRefs.Kukri.ToString());

            var proficiencyList = new[] { WeaponCategory.Kukri };

            FeatureConfigurator.New(FeatName, Guids.JungleExplorerGuid, FeatureGroup.BackgroundSelection, FeatureGroup.Trait)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddClassSkill(StatType.SkillMobility)
                .AddClassSkill(StatType.SkillAthletics)
                .AddProficiencies(weaponProficiencies: proficiencyList)
                //.AddFacts(profList)
                .AddStatBonus(descriptor: ModifierDescriptor.UntypedStackable, stat: StatType.SaveFortitude, value: 1)
                .AddBackgroundClassSkill(StatType.SkillMobility)
                .AddBackgroundClassSkill(StatType.SkillAthletics)
                .AddBackgroundWeaponProficiency(WeaponCategory.Kukri, stackBonusType: ModifierDescriptor.Trait, stackBonus: ContextValues.Constant(1))
                .Configure(delayed: true);
        }
    }
}

