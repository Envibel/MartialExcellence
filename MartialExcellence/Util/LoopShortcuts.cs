using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;
using MartialExcellence.Feats;
using MartialExcellence.RagePowers;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Buffs.Blueprints;

namespace MartialExcellence.Util
{
    /// <summary>
    /// List of new Loop Shortcuts.
    /// </summary>
    class LoopShortcuts
    {
        private static readonly ModLogger Logger = Logging.GetLogger(nameof(LoopShortcuts));

        internal static readonly (Blueprint<BlueprintReference<BlueprintBuff>> buffRef, string Name)[] rageTypes =
    new (Blueprint<BlueprintReference<BlueprintBuff>>, string)[]
    {
                (BuffRefs.StandartFocusedRageBuff, "Standard Rage"),
                (BuffRefs.StandartFocusedRageBuff, "Focused Rage"),
                (BuffRefs.BloodragerStandartRageBuff, "Bloodrager Rage"),
                (BuffRefs.InspiredRageBuff, "Skald Inspired Rage"),
    };

    }
}
