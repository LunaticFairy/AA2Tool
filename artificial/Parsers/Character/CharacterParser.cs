using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Artificial.Parsers.Character
{
    public static class AABinaryReaderExtension
    {
        public static string ReadJISString(this BinaryReader r, int length)
        {
            //var japaneseEncoding = Encoding.GetEncoding("shift_jis");

            byte[] buf = r.ReadBytes(length);
            for (int i = 0; i < buf.Length; i++)
            {
                if (buf[i] == 0)
                {
                    length = i;
                    break;
                }
            }

            return Encoding.UTF8.GetString(buf.Take(length).ToArray());
        }

        public static string ReadJISStringEx(this BinaryReader r, int length)
        {
            //var japaneseEncoding = Encoding.GetEncoding("shift_jis");
            byte[] buf = r.ReadBytes(length);
            for(int i = 0; i < buf.Length; i++)
            {
                buf[i] = (byte)~buf[i];
                if(buf[i] == 0)
                {
                    length = i;
                    break;
                }
            }
            return Encoding.UTF8.GetString(buf.Take(length).ToArray());
        }

        public static Color ReadColor(this BinaryReader r)
        {
            byte[] c = r.ReadBytes(4);
            return new Color(c[2], c[1], c[0], c[3]);
        }
    }

    public class CharacterParser
    {
        public static Character TryRead(Stream s)
        {

            PngBitmapDecoder dth = new PngBitmapDecoder(s, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            s.Seek(12, SeekOrigin.Current); // throw away IEND chunk
            CharacterData dat = ReadCharacterData(s);
            s.Seek(4, SeekOrigin.Current); // throw away the portrait size
            PngBitmapDecoder dpt = new PngBitmapDecoder(s, BitmapCreateOptions.PreservePixelFormat, BitmapCacheOption.OnLoad);
            s.Seek(12, SeekOrigin.Current); // throw away IEND chunk
            s.Seek(4, SeekOrigin.Current); // throw away the data offset
            // at eof!

            BitmapSource thumb = dth.Frames[0];
            BitmapSource portrait = dpt.Frames[0];

            Character c = new Character(thumb, portrait);
            c.data = dat;

            return c;
        }

        private static ulong ReadTraits(BinaryReader r)
        {
            ulong traits = 0;

            for(int i = 0; i < 38; i++)
            {
                if (r.ReadBoolean())
                    traits |= 1ul << i; 
            }
            return traits;
        }

        private static ulong ReadPreferences(BinaryReader r)
        {
            ulong prefs = 0;

            for (int i = 0; i < 16; i++)
            {
                if (r.ReadBoolean())
                    prefs |= 1ul << i;
            }
            return prefs;
        }

        private static CharacterPregnancy ReadPregnancyRisk(BinaryReader r)
        {
            CharacterPregnancy p = new CharacterPregnancy();
            p.week1 = r.ReadBytes(7);
            p.week2 = r.ReadBytes(7);
            return p;
        }

        private static int[] ReadCompatibility(BinaryReader r)
        {
            int[] c = new int[25];
            for (int i = 0; i < 25; i++)
            {
                c[i] = r.ReadInt32();
            }
            return c;
        }

        private static CharacterClothes ReadClothing(BinaryReader r, Stream s)
        {
            CharacterClothes c = new CharacterClothes();
            c.suitId = r.ReadInt32();
            c.shortSkirt = r.ReadBoolean();
            c.socksId = r.ReadByte();
            c.indoorShoesId = r.ReadByte();
            c.outdoorShoesId = r.ReadByte();
            c.top1Color = r.ReadColor();
            c.top2Color = r.ReadColor();
            c.top3Color = r.ReadColor();
            c.top4Color = r.ReadColor();
            c.bottom1Color = r.ReadColor();
            c.bottom2Color = r.ReadColor();
            c.underwearColor = r.ReadColor();
            c.socksColor = r.ReadColor();
            c.indoorShoesColor = r.ReadColor();
            c.outdoorShoesColor = r.ReadColor();
            c.skirtTexture = r.ReadInt32();
            c.underwearTexture = r.ReadInt32();
            c.skirtHue = r.ReadInt32();
            c.skirtBrightness = r.ReadInt32();
            c.underwearHue = r.ReadInt32();
            c.underwearBrightness = r.ReadInt32();
            c.isOnePiece = r.ReadBoolean();
            c.isUnderwear = r.ReadBoolean();
            c.isSkirt = r.ReadBoolean();
            c.skirtShadowHue = r.ReadInt32();
            c.skirtShadowBrightness = r.ReadInt32();
            c.underwearShadowHue = r.ReadInt32();
            c.underwearShadowBrightness = r.ReadInt32();
            return c;
        }

        private static CharacterData ReadCharacterData(Stream s)
        {
            CharacterData d = new CharacterData();
            d.profile = new CharacterProfile();
            d.body = new CharacterBody();
            d.pregnancy = new CharacterPregnancy();

            BinaryReader reader = new BinaryReader(s);
            d.header = reader.ReadBytes(16);
            d.version = reader.ReadInt32();
            d.profile.gender = reader.ReadBoolean();
            d.profile.lastName = reader.ReadJISStringEx(260);
            d.profile.firstName = reader.ReadJISStringEx(260);
            d.profile.profileText = reader.ReadJISStringEx(512);
            d.profile.personalityId = reader.ReadByte();
            d.body.height = reader.ReadByte();
            d.body.figureFemale = reader.ReadByte();
            d.body.breastRank = reader.ReadByte();
            d.body.skinColor = reader.ReadColor();
            d.body.hasGlasses = reader.ReadBoolean();
            d.profile.vaginalExperience = reader.ReadBoolean();
            reader.ReadByte(); // 0x427 ????
            d.profile.clubId = reader.ReadByte();
            d.body.figureMale = reader.ReadByte();
            reader.ReadBytes(2); // duplicate body height/figure
            d.body.headSize = reader.ReadByte();
            d.body.headHeight = reader.ReadByte();
            d.body.waistSize = reader.ReadByte();
            d.body.breastSize = reader.ReadByte();
            d.body.nippleSize = reader.ReadByte();
            d.body.breastShape = reader.ReadByte();
            d.body.breastRoundness = reader.ReadByte();
            d.body.breastDirection = reader.ReadByte();
            d.body.breastHeight = reader.ReadByte();
            d.body.breastSpacing = reader.ReadByte();
            d.body.breastDepth = reader.ReadByte();
            d.body.breastFirmness = reader.ReadByte();
            reader.ReadBytes(4); // duplicate skin color
            d.body.pubicHairShape = reader.ReadByte();
            d.body.pubicHairOpacity = reader.ReadByte();
            d.body.pubicHairColor = reader.ReadColor();
            d.body.nippleType = reader.ReadByte();
            d.body.nippleColor = reader.ReadByte();
            d.body.nippleOpacity = reader.ReadByte();
            d.body.tanMark = reader.ReadByte();
            d.body.tanOpacity = reader.ReadByte();
            d.body.pussyMosaicColor = reader.ReadByte();
            d.body.faceTypeId = reader.ReadByte();
            d.body.eyeWidth = reader.ReadByte();
            d.body.eyeHeight = reader.ReadByte();
            d.body.eyePosition = reader.ReadByte();
            d.body.eyeSpacing = reader.ReadByte();
            d.body.eyeAngle = reader.ReadByte();
            d.body.irisShape = reader.ReadByte();
            d.body.irisWidth = reader.ReadByte();
            d.body.irisHeight = reader.ReadByte();
            d.body.irisPosition = reader.ReadByte();
            d.body.irisType = reader.ReadByte();
            d.body.eyeHighlightType = reader.ReadByte();
            d.body.hasExternalIrisTexture = reader.ReadBoolean();
            d.body.hasExternalHighlightTexture = reader.ReadBoolean();
            d.body.externalIrisTexture = reader.ReadJISStringEx(260);
            d.body.externalHighlightTexture = reader.ReadJISStringEx(260);
            d.body.eyebrowShape = reader.ReadByte();
            d.body.eyebrowAngle = reader.ReadByte();
            d.body.eyebrowColor = reader.ReadColor();
            d.body.leftEyeColor = reader.ReadColor();
            d.body.rightEyeColor = reader.ReadColor();
            d.body.eyelid = reader.ReadByte();
            d.body.upperEyelid = reader.ReadByte();
            d.body.lowerEyelid = reader.ReadByte();
            d.body.glassesType = reader.ReadByte();
            d.body.cheekboneMoleLeft = reader.ReadBoolean();
            d.body.cheekboneMoleRight = reader.ReadBoolean();
            d.body.chinMoleLeft = reader.ReadBoolean();
            d.body.chinMoleRight = reader.ReadBoolean();
            d.body.lipstickColor = reader.ReadByte();
            d.body.lipstickOpacity = reader.ReadByte();
            d.body.glassesColor = reader.ReadColor();
            d.body.frontHairId = reader.ReadByte();
            d.body.sideHairId = reader.ReadByte();
            d.body.backHairId = reader.ReadByte();
            d.body.extensionHairId = reader.ReadByte();
            d.body.frontHairLength = reader.ReadByte();
            d.body.sideHairLength = reader.ReadByte();
            d.body.backHairLength = reader.ReadByte();
            d.body.extensionHairLength = reader.ReadByte();
            d.body.frontHairFlip = reader.ReadBoolean();
            d.body.sideHairFlip = reader.ReadBoolean();
            d.body.backHairFlip = reader.ReadBoolean();
            d.body.extensionHairFlip = reader.ReadBoolean();
            d.body.hairColor = reader.ReadColor();
            d.profile.intelligence = reader.ReadByte();
            d.profile.intelligenceRank = reader.ReadByte();
            d.profile.intelligenceValue = reader.ReadInt32();
            d.profile.strength = reader.ReadByte();
            d.profile.strengthRank = reader.ReadByte();
            d.profile.strengthValue = reader.ReadInt32();
            d.profile.clubRank = reader.ReadByte();
            d.profile.clubValue = reader.ReadInt32();
            d.profile.sociability = reader.ReadByte();
            d.profile.fightingStyle = reader.ReadByte();
            d.profile.virtue = reader.ReadByte();
            d.profile.sexualOrientation = reader.ReadByte();
            reader.ReadByte(); // duplicate vaginalExperience
            d.profile.analExperience = reader.ReadBoolean();
            d.profile.voicePitch = reader.ReadByte();
            d.traits = ReadTraits(reader);
            d.rainbow = reader.ReadBoolean();
            d.preferences = ReadPreferences(reader);
            d.pregnancy = ReadPregnancyRisk(reader);
            d.compatibility = ReadCompatibility(reader);
            d.profile.loversItem = reader.ReadJISStringEx(260);
            d.profile.friendsItem = reader.ReadJISStringEx(260);
            d.profile.sexualItem = reader.ReadJISStringEx(260);
            d.uniform = ReadClothing(reader, s);
            d.sports = ReadClothing(reader, s);
            d.swimsuit = ReadClothing(reader, s);
            d.club = ReadClothing(reader, s);

            return d;
        }
    }
}