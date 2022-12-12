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

        internal const string ExtraFeatureGuid = "9067dd74-b878-44c2-9211-ec0759e77161";

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
        internal const string SkinwalkerChangeShapeResourceGuid = "810a4c50-2070-4c45-97c7-d6111c90ed50";
        internal const string SkinwalkerChangeShapeRevertResourceGuid = "70f3bbcf-1692-457c-81bc-b10d710f63ee";


        internal const string SkinwalkerHeritageClassicGuid = "0185983d-7b7e-4724-91f9-f75295c0a387";
        internal const string SkinwalkerHeritageClassicChangeShapeAbilityGuid = "327d9ff5-b9da-42f5-8d10-cc63345fcb4c";
        internal const string SkinwalkerHeritageClassicChangeShapeRevertAbilityGuid = "8c689f2c-5860-4dad-97df-f75a6639879b";

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
        internal const string SkinwalkerHeritageRagebredChangeShapeAbilityGuid = "4da8258e-293b-484b-a4db-f62bc0c47f9c";
        internal const string SkinwalkerHeritageRagebredChangeShapeRevertAbilityGuid = "7c49bde1-8690-4ca0-8a94-4d79c7a7e509";
        internal const string SkinwalkerAnimalAspectGorillaGuid = "1ab9cb86-0266-46b3-b58c-634b1ba04b6a";

        internal const string SkinwalkerHeritageRagebredChangeShapeSpeedAbilityGuid = "486f52df-7d29-4831-88c2-96b6bbbbe457";
        internal const string SkinwalkerHeritageRagebredChangeShapeSpeedBuffGuid = "002949af-f328-4de4-84d7-a975b8659b29";
        internal const string SkinwalkerHeritageRagebredChangeShapeGoreAbilityGuid = "99c858cc-6232-474e-9faa-ef6e87108cb7";
        internal const string SkinwalkerHeritageRagebredChangeShapeGoreBuffGuid = "f737f2ac-39a9-4379-800d-76e98919e1fc";
        internal const string SkinwalkerHeritageRagebredChangeShapeHoovesAbilityGuid = "23a7c4c9-546d-483b-a576-86a160472f98";
        internal const string SkinwalkerHeritageRagebredChangeShapeHoovesBuffGuid = "0e1caa58-e4a5-4c97-88f5-37282ff38a83";
        internal const string SkinwalkerHeritageRagebredChangeShapeScentAbilityGuid = "3b5ece22-a4f1-495e-bae9-af71a245efaa";
        internal const string SkinwalkerHeritageRagebredChangeShapeScentBuffGuid = "9b6f5e3c-9e81-4ac5-8d60-1d6d0197fb0c";


        internal const string SkinwalkerHeritageBloodmarkedGuid = "7a419040-e5b1-4706-ac88-4f7689b47748";
        internal const string SkinwalkerHeritageBloodmarkedChangeShapeAbilityGuid = "badc4771-8f5e-4296-8c4e-bf3936eac6e7";
        internal const string SkinwalkerHeritageBloodmarkedChangeShapeRevertAbilityGuid = "b0d5d349-249f-45bd-bc07-723371c8f18d";
        internal const string SkinwalkerInvisibilityGuid = "e2008838-27a2-4c7c-a468-34accfbbc24f";

        internal const string SkinwalkerHeritageBloodmarkedChangeShapeBiteAbilityGuid = "5d90e05f-5da3-440e-b5b9-722afafaa994";
        internal const string SkinwalkerHeritageBloodmarkedChangeShapeBiteBuffGuid = "5ec84c44-233b-4848-98cc-af8756290a78";
        internal const string SkinwalkerHeritageBloodmarkedChangeShapePerceptionAbilityGuid = "f8296340-a20f-444f-9d23-f501eed4cfd0";
        internal const string SkinwalkerHeritageBloodmarkedChangeShapePerceptionBuffGuid = "caa8fe41-8629-4df8-a0ce-2d13e074eb97";
        internal const string SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityAbilityGuid = "3c165983-9e4d-42d5-9f46-f56a1de545e8";
        internal const string SkinwalkerHeritageBloodmarkedChangeShapeGroundImmunityBuffGuid = "7b144b3f-6f23-4851-8403-aabac96e4ddb";
        internal const string SkinwalkerHeritageBloodmarkedChangeShapeScentAbilityGuid = "fe188c1c-4640-4306-97e5-10ca46c102e5";
        internal const string SkinwalkerHeritageBloodmarkedChangeShapeScentBuffGuid = "65cff5da-da47-4603-b3fa-5c51a7fadd2c";

        internal const string SkinwalkerHeritageColdbornGuid = "41937963-3ca7-43f5-9a87-156eb2f0ea6e";
        internal const string SkinwalkerHeritageColdbornChangeShapeAbilityGuid = "9eb51540-12f8-451e-b46a-5b2aebe38385";
        internal const string SkinwalkerHeritageColdbornChangeShapeRevertAbilityGuid = "b3ad73d9-6023-4a04-bfeb-28a0b57833f7";
        internal const string SkinwalkerSummonNatureAllySingleGuid = "0599f424-2773-479f-bd70-26f9f249d7ff";
        internal const string SkinwalkerSummonNatureAllyd3Guid = "09f65acb-5647-4515-b233-e1358148ba8a";
        internal const string SkinwalkerSummonNatureAllyd4plus1Guid = "28bef15b-ff8d-47cc-a360-2153527ccf27";

        internal const string SkinwalkerHeritageColdbornChangeShapeBiteAbilityGuid = "fe6e2f00-79d9-4408-994b-05bbec32e560";
        internal const string SkinwalkerHeritageColdbornChangeShapeBiteBuffGuid = "65b9c70e-91c8-48e6-a2a6-9fa2bfde1af6";
        internal const string SkinwalkerHeritageColdbornChangeShapeClawsAbilityGuid = "2b245214-9320-4a45-94a4-1895c1356072";
        internal const string SkinwalkerHeritageColdbornChangeShapeClawsBuffGuid = "6162ec46-07e0-4f1e-9641-003ce7104b2d";
        internal const string SkinwalkerHeritageColdbornChangeShapeAthleticsAbilityGuid = "f157f5b3-2306-49a3-ab2b-0ffb4d322dfb";
        internal const string SkinwalkerHeritageColdbornChangeShapeAthleticsBuffGuid = "b2200915-cb40-48da-b4ed-def08a2e809a";
        internal const string SkinwalkerHeritageColdbornChangeShapeScentAbilityGuid = "f4959d1a-3c66-4140-818b-1ee305da253e";
        internal const string SkinwalkerHeritageColdbornChangeShapeScentBuffGuid = "e2ba372e-52d0-44a2-abc9-ecc36b0075e1";


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
