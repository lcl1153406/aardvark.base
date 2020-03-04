using System;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.CompilerServices;

namespace Aardvark.Base
{
    // [todo ISSUE 20090427 andi : andi] define Similarity2*
    #region Similarity3f

    /// <summary>
    /// Represents a Similarity Transformation in 3D that is composed of a 
    /// Uniform Scale and a subsequent Euclidean transformation (3D rotation Rot and a subsequent translation by a 3D vector Trans).
    /// This is an angle preserving Transformation.
    /// </summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public struct Similarity3f
    {
        [DataMember]
        public float Scale;
        [DataMember]
        public Euclidean3f EuclideanTransformation;

        /// <summary>
        /// Shortcut for Rot of EuclideanTransformation
        /// </summary>
        public Rot3f Rot
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return EuclideanTransformation.Rot; }
        }

        /// <summary>
        /// Shortcut for Trans of EuclideanTransformation
        /// </summary>
        public V3f Trans
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return EuclideanTransformation.Trans; }
        }

        #region Constructors

        /// <summary>
        /// Creates a similarity transformation from an uniform scale by factor <paramref name="scale"/>, and a (subsequent) rigid transformation <paramref name="euclideanTransformation"/>.
        /// </summary>
        public Similarity3f(float scale, Euclidean3f euclideanTransformation)
        {
            Scale = scale;
            EuclideanTransformation = euclideanTransformation;
        }

        /// <summary>
        /// Creates a similarity transformation from a rigid transformation <paramref name="euclideanTransformation"/> and an (subsequent) uniform scale by factor <paramref name="scale"/>.
        /// </summary>
        public Similarity3f(Euclidean3f euclideanTransformation, float scale)
        {
            Scale = scale;
            EuclideanTransformation = new Euclidean3f(
                euclideanTransformation.Rot,
                scale * euclideanTransformation.Trans
                );
        }

        public Similarity3f(M44f m, float epsilon = (float)0.00001)
        {
            if (!(m.M30.IsTiny(epsilon) && m.M31.IsTiny(epsilon) && m.M32.IsTiny(epsilon)))
                throw new ArgumentException("Matrix contains perspective components.");
            if (m.M33.IsTiny(epsilon)) throw new ArgumentException("Matrix is not homogeneous.");
            m /= m.M33; //normalize it
            var m33 = (M33f)m;
            var s0 = m33.C0.Norm2;
            var s1 = m33.C1.Norm2;
            var s2 = m33.C2.Norm2;
            var s = (s0 * s1 * s2).Pow((float)1.0 / 3); //geometric mean of scale
            if (!((s0 / s - 1).IsTiny(epsilon) && (s1 / s - 1).IsTiny(epsilon) && (s2 / s - 1).IsTiny(epsilon)))
                throw new ArgumentException("Matrix features non-uniform scaling");
            m33 /= s;
            Scale = s;
            EuclideanTransformation = new Euclidean3f(m33, m.C3.XYZ);
        }

        #endregion

        #region Constants

        /// <summary>
        /// Identity (1, EuclideanTransformation.Identity)
        /// </summary>
        public static Similarity3f Identity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Similarity3f(1, Euclidean3f.Identity);
        }

        #endregion

        #region Similarity Transformation Arithmetics

        /// <summary>
        /// Returns a new version of this Similarity transformation with a normalized rotation quaternion.
        /// </summary>
        public Similarity3f Normalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return new Similarity3f(Scale, EuclideanTransformation.Normalized);
            }
        }

        /// <summary>
        /// Gets the (multiplicative) inverse of this Similarity transformation.
        /// [1/Scale, Rot^T,-Rot^T Trans/Scale]
        /// </summary>
        public Similarity3f Inverse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var newS = 1 / Scale;
                var newR = EuclideanTransformation.Inverse;
                newR.Trans *= newS;
                return new Similarity3f(newS, newR);
            }
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>
        /// Multiplies 2 Similarity transformations.
        /// This concatenates the two similarity transformations into a single one, first b is applied, then a.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Similarity3f operator *(Similarity3f a, Similarity3f b)
        {
            //a.Scale * b.Scale, a.Rot * b.Rot, a.Trans + a.Rot * a.Scale * b.Trans
            return new Similarity3f(a.Scale * b.Scale, new Euclidean3f(
                a.Rot * b.Rot,
                a.Trans + a.Rot.Transform(a.Scale * b.Trans))
                );
        }

        /// <summary>
        /// Multiplies an Euclidean transformation by a Similarity transformation.
        /// This concatenates the two transformations into a single one, first b is applied, then a.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Similarity3f operator *(Euclidean3f a, Similarity3f b)
        {
            return (Similarity3f)a * b;
        }

        /// <summary>
        /// Multiplies a Similarity transformation by an Euclidean transformation.
        /// This concatenates the two transformations into a single one, first b is applied, then a.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Similarity3f operator *(Similarity3f a, Euclidean3f b)
        {
            return a * (Similarity3f)b;
        }

        // [todo ISSUE 20090427 andi : andi] add operator * for all other Trafo structs.
        /*
                public static M33f operator *(Similarity3f t, Rot3f m)
                {
                    return (M34f)t * m;
                }

                public static M33f operator *(Similarity3f t, Scale3f m)
                {
                    return (M34f)t * m;
                }
        */
        /*
                // [todo ISSUE 20090427 andi : andi] this is again a Similarity3f.
                // [todo ISSUE 20090427 andi : andi] Rot3f * Shift3f should return a Similarity3f!
                public static M34f operator *(Similarity3f t, Shift3f m)
                {
                    return (M34f)t * m;
                }

                public static M33f operator *(Similarity3f t, M33f m)
                {
                    return (M34f)t * m;
                }

                public static M33f operator *(M33f m, Similarity3f t)
                {
                    return m * (M34f)t;
                }
        */
        #endregion

        #region Comparison Operators

        public static bool operator ==(Similarity3f t0, Similarity3f t1)
        {
            return t0.Scale == t1.Scale && t0.EuclideanTransformation == t1.EuclideanTransformation;
        }

        public static bool operator !=(Similarity3f t0, Similarity3f t1)
        {
            return !(t0 == t1);
        }

        #endregion

        #region Conversion

        public static explicit operator M34f(Similarity3f t)
        {
            M34f rv = (M34f)t.EuclideanTransformation;
            rv.M00 *= t.Scale;
            rv.M01 *= t.Scale;
            rv.M02 *= t.Scale;
            rv.M10 *= t.Scale;
            rv.M11 *= t.Scale;
            rv.M12 *= t.Scale;
            rv.M20 *= t.Scale;
            rv.M21 *= t.Scale;
            rv.M22 *= t.Scale;
            return rv;
        }

        public static explicit operator M44f(Similarity3f t)
        {
            M44f rv = (M44f)t.EuclideanTransformation;
            rv.M00 *= t.Scale;
            rv.M01 *= t.Scale;
            rv.M02 *= t.Scale;
            rv.M10 *= t.Scale;
            rv.M11 *= t.Scale;
            rv.M12 *= t.Scale;
            rv.M20 *= t.Scale;
            rv.M21 *= t.Scale;
            rv.M22 *= t.Scale;
            return rv;
        }

        #endregion

        #region Overrides

        public override int GetHashCode()
        {
            return HashCode.GetCombined(Scale, EuclideanTransformation);
        }

        public override bool Equals(object other)
        {
            return (other is Similarity3f) ? (this == (Similarity3f)other) : false;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0}, {1}]", Scale, EuclideanTransformation);
        }

        public static Similarity3f Parse(string s)
        {
            var x = s.NestedBracketSplitLevelOne().ToArray();
            return new Similarity3f(float.Parse(x[0]), Euclidean3f.Parse(x[1]));
        }

        #endregion
    }

    public static partial class Similarity
    {
        #region Invert, Normalize

        /// <summary>
        /// Inverts the similarity transformation (multiplicative inverse).
        /// this = [1/Scale, Rot^T,-Rot^T Trans/Scale]
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Invert(this ref Similarity3f t)
        {
            t.Scale = 1 / t.Scale;
            t.EuclideanTransformation.Invert();
            t.EuclideanTransformation.Trans *= t.Scale;
        }

        /// <summary>
        /// Normalizes the rotation quaternion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(this ref Similarity3f t)
        {
            t.EuclideanTransformation.Normalize();
        }

        #endregion

        #region Transform

        /// <summary>
        /// Transforms direction vector v (v.w is presumed 0.0) by similarity transformation t.
        /// Actually, only the rotation and scale is used.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V3f TransformDir(this Similarity3f t, V3f v)
        {
            return t.EuclideanTransformation.TransformDir(t.Scale * v);
        }

        /// <summary>
        /// Transforms point p (p.w is presumed 1.0) by similarity transformation t.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V3f TransformPos(this Similarity3f t, V3f p)
        {
            return t.EuclideanTransformation.TransformPos(t.Scale * p);
        }

        /// <summary>
        /// Transforms direction vector v (v.w is presumed 0.0) by the inverse of the similarity transformation t.
        /// Actually, only the rotation and scale is used.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V3f InvTransformDir(this Similarity3f t, V3f v)
        {
            return t.EuclideanTransformation.InvTransformDir(v) / t.Scale;
        }

        /// <summary>
        /// Transforms point p (p.w is presumed 1.0) by the inverse of the similarity transformation t.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V3f InvTransformPos(this Similarity3f t, V3f p)
        {
            return t.EuclideanTransformation.InvTransformPos(p) / t.Scale;
        }

        #endregion
    }

    public static partial class Fun
    {
        #region ApproximateEquals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this Similarity3f t0, Similarity3f t1)
        {
            return ApproximateEquals(t0, t1, Constant<float>.PositiveTinyValue, Constant<float>.PositiveTinyValue, Constant<float>.PositiveTinyValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this Similarity3f t0, Similarity3f t1, float angleTol, float posTol, float scaleTol)
        {
            return t0.Scale.ApproximateEquals(t1.Scale, scaleTol) && t0.EuclideanTransformation.ApproximateEquals(t1.EuclideanTransformation, angleTol, posTol);
        }

        #endregion
    }

    #endregion

    // [todo ISSUE 20090427 andi : andi] define Similarity2*
    #region Similarity3d

    /// <summary>
    /// Represents a Similarity Transformation in 3D that is composed of a 
    /// Uniform Scale and a subsequent Euclidean transformation (3D rotation Rot and a subsequent translation by a 3D vector Trans).
    /// This is an angle preserving Transformation.
    /// </summary>
    [DataContract]
    [StructLayout(LayoutKind.Sequential)]
    public struct Similarity3d
    {
        [DataMember]
        public double Scale;
        [DataMember]
        public Euclidean3d EuclideanTransformation;

        /// <summary>
        /// Shortcut for Rot of EuclideanTransformation
        /// </summary>
        public Rot3d Rot
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return EuclideanTransformation.Rot; }
        }

        /// <summary>
        /// Shortcut for Trans of EuclideanTransformation
        /// </summary>
        public V3d Trans
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get { return EuclideanTransformation.Trans; }
        }

        #region Constructors

        /// <summary>
        /// Creates a similarity transformation from an uniform scale by factor <paramref name="scale"/>, and a (subsequent) rigid transformation <paramref name="euclideanTransformation"/>.
        /// </summary>
        public Similarity3d(double scale, Euclidean3d euclideanTransformation)
        {
            Scale = scale;
            EuclideanTransformation = euclideanTransformation;
        }

        /// <summary>
        /// Creates a similarity transformation from a rigid transformation <paramref name="euclideanTransformation"/> and an (subsequent) uniform scale by factor <paramref name="scale"/>.
        /// </summary>
        public Similarity3d(Euclidean3d euclideanTransformation, double scale)
        {
            Scale = scale;
            EuclideanTransformation = new Euclidean3d(
                euclideanTransformation.Rot,
                scale * euclideanTransformation.Trans
                );
        }

        public Similarity3d(M44d m, double epsilon = (double)0.00001)
        {
            if (!(m.M30.IsTiny(epsilon) && m.M31.IsTiny(epsilon) && m.M32.IsTiny(epsilon)))
                throw new ArgumentException("Matrix contains perspective components.");
            if (m.M33.IsTiny(epsilon)) throw new ArgumentException("Matrix is not homogeneous.");
            m /= m.M33; //normalize it
            var m33 = (M33d)m;
            var s0 = m33.C0.Norm2;
            var s1 = m33.C1.Norm2;
            var s2 = m33.C2.Norm2;
            var s = (s0 * s1 * s2).Pow((double)1.0 / 3); //geometric mean of scale
            if (!((s0 / s - 1).IsTiny(epsilon) && (s1 / s - 1).IsTiny(epsilon) && (s2 / s - 1).IsTiny(epsilon)))
                throw new ArgumentException("Matrix features non-uniform scaling");
            m33 /= s;
            Scale = s;
            EuclideanTransformation = new Euclidean3d(m33, m.C3.XYZ);
        }

        #endregion

        #region Constants

        /// <summary>
        /// Identity (1, EuclideanTransformation.Identity)
        /// </summary>
        public static Similarity3d Identity
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => new Similarity3d(1, Euclidean3d.Identity);
        }

        #endregion

        #region Similarity Transformation Arithmetics

        /// <summary>
        /// Returns a new version of this Similarity transformation with a normalized rotation quaternion.
        /// </summary>
        public Similarity3d Normalized
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return new Similarity3d(Scale, EuclideanTransformation.Normalized);
            }
        }

        /// <summary>
        /// Gets the (multiplicative) inverse of this Similarity transformation.
        /// [1/Scale, Rot^T,-Rot^T Trans/Scale]
        /// </summary>
        public Similarity3d Inverse
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                var newS = 1 / Scale;
                var newR = EuclideanTransformation.Inverse;
                newR.Trans *= newS;
                return new Similarity3d(newS, newR);
            }
        }

        #endregion

        #region Arithmetic Operators

        /// <summary>
        /// Multiplies 2 Similarity transformations.
        /// This concatenates the two similarity transformations into a single one, first b is applied, then a.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Similarity3d operator *(Similarity3d a, Similarity3d b)
        {
            //a.Scale * b.Scale, a.Rot * b.Rot, a.Trans + a.Rot * a.Scale * b.Trans
            return new Similarity3d(a.Scale * b.Scale, new Euclidean3d(
                a.Rot * b.Rot,
                a.Trans + a.Rot.Transform(a.Scale * b.Trans))
                );
        }

        /// <summary>
        /// Multiplies an Euclidean transformation by a Similarity transformation.
        /// This concatenates the two transformations into a single one, first b is applied, then a.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Similarity3d operator *(Euclidean3d a, Similarity3d b)
        {
            return (Similarity3d)a * b;
        }

        /// <summary>
        /// Multiplies a Similarity transformation by an Euclidean transformation.
        /// This concatenates the two transformations into a single one, first b is applied, then a.
        /// Attention: Multiplication is NOT commutative!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Similarity3d operator *(Similarity3d a, Euclidean3d b)
        {
            return a * (Similarity3d)b;
        }

        // [todo ISSUE 20090427 andi : andi] add operator * for all other Trafo structs.
        /*
                public static M33d operator *(Similarity3d t, Rot3d m)
                {
                    return (M34d)t * m;
                }

                public static M33d operator *(Similarity3d t, Scale3d m)
                {
                    return (M34d)t * m;
                }
        */
        /*
                // [todo ISSUE 20090427 andi : andi] this is again a Similarity3d.
                // [todo ISSUE 20090427 andi : andi] Rot3d * Shift3d should return a Similarity3d!
                public static M34d operator *(Similarity3d t, Shift3d m)
                {
                    return (M34d)t * m;
                }

                public static M33d operator *(Similarity3d t, M33d m)
                {
                    return (M34d)t * m;
                }

                public static M33d operator *(M33d m, Similarity3d t)
                {
                    return m * (M34d)t;
                }
        */
        #endregion

        #region Comparison Operators

        public static bool operator ==(Similarity3d t0, Similarity3d t1)
        {
            return t0.Scale == t1.Scale && t0.EuclideanTransformation == t1.EuclideanTransformation;
        }

        public static bool operator !=(Similarity3d t0, Similarity3d t1)
        {
            return !(t0 == t1);
        }

        #endregion

        #region Conversion

        public static explicit operator M34d(Similarity3d t)
        {
            M34d rv = (M34d)t.EuclideanTransformation;
            rv.M00 *= t.Scale;
            rv.M01 *= t.Scale;
            rv.M02 *= t.Scale;
            rv.M10 *= t.Scale;
            rv.M11 *= t.Scale;
            rv.M12 *= t.Scale;
            rv.M20 *= t.Scale;
            rv.M21 *= t.Scale;
            rv.M22 *= t.Scale;
            return rv;
        }

        public static explicit operator M44d(Similarity3d t)
        {
            M44d rv = (M44d)t.EuclideanTransformation;
            rv.M00 *= t.Scale;
            rv.M01 *= t.Scale;
            rv.M02 *= t.Scale;
            rv.M10 *= t.Scale;
            rv.M11 *= t.Scale;
            rv.M12 *= t.Scale;
            rv.M20 *= t.Scale;
            rv.M21 *= t.Scale;
            rv.M22 *= t.Scale;
            return rv;
        }

        #endregion

        #region Overrides

        public override int GetHashCode()
        {
            return HashCode.GetCombined(Scale, EuclideanTransformation);
        }

        public override bool Equals(object other)
        {
            return (other is Similarity3d) ? (this == (Similarity3d)other) : false;
        }

        public override string ToString()
        {
            return string.Format(CultureInfo.InvariantCulture, "[{0}, {1}]", Scale, EuclideanTransformation);
        }

        public static Similarity3d Parse(string s)
        {
            var x = s.NestedBracketSplitLevelOne().ToArray();
            return new Similarity3d(double.Parse(x[0]), Euclidean3d.Parse(x[1]));
        }

        #endregion
    }

    public static partial class Similarity
    {
        #region Invert, Normalize

        /// <summary>
        /// Inverts the similarity transformation (multiplicative inverse).
        /// this = [1/Scale, Rot^T,-Rot^T Trans/Scale]
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Invert(this ref Similarity3d t)
        {
            t.Scale = 1 / t.Scale;
            t.EuclideanTransformation.Invert();
            t.EuclideanTransformation.Trans *= t.Scale;
        }

        /// <summary>
        /// Normalizes the rotation quaternion.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Normalize(this ref Similarity3d t)
        {
            t.EuclideanTransformation.Normalize();
        }

        #endregion

        #region Transform

        /// <summary>
        /// Transforms direction vector v (v.w is presumed 0.0) by similarity transformation t.
        /// Actually, only the rotation and scale is used.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V3d TransformDir(this Similarity3d t, V3d v)
        {
            return t.EuclideanTransformation.TransformDir(t.Scale * v);
        }

        /// <summary>
        /// Transforms point p (p.w is presumed 1.0) by similarity transformation t.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V3d TransformPos(this Similarity3d t, V3d p)
        {
            return t.EuclideanTransformation.TransformPos(t.Scale * p);
        }

        /// <summary>
        /// Transforms direction vector v (v.w is presumed 0.0) by the inverse of the similarity transformation t.
        /// Actually, only the rotation and scale is used.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V3d InvTransformDir(this Similarity3d t, V3d v)
        {
            return t.EuclideanTransformation.InvTransformDir(v) / t.Scale;
        }

        /// <summary>
        /// Transforms point p (p.w is presumed 1.0) by the inverse of the similarity transformation t.
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static V3d InvTransformPos(this Similarity3d t, V3d p)
        {
            return t.EuclideanTransformation.InvTransformPos(p) / t.Scale;
        }

        #endregion
    }

    public static partial class Fun
    {
        #region ApproximateEquals

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this Similarity3d t0, Similarity3d t1)
        {
            return ApproximateEquals(t0, t1, Constant<double>.PositiveTinyValue, Constant<double>.PositiveTinyValue, Constant<double>.PositiveTinyValue);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool ApproximateEquals(this Similarity3d t0, Similarity3d t1, double angleTol, double posTol, double scaleTol)
        {
            return t0.Scale.ApproximateEquals(t1.Scale, scaleTol) && t0.EuclideanTransformation.ApproximateEquals(t1.EuclideanTransformation, angleTol, posTol);
        }

        #endregion
    }

    #endregion

}