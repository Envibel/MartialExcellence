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

        internal const string ViciousStompGuid = "d3c1e291-f5d0-4957-ab58-fbd03954d872";

        internal const string RagingBrutalityGuid = "d5f72532-ce07-4194-bc84-6436dc1933d5";
        internal const string RagingBrutalityBuffGuid = "c27dfaf9-189f-4720-927d-2de46ae1ba39";
        internal const string RagingBrutalityAbilityStandardRageGuid = "00b57662-6f7f-4322-9e1f-d1629f13a1d7";
        internal const string RagingBrutalityAbilityFocusedRageGuid = "37014394-e337-4e45-8410-d53107f1fa7e";
        internal const string RagingBrutalityAbilityBloodragerRageGuid = "a55da688-c50b-4474-ba03-af88c6879e4c";

        internal const string HandsOfValorGuid = "0c5a0ef0-7ed1-475e-a51e-188d18eca411";
        internal const string HandsOfValorBuffGuid = "36968e50-343b-40d5-8dd9-bc1ad95dbb94";
        internal const string HandsOfValorAbilitySelfGuid = "b5a9ad92-89b9-49d7-a435-482e42271b82";
        internal const string HandsOfValorAbilityOthersGuid = "a6bab4dc-d958-453d-bec3-d8934765981a";
        internal const string HandsOfValorAbilityResourceGuid = "4c9951d8-13d3-45c8-9578-10a8720bb605";


        internal static readonly (string guid, string displayName)[] Feats =
            new (string, string)[]
            {
                //(BrokenWingGambitGuid, BrokenWingGambit.DisplayName),
                (DazingAssaultGuid, DazingAssault.DisplayName),
                (StunningAssaultGuid, StunningAssault.DisplayName),
                (ShieldSlamGuid, ShieldSlam.DisplayName),
                (RagingBrutalityGuid, RagingBrutality.DisplayName),
                //(BuletteRampageFeat, BuletteRampage.DisplayName),
                (ViciousStompGuid, ViciousStomp.DisplayName),
                (HandsOfValorGuid, HandsOfValor.DisplayName),
            };

        #endregion

        #region Races

        internal const string SkinwalkerGuid = "bc5a0f32-2e7c-43d0-8140-8d49b983cc00";
        internal const string SkinwalkerHeritageSelectionGuid = "9fea524c-cc6e-40fc-b789-d4013bf81cdd";
        internal const string SkinwalkerAnimalAspectGuid = "1437cfdf-4cae-4e15-86a3-ca5faa24d75d";
        internal const string SkinwalkerSpellLikeResourceGuid = "1b3fc415-5c97-4910-8e2a-ba9a1a3307a9";



        internal const string SkinwalkerHeritageClassicGuid = "0185983d-7b7e-4724-91f9-f75295c0a387";
        internal const string SkinwalkerHeritageClassicChangeShapeAbilityGuid = "327d9ff5-b9da-42f5-8d10-cc63345fcb4c";
        internal const string SkinwalkerHeritageClassicChangeShapeRevertAbilityGuid = "8c689f2c-5860-4dad-97df-f75a6639879b";
        internal const string SkinwalkerHeritageClassicChangeShapeResourceGuid = "810a4c50-2070-4c45-97c7-d6111c90ed50";
        internal const string SkinwalkerHeritageClassicChangeShapeRevertResourceGuid = "70f3bbcf-1692-457c-81bc-b10d710f63ee";

        internal const string SkinwalkerHeritageClassicChangeShapeClawsAbilityGuid = "cbc08a54-7740-48bc-a509-22809f9a8f42";
        internal const string SkinwalkerHeritageClassicChangeShapeClawsBuffGuid = "e1efebee-5927-46f5-b52a-7673f73b93bf";
        internal const string SkinwalkerHeritageClassicChangeShapeArmorAbilityGuid = "de9062e5-edca-42be-9ff7-bef56e61154e";
        internal const string SkinwalkerHeritageClassicChangeShapeArmorBuffGuid = "40025f5c-cf50-4925-b5a4-ee3359e35277";
        internal const string SkinwalkerHeritageClassicChangeShapePerceptionAbilityGuid = "4143d2e0-fb29-4d90-8179-304336a17570";
        internal const string SkinwalkerHeritageClassicChangeShapePerceptionBuffGuid = "ddcdb82c-737f-45cd-999e-cd2cde38c21d";
        internal const string SkinwalkerHeritageSelectionClassicStrengthGuid = "0495f599-46f5-4ee0-b0e6-c3e23ed167a9";
        internal const string SkinwalkerHeritageSelectionClassicDexterityGuid = "c0183f17-138d-41a5-8e08-3b5a0e224215";
        internal const string SkinwalkerHeritageSelectionClassicConstitutionGuid = "5067f74a-7d11-45cd-ac5e-8aef2af23c7d";





        internal const string SkinwalkerHeritageRagebredGuid = "da76b92d-17c3-4121-987e-e2dd6e21fc9b";




        #endregion

        #region RagePowers
        internal const string ComeAndGetMeGuid = "63AEABA5-1974-4A97-9C9D-BCAD34C7B1D5";
        internal const string ComeAndGetMeSwitchBuffGuid = "1B1554BD-F3C2-41F9-8B94-0487D45EF9F1";
        internal const string ComeAndGetMeEffectBuffGuid = "2ACA6CA0-D80C-471C-A9CA-74694BF0003B";
        internal const string ComeAndGetMeAbilityGuid = "4BAA4A2A-F2CE-401C-B501-A67524838CAB";

        internal const string UnrestrainedRageGuid = "8678e342-7b58-4155-8ac4-48eea5056fd3";
        internal const string UnrestrainedRageEffectBuffGuid = "e8b7355a-df19-4b4e-b4e1-9c615982b345";

        internal const string SpiritTotemLesserGuid = "40ba266c-d464-4421-b114-5dcdc06c9b9c";
        internal const string SpiritTotemLesserBuffGuid = "c9042f41-698b-4970-aa5d-92e2aba60587";
        internal const string SpiritTotemLesserItemEnchantGuid = "6afeeb29-6e05-4ceb-b749-41c64f2dc250";

        internal static readonly (string guid, string displayName)[] RagePowers =
            new (string, string)[]
            {
                (ComeAndGetMeGuid, ComeAndGetMe.DisplayName),
                //(DisruptiveGuid, Disruptive.DisplayName),
                //(SpellbreakerGuid, Spellbreaker.DisplayName),
                //(GhostRagerFeat, GhostRager.DisplayName),
                //(OverbearingAdvanceFeat, OverbearingAdvance.DisplayName),
                //(SuperstitionFeat, Superstition.DisplayName),
                (UnrestrainedRageGuid, UnrestrainedRage.DisplayName),
                (SpiritTotemLesserGuid, SpiritTotemLesser.DisplayName),
                //(WitchHunterFeat, WitchHunter.DisplayName),
            };

        #endregion

        #region Backgrounds
        internal const string JungleExplorerGuid = "97ed0d30-9f70-4d85-b0fd-1eacd6f91208";

        #endregion
    }
}
