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


        internal const string SkinwalkerHeritageScaleheartGuid = "c23c947b-6249-458d-87d3-5468270c3031";
        internal const string SkinwalkerHeritageScaleheartChangeShapeAbilityGuid = "c00c4051-03c3-4bbd-9896-848436086cb6";
        internal const string SkinwalkerHeritageScaleheartChangeShapeRevertAbilityGuid = "5f8dbf84-ba71-4dbb-927c-1f20535798ff";
        internal const string SkinwalkerScareGuid = "8b914b37-aecf-4251-89a0-7c93b197fc87";

        internal const string SkinwalkerHeritageScaleheartChangeShapeBiteAbilityGuid = "a4d09881-a76f-4f1c-8964-dc6e45b57b73";
        internal const string SkinwalkerHeritageScaleheartChangeShapeBiteBuffGuid = "bb7fc3f5-d026-4bb8-a5b4-33e3e262beb0";
        internal const string SkinwalkerHeritageScaleheartChangeShapeArmorAbilityGuid = "b367fd43-8334-4f3e-937a-08e31cda263f";
        internal const string SkinwalkerHeritageScaleheartChangeShapeArmorBuffGuid = "af31c9a3-7c5c-4b73-9378-f49015322951";
        internal const string SkinwalkerHeritageScaleheartChangeShapeInitiativeAbilityGuid = "96fecee2-b0f8-4d16-a641-9c451d0306db";
        internal const string SkinwalkerHeritageScaleheartChangeShapeInitiativeBuffGuid = "f0f26803-aef9-44c3-b72e-c9c11425dbf2";
        internal const string SkinwalkerHeritageScaleheartChangeShapeFerocityAbilityGuid = "8360b2b0-82bf-4460-ba51-22dfd2332eee";
        internal const string SkinwalkerHeritageScaleheartChangeShapeFerocityBuffGuid = "edf00fa1-8d9c-446d-9942-82f09b72532d";


        internal const string SkinwalkerHeritageAeriebornGuid = "9f264c6b-02e7-4637-9caf-f7bcbd56f233";
        internal const string SkinwalkerHeritageAeriebornChangeShapeAbilityGuid = "2aa30267-cf85-40b8-ae5a-c4204c1a6431";
        internal const string SkinwalkerHeritageAeriebornChangeShapeRevertAbilityGuid = "15176ee2-ba4c-4295-85c9-9a98538468b4";
        internal const string SkinwalkerFeatherStepGuid = "a0ff1456-26fe-4adf-88c1-81664b6cf77f";

        internal const string SkinwalkerHeritageAeriebornChangeShapeBiteAbilityGuid = "f5a05ae1-0069-438a-a69b-b0010bf525e4";
        internal const string SkinwalkerHeritageAeriebornChangeShapeBiteBuffGuid = "4d515200-80c0-4b15-9808-72f1085add21";
        internal const string SkinwalkerHeritageAeriebornChangeShapePerceptionAbilityGuid = "9399ccb6-2426-484a-84fa-bb75410b424c";
        internal const string SkinwalkerHeritageAeriebornChangeShapePerceptionBuffGuid = "b647fd90-8ac9-48ca-9106-2031f666a13e";
        internal const string SkinwalkerHeritageAeriebornChangeShapeTalonsAbilityGuid = "ca10bc7b-e1ac-4142-baa4-607ea80b19a7";
        internal const string SkinwalkerHeritageAeriebornChangeShapeTalonsBuffGuid = "ec4ce2b6-5011-4cec-9d0f-b01eb6cb3aef";
        internal const string SkinwalkerHeritageAeriebornChangeShapeDodgeAbilityGuid = "f3eccd0c-e04d-4179-b969-ba7114489abd";
        internal const string SkinwalkerHeritageAeriebornChangeShapeDodgeBuffGuid = "cb920ce7-65e0-4838-ba72-7a55e47e7a19";


        internal const string SkinwalkerHeritageNightskulkGuid = "a2436927-58f6-4bf9-be88-f73c755cca31";
        internal const string SkinwalkerHeritageNightskulkChangeShapeAbilityGuid = "c3d77a6c-d5c7-4242-8048-2a6bdddab2ae";
        internal const string SkinwalkerHeritageNightskulkChangeShapeRevertAbilityGuid = "335983bc-7a69-48d5-8ff9-2ebc58e26043";
        internal const string SkinwalkerAnimalAspectRaccoonGuid = "31c62244-c8f7-45d1-a479-de7b6f5c98f5";

        internal const string SkinwalkerHeritageNightskulkChangeShapeBiteAbilityGuid = "84a04d9d-c4bd-4c5e-8d3c-29652f095dc8";
        internal const string SkinwalkerHeritageNightskulkChangeShapeBiteBuffGuid = "712abf3d-4d3a-4e28-92c6-5a09703c74d5";
        internal const string SkinwalkerHeritageNightskulkChangeShapeAthleticsAbilityGuid = "e449bc2d-e71f-4566-8103-547a0abe9d51";
        internal const string SkinwalkerHeritageNightskulkChangeShapeAthleticsBuffGuid = "01718520-3bcb-4d2d-a947-2ff6e7085ceb";
        internal const string SkinwalkerHeritageNightskulkChangeShapeDistractionAbilityGuid = "077d66be-f2d3-4a6f-861a-436749199853";
        internal const string SkinwalkerHeritageNightskulkChangeShapeDistractionBuffGuid = "1675d0b4-c76b-4bbe-b949-cb8bb34b8ec4";
        internal const string SkinwalkerHeritageNightskulkChangeShapeScentAbilityGuid = "8b901758-2396-4c8d-bea9-6144b6d0ab20";
        internal const string SkinwalkerHeritageNightskulkChangeShapeScentBuffGuid = "998bcdf0-26b1-488f-bba2-ec09c674260e";


        internal const string SkinwalkerHeritageSeascarredGuid = "bfce8a5f-32d7-4379-8e21-d16fa5918b26";
        internal const string SkinwalkerHeritageSeascarredChangeShapeAbilityGuid = "d30080f5-8f5d-449a-997a-dfd28e9abb51";
        internal const string SkinwalkerHeritageSeascarredChangeShapeRevertAbilityGuid = "31938ded-f64b-4148-a1ea-7380d58a0512";
        internal const string SkinwalkerResistEnergyColdGuid = "59658da2-d93f-4c6b-a283-1f6be793f084";

        internal const string SkinwalkerHeritageSeascarredChangeShapeBiteAbilityGuid = "bbd25514-d4d0-4dff-ab48-f6a444714239";
        internal const string SkinwalkerHeritageSeascarredChangeShapeBiteBuffGuid = "a5536911-eefc-4ff3-839f-f505495f5a9d";
        internal const string SkinwalkerHeritageSeascarredChangeShapeScentAbilityGuid = "84a3dcdd-413f-4046-8a78-a13c01a0b8a3";
        internal const string SkinwalkerHeritageSeascarredChangeShapeScentBuffGuid = "fee00fa2-85e1-436e-8753-0233500a9221";
        internal const string SkinwalkerHeritageSeascarredChangeShapeInitiativeAbilityGuid = "b8fca8b6-6c92-40d9-a412-a0f03f5583ab";
        internal const string SkinwalkerHeritageSeascarredChangeShapeInitiativeBuffGuid = "c6cff002-331a-49df-9b82-3a8ec49c151e";
        internal const string SkinwalkerHeritageSeascarredChangeShapeFerocityAbilityGuid = "285ed958-69de-43b9-b979-ec5d1b05fd5f";
        internal const string SkinwalkerHeritageSeascarredChangeShapeFerocityBuffGuid = "806201b0-0d65-4e9f-9cc7-90d086998b29";

        internal const string SkinwalkerHeritageFanglordGuid = "aa359d3f-6317-4130-aaec-3536d46d761c";
        internal const string SkinwalkerHeritageFanglordChangeShapeAbilityGuid = "bcc05909-605e-4f41-a003-f400778d8827";
        internal const string SkinwalkerHeritageFanglordChangeShapeRevertAbilityGuid = "85d3ebaa-3cc3-4ac6-a410-3a0dd79943b1";
        internal const string SkinwalkerMagicFangGuid = "f670e93d-0378-4ef4-a3ca-f544e270eea8";

        internal const string SkinwalkerHeritageFanglordChangeShapeBiteAbilityGuid = "3a456cc1-ccaa-467f-aa61-72a5e9e41784";
        internal const string SkinwalkerHeritageFanglordChangeShapeBiteBuffGuid = "df259461-c837-4122-a132-309b4820c541";
        internal const string SkinwalkerHeritageFanglordChangeShapeClawsAbilityGuid = "881c0dd1-4279-4514-91f8-500163cc9e3e";
        internal const string SkinwalkerHeritageFanglordChangeShapeClawsBuffGuid = "d6c13812-d6a8-441f-a84c-c11a40481ec1";
        internal const string SkinwalkerHeritageFanglordChangeShapeSpeedAbilityGuid = "ad97d7be-3be2-44d0-8739-d5504bdf4042";
        internal const string SkinwalkerHeritageFanglordChangeShapeSpeedBuffGuid = "9aa696d0-ff1c-4e97-9382-8ce068098f29";
        internal const string SkinwalkerHeritageFanglordChangeShapeScentAbilityGuid = "0eb43ab6-91c4-4df5-bcd9-af6c39f7564c";
        internal const string SkinwalkerHeritageFanglordChangeShapeScentBuffGuid = "fcf24a86-f11b-4034-b949-03fb197527d6";

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
