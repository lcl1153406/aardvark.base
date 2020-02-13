﻿using System;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace Aardvark.Base
{
    // AUTOGENERATED CODE - DO NOT CHANGE!

    //# Action comma = () => Out(", ");
    //# Action commaln = () => Out("," + Environment.NewLine);
    //# Action add = () => Out(" + ");
    //# var fields = new[] {"X", "Y", "Z", "W"};
    //# foreach (var isDouble in new[] { false, true }) {
    //# for (int n = 2; n <= 3; n++) {
    //#   var ftype = isDouble ? "double" : "float";
    //#   var tc = isDouble ? "d" : "f";
    //#   var m = n + 1;
    //#   var type = "Affine" + n + tc;
    //#   var trafont = "Trafo" + n + tc;
    //#   var euclideannt = "Euclidean" + n + tc;
    //#   var rotnt = "Rot" + n + tc;
    //#   var scalent = "Scale" + n + tc;
    //#   var shiftnt = "Shift" + n + tc;
    //#   var similaritynt = "Similarity" + n + tc;
    //#   var mnnt = "M" + n + n + tc;
    //#   var mnmt = "M" + n + m + tc;
    //#   var mmmt = "M" + m + m + tc;
    //#   var vnt = "V" + n + tc;
    //#   var vmt = "V" + m + tc;
    //#   var nfields = fields.Take(n).ToArray();
    //#   var mfields = fields.Take(m).ToArray();
    //#   var fn = fields[n];
    #region __type__

    /// <summary>
    /// Struct to represent an affine transformation in __n__-dimensional space. It consists of
    /// a linear tranformation (invertible __n__x__n__ matrix) and a translational component (__n__d vector).
    /// </summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public struct __type__ : IValidity
    {
        [DataMember]
        public __mnnt__ Linear;
        [DataMember]
        public __vnt__ Trans;

        #region Constructors

        /// <summary>
        /// Constructs an affine transformation from a linear map and a translation.
        /// The matrix <paramref name="linear"/> must be invertible.
        /// </summary>
        public __type__(__mnnt__ linear, __vnt__ translation)
        {
            Debug.Assert(linear.Invertible);
            Linear = linear;
            Trans = translation;
        }

        /// <summary>
        /// Constructs an affine transformation from a linear map and a translation.
        /// The matrix <paramref name="linear"/> must be invertible.
        /// </summary>
        public __type__(__mnnt__ linear, /*# nfields.ForEach(f => { */__ftype__ t__f__/*# }, comma); */)
        {
            Debug.Assert(linear.Invertible);
            Linear = linear;
            Trans = new __vnt__(/*# nfields.ForEach(f => { */t__f__/*# }, comma); */);
        }

        /// <summary>
        /// Constructs an affine transformation from a linear map.
        /// The matrix <paramref name="linear"/> must be invertible.
        /// </summary>
        public __type__(__mnnt__ linear)
        {
            Debug.Assert(linear.Invertible);
            Linear = linear;
            Trans = __vnt__.Zero;
        }

        /// <summary>
        /// Constructs an affine transformation from a __n__x__m__ matrix.
        /// The left __n__x__n__ submatrix of <paramref name="matrix"/> must be invertible.
        /// </summary>
        public __type__(__mnmt__ matrix)
        {
            Linear = (__mnnt__)matrix;
            Trans = new __vnt__(/*# n.ForEach(i => { */matrix.M__i____n__/*# }, comma); */);
            Debug.Assert(Linear.Invertible);
        }

        /// <summary>
        /// Constructs an affine transformation from a __m__x__m__ matrix.
        /// The upper left __n__x__n__ submatrix of <paramref name="matrix"/> must be invertible.
        /// </summary>
        public __type__(__mmmt__ matrix)
        {
            Linear = (__mnnt__)matrix;
            Trans = new __vnt__(/*# n.ForEach(i => { */matrix.M__i____n__/*# }, comma); */);
            Debug.Assert(Linear.Invertible);
        }

        /// <summary>
        /// Constructs an affine transformation from a <see cref="__trafont__"/>.
        /// </summary>
        public __type__(__trafont__ trafo)
        {
            Linear = (__mnnt__)trafo.Forward;
            Trans = new __vnt__(/*# n.ForEach(i => { */trafo.Forward.M__i____n__/*# }, comma); */);
            Debug.Assert(Linear.Invertible);
        }

        /// <summary>
        /// Constructs an affine transformation from an <see cref="__euclideannt__"/>.
        /// </summary>
        public __type__(__euclideannt__ e) : this((__mmmt__)e) {}

        /// <summary>
        /// Constructs an affine transformation from a <see cref="__rotnt__"/>.
        /// </summary>
        public __type__(__rotnt__ r) : this((__mnnt__)r) { }

        //# if (n == 3) {
        /// <summary>
        /// Constructs an affine transformation from a <see cref="__scalent__"/>.
        /// </summary>
        public __type__(__scalent__ s) : this((__mnnt__)s) { }

        /// <summary>
        /// Constructs an affine transformation from a linear map and a <see cref="__shiftnt__"/>.
        /// The matrix <paramref name="linear"/> must be invertible.
        /// </summary>
        public __type__(__mnnt__ linear, __shiftnt__ shift)
        {
            Debug.Assert(linear.Invertible);
            Linear = linear;
            Trans = shift.V;
        }

        /// <summary>
        /// Constructs an affine transformation from a <see cref="__shiftnt__"/>.
        /// </summary>
        public __type__(__shiftnt__ s)
        {
            Linear = __mnnt__.Identity;
            Trans = s.V;
        }

        /// <summary>
        /// Constructs an affine transformation from a <see cref="__similaritynt__"/>.
        /// </summary>
        public __type__(__similaritynt__ s) : this((__mmmt__)s) { }

        //# } // n = 3
        #endregion

        #region Constants

        /// <summary>
        /// Gets the identity transformation.
        /// </summary>
        public static __type__ Identity
        { 
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new __type__(__mnnt__.Identity);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets if this affine transformation is valid, i.e. if the linear map is invertible.
        /// </summary>
        public bool IsValid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => Linear.Invertible;
        }

        /// <summary>
        /// Gets if this affine transformation is invalid, i.e. if the linear map is singular.
        /// </summary>
        public bool IsInvalid
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => !IsValid;
        }

        /// <summary>
        /// Gets the inverse of this affine tranformation.
        /// </summary>
        public __type__ Inverse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                Debug.Assert(Linear.Invertible);
                var i = Linear.Inverse;
                return new __type__(i, -i * Trans);
            }
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>
        /// Multiplies two affine transformations.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __type__ b)
        {
            return new __type__(a.Linear * b.Linear, a.Linear * b.Trans + a.Trans);
        }

        /// <summary>
        /// Transforms a <see cref="__type__"/> vector by an affine transformation.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vmt__ operator *(__type__ a, __vmt__ v)
        {
            return new __vmt__(/*# nfields.ForEach((fi, i) => { */
                /*# mfields.ForEach((fj, j) => {
                var aij = (j < n) ? "a.Linear.M" + i + j : "a.Trans." + fi;
                */__aij__ * v.__fj__/*# }, add); }, comma);*/, 
                v.__fn__);
        }

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__mmmt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mmmt__ operator *(__type__ a, __mmmt__ m)
        {
            return new __mmmt__(/*# nfields.ForEach((fi, i) => { mfields.ForEach((fj, j) => { */
                /*# mfields.ForEach((fk, k) => {
                var aik = (k < n) ? "a.Linear.M" + i + k : "a.Trans." + fi;
                */__aik__ * m.M__k____j__/*# }, add); }, comma); }, commaln);*/,

                /*# mfields.ForEach((f, i) => { */m.M__n____i__/*# }, comma);*/);
        }

        /// <summary>
        /// Multiplies a <see cref="__mmmt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mmmt__ operator *(__mmmt__ m, __type__ a)
        {
            return new __mmmt__(/*# mfields.ForEach((fi, i) => { nfields.ForEach((fj, j) => { */
                /*# nfields.ForEach((fk, k) => {
                */m.M__i____k__ * a.Linear.M__k____j__/*# }, add); }, comma);*/,
                /*# nfields.ForEach((fk, k) => {
                */m.M__i____k__ * a.Trans.__fk__/*# }, add);*/ + m.M__i____n__/*# }, commaln);*/);
        }

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__mnnt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mnmt__ operator *(__type__ a, __mnnt__ m)
            => new __mnmt__(a.Linear * m, a.Trans);

        /// <summary>
        /// Multiplies a <see cref="__mnnt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __mnmt__ operator *(__mnnt__ m, __type__ a)
            => new __mnmt__(m * a.Linear, m * a.Trans);

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__euclideannt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __euclideannt__ e)
            => a * (__type__)e;

        /// <summary>
        /// Multiplies a <see cref="__euclideannt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__euclideannt__ e, __type__ a)
            => (__type__)e * a;

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__rotnt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __rotnt__ r)
            => new __type__(a.Linear * r, a.Trans);

        /// <summary>
        /// Multiplies a <see cref="__rotnt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__rotnt__ r, __type__ a)
            => new __type__(r * a.Linear, r * a.Trans);

        //# if (n == 3) {
        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__scalent__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __scalent__ s)
        {
            return new __type__(new __mnnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */a.Linear.M__i____j__ * s.__fj__/*# }, comma); }, comma);*/),
                a.Trans);
        }

        /// <summary>
        /// Multiplies a <see cref="__scalent__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__scalent__ s, __type__ a)
        {
            return new __type__(new __mnnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */a.Linear.M__i____j__ * s.__fi__/*# }, comma); }, comma);*/),
                a.Trans * s.V);
        }

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__shiftnt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __shiftnt__ s)
        {
            return new __type__(a.Linear, a.Linear * s.V + a.Trans);
        }

        /// <summary>
        /// Multiplies a <see cref="__shiftnt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__shiftnt__ s, __type__ a)
        {
            return new __type__(a.Linear, a.Trans + s.V);
        }

        /// <summary>
        /// Multiplies a <see cref="__type__"/> and a <see cref="__similaritynt__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__type__ a, __similaritynt__ s)
            => a * (__type__)s;

        /// <summary>
        /// Multiplies a <see cref="__similaritynt__"/> and a <see cref="__type__"/>.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ operator *(__similaritynt__ s, __type__ a)
            => (__type__)s * a;

        //# }
        #endregion

        #region Static Creators

        /// <summary>
        /// Creates an affine transformation with the translational component given by __n__ scalars.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Translation(/*# nfields.ForEach(f => { */__ftype__ t__f__/*# }, comma); */)
            => new __type__(__mnnt__.Identity, /*# nfields.ForEach(f => { */t__f__/*# }, comma); */);

        /// <summary>
        /// Creates an affine transformation with the translational component given a <see cref="__vnt__"/> vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Translation(__vnt__ vector)
            => new __type__(__mnnt__.Identity, vector);

        //# if (n == 3) {
        /// <summary>
        /// Creates an affine transformation with the translational component given a <see cref="__shiftnt__"/> vector.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Translation(__shiftnt__ shift)
            => new __type__(__mnnt__.Identity, shift);

        //# }
        /// <summary>
        /// Creates a scaling transformation using a uniform scaling factor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Scale(__ftype__ scaleFactor)
            => new __type__(__mnnt__.Scale(/*# nfields.ForEach(f => { */scaleFactor/*# }, comma); */));

        /// <summary>
        /// Creates a scaling transformation using __n__ scalars as scaling factors.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Scale(/*# nfields.ForEach(f => { */__ftype__ s__f__/*# }, comma); */)
            => new __type__(__mnnt__.Scale(/*# nfields.ForEach(f => { */s__f__/*# }, comma); */));

        /// <summary>
        /// Creates a scaling transformation using a <see cref="__vnt__"/> as scaling factor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Scale(__vnt__ scaleFactors)
            => new __type__(__mnnt__.Scale(scaleFactors));

        //# if (n == 3) {
        /// <summary>
        /// Creates a scaling transformation using a <see cref="__scalent__"/> as scaling factor.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Scale(__scalent__ scale)
            => new __type__(__mnnt__.Scale(/*# nfields.ForEach(f => { */scale.__f__/*# }, comma); */));

        //# }
        /// <summary>
        /// Creates a rotation transformation from a <see cref="__rotnt__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Rotation(__rotnt__ q)
            => new __type__(__mnnt__.Rotation(q));

        //# if (n == 3) {
        /// <summary>
        /// Creates a rotation transformation from an axis vector and an angle in radians.
        /// The axis vector has to be normalized.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Rotation(__vnt__ normalizedAxis, __ftype__ angleRadians)
            => new __type__(__mnnt__.Rotation(normalizedAxis, angleRadians));

        /// <summary>
        /// Creates a rotation transformation from roll (X), pitch (Y), and yaw (Z). 
        /// The rotation order is: Z, Y, X.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ Rotation(__ftype__ rollInRadians, __ftype__ pitchInRadians, __ftype__ yawInRadians)
            => new __type__(__mnnt__.Rotation(rollInRadians, pitchInRadians, yawInRadians));

        /// <summary>
        /// Creates a rotation transformation by <paramref name="angleRadians"/> radians around the x-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationX(__ftype__ angleRadians)
            => new __type__(__mnnt__.RotationX(angleRadians));

        /// <summary>
        /// Creates a rotation transformation by <paramref name="angleRadians"/> radians around the y-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationY(__ftype__ angleRadians)
            => new __type__(__mnnt__.RotationY(angleRadians));

        /// <summary>
        /// Creates a rotation transformation by <paramref name="angleRadians"/> radians around the z-axis.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __type__ RotationZ(__ftype__ angleRadians)
            => new __type__(__mnnt__.RotationZ(angleRadians));

        //# }
        #endregion

        #region Conversions

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __mnmt__(__type__ a)
            => new __mnmt__(a.Linear, a.Trans);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __mnnt__(__type__ a)
            => a.Linear;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __mmmt__(__type__ a)
            => new __mmmt__((__mnmt__) a);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static explicit operator __trafont__(__type__ a)
        {
            Debug.Assert(a.Linear.Invertible);
            var t = (__mmmt__) a;
            return new __trafont__(t, t.Inverse);
        }

        #endregion
    }

    public static partial class Affine
    {
        #region Invert

        /// <summary>
        /// Inverts the given affine transformation.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Invert(this ref __type__ a)
        {
            a = a.Inverse;
        }

        #endregion

        #region Transformations

        /// <summary>
        /// Transforms a <see cref="__vmt__"/> by an <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vmt__ Transform(this __type__ a, __vmt__ v)
            => a * v;

        /// <summary>
        /// Transforms a <see cref="__vnt__"/> position vector (v.__fn__ is presumed 1) by an <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vnt__ TransformPos(this __type__ a, __vnt__ v)
        {
            return new __vnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */a.Linear.M__i____j__ * v.__fj__/*# }, add);
                */ + a.Trans.__fi__/*# }, comma);*/);
        }

        /// <summary>
        /// Transforms a <see cref="__vnt__"/> direction vector (v.__fn__ is presumed 0) by an <see cref="__type__"/>.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vnt__ TransformDir(this __type__ a, __vnt__ v)
        {
            return new __vnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */a.Linear.M__i____j__ * v.__fj__/*# }, add); }, comma);*/);
        }

        /// <summary>
        /// Transforms a <see cref="__vmt__"/> by the transpose of an <see cref="__type__"/> (as a __m__x__m__ matrix).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vmt__ TransposedTransform(this __type__ a, __vmt__ v)
        {
            return new __vmt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */v.__fj__ * a.Linear.M__j____i__/*# }, add); }, comma);*/,
                /*# nfields.ForEach((f, i) => { */v.__f__ * a.Trans.__f__/*# }, add);*/ + v.__fn__);
        }

        /// <summary>
        /// Transforms a <see cref="__vnt__"/> by the transpose of an <see cref="__type__"/> (as a __m__x__m__ matrix).
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vnt__ TransposedTransform(this __type__ a, __vnt__ v)
        {
            return new __vnt__(/*# nfields.ForEach((fi, i) => { */
                /*# nfields.ForEach((fj, j) => { */v.__fj__ * a.Linear.M__j____i__/*# }, add); }, comma);*/);
        }

        /// <summary>
        /// Transforms a <see cref="__vnt__"/> position vector (v.__fn__ is presumed 1) by the transpose of an <see cref="__type__"/> (as a __m__x__m__ matrix).
        /// Projective transform is performed. Perspective Division is performed.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static __vnt__ TransposedTransformPosProj(this __type__ a, __vnt__ v)
        {
            var s = /*# nfields.ForEach(f => {*/v.__f__ * a.Trans.__f__/*# }, add);*/ + 1;
            return TransposedTransform(a, v) * (1 / s);
        }

        #endregion
    }

    #endregion

    //# }
    //# }
}