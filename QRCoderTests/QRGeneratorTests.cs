﻿using QRCoder;
using QRCoderTests.Helpers.XUnitExtenstions;
using Shouldly;
using System.Collections.Generic;
using System.Reflection;
using Xunit;
using System.Linq;
using System.Collections;
using System.Text;

namespace QRCoderTests
{

    public class QRGeneratorTests
    {
        [Fact]
        [Category("QRGenerator/Antilog")]
        public void validate_antilogtable()
        {
            var gen = new QRCodeGenerator();

            var checkString = string.Empty;
            var gField = gen.GetType().GetField("galoisFieldByExponentAlpha", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null).ShouldBeOfType<int[]>();
            gField.Length.ShouldBe(256);
            for (int i = 0; i < gField.Length; i++)
            {
                checkString += i + "," + gField[i] + ",:";
            }
            checkString.ShouldBe("0,1,:1,2,:2,4,:3,8,:4,16,:5,32,:6,64,:7,128,:8,29,:9,58,:10,116,:11,232,:12,205,:13,135,:14,19,:15,38,:16,76,:17,152,:18,45,:19,90,:20,180,:21,117,:22,234,:23,201,:24,143,:25,3,:26,6,:27,12,:28,24,:29,48,:30,96,:31,192,:32,157,:33,39,:34,78,:35,156,:36,37,:37,74,:38,148,:39,53,:40,106,:41,212,:42,181,:43,119,:44,238,:45,193,:46,159,:47,35,:48,70,:49,140,:50,5,:51,10,:52,20,:53,40,:54,80,:55,160,:56,93,:57,186,:58,105,:59,210,:60,185,:61,111,:62,222,:63,161,:64,95,:65,190,:66,97,:67,194,:68,153,:69,47,:70,94,:71,188,:72,101,:73,202,:74,137,:75,15,:76,30,:77,60,:78,120,:79,240,:80,253,:81,231,:82,211,:83,187,:84,107,:85,214,:86,177,:87,127,:88,254,:89,225,:90,223,:91,163,:92,91,:93,182,:94,113,:95,226,:96,217,:97,175,:98,67,:99,134,:100,17,:101,34,:102,68,:103,136,:104,13,:105,26,:106,52,:107,104,:108,208,:109,189,:110,103,:111,206,:112,129,:113,31,:114,62,:115,124,:116,248,:117,237,:118,199,:119,147,:120,59,:121,118,:122,236,:123,197,:124,151,:125,51,:126,102,:127,204,:128,133,:129,23,:130,46,:131,92,:132,184,:133,109,:134,218,:135,169,:136,79,:137,158,:138,33,:139,66,:140,132,:141,21,:142,42,:143,84,:144,168,:145,77,:146,154,:147,41,:148,82,:149,164,:150,85,:151,170,:152,73,:153,146,:154,57,:155,114,:156,228,:157,213,:158,183,:159,115,:160,230,:161,209,:162,191,:163,99,:164,198,:165,145,:166,63,:167,126,:168,252,:169,229,:170,215,:171,179,:172,123,:173,246,:174,241,:175,255,:176,227,:177,219,:178,171,:179,75,:180,150,:181,49,:182,98,:183,196,:184,149,:185,55,:186,110,:187,220,:188,165,:189,87,:190,174,:191,65,:192,130,:193,25,:194,50,:195,100,:196,200,:197,141,:198,7,:199,14,:200,28,:201,56,:202,112,:203,224,:204,221,:205,167,:206,83,:207,166,:208,81,:209,162,:210,89,:211,178,:212,121,:213,242,:214,249,:215,239,:216,195,:217,155,:218,43,:219,86,:220,172,:221,69,:222,138,:223,9,:224,18,:225,36,:226,72,:227,144,:228,61,:229,122,:230,244,:231,245,:232,247,:233,243,:234,251,:235,235,:236,203,:237,139,:238,11,:239,22,:240,44,:241,88,:242,176,:243,125,:244,250,:245,233,:246,207,:247,131,:248,27,:249,54,:250,108,:251,216,:252,173,:253,71,:254,142,:255,1,:");

            var gField2 = gen.GetType().GetField("galoisFieldByIntegerValue", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null).ShouldBeOfType<int[]>();
            gField2.Length.ShouldBe(256);
            var checkString2 = string.Empty;
            for (int i = 0; i < gField2.Length; i++)
            {
                checkString2 += i + "," + gField2[i] + ",:";
            }
            checkString2.ShouldBe("0,0,:1,0,:2,1,:3,25,:4,2,:5,50,:6,26,:7,198,:8,3,:9,223,:10,51,:11,238,:12,27,:13,104,:14,199,:15,75,:16,4,:17,100,:18,224,:19,14,:20,52,:21,141,:22,239,:23,129,:24,28,:25,193,:26,105,:27,248,:28,200,:29,8,:30,76,:31,113,:32,5,:33,138,:34,101,:35,47,:36,225,:37,36,:38,15,:39,33,:40,53,:41,147,:42,142,:43,218,:44,240,:45,18,:46,130,:47,69,:48,29,:49,181,:50,194,:51,125,:52,106,:53,39,:54,249,:55,185,:56,201,:57,154,:58,9,:59,120,:60,77,:61,228,:62,114,:63,166,:64,6,:65,191,:66,139,:67,98,:68,102,:69,221,:70,48,:71,253,:72,226,:73,152,:74,37,:75,179,:76,16,:77,145,:78,34,:79,136,:80,54,:81,208,:82,148,:83,206,:84,143,:85,150,:86,219,:87,189,:88,241,:89,210,:90,19,:91,92,:92,131,:93,56,:94,70,:95,64,:96,30,:97,66,:98,182,:99,163,:100,195,:101,72,:102,126,:103,110,:104,107,:105,58,:106,40,:107,84,:108,250,:109,133,:110,186,:111,61,:112,202,:113,94,:114,155,:115,159,:116,10,:117,21,:118,121,:119,43,:120,78,:121,212,:122,229,:123,172,:124,115,:125,243,:126,167,:127,87,:128,7,:129,112,:130,192,:131,247,:132,140,:133,128,:134,99,:135,13,:136,103,:137,74,:138,222,:139,237,:140,49,:141,197,:142,254,:143,24,:144,227,:145,165,:146,153,:147,119,:148,38,:149,184,:150,180,:151,124,:152,17,:153,68,:154,146,:155,217,:156,35,:157,32,:158,137,:159,46,:160,55,:161,63,:162,209,:163,91,:164,149,:165,188,:166,207,:167,205,:168,144,:169,135,:170,151,:171,178,:172,220,:173,252,:174,190,:175,97,:176,242,:177,86,:178,211,:179,171,:180,20,:181,42,:182,93,:183,158,:184,132,:185,60,:186,57,:187,83,:188,71,:189,109,:190,65,:191,162,:192,31,:193,45,:194,67,:195,216,:196,183,:197,123,:198,164,:199,118,:200,196,:201,23,:202,73,:203,236,:204,127,:205,12,:206,111,:207,246,:208,108,:209,161,:210,59,:211,82,:212,41,:213,157,:214,85,:215,170,:216,251,:217,96,:218,134,:219,177,:220,187,:221,204,:222,62,:223,90,:224,203,:225,89,:226,95,:227,176,:228,156,:229,169,:230,160,:231,81,:232,11,:233,245,:234,22,:235,235,:236,122,:237,117,:238,44,:239,215,:240,79,:241,174,:242,213,:243,233,:244,230,:245,231,:246,173,:247,232,:248,116,:249,214,:250,244,:251,234,:252,168,:253,80,:254,88,:255,175,:");
        }

