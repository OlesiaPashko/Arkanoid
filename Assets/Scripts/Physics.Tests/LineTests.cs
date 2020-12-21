using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class LineTests
    {

        [Test]
        public void IsCollision_ParallelLines_Negative()
        {
            LineSegment line1 = new LineSegment(new Vector2(0, -5), new Vector2(0, 5));
            LineSegment line2 = new LineSegment(new Vector2(1, -5), new Vector2(1, 5));
            Assert.IsFalse(line1.IsCollision(line2));
        }


        [Test]
        public void IsCollision_Positive()
        {
            LineSegment line1 = new LineSegment(new Vector2(0, -5), new Vector2(0, 5));
            LineSegment line2 = new LineSegment(new Vector2(-5, 0), new Vector2(5, 0));

            Assert.IsTrue(line1.IsCollision(line2));
        }

        [Test]
        public void IsPointOnLine_Negative()
        {
            LineSegment line = new LineSegment(new Vector2(1, -5), new Vector2(1, 5));
            bool isOnLine =line.IsPointOnLine(new Vector2(0, 0), 0.00001f);
            Assert.IsFalse(isOnLine);
        }

        [Test]
        public void IsPointOnLine_Positive()
        {
            LineSegment line = new LineSegment(new Vector2(1, -5), new Vector2(1, 5));
            bool isOnLine = line.IsPointOnLine(new Vector2(1, 0), 0.001f);
            Assert.IsTrue(isOnLine);
        }

        [Test]
        public void GetCoefsFromLine()
        {
            Vector2 point1 = new Vector2(0.5f, 0.5f);
            Vector2 point2 = new Vector2(-0.5f, 0.5f);
            LineSegment line = new LineSegment(point1, point2);
            var (A, B, C) = line.GetCoefs();
            var (expectedA, expectedB, expectedC) = ( 0, 1, 0.5f);
            Assert.AreEqual(expectedA, A);
            Assert.AreEqual(expectedB, B);
            Assert.AreEqual(expectedC, C);
        }

        [Test]
        public void GetCoefsFromLineTest2()
        {
            Vector2 point1 = new Vector2(-0.5f, -0.5f);
            Vector2 point2 = new Vector2(-0.5f, 0.5f);
            LineSegment line = new LineSegment(point1, point2);
            var (A, B, C) = line.GetCoefs();
            var (expectedA, expectedB, expectedC) = (1, 0, -0.5f);
            Assert.AreEqual(expectedA, A);
            Assert.AreEqual(expectedB, B);
            Assert.AreEqual(expectedC, C);
        }

        [Test]
        public void GetCoefsFromLineTest3()
        {
            Vector2 point1 = new Vector2(0, 0);
            Vector2 point2 = new Vector2(1, 1);
            LineSegment line = new LineSegment(point1, point2);
            var (A, B, C) = line.GetCoefs();
            var (expectedA, expectedB, expectedC) = (1, -1, 0);
            Assert.AreEqual(expectedA, A);
            Assert.AreEqual(expectedB, B);
            Assert.AreEqual(expectedC, C);
        }

        [Test]
        public void GetIntersectPoint_Positive()
        {
            LineSegment line1 = new LineSegment(new Vector2(-5, 1), new Vector2(5, 1));
            LineSegment line2 = new LineSegment(new Vector2(1, -5), new Vector2(1, 5));
            Vector2 point = line1.GetIntersectPoint(line2);
            Vector2 desirablePoint = new Vector2(1, 1);
            float epsilon = 0.0001f;
            Assert.That(Vector3.Distance(point, desirablePoint) < epsilon);
        }

        [Test]
        public void GetIntersectPoint_Negative()
        {
            LineSegment line1 = new LineSegment(new Vector2(-2, 0), new Vector2(2, 0));
            LineSegment line2 = new LineSegment(new Vector2(-4, 0), new Vector2(4, 0));
            Assert.Throws<ArgumentException>(() => line1.GetIntersectPoint(line2));
        }

    }
}
