﻿using System;
using System.Globalization;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Aardvark.Base
{
    // AUTO GENERATED CODE - DO NOT CHANGE!

    //# var ColorNames
    //#    = new Dictionary<string, V3d>()
    //#    {
    //#        { "AliceBlue", new V3d(0.941176, 0.972549, 1.000000) },
    //#        { "AntiqueWhite", new V3d(0.980392, 0.921569, 0.843137) },
    //#        { "Aqua", new V3d(0.000000, 1.000000, 1.000000) },
    //#        { "Aquamarine", new V3d(0.498039, 1.000000, 0.831373) },
    //#        { "Azure", new V3d(0.941176, 1.000000, 1.000000) },
    //#        { "Beige", new V3d(0.960784, 0.960784, 0.862745) },
    //#        { "Bisque", new V3d(1.000000, 0.894118, 0.768627) },
    //#        { "Black", new V3d(0.000000, 0.000000, 0.000000) },
    //#        { "BlanchedAlmond", new V3d(1.000000, 0.921569, 0.803922) },
    //#        { "Blue", new V3d(0.000000, 0.000000, 1.000000) },
    //#        { "BlueViolet", new V3d(0.541176, 0.168627, 0.886275) },
    //#        { "Brown", new V3d(0.647059, 0.164706, 0.164706) },
    //#        { "BurlyWood", new V3d(0.870588, 0.721569, 0.529412) },
    //#        { "CadetBlue", new V3d(0.372549, 0.619608, 0.627451) },
    //#        { "Chartreuse", new V3d(0.498039, 1.000000, 0.000000) },
    //#        { "Chocolate", new V3d(0.823529, 0.411765, 0.117647) },
    //#        { "Coral", new V3d(1.000000, 0.498039, 0.313725) },
    //#        { "CornflowerBlue", new V3d(0.392157, 0.584314, 0.929412) },
    //#        { "Cornsilk", new V3d(1.000000, 0.972549, 0.862745) },
    //#        { "Crimson", new V3d(0.862745, 0.078431, 0.235294) },
    //#        { "Cyan", new V3d(0.000000, 1.000000, 1.000000) },
    //#        { "DarkBlue", new V3d(0.000000, 0.000000, 0.545098) },
    //#        { "DarkCyan", new V3d(0.000000, 0.545098, 0.545098) },
    //#        { "DarkGoldenRod", new V3d(0.721569, 0.525490, 0.043137) },
    //#        { "DarkGray", new V3d(0.662745, 0.662745, 0.662745) },
    //#        { "DarkGrey", new V3d(0.662745, 0.662745, 0.662745) },
    //#        { "DarkGreen", new V3d(0.000000, 0.392157, 0.000000) },
    //#        { "DarkKhaki", new V3d(0.741176, 0.717647, 0.419608) },
    //#        { "DarkMagenta", new V3d(0.545098, 0.000000, 0.545098) },
    //#        { "DarkOliveGreen", new V3d(0.333333, 0.419608, 0.184314) },
    //#        { "DarkOrange", new V3d(1.000000, 0.549020, 0.000000) },
    //#        { "DarkOrchid", new V3d(0.600000, 0.196078, 0.800000) },
    //#        { "DarkRed", new V3d(0.545098, 0.000000, 0.000000) },
    //#        { "DarkSalmon", new V3d(0.913725, 0.588235, 0.478431) },
    //#        { "DarkSeaGreen", new V3d(0.560784, 0.737255, 0.560784) },
    //#        { "DarkSlateBlue", new V3d(0.282353, 0.239216, 0.545098) },
    //#        { "DarkSlateGray", new V3d(0.184314, 0.309804, 0.309804) },
    //#        { "DarkSlateGrey", new V3d(0.184314, 0.309804, 0.309804) },
    //#        { "DarkTurquoise", new V3d(0.000000, 0.807843, 0.819608) },
    //#        { "DarkViolet", new V3d(0.580392, 0.000000, 0.827451) },
    //#        { "DeepPink", new V3d(1.000000, 0.078431, 0.576471) },
    //#        { "DeepSkyBlue", new V3d(0.000000, 0.749020, 1.000000) },
    //#        { "DimGray", new V3d(0.411765, 0.411765, 0.411765) },
    //#        { "DimGrey", new V3d(0.411765, 0.411765, 0.411765) },
    //#        { "DodgerBlue", new V3d(0.117647, 0.564706, 1.000000) },
    //#        { "FireBrick", new V3d(0.698039, 0.133333, 0.133333) },
    //#        { "FloralWhite", new V3d(1.000000, 0.980392, 0.941176) },
    //#        { "ForestGreen", new V3d(0.133333, 0.545098, 0.133333) },
    //#        { "Fuchsia", new V3d(1.000000, 0.000000, 1.000000) },
    //#        { "Gainsboro", new V3d(0.862745, 0.862745, 0.862745) },
    //#        { "GhostWhite", new V3d(0.972549, 0.972549, 1.000000) },
    //#        { "Gold", new V3d(1.000000, 0.843137, 0.000000) },
    //#        { "GoldenRod", new V3d(0.854902, 0.647059, 0.125490) },
    //#        { "Gray", new V3d(0.501961, 0.501961, 0.501961) },
    //#        { "Grey", new V3d(0.501961, 0.501961, 0.501961) },
    //#        { "Green", new V3d(0.000000, 0.501961, 0.000000) },
    //#        { "GreenYellow", new V3d(0.678431, 1.000000, 0.184314) },
    //#        { "HoneyDew", new V3d(0.941176, 1.000000, 0.941176) },
    //#        { "HotPink", new V3d(1.000000, 0.411765, 0.705882) },
    //#        { "IndianRed ", new V3d(0.803922, 0.360784, 0.360784) },
    //#        { "Indigo ", new V3d(0.294118, 0.000000, 0.509804) },
    //#        { "Ivory", new V3d(1.000000, 1.000000, 0.941176) },
    //#        { "Khaki", new V3d(0.941176, 0.901961, 0.549020) },
    //#        { "Lavender", new V3d(0.901961, 0.901961, 0.980392) },
    //#        { "LavenderBlush", new V3d(1.000000, 0.941176, 0.960784) },
    //#        { "LawnGreen", new V3d(0.486275, 0.988235, 0.000000) },
    //#        { "LemonChiffon", new V3d(1.000000, 0.980392, 0.803922) },
    //#        { "LightBlue", new V3d(0.678431, 0.847059, 0.901961) },
    //#        { "LightCoral", new V3d(0.941176, 0.501961, 0.501961) },
    //#        { "LightCyan", new V3d(0.878431, 1.000000, 1.000000) },
    //#        { "LightGoldenRodYellow", new V3d(0.980392, 0.980392, 0.823529) },
    //#        { "LightGray", new V3d(0.827451, 0.827451, 0.827451) },
    //#        { "LightGrey", new V3d(0.827451, 0.827451, 0.827451) },
    //#        { "LightGreen", new V3d(0.564706, 0.933333, 0.564706) },
    //#        { "LightPink", new V3d(1.000000, 0.713725, 0.756863) },
    //#        { "LightSalmon", new V3d(1.000000, 0.627451, 0.478431) },
    //#        { "LightSeaGreen", new V3d(0.125490, 0.698039, 0.666667) },
    //#        { "LightSkyBlue", new V3d(0.529412, 0.807843, 0.980392) },
    //#        { "LightSlateGray", new V3d(0.466667, 0.533333, 0.600000) },
    //#        { "LightSlateGrey", new V3d(0.466667, 0.533333, 0.600000) },
    //#        { "LightSteelBlue", new V3d(0.690196, 0.768627, 0.870588) },
    //#        { "LightYellow", new V3d(1.000000, 1.000000, 0.878431) },
    //#        { "Lime", new V3d(0.000000, 1.000000, 0.000000) },
    //#        { "LimeGreen", new V3d(0.196078, 0.803922, 0.196078) },
    //#        { "Linen", new V3d(0.980392, 0.941176, 0.901961) },
    //#        { "Magenta", new V3d(1.000000, 0.000000, 1.000000) },
    //#        { "Maroon", new V3d(0.501961, 0.000000, 0.000000) },
    //#        { "MediumAquaMarine", new V3d(0.400000, 0.803922, 0.666667) },
    //#        { "MediumBlue", new V3d(0.000000, 0.000000, 0.803922) },
    //#        { "MediumOrchid", new V3d(0.729412, 0.333333, 0.827451) },
    //#        { "MediumPurple", new V3d(0.576471, 0.439216, 0.847059) },
    //#        { "MediumSeaGreen", new V3d(0.235294, 0.701961, 0.443137) },
    //#        { "MediumSlateBlue", new V3d(0.482353, 0.407843, 0.933333) },
    //#        { "MediumSpringGreen", new V3d(0.000000, 0.980392, 0.603922) },
    //#        { "MediumTurquoise", new V3d(0.282353, 0.819608, 0.800000) },
    //#        { "MediumVioletRed", new V3d(0.780392, 0.082353, 0.521569) },
    //#        { "MidnightBlue", new V3d(0.098039, 0.098039, 0.439216) },
    //#        { "MintCream", new V3d(0.960784, 1.000000, 0.980392) },
    //#        { "MistyRose", new V3d(1.000000, 0.894118, 0.882353) },
    //#        { "Moccasin", new V3d(1.000000, 0.894118, 0.709804) },
    //#        { "NavajoWhite", new V3d(1.000000, 0.870588, 0.678431) },
    //#        { "Navy", new V3d(0.000000, 0.000000, 0.501961) },
    //#        { "OldLace", new V3d(0.992157, 0.960784, 0.901961) },
    //#        { "Olive", new V3d(0.501961, 0.501961, 0.000000) },
    //#        { "OliveDrab", new V3d(0.419608, 0.556863, 0.137255) },
    //#        { "Orange", new V3d(1.000000, 0.647059, 0.000000) },
    //#        { "OrangeRed", new V3d(1.000000, 0.270588, 0.000000) },
    //#        { "Orchid", new V3d(0.854902, 0.439216, 0.839216) },
    //#        { "PaleGoldenRod", new V3d(0.933333, 0.909804, 0.666667) },
    //#        { "PaleGreen", new V3d(0.596078, 0.984314, 0.596078) },
    //#        { "PaleTurquoise", new V3d(0.686275, 0.933333, 0.933333) },
    //#        { "PaleVioletRed", new V3d(0.847059, 0.439216, 0.576471) },
    //#        { "PapayaWhip", new V3d(1.000000, 0.937255, 0.835294) },
    //#        { "PeachPuff", new V3d(1.000000, 0.854902, 0.725490) },
    //#        { "Peru", new V3d(0.803922, 0.521569, 0.247059) },
    //#        { "Pink", new V3d(1.000000, 0.752941, 0.796078) },
    //#        { "Plum", new V3d(0.866667, 0.627451, 0.866667) },
    //#        { "PowderBlue", new V3d(0.690196, 0.878431, 0.901961) },
    //#        { "Purple", new V3d(0.501961, 0.000000, 0.501961) },
    //#        { "Red", new V3d(1.000000, 0.000000, 0.000000) },
    //#        { "RosyBrown", new V3d(0.737255, 0.560784, 0.560784) },
    //#        { "RoyalBlue", new V3d(0.254902, 0.411765, 0.882353) },
    //#        { "SaddleBrown", new V3d(0.545098, 0.270588, 0.074510) },
    //#        { "Salmon", new V3d(0.980392, 0.501961, 0.447059) },
    //#        { "SandyBrown", new V3d(0.956863, 0.643137, 0.376471) },
    //#        { "SeaGreen", new V3d(0.180392, 0.545098, 0.341176) },
    //#        { "SeaShell", new V3d(1.000000, 0.960784, 0.933333) },
    //#        { "Sienna", new V3d(0.627451, 0.321569, 0.176471) },
    //#        { "Silver", new V3d(0.752941, 0.752941, 0.752941) },
    //#        { "SkyBlue", new V3d(0.529412, 0.807843, 0.921569) },
    //#        { "SlateBlue", new V3d(0.415686, 0.352941, 0.803922) },
    //#        { "SlateGray", new V3d(0.439216, 0.501961, 0.564706) },
    //#        { "SlateGrey", new V3d(0.439216, 0.501961, 0.564706) },
    //#        { "Snow", new V3d(1.000000, 0.980392, 0.980392) },
    //#        { "SpringGreen", new V3d(0.000000, 1.000000, 0.498039) },
    //#        { "SteelBlue", new V3d(0.274510, 0.509804, 0.705882) },
    //#        { "Tan", new V3d(0.823529, 0.705882, 0.549020) },
    //#        { "Teal", new V3d(0.000000, 0.501961, 0.501961) },
    //#        { "Thistle", new V3d(0.847059, 0.749020, 0.847059) },
    //#        { "Tomato", new V3d(1.000000, 0.388235, 0.278431) },
    //#        { "Turquoise", new V3d(0.250980, 0.878431, 0.815686) },
    //#        { "Violet", new V3d(0.933333, 0.509804, 0.933333) },
    //#        { "Wheat", new V3d(0.960784, 0.870588, 0.701961) },
    //#        { "White", new V3d(1.000000, 1.000000, 1.000000) },
    //#        { "WhiteSmoke", new V3d(0.960784, 0.960784, 0.960784) },
    //#        { "Yellow", new V3d(1.000000, 1.000000, 0.000000) },
    //#        { "YellowGreen", new V3d(0.603922, 0.803922, 0.196078) },
    //#    };
    //#
    //# Action andand = () => Out(" && ");
    //# Action add = () => Out(" + ");
    //# Action addbetween = () => Out(" + between ");
    //# Action addqcommaspace = () => Out(" + \", \" ");
    //# Action comma = () => Out(", ");
    //# Action oror = () => Out(" || ");
    //# Action semicolon = () => Out("; ");
    //# Action xor = () => Out(" ^ ");
    //# var dtoftmap = new Dictionary<Meta.SimpleType, string>
    //#     {
    //#         { Meta.ByteType, "Col.ByteFromDoubleClamped" },
    //#         { Meta.UShortType, "Col.UShortFromDoubleClamped" },
    //#         { Meta.UIntType, "Col.UIntFromDoubleClamped" },
    //#         { Meta.FloatType, "(float)" },
    //#         { Meta.DoubleType, "" },
    //#     };
    //# var fttodmap = new Dictionary<Meta.SimpleType, string>
    //#     {
    //#         { Meta.ByteType, "Col.DoubleFromByte" },
    //#         { Meta.UShortType, "Col.DoubleFromUShort" },
    //#         { Meta.UIntType, "Col.DoubleFromUInt" },
    //#         { Meta.FloatType, "(double)" },
    //#         { Meta.DoubleType, "" },
    //#     };
    //# var btoftmap = new Dictionary<Meta.SimpleType, string>
    //#     {
    //#         { Meta.ByteType, "" },
    //#         { Meta.UShortType, "Col.UShortFromByte" },
    //#         { Meta.UIntType, "Col.UIntFromByte" },
    //#         { Meta.FloatType, "Col.FloatFromByte" },
    //#         { Meta.DoubleType, "Col.DoubleFromByte" },
    //#     };
    //# var fttobmap = new Dictionary<Meta.SimpleType, string>
    //#     {
    //#         { Meta.ByteType, "" },
    //#         { Meta.UShortType, "Col.ByteFromUShort" },
    //#         { Meta.UIntType, "Col.ByteFromUInt" },
    //#         { Meta.FloatType, "Col.ByteFromFloatClamped" },
    //#         { Meta.DoubleType, "Col.ByteFromDoubleClamped" },
    //#     };
    //# var vftmap = new Dictionary<Meta.SimpleType, Meta.SimpleType[]>
    //#     {
    //#         { Meta.ByteType, new[] { Meta.IntType, Meta.LongType } },
    //#         { Meta.UShortType, new[] { Meta.IntType, Meta.LongType } },
    //#         { Meta.UIntType, new[] { Meta.LongType } },
    //#         { Meta.FloatType, new[] { Meta.FloatType, Meta.DoubleType } },
    //#         { Meta.DoubleType, new[] { Meta.DoubleType } },
    //#     };
    //# var fdtypes = new[] { Meta.FloatType, Meta.DoubleType };
    //# foreach (var t in Meta.ColorTypes) {
    //#     var type = t.Name;
    //#     var ft = t.FieldType;
    //#     var ht = Meta.HighPrecisionTypeOf(ft);
    //#     var htype = ht.Name;
    //#     var hnd = ht != Meta.DoubleType; // high not double
    //#     var dblt = Meta.ColorTypeOf(t.Len, Meta.DoubleType);
    //#     var dbltype = dblt.Name;
    //#     var fltt = Meta.ColorTypeOf(t.Len, Meta.FloatType);
    //#     var flttype = fltt.Name;
    //#     var isByte = ft == Meta.ByteType;
    //#     var isUShort = ft == Meta.UShortType;
    //#     var isFloat = ft == Meta.FloatType;
    //#     var isDouble = ft == Meta.DoubleType;
    //#     var isReal = ft.IsReal;
    //#     var ftype = ft.Name;
    //#     var fcaps = ft.Caps;
    //#     var fields = t.Fields;
    //#     var channels = t.Channels;
    //#     var args = fields.ToLower();
    //#     var cargs = channels.ToLower();
    //#     var d_to_ft = dtoftmap[ft];
    //#     var ft_to_d = fttodmap[ft];
    //#     var b_to_ft = btoftmap[ft];
    //#     var ft_to_b = fttobmap[ft];
    //#     var fabs_p = isReal ? "Fun.Abs(" : "";
    //#     var q_fabs = isReal ? ")" : "";
    #region __type__

    [Serializable]
    public partial struct __type__ : IFormattable, IEquatable<__type__>, IRGB/*# if (t.HasAlpha) { */, IOpacity/*# } */
    {
        #region Constructors

        public __type__(/*# args.ForEach(a => { */__ftype__ __a__/*# }, comma); */)
        {
            /*# fields.ForEach(args, (f,a) => { */__f__ = __a__/*# }, semicolon); */;
        }

        public __type__(/*# args.ForEach(a => { */int __a__/*# }, comma); */)
        {
            /*# fields.ForEach(args, (f,a) => { */__f__ = (__ftype__)__a__/*# }, semicolon); */;
        }

        public __type__(/*# args.ForEach(a => { */long __a__/*# }, comma); */)
        {
            /*# fields.ForEach(args, (f,a) => { */__f__ = (__ftype__)__a__/*# }, semicolon); */;
        }

        //# if (!isDouble) {
        public __type__(/*# args.ForEach(a => { */double __a__/*# }, comma); */)
        {
            //# fields.ForEach(args, (f,a) => {
            __f__ = __d_to_ft__(__a__);
            //# });
        }

        //# } // !isDouble
        //# if (t.HasAlpha) {
        public __type__(/*# cargs.ForEach(a => { */__ftype__ __a__/*# }, comma); */)
        {
            /*# channels.ForEach(args,
                    (c, a) => { */__c__ = __a__/*# }, semicolon); */;
            A = __t.MaxValue__;
        }

        public __type__(/*# cargs.ForEach(a => { */int __a__/*# }, comma); */)
        {
            /*# channels.ForEach(args,
                    (c, a) => { */__c__ = (__ftype__)__a__/*# }, semicolon); */;
            A = __t.MaxValue__;
        }

        public __type__(/*# cargs.ForEach(a => { */long __a__/*# }, comma); */)
        {
            /*# channels.ForEach(args,
                    (c, a) => { */__c__ = (__ftype__)__a__/*# }, semicolon); */;
            A = __t.MaxValue__;
        }

        //# if (!isDouble) {
        public __type__(/*# cargs.ForEach(a => { */double __a__/*# }, comma); */)
        {
            /*# channels.ForEach(args,
                    (c,a) => { */__c__ = __d_to_ft__(__a__)/*# }, semicolon); */;
            A = __t.MaxValue__;
        }

        //# } // !isDouble
        //# } // t.HasAlpha
        public __type__(__ftype__ gray)
        {
            /*# channels.ForEach(
                    c => { */__c__ = gray/*# },
                    semicolon); if (t.HasAlpha) {*/; A = __t.MaxValue__/*# } */;
        }

        //# if (!isDouble) {
        public __type__(double gray)
        {
            var value = __d_to_ft__(gray);
            /*# channels.ForEach(
                    c => { */__c__ = value/*# },
                    semicolon); if (t.HasAlpha) {*/; A = __t.MaxValue__/*# } */;
        }

        //# } // !isDouble
        //# foreach (var t1 in Meta.ColorTypes) {
        //#     var convert = t.FieldType != t1.FieldType
        //#         ? "Col." + t.FieldType.Caps + "From" + t1.FieldType.Caps
        //#         : "";
        public __type__(__t1.Name__ color)
        {
            //# channels.ForEach(c => {
            __c__ = __convert__(color.__c__);
            //# });
            //# if (t.HasAlpha) {
            //#     if (t1.HasAlpha) {
            A = __convert__(color.A);
            //#     } else {
            A = __t.MaxValue__;
            //#     }
            //# }
        }

        //#if (t.HasAlpha && !t1.HasAlpha) { // build constructor from Color3 with explicit alpha
        public __type__(__t1.Name__ color, __ftype__ alpha)
        {
            //# channels.ForEach(Meta.VecFields, (c, vf) => {
            __c__ = __convert__(color.__c__);
            //# });
            A = alpha;
        }

        //# }
        //# } // end For
        //# var vecTypes = new List<Meta.VecType>();
        //# var vecFieldTypes = vftmap[ft];
        //# for (int d = 3; d < 5; d++) {
        //#     foreach (var vft in vecFieldTypes) {
        //#         var vt = Meta.VecTypeOf(d, vft);
        //#         vecTypes.Add(vt);
        //#         var convert = ft != vft ? "("+ ft.Name+")" : "";
        public __type__(__vt.Name__ vec)
        {
            //# channels.ForEach(Meta.VecFields, (c, vf) => {
            __c__ = __convert__(vec.__vf__);
            //# });
            //# if (t.HasAlpha) {
            //#     if (d == 4) {
            A = __convert__(vec.W);
            //#     } else {
            A = __t.MaxValue__;
            //#     }
            //# }
        }

        //#if (t.HasAlpha && d == 3) { // build constructor from Vec3 with explicit alpha
        public __type__(__vt.Name__ vec, __ftype__ alpha)
        {
            //# channels.ForEach(Meta.VecFields, (c, vf) => {
            __c__ = __convert__(vec.__vf__);
            //# });
            A = alpha;
        }

        //#         }
        //#     }
        //# }
        #endregion

        #region Conversions

        //# foreach (var t1 in Meta.ColorTypes) if (t1 != t) {
        //#     var type1 = t1.Name;
        public static explicit operator __type1__(__type__ color)
        {
            return new __type1__(color);
        }

        //# }
        //# for (int d = 3; d < 5; d++) {
        //#     foreach (var vft in vecFieldTypes) {
        //#         var vt = Meta.VecTypeOf(d, vft);
        //#         var convert = ft != vft ? "("+ vft.Name+")" : "";
        public static explicit operator __vt.Name__(__type__ color)
        {
            return new __vt.Name__(/*# channels.ForEach(c => { */
                __convert__(color.__c__)/*# }, comma);
                if (d == 4) {
                    if (t.HasAlpha) { */,
                __convert__(color.A)/*#
                    } else { */,
                __convert__(__t.MaxValue__)/*#
                    }
                } */
                );
        }

        //#     }
        //# }
        //# foreach (var t1 in Meta.ColorTypes) if (t1 != t) {
        //#     var type1 = t1.Name;
        public __type1__ To__type1__() { return (__type1__)this; }
        //# }

        /// <summary>
        /// Creates a color from the results of the supplied function of the index.
        /// </summary>
        public __type__(Func<int, __ftype__> index_fun)
        {
            //# fields.ForEach((f, fi) => {
            __f__ = index_fun(__fi__);
            //# });
        }

        //# foreach (var t1 in vecTypes) {
        //#     var type1 = t1.Name;
        public __type1__ To__type1__() { return (__type1__)this; }
        //# }

        //# foreach (var t1 in Meta.ColorTypes) if (t1 != t) {
        //#     var type1 = t1.Name;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__type1__(__type1__ c)
            => new __type__(c);
        //# }

        //# foreach (var t1 in vecTypes) {
        //#     var type1 = t1.Name;
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ From__type1__(__type1__ c)
            => new __type__(c);
        //# }

        //# foreach (var t1 in Meta.ColorTypes) {
        //#     if (t.Fields.Length != t1.Fields.Length) continue;
        //#     var type1 = t1.Name;
        //#     var ftype1 = t1.FieldType.Name;
        /// <summary>
        /// Returns a copy with all elements transformed by the supplied function.
        /// </summary>
        [Obsolete("Use 'Map' instead (same functionality and parameters)", false)]
        public __type1__ Copy(Func<__ftype__, __ftype1__> channel_fun)
        {
            return Map(channel_fun);
        }

        /// <summary>
        /// Returns a copy with all elements transformed by the supplied function.
        /// </summary>
        public __type1__ Map(Func<__ftype__, __ftype1__> channel_fun)
        {
            return new __type1__(/*# fields.ForEach(f => { */channel_fun(__f__)/*# }, comma); */);
        }

        //# }
        public void CopyTo<T>(T[] array, int start, Func<__ftype__, T> element_fun)
        {
            //# fields.ForEach((f, i) => {
            array[start + __i__] = element_fun(__f__);
            //# });
        }

        public void CopyTo<T>(T[] array, int start, Func<__ftype__, int, T> element_index_fun)
        {
            //# fields.ForEach((f, i) => {
            array[start + __i__] = element_index_fun(__f__, __i__);
            //# });
        }

        #endregion

        #region Indexer
        /// <summary>
        /// Indexer in canonical order 0=R, 1=G, 2=B, 3=A (availability depending on color type).
        /// </summary>
        public __ftype__ this[int i]
        {
            set
            {
                switch (i)
                {/*#
                    fields.ForEach((f,i) => {*/
                    case __i__:
                        __f__ = value;
                        break;/*# }); */
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            get
            {
                switch (i)
                {/*#
                    fields.ForEach((f,i) => {*/
                    case __i__:
                        return __f__;/*# }); */
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }
        #endregion

        #region Constants

        /// <summary>
        /// __type__ with all components zero.
        /// </summary>
        public static __type__ Zero => new __type__(/*# fields.ForEach(f => {*/__t.MinValue__/*#}, comma); */);

        // Web colors
        //# foreach(KeyValuePair<string, V3d> entry in ColorNames) {
        //# var name = entry.Key;
        //# var color = new C3d(entry.Value);
        public static __type__ __name__ => new __type__(__d_to_ft__(__color.R__), __d_to_ft__(__color.G__), __d_to_ft__(__color.B__));
        //# }

        public static __type__ DarkYellow => Olive;

        public static __type__ VRVisGreen => new __type__(__d_to_ft__(0.698), __d_to_ft__(0.851), __d_to_ft__(0.008));

        //# for (int i = 1; i < 10; i++) {
        //# var val = 0.1 * i; int percent = 10 * i;
        public static __type__ Gray__percent__ => new __type__(__d_to_ft__(__val__));
        //# }

        #endregion

        #region Comparison Operators

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator ==(__type__ a, __type__ b)
        {
            return /*# fields.ForEach(f => { */a.__f__ == b.__f__/*# }, andand); */;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool operator !=(__type__ a, __type__ b)
        {
            return /*# fields.ForEach(f => { */a.__f__ != b.__f__/*# }, oror); */;
        }

        #endregion

        #region Color Arithmetic

        public static __type__ operator *(__type__ col, double scalar)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(col.__f__ * scalar)/*# }, comma); */);
        }

        public static __type__ operator *(double scalar, __type__ col)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(scalar * col.__f__)/*# }, comma); */);
        }

        public static __type__ operator /(__type__ col, double scalar)
        {
            double f = 1.0 / scalar;
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(col.__f__ * f)/*# }, comma); */);
        }

        //# foreach (var t1 in Meta.ColorTypes) { if (t1.HasAlpha != t.HasAlpha) continue;
        //#
        //#     var type1 = t1.Name; var ft1 = t1.FieldType;
        //#     var ft1_from_ft = t1 != t
        //#         ? (ft.IsReal && ft1.IsReal ? "(" + ftype + ")" : "Col." + ft.Caps + "From" + ft1.Caps)
        //#         : "";
        public static __type__ operator +(__type__ c0, __type1__ c1)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(c0.__f__ + __ft1_from_ft__(c1.__f__))/*# }, comma); */);
        }

        public static __type__ operator -(__type__ c0, __type1__ c1)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(c0.__f__ - __ft1_from_ft__(c1.__f__))/*# }, comma); */);
        }

        //# } // t1
        //# if (ft.IsReal) {
        public static __type__ operator *(__type__ c0, __type__ c1)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(c0.__f__ * c1.__f__)/*# }, comma); */);
        }

        public static __type__ operator /(__type__ c0, __type__ c1)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(c0.__f__ / c1.__f__)/*# }, comma); */);
        }

        public static __type__ operator +(__type__ col, double scalar)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(col.__f__ + scalar)/*# }, comma); */);
        }

        public static __type__ operator +(double scalar, __type__ col)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(scalar + col.__f__)/*# }, comma); */);
        }

        public static __type__ operator -(__type__ col, double scalar)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(col.__f__ - scalar)/*# }, comma); */);
        }

        public static __type__ operator -(double scalar, __type__ col)
        {
            return new __type__(/*# fields.ForEach(f => { */
                (__ftype__)(scalar - col.__f__)/*# }, comma); */);
        }

        //# } // ft.IsReal
        //# for (int d = 3; d < 5; d++) {
        //#     foreach (var vft in vecFieldTypes) {
        //#         var vt = Meta.VecTypeOf(d, vft);
        //#         var vfields = vt.Fields;
        //#         var convert = ft != vft ? "("+ vft.Name+")" : "";
        public static __vt.Name__ operator + (__vt.Name__ vec, __type__ color)
        {
            return new __vt.Name__(/*# vfields.ForEach(channels, (f, c) => { */
                vec.__f__ + __convert__(color.__c__)/*# }, comma);
                if (d == 4) {
                    if (t.HasAlpha) { */,
                vec.W + __convert__(color.A)/*#
                    } else { */,
                vec.W + __convert__(__t.MaxValue__)/*#
                    }
                } */
                );
        }

        public static __vt.Name__ operator -(__vt.Name__ vec, __type__ color)
        {
            return new __vt.Name__(/*# vfields.ForEach(channels, (f, c) => { */
                vec.__f__ - __convert__(color.__c__)/*# }, comma);
                if (d == 4) {
                    if (t.HasAlpha) { */,
                vec.W - __convert__(color.A)/*#
                    } else { */,
                vec.W - __convert__(__t.MaxValue__)/*#
                    }
                } */
                );
        }

        //#     }
        //# }
        /// <summary>
        /// Clamps the color channels to the given bounds.
        /// </summary>
        public void Clamp(__ftype__ min, __ftype__ max)
        {
            //# channels.ForEach(c => {
            __c__ = __c__.Clamp(min, max);
            //# });
        }

        /// <summary>
        /// Returns a copy with the color channels clamped to the given bounds.
        /// </summary>
        public __type__ Clamped(__ftype__ min, __ftype__ max)
        {
            return new __type__(/*# channels.ForEach(
                c => { */__c__.Clamp(min, max)/*# }, comma);
                if (t.HasAlpha) {*/, A/*# } */);
        }

        //# if (!isDouble) {
        /// <summary>
        /// Clamps the color channels to the given bounds.
        /// </summary>
        public void Clamp(double min, double max)
        {
            Clamp(__d_to_ft__(min), __d_to_ft__(max));
        }

        /// <summary>
        /// Returns a copy with the color channels clamped to the given bounds.
        /// </summary>
        public __type__ Clamped(double min, double max)
        {
            return Clamped(__d_to_ft__(min), __d_to_ft__(max));
        }

        //# } // !isDouble
        #endregion

        #region Norms

        /// <summary>
        /// Returns the Manhattan (or 1-) norm of the vector. This is
        /// calculated as |R| + |G| + |B|. /*# if (t.HasAlpha) { */The alpha channel is ignored./*# } */
        /// </summary>
        public __htype__ Norm1
        {
            get { return /*# channels.ForEach(c => { */(__htype__)__fabs_p____c____q_fabs__/*# }, add); */; }
        }

        /// <summary>
        /// Returns the Euclidean (or 2-) norm of the color. This is calculated
        /// as sqrt(R^2 + G^2 + B^2). /*# if (t.HasAlpha) { */The alpha channel is ignored./*# } */
        /// </summary>
        public double Norm2
        {
            get { return Fun.Sqrt(/*# channels.ForEach(c => { */(double)__c__ * (double)__c__/*# }, add); */); }
        }

        /// <summary>
        /// Returns the infinite (or maximum) norm of the color. This is
        /// calculated as max(|R|, |G|, |B|). /*# if (t.HasAlpha) { */The alpha channel is ignored./*# } */
        /// </summary>
        public __ftype__ NormMax
        {
            get { return Fun.Max(/*# channels.ForEach(c => { */__fabs_p____c____q_fabs__/*# }, comma); */); }
        }

        /// <summary>
        /// Returns the minimum norm of the color. This is calculated as
        /// min(|R|, |G|, |B|). /*# if (t.HasAlpha) { */The alpha channel is ignored./*# } */
        /// </summary>
        public __ftype__ NormMin
        {
            get { return Fun.Min(/*# channels.ForEach(c => { */__fabs_p____c____q_fabs__/*# }, comma); */); }
        }

        #endregion

        #region Overrides

        public override bool Equals(object other)
            => (other is __type__ o) ? Equals(o) : false;

        public override int GetHashCode()
        {
            return HashCode.GetCombined(/*# t.Fields.ForEach(f => { */__f__/*# }, comma); */);
        }

        public override string ToString()
        {
            return ToString(null, CultureInfo.InvariantCulture);
        }

        public Text ToText(int bracketLevel = 1)
        {
            return
                ((bracketLevel == 1 ? "[" : "")/*# fields.ForEach(f => {*/
                + __f__.ToString(null, CultureInfo.InvariantCulture) /*# }, addqcommaspace); */
                + (bracketLevel == 1 ? "]" : "")).ToText();
        }

        #endregion

        #region Static Methods

        /// <summary>
        /// Element setter action.
        /// </summary>
        public static readonly ActionRefValVal<__type__, int, __ftype__> Setter =
            (ref __type__ color, int i, __ftype__ value) =>
            {
                switch (i)
                {
                    //# fields.ForEach((f, i) => {
                    case __i__: color.__f__ = value; return;
                    //# });
                    default: throw new IndexOutOfRangeException();
                }
            };

        /// <summary>
        /// Returns the given color, with each element divided by <paramref name="x"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ DivideByInt(__type__ c, int x)
            => c / x;

        #endregion

        #region Parsing

        public static __type__ Parse(string s, IFormatProvider provider)
        {
            return Parse(s);
        }

        public static __type__ Parse(string s)
        {
            var x = s.NestedBracketSplitLevelOne().ToArray();
            return new __type__(/*# t.Len.ForEach(p => { */
                __ftype__.Parse(x[__p__], CultureInfo.InvariantCulture)/*# }, comma); */
            );
        }

        public static __type__ Parse(Text t, int bracketLevel = 1)
        {
            return t.NestedBracketSplit(bracketLevel, Text<__ftype__>.Parse, __type__.Setter);
        }

        public static __type__ Parse(Text t)
        {
            return t.NestedBracketSplit(1, Text<__ftype__>.Parse, __type__.Setter);
        }

        #endregion

        #region IFormattable Members

        public string ToString(string format)
        {
            return ToString(format, CultureInfo.InvariantCulture);
        }

        public string ToString(string format, IFormatProvider fp)
        {
            return ToString(format, fp, "[", ", ", "]");
        }

        /// <summary>
        /// Outputs e.g. a 3D-Vector in the form "(begin)x(between)y(between)z(end)".
        /// </summary>
        public string ToString(string format, IFormatProvider fp, string begin, string between, string end)
        {
            if (fp == null) fp = CultureInfo.InvariantCulture;
            return begin /*# fields.ForEach(f => {*/+ __f__.ToString(format, fp) /*# }, addbetween); */ + end;
        }

        #endregion

        #region IEquatable<__type__> Members

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(__type__ other)
        {
            return /*# fields.ForEach(f => { */__f__.Equals(other.__f__)/*# }, andand); */;
        }

        #endregion

        #region IRGB Members

        double IRGB.Red
        {
            get { return __ft_to_d__(R); }
            set { R = __d_to_ft__(value); }
        }

        double IRGB.Green
        {
            get { return __ft_to_d__(G); }
            set { G = __d_to_ft__(value); }
        }

        double IRGB.Blue
        {
            get { return __ft_to_d__(B); }
            set { B = __d_to_ft__(value); }
        }

        #endregion

        //# if (t.HasAlpha) {
        #region IOpacity Members

        public double Opacity
        {
            get { return __ft_to_d__(A); }
            set { A = __d_to_ft__(value); }
        }

        #endregion

        //# }
    }

    public static partial class Fun
    {
        #region Interpolation

        //# if (!fdtypes.Contains(ft)) {
        //# fdtypes.ForEach(rt => {
        /// <summary>
        /// Returns the linearly interpolated color between a and b.
        /// </summary>
        public static __type__ Lerp(this __rt.Name__ x, __type__ a, __type__ b)
        {
            return new __type__(/*# fields.ForEach(f => {*/Lerp(x, a.__f__, b.__f__)/*#}, comma); */);
        }

        //# });
        //# } else {
        /// <summary>
        /// Returns the linearly interpolated color between a and b.
        /// </summary>
        public static __type__ Lerp(this __ftype__ x, __type__ a, __type__ b)
        {
            return new __type__(/*# fields.ForEach(f => {*/Lerp(x, a.__f__, b.__f__)/*#}, comma); */);
        }
        //# }
        #endregion

        #region ApproximateEquals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this __type__ a, __type__ b)
        {
            return ApproximateEquals(a, b, Constant<__ftype__>.PositiveTinyValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this __type__ a, __type__ b, __ftype__ tolerance)
        {
            return /*# fields.ForEach(f => {*/ApproximateEquals(a.__f__, b.__f__, tolerance)/*# }, andand);*/;
        }

        #endregion
    }

    public static partial class Col
    {
        #region Comparisons

        //# var bops = new[,] { { "<",  "Smaller"        }, { ">" , "Greater"},
        //#                     { "<=", "SmallerOrEqual" }, { ">=", "GreaterOrEqual"},
        //#                     { "==", "Equal" },          { "!=", "Different" } };
        //# var attention = "ATTENTION: For example (AllSmaller(a,b)) is not the same as !(AllGreaterOrEqual(a,b)) but !(AnyGreaterOrEqual(a,b)).";
        //# for(int o = 0; o < bops.GetLength(0); o++) {
        //#     string bop = " " + bops[o,0] + " ", opName = bops[o,1];
        /// <summary>
        /// Returns whether ALL elements of a are __opName__ the corresponding element of b.
        /// __attention__
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All__opName__(this __type__ a, __type__ b)
        {
            return (/*# fields.ForEach(f => { */a.__f____bop__b.__f__/*# }, andand); */);
        }

        /// <summary>
        /// Returns whether ALL elements of col are __opName__ s.
        /// __attention__
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All__opName__(this __type__ col, __ftype__ s)
        {
            return (/*# fields.ForEach(f => { */col.__f____bop__s/*# }, andand); */);
        }

        /// <summary>
        /// Returns whether a is __opName__ ALL elements of col.
        /// __attention__
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool All__opName__(__ftype__ s, __type__ col)
        {
            return (/*# fields.ForEach(f => { */s__bop__col.__f__/*# }, andand); */);
        }

        /// <summary>
        /// Returns whether AT LEAST ONE element of a is __opName__ the corresponding element of b.
        /// __attention__
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any__opName__(this __type__ a, __type__ b)
        {
            return (/*# fields.ForEach(f => { */a.__f____bop__b.__f__/*# }, oror); */);
        }

        /// <summary>
        /// Returns whether AT LEAST ONE element of col is __opName__ s.
        /// __attention__
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any__opName__(this __type__ col, __ftype__ s)
        {
            return (/*# fields.ForEach(f => { */col.__f____bop__s/*# }, oror); */);
        }

        /// <summary>
        /// Returns whether a is __opName__ AT LEAST ONE element of col.
        /// __attention__
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool Any__opName__(__ftype__ s, __type__ col)
        {
            return (/*# fields.ForEach(f => { */s__bop__col.__f__/*# }, oror); */);
        }
        //# }

        #endregion

        #region Linear Combination

        //# for (int tpc = 4; tpc < 7; tpc+=2) {
        //# foreach (var rt in new[] { fltt, dblt }) { var rtype = rt.Name; var wtype = rt.FieldType.Name; var rtc = rt.FieldType.Caps[0];
        //#     var convert = ft.IsReal ? ""
        //#        : "Col." + ft.Caps + "From" + ft.Caps + "In"
        //#          + (ft.Name == "uint" ? "Double" : rt.FieldType.Caps) + "Clamped";
        /// <summary>
        /// A function that returns the linear combination fo the supplied parameters
        /// with the referenced weight tuple.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ LinCom(
            /*# tpc.ForEach(i => { */__type__ p__i__/*# }, comma); */, ref Tup__tpc__<__wtype__> w)
        {
            return new __type__(/*# channels.ForEach(ch => { */
                __convert__(/*# tpc.ForEach(i => { */p__i__.__ch__ * w.E__i__/*# }, add); */)/*# }, comma); */);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __rtype__ LinComRaw__rtc__(
            /*# tpc.ForEach(i => { */__type__ p__i__/*# }, comma); */, ref Tup__tpc__<__wtype__> w)
        {
            return new __rtype__(/*# channels.ForEach(ch => { */
                /*# tpc.ForEach(i => { */p__i__.__ch__ * w.E__i__/*# }, add); }, comma); */);
        }

        //# } // rt
        //# } // tpc
        #endregion
    }

    //# if (ft != Meta.ByteType && ft != Meta.UShortType) {
    public static class IRandomUniform__type__Extensions
    {
        #region IRandomUniform extensions for __type__

        //# string[] variants;
        //# if (ft == Meta.FloatType) {
        //#     variants = new string[] { "", "Closed", "Open" };
        //# } else if (ft == Meta.DoubleType) {
        //#     variants = new string[] { "", "Closed", "Open", "Full", "FullClosed", "FullOpen" };
        //# } else {
        //#     variants = new string[] { "" };
        //# }
        //# foreach (var v in variants) {
        /// <summary>
        /// Uses Uniform__fcaps____v__() to generate the elements of a __type__ color.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Uniform__type____v__(this IRandomUniform rnd)
        {
            return new __type__(/*# fields.ForEach(f => { */rnd.Uniform__fcaps____v__()/*#  }, comma); */);
        }

        //# }
        #endregion
    }

    //# }
    #endregion

    //# }
}
