using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UnityModManagerNet.UnityModManager.ModEntry;
using MartialExcellence.Feats;
using MartialExcellence.RagePowers;


namespace MartialExcellence.Util
{
    /// <summary>
    /// List of new Guids.
    /// </summary>
    class Guids
    {
        private static readonly ModLogger Logger = Logging.GetLogger(nameof(Guids));

        #region Feats
        internal const string BrokenWingGambitGuid = "9f13596e-962b-47b3-8209-f2fc7887263e";
        internal const string BrokenWingGambitBuffGuid = "c165955e-b490-490c-a9e2-8f520f540915";
        internal const string BrokenWingGambitAbilityGuid = "ec6808e7-0ba9-4efa-8212-4f9a2ac1a223";
        internal const string BrokenWingGambitDebuffGuid = "86c86d29-d311-4525-a38d-f86b7bf88bb5";

        internal const string DazingAssaultGuid = "49c8436c-787b-4df9-af9c-3445fd9e7a78";
        internal const string DazingAssaultBuffGuid = "4b618e29-29fb-4d08-aebc-8f3b9b395acc";
        internal const string DazingAssaultAbilityGuid = "6fb7a1b5-ad17-4e29-b714-4b85028d029d";

        internal const string StunningAssaultGuid = "0263cc00-d795-407b-a24b-81e54722b3bd";
        internal const string StunningAssaultBuffGuid = "4c901ec3-38d1-4b63-bcde-426efaa54ffc";
        internal const string StunningAssaultAbilityGuid = "a2b07a78-1c4f-44c2-9243-1f0073127482";

        internal const string ShieldSlamGuid = "c0d00f98-0a49-4088-8b5b-4da84b1274bc";
        internal const string ShieldSlamBuffGuid = "bbd6e969-16ba-40bd-9886-27f201359fc5";
        internal const string ShieldSlamAbilityGuid = "a1ec8bcf-7e9c-4fae-ae06-19d584998fbc";


        internal static readonly (string guid, string displayName)[] Feats =
            new (string, string)[]
            {
                //(BrokenWingGambitGuid, BrokenWingGambit.DisplayName),
                (DazingAssaultGuid, DazingAssault.DisplayName),
                (StunningAssaultGuid, StunningAssault.DisplayName),
                (ShieldSlamGuid, ShieldSlam.DisplayName),
                //(BuletteLeapFeat, BuletteLeap.DisplayName),
                //(BuletteRampageFeat, BuletteRampage.DisplayName),
                //(ViciousStompFeat, ViciousStomp.DisplayName),
                //(ShieldSlamFeat, ShieldSlam.DisplayName),
            };

        #endregion


        #region RagePowers
        internal const string ComeAndGetMeGuid = "63AEABA5-1974-4A97-9C9D-BCAD34C7B1D5";
        internal const string ComeAndGetMeSwitchBuffGuid = "1B1554BD-F3C2-41F9-8B94-0487D45EF9F1";
        internal const string ComeAndGetMeEffectBuffGuid = "2ACA6CA0-D80C-471C-A9CA-74694BF0003B";
        internal const string ComeAndGetMeAbilityGuid = "4BAA4A2A-F2CE-401C-B501-A67524838CAB";


        internal static readonly (string guid, string displayName)[] RagePowers =
            new (string, string)[]
            {
                (ComeAndGetMeGuid, ComeAndGetMe.DisplayName),
                //(DisruptiveGuid, Disruptive.DisplayName),
                //(SpellbreakerGuid, Spellbreaker.DisplayName),
                //(GhostRagerFeat, GhostRager.DisplayName),
                //(OverbearingAdvanceFeat, OverbearingAdvance.DisplayName),
                //(SuperstitionFeat, Superstition.DisplayName),
                //(UnrestrainedRageFeat, UnrestrainedRage.DisplayName),
                //(WitchHunterFeat, WitchHunter.DisplayName),
            };

        #endregion
    }
}
