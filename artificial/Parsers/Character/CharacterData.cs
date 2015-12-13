namespace Artificial.Parsers.Character
{

    public class Color
    {
        byte a;
        byte r;
        byte g;
        byte b;
    }

    public class CharacterData
    {
        byte[] header = { 0x81, 0x79, 0x83, 0x47, 0x83, 0x66, 0x83, 0x42, 0x83, 0x62, 0x83, 0x67, 0x81, 0x7A, 0x00, 0x00 };
        int version;
        bool rainbow;
        CharacterProfile profile;
        CharacterBody body;
        // todo
        /*CharacterTraits traits;
        CharacterPreferences preferences;
        CharacterPregnancy pregnancy;
        CharacterCompatability compatability;*/
        CharacterClothes uniform;
        CharacterClothes sports;
        CharacterClothes swimsuit;
        CharacterClothes club;
    }

    public class CharacterBody
    {
        byte height;
        byte figureFemale;
        byte figureMale;
        byte breastRank;
        Color skinColor;
        bool hasGlasses;
        byte glassesType;
        byte headSize;
        byte headHeight;
        byte waistSize;
        byte breastSize;
        byte breastShape;
        byte breastRoundness;
        byte breastDirection;
        byte breastHeight;
        byte breastSpacing;
        byte breastDepth;
        byte breastFirmness;
        byte pubicHairShape;
        byte pubicHairOpacity;
        Color pubicHairColor;
        byte nippleSize;
        byte nippleType;
        byte nippleColor;
        byte nippleOpacity;
        byte tanMark;
        byte tanOpacity;
        // didnt make this name i swear
        // byte 0x447 BODY_PUSSY_MOSAIC_COLOR 0~4
        byte pussyMosaicColor; 
        byte faceTypeId;
        byte eyeWidth;
        byte eyeHeight;
        byte eyePosition;
        byte eyeSpacing;
        byte eyeAngle;
        byte irisShape;
        byte irisWidth;
        byte irisHeight;
        byte irisPosition;
        byte irisType;
        byte eyeHighlightType;
        bool hasExternalIrisTexture;
        bool hasExternalHighlightTexture;
        string externalIrisTexture;
        string externalHighlightTexture;
        byte eyebrowShape;
        byte eyebrowAngle;
        Color eyebrowColor;
        Color leftEyeColor;
        Color rightEyeColor;
        byte eyelid;
        byte upperEyelid;
        byte lowerEyelid;
        bool cheekboneMoleLeft;
        bool cheekboneMoleRight;
        bool chinMoleLeft;
        bool chinMoleRight;
        byte lipstickColor;
        byte lipstickOpacity;
        Color glassesColor;
        byte frontHairId;
        byte sideHairId;
        byte backHairId;
        byte extensionHairId;
        byte frontHairLength;
        byte sideHairLength;
        byte backHairLength;
        byte extensionHairLength;
        bool frontHairFlip;
        bool sideHairFlip;
        bool backHairFlip;
        bool extensionHairFlip;
        Color hairColor;
    }

    public class CharacterProfile
    {
        bool gender; // 0 = male, 1 = female
        string firstName;
        string lastName;
        string profile;
        byte personalityId;
        byte clubId; // 0-7
        byte clubRank; // 0-8
        int clubValue; // 0-1000
        byte intelligence; // 0-5
        byte intelligenceRank; // 0-8
        int intelligenceValue; // 0-1000
        byte strength;
        byte strengthRank;
        int strengthValue;
        byte sociability; // 0-4
        byte fightingStyle; // 0: No Restraint, 1: One Blow, 2: Irregular
        byte virtue; // 0-8
        byte sexualOrientation; // 0: Hetero, 1: Lean Hetero, 2: Bi, 3: Lean Homo, 4: Homo
        bool vaginalExperience;
        bool analExperience;
        byte voicePitch; // 0-4
        string loversItem;
        string friendsItem;
        string sexualItem;
    }

    public class CharacterClothes
    {
        byte suitId;
        bool shortSkirt;
        byte socksId;
        byte indoorShoesId;
        byte outdoorShoesId;
        Color top1Color;
        Color top2Color;
        Color top3Color;
        Color top4Color;
        Color bottom1Color;
        Color bottom2Color;
        Color underwearColor;
        Color socksColor;
        Color indoorShoesColor;
        Color outdoorShoesColor;
        int skirtTexture;
        int underwearTexture;
        int skirtHue;
        int skirtBrightness;
        int underwearHue;
        int underwearBrightness;
        bool isOnePiece;
        bool isUnderwear;
        bool isSkirt;
        int skirtShadowHue;
        int skirtShadowBrightness;
        int underwearShadowHue;
        int underwearShadowBrightness;
    }
}