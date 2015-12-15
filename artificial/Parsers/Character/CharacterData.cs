namespace Artificial.Parsers.Character
{

    public class Color
    {
        public Color(byte r, byte b, byte g, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }   

        public byte a;
        public byte r;
        public byte g;
        public byte b;
    }

    public class CharacterData
    {
        public static readonly byte[] idealHeader = new byte[]{ 0x81, 0x79, 0x83, 0x47, 0x83, 0x66, 0x83, 0x42, 0x83, 0x62, 0x83, 0x67, 0x81, 0x7A, 0x00, 0x00 };
        public byte[] header;
        public int version;
        public bool rainbow;
        public CharacterProfile profile;
        public CharacterBody body;
        // todo
        public ulong traits;
        public ulong preferences;
        public CharacterPregnancy pregnancy;
        public int[] compatibility;
        public CharacterClothes uniform;
        public CharacterClothes sports;
        public CharacterClothes swimsuit;
        public CharacterClothes club;
    }


    public class CharacterPregnancy
    {
        public byte[] week1;
        public byte[] week2;
    }

    public class CharacterBody
    {
        public byte height;
        public byte figureFemale;
        public byte figureMale;
        public byte breastRank;
        public Color skinColor;
        public bool hasGlasses;
        public byte glassesType;
        public byte headSize;
        public byte headHeight;
        public byte waistSize;
        public byte breastSize;
        public byte breastShape;
        public byte breastRoundness;
        public byte breastDirection;
        public byte breastHeight;
        public byte breastSpacing;
        public byte breastDepth;
        public byte breastFirmness;
        public byte pubicHairShape;
        public byte pubicHairOpacity;
        public Color pubicHairColor;
        public byte nippleSize;
        public byte nippleType;
        public byte nippleColor;
        public byte nippleOpacity;
        public byte tanMark;
        public byte tanOpacity;
        // didnt make this name i swear
        // byte 0x447 BODY_PUSSY_MOSAIC_COLOR 0~4
        public byte pussyMosaicColor; 
        public byte faceTypeId;
        public byte eyeWidth;
        public byte eyeHeight;
        public byte eyePosition;
        public byte eyeSpacing;
        public byte eyeAngle;
        public byte irisShape;
        public byte irisWidth;
        public byte irisHeight;
        public byte irisPosition;
        public byte irisType;
        public byte eyeHighlightType;
        public bool hasExternalIrisTexture;
        public bool hasExternalHighlightTexture;
        public string externalIrisTexture;
        public string externalHighlightTexture;
        public byte eyebrowShape;
        public byte eyebrowAngle;
        public Color eyebrowColor;
        public Color leftEyeColor;
        public Color rightEyeColor;
        public byte eyelid;
        public byte upperEyelid;
        public byte lowerEyelid;
        public bool cheekboneMoleLeft;
        public bool cheekboneMoleRight;
        public bool chinMoleLeft;
        public bool chinMoleRight;
        public byte lipstickColor;
        public byte lipstickOpacity;
        public Color glassesColor;
        public byte frontHairId;
        public byte sideHairId;
        public byte backHairId;
        public byte extensionHairId;
        public byte frontHairLength;
        public byte sideHairLength;
        public byte backHairLength;
        public byte extensionHairLength;
        public bool frontHairFlip;
        public bool sideHairFlip;
        public bool backHairFlip;
        public bool extensionHairFlip;
        public Color hairColor;
    }

    public class CharacterProfile
    {
        public bool gender; // 0 = male, 1 = female
        public string firstName;
        public string lastName;
        public string profileText;
        public byte personalityId;
        public byte clubId; // 0-7
        public byte clubRank; // 0-8
        public int clubValue; // 0-1000
        public byte intelligence; // 0-5
        public byte intelligenceRank; // 0-8
        public int intelligenceValue; // 0-1000
        public byte strength;
        public byte strengthRank;
        public int strengthValue;
        public byte sociability; // 0-4
        public byte fightingStyle; // 0: No Restraint, 1: One Blow, 2: Irregular
        public byte virtue; // 0-8
        public byte sexualOrientation; // 0: Hetero, 1: Lean Hetero, 2: Bi, 3: Lean Homo, 4: Homo
        public bool vaginalExperience;
        public bool analExperience;
        public byte voicePitch; // 0-4
        public string loversItem;
        public string friendsItem;
        public string sexualItem;
    }

    public class CharacterClothes
    {
        public int suitId;
        public bool shortSkirt;
        public byte socksId;
        public byte indoorShoesId;
        public byte outdoorShoesId;
        public Color top1Color;
        public Color top2Color;
        public Color top3Color;
        public Color top4Color;
        public Color bottom1Color;
        public Color bottom2Color;
        public Color underwearColor;
        public Color socksColor;
        public Color indoorShoesColor;
        public Color outdoorShoesColor;
        public int skirtTexture;
        public int underwearTexture;
        public int skirtHue;
        public int skirtBrightness;
        public int underwearHue;
        public int underwearBrightness;
        public bool isOnePiece;
        public bool isUnderwear;
        public bool isSkirt;
        public int skirtShadowHue;
        public int skirtShadowBrightness;
        public int underwearShadowHue;
        public int underwearShadowBrightness;
    }
}