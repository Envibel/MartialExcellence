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

namespace MartialExcellence.Races.Skinwalker
{
    class Skinwalker
    {
        private static readonly string SkinwalkerName = "SkinwalkerRace";
        private static readonly string SkinwalkerHeritageSelectionName = "SkinwalkerHeritageSelection";

        private static readonly string SkinwalkerSpellLikeResourceName = "SkinwalkerSpellLikeResource";
        private static readonly string SkinwalkerChangeShapeRevertResourceName = "SkinwalkerChangeShapeRevertResource";
        private static readonly string SkinwalkerChangeShapeResourceName = "SkinwalkerChangeShapeResource";

        internal const string SkinwalkerDisplayName = "Skinwalker.Name";
        private static readonly string SkinwalkerDescription = "Skinwalker.Description";

        internal const string HeritageSelectionDisplayName = "Skinwalker.HeritageSelection.Name";
        private static readonly string HeritageSelectionDescription = "Skinwalker.HeritageSelection.Description";


        private static readonly string ClassicIcon = "assets/icons/skinwalkerclassic.jpg";
        private static readonly string HeritageIcon = "assets/icons/skinwalkerheritage.jpg";


        private static readonly LogWrapper Logger = LogWrapper.Get("MartialExcellence");

        public static void Configure()
        {
            var changeShapeRevertResource =
                AbilityResourceConfigurator.New(SkinwalkerChangeShapeRevertResourceName, Guids.SkinwalkerChangeShapeRevertResourceGuid)
                    .SetMaxAmount(ResourceAmountBuilder.New(1))
                    .Configure();

            var changeShapeResource =
                AbilityResourceConfigurator.New(SkinwalkerChangeShapeResourceName, Guids.SkinwalkerChangeShapeResourceGuid)
                    .SetMaxAmount(ResourceAmountBuilder.New(1))
                    .Configure();

            var skinwalkerSpellLikeResource =
                AbilityResourceConfigurator.New(SkinwalkerSpellLikeResourceName, Guids.SkinwalkerSpellLikeResourceGuid)
                .SetMaxAmount(ResourceAmountBuilder.New(1))
                .Configure();



            Heritages.SkinwalkerClassic.Configure();
            Heritages.SkinwalkerRagebred.Configure();
            Heritages.SkinwalkerBloodmarked.Configure();
            Heritages.SkinwalkerColdborn.Configure();
            Heritages.SkinwalkerScaleheart.Configure();

            var heritageClassic = BlueprintTool.Get<BlueprintFeature>(Guids.SkinwalkerHeritageClassicGuid);
            var heritageRagebred = BlueprintTool.Get<BlueprintFeature>(Guids.SkinwalkerHeritageRagebredGuid);
            var heritageBloodmarked = BlueprintTool.Get<BlueprintFeature>(Guids.SkinwalkerHeritageBloodmarkedGuid);
            var heritageColdborn = BlueprintTool.Get<BlueprintFeature>(Guids.SkinwalkerHeritageColdbornGuid);
            var heritageScaleheart = BlueprintTool.Get<BlueprintFeature>(Guids.SkinwalkerHeritageScaleheartGuid);



            Blueprint<BlueprintFeatureReference>[] heritageList = new Blueprint<BlueprintFeatureReference>[] { heritageClassic, heritageRagebred, heritageBloodmarked, heritageColdborn, heritageScaleheart };

            var hertiageSelection =
                FeatureSelectionConfigurator.New(SkinwalkerHeritageSelectionName, Guids.SkinwalkerHeritageSelectionGuid)
                    .SetDisplayName(HeritageSelectionDisplayName)
                    .SetDescription(HeritageSelectionDescription)
                    .AddToGroups(FeatureGroup.Racial)
                    .SetAllFeatures(heritageList)
                    .SetIcon(HeritageIcon)
                    .Configure();


            var race =
            RaceConfigurator.New(SkinwalkerName, Guids.SkinwalkerGuid)
                .CopyFrom(RaceRefs.HumanRace)
                .SetDisplayName(SkinwalkerDisplayName)
                .SetDescription(SkinwalkerDescription)
                .SetSelectableRaceStat(false)
                .SetFeatures(hertiageSelection)
                .SetIcon(ClassicIcon)
                .SetRaceId(Race.HalfElf)
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
