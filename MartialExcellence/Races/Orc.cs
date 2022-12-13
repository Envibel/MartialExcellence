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
using static Kingmaker.UnitLogic.FactLogic.AddMechanicsFeature;

namespace MartialExcellence.Races.Orc
{
    class Orc
    {
        private static readonly string OrcName = "OrcRace";
        private static readonly string OrcFerocityName = "OrcFerocity";

        internal const string OrcDisplayName = "Orc.Name";
        private static readonly string OrcDescription = "Orc.Description";
        internal const string OrcFerocityDisplayName = "Orc.Ferocity.Name";
        private static readonly string OrcFerocityDescription = "Orc.Ferocity.Description";

        private static readonly string OrcIcon = "assets/icons/orc.jpg";
        private static readonly string OrcFerocityIcon = "assets/icons/skinwalkerragebred.jpg";


        private static readonly LogWrapper Logger = LogWrapper.Get("MartialExcellence");

        public static void Configure()
        {
            var ferocity =
                FeatureConfigurator.New(OrcFerocityName, Guids.OrcFerocityGuid)
                .SetDisplayName(OrcFerocityDisplayName)
                .SetDescription(OrcFerocityDescription)
                .AddMechanicsFeature(MechanicsFeatureType.Ferocity)
                .SetIcon(OrcFerocityIcon)
                .Configure();

            var race =
            RaceConfigurator.New(OrcName, Guids.OrcGuid)
                .CopyFrom(RaceRefs.HalfOrcRace)
                .SetDisplayName(OrcDisplayName)
                .SetDescription(OrcDescription)
                .SetSelectableRaceStat(false)
                .SetFeatures(ferocity, FeatureRefs.OrcWeaponFamiliarity.ToString())
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Strength, value: 4)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Wisdom, value: -2)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Intelligence, value: -2)
                .AddStatBonus(ModifierDescriptor.Racial, stat: StatType.Charisma, value: -2)
                .SetIcon(OrcIcon)
                .SetRaceId(Race.HalfOrc)
                .Configure(delayed: true);


            // Add race to race list
            var raceRef = race.ToReference<BlueprintRaceReference>();
            ref var races = ref BlueprintRoot.Instance.Progression.m_CharacterRaces;

            var length = races.Length;
            Array.Resize(ref races, length + 1);
            races[length] = raceRef;
        }
    }
}