        [Fact]
        [Category("QRGenerator/AlphanumDict")]
        public void validate_alphanumencdict()
        {
            var gen = new QRCodeGenerator();

            var checkString = string.Empty;
            var gField = gen.GetType().GetField("alphanumEncDict", BindingFlags.NonPublic | BindingFlags.Static);
            foreach (var listitem in (Dictionary<char, int>)gField.GetValue(gen))
            {
                checkString += $"{listitem.Key},{listitem.Value}:";
            }
            checkString.ShouldBe("0,0:1,1:2,2:3,3:4,4:5,5:6,6:7,7:8,8:9,9:A,10:B,11:C,12:D,13:E,14:F,15:G,16:H,17:I,18:J,19:K,20:L,21:M,22:N,23:O,24:P,25:Q,26:R,27:S,28:T,29:U,30:V,31:W,32:X,33:Y,34:Z,35: ,36:$,37:%,38:*,39:+,40:-,41:.,42:/,43::,44:");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_recognize_enconding_numeric()
        {
            var gen = new QRCodeGenerator();
            MethodInfo method = gen.GetType().GetMethod("GetEncodingFromPlaintext", BindingFlags.NonPublic | BindingFlags.Static);
            var result = (int)method.Invoke(gen, new object[] { "0123456789", false });

            result.ShouldBe(1);
        }


        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_recognize_enconding_alphanumeric()
        {
            var gen = new QRCodeGenerator();
            MethodInfo method = gen.GetType().GetMethod("GetEncodingFromPlaintext", BindingFlags.NonPublic | BindingFlags.Static);
            var result = (int)method.Invoke(gen, new object[] { "0123456789ABC", false });

            result.ShouldBe(2);
        }


        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_recognize_enconding_forced_bytemode()
        {
            var gen = new QRCodeGenerator();
            MethodInfo method = gen.GetType().GetMethod("GetEncodingFromPlaintext", BindingFlags.NonPublic | BindingFlags.Static);
            var result = (int)method.Invoke(gen, new object[] { "0123456789", true });

            result.ShouldBe(4);
        }


        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_recognize_enconding_byte()
        {
            var gen = new QRCodeGenerator();
            MethodInfo method = gen.GetType().GetMethod("GetEncodingFromPlaintext", BindingFlags.NonPublic | BindingFlags.Static);
            var result = (int)method.Invoke(gen, new object[] { "0123456789äöüß", false });

            result.ShouldBe(4);
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_encode_numeric()
        {
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode("123", QRCodeGenerator.ECCLevel.L);
            var result = string.Join("", qrData.ModuleMatrix.Select(x => x.ToBitString()).ToArray());
            result.ShouldBe("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111111011111011111110000000010000010010100100000100000000101110100110001011101000000001011101001110010111010000000010111010001010101110100000000100000100001101000001000000001111111010101011111110000000000000000111110000000000000000110110100110101000001000000001110110000001010101100000000000110111100001101110000000000101111010011000001111000000000011101111100010011010000000000000000111110010101100000000111111100010111110001000000001000001000011101110010000000010111010101110110110100000000101110101011100011100000000001011101001100010001110000000010000010101001101010100000000111111101101000001110000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_encode_numeric_2()
        {
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode("1234567", QRCodeGenerator.ECCLevel.L);
            var result = string.Join("", qrData.ModuleMatrix.Select(x => x.ToBitString()).ToArray());
            result.ShouldBe("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111111011111011111110000000010000010010100100000100000000101110100110001011101000000001011101001110010111010000000010111010001010101110100000000100000100001101000001000000001111111010101011111110000000000000000111110000000000000000110110100110101000001000000000100000000101010111100000000010110110100001101000000000000101110001101000001111000000001110111111000010010010000000000000000100110010011100000000111111100100111111101000000001000001000111101110110000000010111010110110110110100000000101110101101100011100000000001011101000100010011110000000010000010100001101010100000000111111101111000000110000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_encode_numeric_3()
        {
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode("12345678901", QRCodeGenerator.ECCLevel.L);
            var result = string.Join("", qrData.ModuleMatrix.Select(x => x.ToBitString()).ToArray());
            result.ShouldBe("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111111010111011111110000000010000010001100100000100000000101110101101001011101000000001011101011001010111010000000010111010100100101110100000000100000100111101000001000000001111111010101011111110000000000000000000110000000000000000111100101111110011101000000001110010101011110011110000000010011010000100000010000000000010010010111001110001000000000101101011001001000100000000000000000111100100100100000000111111100111100101101000000001000001001100001101010000000010111010001011111000100000000101110101011001011010000000001011101011001011011000000000010000010111001001101100000000111111101000010010010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_encode_alphanumeric()
        {
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode("123ABC", QRCodeGenerator.ECCLevel.L);
            var result = string.Join("", qrData.ModuleMatrix.Select(x => x.ToBitString()).ToArray());
            result.ShouldBe("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111111010111011111110000000010000010001100100000100000000101110101101001011101000000001011101011001010111010000000010111010100100101110100000000100000100111101000001000000001111111010101011111110000000000000000000110000000000000000111100101111110011101000000000111100010011110001110000000000100010100100000001000000000011110011111001110011000000001111101110101001000000000000000000000111100100100100000000111111100001100100110000000001000001000100001111110000000010111010010011111010100000000101110101111001011110000000001011101010101011000000000000010000010111001000010000000000111111101010010010010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_encode_byte_long()
        {
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode("https://github.com/codebude/QRCoder/blob/f89aa90081f369983a9ba114e49cc6ebf0b2a7b1/QRCoder/Framework4.0Methods/Stream4Methods.cs", QRCodeGenerator.ECCLevel.H);
            var result = string.Join("", qrData.ModuleMatrix.Select(x => x.ToBitString()).ToArray());
            result.ShouldBe("000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000011111110111011110110000101001110011101111011110001011011111110000000010000010111110111110001010010001100010100000011000011010000010000000010111010110010100110110000100110001010110100101010111010111010000000010111010000110010111011000101111110011010101000100101010111010000000010111010011010111000011000101111100001101111110001110010111010000000010000010110101101010101100011000100100100001011101100010000010000000011111110101010101010101010101010101010101010101010101011111110000000000000000111011011010010111001000100010111011010101000000000000000000000111010111110001111111100111111110110000111011110011111001110000000011111101111010101011111100011110101010001011000111000110100000000000000101111000110111101010010011011000010000110010110101000000110000000000000001111100010111100110100010100011010111100000001000100010000000000101010011011100110011111101000111110001100011111011011011110000000010010001110011110000101111001100100011001111110010010011010100000000001010011010001011011011010111011001110110000001001100101011110000000010110000111100111100010110011101110000001101111001000010110010000000010101010100011010111011110111010010100010100000110111111011010000000000110101111110101110100001101100010101110110010111000011010000000000001011111111001010110101000111001001011011000101011111101010110000000000010000000110100110010011100110100000100110111101001011110000000000010101110011111100011001000110101101111001011000011001001001100000000000100000101111001101001100001000010110010111000001000010010100000000010000011000010110111001110111011010010101000111011110100111110000000001100000100110001100100010101111011011100010110101000010000010000000000001111101011110111110100010100101010101111000010000000011110000000011010100010000111011000110000110001011000111110011010011100100000000010010011011110011110011001101110011001110001111110000000011010000000011101000110001100001110010010001011000000010101101110010110100000000010111111101100100010001000111111100111011101000010101111101000000000011001000110101111011001011001000101101011111100001101000100000000000010001010100000111101011101111010101010000000011110011010110110000000010111000100001011000010010011000100000100110101000011000100100000000000001111101111110100000010101111111100001001001110001111111100000000010111001011011001100001101010001000100111111100101011011000000000000000000011111101001100110000110100010001111001111101100111010110000000010101101101010110010011111101010000100100010000110001011010000000000010100011111001110010000010000111111110110001110111111011111010000000000001000000111110111001100111011011010100110100111011110010000000000000110111001011011100010111100000000010010011111010100110111110000000001110000110101101001100001001000111010011100110001111001100110000000001100011100110101100100101001010001100110101000111111101111000000000011101100100001000100011101010100111110101110010101001001010100000000011111110000111010111100001011011101000110100100101000101001010000000010111101100010010110000011101011011101101101101100001011000110000000010101111001111111101011010100000001000100101001010110110101000000000000011101100001001011001110010110111100101110010100000011001100000000010001111010011100000100100110111011011010111011010111110001110000000010000001111101010111111110001110110001011111101110000100000110000000000100010110000000101000111001011000011100011001011111011111110000000010110101101100011101011100001111101011111111000110010000011000000000000111111100010001000110100000001101111110101011011110011010110000000011101000111010011011110100001010110011111101010001001000000010000000011110011110100001110111110011111101110100001001111011111101110000000000000000100110000001011111101000100101001101100110001000110100000000011111110011101111000110110011010110001110011111101111010111110000000010000010010101100101110011001000111101111010111001011000100110000000010111010100001010110001101111111101101000111010111111111101000000000010111010101001111101101011110000100011100011110011011111101010000000010111010100101010001000010100001001101000100001110100010001010000000010000010001010111111111001100110111100101011111000010110000010000000011111110001011000110010001101010000101110110000110101000011110000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_encode_byte()
        {
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode("äöü", QRCodeGenerator.ECCLevel.L);
            var result = string.Join("", qrData.ModuleMatrix.Select(x => x.ToBitString()).ToArray());
            result.ShouldBe("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111111001011011111110000000010000010011100100000100000000101110101101101011101000000001011101001010010111010000000010111010001010101110100000000100000100000101000001000000001111111010101011111110000000000000000110110000000000000000111011111111011000100000000001001110001100010000010000000010011110001010001001000000000110011010000001000110000000001110001111001010110110000000000000000111101010011100000000111111101111011100110000000001000001010011101110010000000010111010110101110010100000000101110100110001000110000000001011101011001000100010000000010000010100000100011000000000111111101110101010111000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_encode_utf8()
        {
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode("https://en.wikipedia.org/wiki/🍕", QRCodeGenerator.ECCLevel.L, true, false, QRCodeGenerator.EciMode.Utf8);
            var result = string.Join("", qrData.ModuleMatrix.Select(x => x.ToBitString()).ToArray());
            result.ShouldBe("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000011111110101011010011101111111000000001000001001111100001110100000100000000101110101110000011000010111010000000010111010111010111100101011101000000001011101010011010111010101110100000000100000100011010001110010000010000000011111110101010101010101111111000000000000000000101000011100000000000000000111100101011110101011100111010000000001011000101011111010011101010000000001010011101111101001111011101000000000111011011110000010001100000100000000000000010011010101100000000000000000001100110101011011111001101110000000000000011100001010101010110101000000000000111001011100110111111110011000000001110101011001011001000100011000000000000101010100001010111111000000000000010111010101001111100000001110000000000010110100010111111100100010100000000011101111010011101111111101010000000000000000110000001000100010010000000001111111001100011001010101101000000000100000100111111111011000111000000000010111010010100011010111110111000000001011101010110100011100101011000000000101110101100101111100101111010000000010000010111011001111000001101000000001111111011110000100000110101000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_encode_utf8_bom()
        {
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode("https://en.wikipedia.org/wiki/🍕", QRCodeGenerator.ECCLevel.L, true, true, QRCodeGenerator.EciMode.Utf8);
            var result = string.Join("", qrData.ModuleMatrix.Select(x => x.ToBitString()).ToArray());
            result.ShouldBe("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000011111110010001101010101111111000000001000001011011000110000100000100000000101110100111010101111010111010000000010111010110100100010101011101000000001011101000101111000010101110100000000100000101010000111000010000010000000011111110101010101010101111111000000000000000000001010101110000000000000000111110111110101010100101010100000000000100000110000101000001100101000000000001001001011000011010000111100000000100010001111000001111110111010000000010110111010100011100100101111000000000001010001101101001000010100100000000100001101110011001010000001010000000001011001100011001111111010111000000000010001010101011110010100000100000000100100010000000000010110010000000000010110110010110000101010101100000000001001100100010010100111101101100000000101010110011000111101111100100000000000000000111011110011100011010000000001111111011100110010010101110000000000100000100100110010101000110110000000010111010110010111101111110011000000001011101010100000100010110100000000000101110101001100111110110111100000000010000010111100101111100100001000000001111111011110001110100111000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void can_generate_from_bytes()
        {
            byte[] test_data = { 49, 50, 51, 65, 66, 67 }; //123ABC
            var gen = new QRCodeGenerator();
            var qrData = gen.CreateQrCode(test_data, QRCodeGenerator.ECCLevel.L);
            var result = string.Join("", qrData.ModuleMatrix.Select(x => x.ToBitString()).ToArray());
            result.ShouldBe("0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001111111011001011111110000000010000010010010100000100000000101110101010101011101000000001011101010010010111010000000010111010111000101110100000000100000100000001000001000000001111111010101011111110000000000000000011000000000000000000111100101010010011101000000001011100001001001001110000000010101011111011111110100000000000101000000110000000000000001011001001010100110000000000000000000110001000101000000000111111100110011011110000000001000001001111110111010000000010111010011100100101100000000101110101110010010010000000001011101011010100011000000000010000010110110101000100000000111111101011100010000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000");
        }

        [Fact]
        [Category("QRGenerator/TextEncoding")]
        public void isValidIso_works()
        {
            Encoding _iso88591ExceptionFallback = Encoding.GetEncoding("ISO-8859-1", new EncoderExceptionFallback(), new DecoderExceptionFallback());

            IsValidISO("abc").ShouldBeTrue();
            IsValidISO("äöü").ShouldBeTrue();
            IsValidISO("🍕").ShouldBeFalse();

            bool IsValidISO(string input)
            {
                try
                {
                    _ = _iso88591ExceptionFallback.GetByteCount(input);
                    return true;
                }
                catch (EncoderFallbackException)
                {
                    return false;
                }
            }
        }
    }

    public static class ExtensionMethods
    {
        public static string ToBitString(this BitArray bits)
        {
            var sb = new StringBuilder();
            int bitLength = bits.Length;
            for (int i = 0; i < bitLength; i++)
            {
                char c = bits[i] ? '1' : '0';
                sb.Append(c);
            }

            return sb.ToString();
        }
    }
}



