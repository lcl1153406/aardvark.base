﻿using Aardvark.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Aardvark.Tests
{
    [TestFixture]
    public static class EuclideanTests
    {
        private static readonly int iterations = 10000;

        private static Scale3d GetRandomScale(RandomSystem rnd)
        {
            return new Scale3d(rnd.UniformV3d() * 5);
        }

        private static Rot3d GetRandomRot(RandomSystem rnd)
        {
            return Rot3d.Rotation(rnd.UniformV3dDirection(), rnd.UniformDouble() * Constant.PiTimesTwo);
        }

        private static Shift3d GetRandomShift(RandomSystem rnd)
        {
            return new Shift3d(rnd.UniformV3d() * 10);
        }

        private static Euclidean3d GetRandomEuclidean(RandomSystem rnd, bool withTranslation = true)
        {
            var translation = withTranslation ? GetRandomShift(rnd).V : V3d.Zero;
            return new Euclidean3d(GetRandomRot(rnd), translation);
        }

        [Test]
        public static void Comparison()
        {
            var rnd = new RandomSystem(1);

            for (int i = 0; i < iterations; i++)
            {
                var e0 = GetRandomEuclidean(rnd);
                var e1 = new Euclidean3d(e0.Rot, e0.Trans + V3d.OII);

                Assert.IsFalse(e0.Equals(e1));
                Assert.IsFalse(e0 == e1);
                Assert.IsTrue(e0 != e1);
            }
        }

        [Test]
        public static void InverseTest()
        {
            var rnd = new RandomSystem(1);

            for (int i = 0; i < iterations; i++)
            {
                var e = GetRandomEuclidean(rnd);

                var p = rnd.UniformV3d() * rnd.UniformInt(1000);
                var q = e.TransformPos(p);

                // Inverse property
                var res = e.Inverse.TransformPos(q);

                // Invert method
                Euclidean.Invert(ref e);
                var res2 = e.TransformPos(q);

                Assert.IsTrue(Fun.ApproximateEquals(p, res, 0.00001), "{0} != {1}", p, res);
                Assert.IsTrue(Fun.ApproximateEquals(p, res2, 0.00001), "{0} != {1}", p, res2);
            }
        }

        [Test]
        public static void Multiplication3x3Test()
        {
            var rnd = new RandomSystem(1);

            for (int i = 0; i < iterations; i++)
            {
                var e1 = GetRandomEuclidean(rnd, false);
                var e2 = GetRandomEuclidean(rnd, false);
                var e = e1 * e2;
                var em = (M33d)e1 * e2;
                var me = e1 * (M33d)e2;
                var m = (M33d)e1 * (M33d)e2;

                {
                    var p = new V4d(rnd.UniformV3d() * rnd.UniformInt(1000), 1);
                    var res = e.Transform(p).XYZ;
                    var res2 = m.Transform(p).XYZ;
                    var res3 = em.Transform(p);
                    var res4 = me.Transform(p);

                    Assert.IsTrue(Fun.ApproximateEquals(res, res2, 0.00001), "{0} != {1}", res, res2);
                    Assert.IsTrue(Fun.ApproximateEquals(res, res3, 0.00001), "{0} != {1}", res, res3);
                    Assert.IsTrue(Fun.ApproximateEquals(res, res4, 0.00001), "{0} != {1}", res, res4);
                }

                {
                    var p = new V4d(rnd.UniformV3d() * rnd.UniformInt(1000), 1);
                    var res = (e * p).XYZ;
                    var res2 = m * p.XYZ;
                    var res3 = em * p;
                    var res4 = me * p;

                    Assert.IsTrue(Fun.ApproximateEquals(res, res2, 0.00001), "{0} != {1}", res, res2);
                    Assert.IsTrue(Fun.ApproximateEquals(res, res3, 0.00001), "{0} != {1}", res, res3);
                    Assert.IsTrue(Fun.ApproximateEquals(res, res4, 0.00001), "{0} != {1}", res, res4);
                }
            }
        }

        [Test]
        public static void Multiplication4x4Test()
        {
            var rnd = new RandomSystem(1);

            for (int i = 0; i < iterations; i++)
            {
                var e1 = GetRandomEuclidean(rnd);
                var e2 = GetRandomEuclidean(rnd);
                var a = e1 * e2;
                var am = (M44d)e1 * e2;
                var ma = e1 * (M44d)e2;
                var m = (M44d)e1 * (M44d)e2;

                {
                    var p = rnd.UniformV3d() * rnd.UniformInt(1000);
                    var res = a.TransformPos(p);
                    var res2 = m.TransformPos(p);
                    var res3 = am.TransformPos(p);
                    var res4 = ma.TransformPos(p);

                    Assert.IsTrue(Fun.ApproximateEquals(res, res2, 0.00001), "{0} != {1}", res, res2);
                    Assert.IsTrue(Fun.ApproximateEquals(res, res3, 0.00001), "{0} != {1}", res, res3);
                    Assert.IsTrue(Fun.ApproximateEquals(res, res4, 0.00001), "{0} != {1}", res, res4);
                }

                {
                    var p = rnd.UniformV4d() * rnd.UniformInt(1000);
                    var res = a * p;
                    var res2 = m * p;
                    var res3 = am * p;
                    var res4 = ma * p;

                    Assert.IsTrue(Fun.ApproximateEquals(res, res2, 0.00001), "{0} != {1}", res, res2);
                    Assert.IsTrue(Fun.ApproximateEquals(res, res3, 0.00001), "{0} != {1}", res, res3);
                    Assert.IsTrue(Fun.ApproximateEquals(res, res4, 0.00001), "{0} != {1}", res, res4);
                }
            }
        }

        private static void GenericMultiplicationTest<T, U>(Func<RandomSystem, T> frnd, Func<U, V3d, V3d> transform)
        {
            var rnd = new RandomSystem(1);

            for (int i = 0; i < iterations; i++)
            {
                var a = GetRandomEuclidean(rnd);
                dynamic t = frnd(rnd);

                var p = rnd.UniformV3d() * rnd.UniformInt(1000);

                {
                    var trafo = a * t;
                    var res = transform(trafo, p);

                    var trafoRef = (M44d)a * (M44d)t;
                    var resRef = trafoRef.TransformPos(p);

                    Assert.IsTrue(Fun.ApproximateEquals(res, resRef, 0.00001), "{0} != {1}", res, resRef);
                }

                {
                    var trafo = t * a;
                    var res = transform(trafo, p);

                    var trafoRef = (M44d)t * (M44d)a;
                    var resRef = trafoRef.TransformPos(p);

                    Assert.IsTrue(Fun.ApproximateEquals(res, resRef, 0.00001), "{0} != {1}", res, resRef);
                }
            }
        }

        [Test]
        public static void ConsistentWithMatrixRotationAndShiftTest()
        {
            var rnd = new RandomSystem(1);

            for (int i = 0; i < iterations; i++)
            {
                var trans = rnd.UniformV3d() * 10;

                var axis = rnd.UniformV3dDirection();
                var angle = rnd.UniformDouble() * Constant.PiTimesTwo;

                var m = M44d.Translation(trans) * M44d.Rotation(axis, angle);
                var e = new Euclidean3d(Rot3d.Rotation(axis, angle), trans);

                var p = rnd.UniformV3d() * rnd.UniformInt(1000);
                var res = m.TransformPos(p);
                var res2 = e.TransformPos(p);

                Assert.IsTrue(Fun.ApproximateEquals(res, res2, 0.00001), "{0} != {1}", res, res2);
            }
        }

        [Test]
        public static void MultiplicationEuclideanTest()
            => GenericMultiplicationTest<Euclidean3d, Euclidean3d>(rnd => GetRandomEuclidean(rnd), Euclidean.TransformPos);

        [Test]
        public static void MultiplicationRotTest()
            => GenericMultiplicationTest<Rot3d, Euclidean3d>(GetRandomRot, Euclidean.TransformPos);

        [Test]
        public static void MultiplicationShiftTest()
            => GenericMultiplicationTest<Shift3d, Euclidean3d>(GetRandomShift, Euclidean.TransformPos);

        [Test]
        public static void MultiplicationScaleTest()
            => GenericMultiplicationTest<Scale3d, Affine3d>(GetRandomScale, Affine.TransformPos);

        [Test]
        public static void ToStringAndParse()
        {
            var rnd = new RandomSystem(1);
            
            for (int i = 0; i < iterations; i++)
            {
                var a = GetRandomEuclidean(rnd);

                var str = a.ToString();
                var parsed = Euclidean3d.Parse(str);

                Assert.IsTrue(Fun.ApproximateEquals(parsed, a, 0.00001, 0.00001));
            }
        }
    }
}
