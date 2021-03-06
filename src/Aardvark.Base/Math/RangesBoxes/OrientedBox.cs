﻿using System.Runtime.Serialization;

namespace Aardvark.Base
{
    [DataContract]
    public struct OrientedBox2d
    {
        [DataMember]
        public Box2d Box;
        [DataMember]
        public Euclidean2d Trafo;

        public OrientedBox2d(Box2d box, Rot2d rot)
        {
            Box = box;
            Trafo = new Euclidean2d(rot, V2d.Zero);
        }

        public OrientedBox2d(Box2d box, V2d trans)
        {
            Box = box;
            Trafo = new Euclidean2d(Rot2d.Identity, trans);
        }

        public OrientedBox2d(Box2d box, Euclidean2d trafo)
        {
            Box = box;
            Trafo = trafo;
        }

        public Box2d AxisAlignedBox => Box.Transformed((M33d)Trafo);

        public V2d[] Corners
        {
            get
            {
                var m = (M33d)Trafo;
                return Box.ComputeCorners().Map(p => m.TransformPos(p));
            }
        }

        public V2d[] CornersCCW
        {
            get
            {
                var m = (M33d)Trafo;
                return Box.ComputeCornersCCW().Map(p => m.TransformPos(p));
            }
        }
    }
    
    [DataContract]
    public struct OrientedBox3d
    {
        [DataMember]
        public Box3d Box;
        [DataMember]
        public Euclidean3d Trafo;

        public OrientedBox3d(Box3d box, Rot3d rot)
        {
            Box = box;
            Trafo = new Euclidean3d(rot, V3d.Zero);
        }

        public OrientedBox3d(Box3d box, Euclidean3d trafo)
        {
            Box = box;
            Trafo = trafo;
        }

        public OrientedBox3d(Box3d box, Rot3d rot, V3d trans)
        {
            Box = box;
            Trafo = new Euclidean3d(rot, trans);
        }

        public Box3d AxisAlignedBox => Box.Transformed((M44d)Trafo);

        public V3d[] Corners
        {
            get
            {
                var m = (M44d)Trafo;
                return Box.ComputeCorners().Map(p => m.TransformPos(p));
            }
        }
    }
}
