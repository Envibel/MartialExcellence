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
using Kingmaker.Designers.Mechanics.Buffs;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using static Kingmaker.UnitLogic.FactLogic.AddMechanicsFeature;
using static CodexLib.Helper;
using CodexLib;
using Kingmaker.Blueprints.Classes.Prerequisites;

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
            var mythic = Helper.ToRef<BlueprintUnitFactReference>("325f078c584318849bfe3da9ea245b9d").ObjToArray();
            var mythicraces = mythic[0].Get().GetComponent<PrerequisiteFeaturesFromList>();
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
                .AddComponent(new AddStatBonusIfHasFact
                {
                    Descriptor = ModifierDescriptor.Racial,
                    Stat = StatType.Wisdom,
                    Value = -2,
                    InvertCondition = true,
                    m_CheckedFacts = mythic
                })
                .AddComponent(new AddStatBonusIfHasFact
                {
                    Descriptor = ModifierDescriptor.Racial,
                    Stat = StatType.Intelligence,
                    Value = -2,
                    InvertCondition = true,
                    m_CheckedFacts = mythic
                })
                .AddComponent(new AddStatBonusIfHasFact
                {
                    Descriptor = ModifierDescriptor.Racial,
                    Stat = StatType.Charisma,
                    Value = -2,
                    InvertCondition = true,
                    m_CheckedFacts = mythic
                })
                .SetIcon(OrcIcon)
                .SetRaceId(Race.HalfOrc)
                .Configure(delayed: true);


            // Add race to race list
            var raceRef = race.ToReference<BlueprintRaceReference>();
            ref var races = ref BlueprintRoot.Instance.Progression.m_CharacterRaces;

            // Add race to Destiny Beyond Birth
            Helper.AppendAndReplace(ref mythicraces.m_Features, raceRef);

            var length = races.Length;
            Array.Resize(ref races, length + 1);
            races[length] = raceRef;
        }
    }
}
