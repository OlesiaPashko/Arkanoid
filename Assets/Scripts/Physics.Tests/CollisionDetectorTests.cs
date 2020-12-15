﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CollisionDetectorTests
    {
        [Test]
        public void IsCollision2LinesTest()
        {
            Line line1 = new Line { A = 1, B = 0, C = 0 };
            Line line2 = new Line { A = 1, B = 0, C = 1 };
            Assert.IsFalse(CollisionDetector.IsCollision(line1, line2));
        }

        [Test]
        public void IsCollision2LinesTest2()
        {
            Line line1 = new Line { A = 1, B = 0, C = 0 };
            Line line2 = new Line { A = 0, B = 1, C = 0 };
            Assert.IsTrue(CollisionDetector.IsCollision(line1, line2));
        }

        [Test]
        public void IsPointOnLineTest()
        {
            bool isOnLine = CollisionDetector.IsPointOnLine(new Line { A = 1, B = 0, C = 1 }, new Vector2(0, 0), 0.00001f);
            Assert.IsFalse(isOnLine);
        }

        [Test]
        public void IsPointOnLineTest2()
        {
            bool isOnLine = CollisionDetector.IsPointOnLine(new Line { A = 1, B = 0, C = 1, startPoint = new Vector2(1,-1), endPoint = new Vector2(1, 1) }, new Vector2(1, 0), 0.001f);
            Assert.IsTrue(isOnLine);
        }

        [Test]
        public void GetLinesFromRectTest()
        {
            Rectangle rect = new Rectangle() { A = new Vector2(0, 0), B = new Vector2(0, 1), C = new Vector2(1, 1), D = new Vector2(1, 0) };
            Line[] lines = CollisionDetector.GetLinesFromRectangle(rect);
            Line[] expected = new Line[]
            {
                new Line{A = 0, B = 1, C = 1, startPoint = new Vector2(1, 1), endPoint = new Vector2(0, 1)},
                new Line{A = 0, B = -1, C = 0, startPoint = new Vector2(0, 0), endPoint = new Vector2(1, 0)},
                new Line{A = -1, B = 0, C = -1, startPoint = new Vector2(1, 1), endPoint = new Vector2(1, 0)},
                new Line{A = 1, B = 0, C = 0, startPoint = new Vector2(0, 0), endPoint = new Vector2(0, 1)}
            };
            CollectionAssert.AreEquivalent(expected, lines);
        }

        [Test]
        public void GetLineFromPointsTest()
        {
            Vector2 point1 = new Vector2(0.5f, 0.5f);
            Vector2 point2 = new Vector2(-0.5f, 0.5f);
            Line line = CollisionDetector.GetLineFromPoints(point1, point2);
            Assert.AreEqual(new Line { A = 0, B = 1, C = 0.5f, startPoint = new Vector2(0.5f,0.5f), endPoint = new Vector2(-0.5f, 0.5f) }, line);
        }

        [Test]
        public void GetLineFromPointsTest2()
        {
            Vector2 point1 = new Vector2(-0.5f, -0.5f);
            Vector2 point2 = new Vector2(-0.5f, 0.5f);
            Line line = CollisionDetector.GetLineFromPoints(point1, point2);
            Assert.AreEqual(new Line { A = 1, B = 0, C = -0.5f, startPoint = new Vector2(-0.5f, -0.5f), endPoint = new Vector2(-0.5f, 0.5f) }, line);
        }


        [Test]
        public void LinesCollisionTest()
        {
            Vector2 point = CollisionDetector.GetIntersectPoint(new Line { A = 0, B = 1, C = 1}, new Line { A=1, B=0, C=1});
            Vector2 desirablePoint = new Vector2(1, 1);
            float epsilon = 0.0001f;
            Assert.That(Vector3.Distance(point, desirablePoint) < epsilon);
        }

        [Test]
        public void LinesCollisionTest2()
        {
            Vector2 point = CollisionDetector.GetIntersectPoint(new Line { A = 1, B = 1, C = 2 }, new Line { A = 1, B = -1, C = 0 });
            Vector2 desirablePoint = new Vector2(1, 1);
            float epsilon = 0.0001f;
            Assert.That(Vector3.Distance(point, desirablePoint) < epsilon);
        }

        [Test]
        public void AlignedRectsCollisionTest()
        {
            Rectangle rect1 = new Rectangle() { A = new Vector2(0, 0), B = new Vector2(0, 2), C = new Vector2(2, 2), D = new Vector2(2, 0) };
            Rectangle rect2 = new Rectangle() { A = new Vector2(3, 0), B = new Vector2(3, 4), C = new Vector2(7, 4), D = new Vector2(7, 0) };
            bool isCollision = CollisionDetector.IsCollision(rect1, rect2);
            Assert.IsFalse(isCollision);
        }

        [Test]
        public void AlignedRectsCollisionTest2()
        {
            Rectangle rect1 = new Rectangle() { A = new Vector2(0, 0), B = new Vector2(0, 1), C = new Vector2(1, 1), D = new Vector2(1, 0) };
            Rectangle rect2 = new Rectangle() { A = new Vector2(1, 1), B = new Vector2(1, 3), C = new Vector2(3, 3), D = new Vector2(3, 1) };
            bool isCollision = CollisionDetector.IsCollision(rect1, rect2);
            Assert.IsTrue(isCollision);
        }

        [Test]
        public void AlignedRectsCollisionTest3()
        {
            Rectangle rect1 = new Rectangle() { A = new Vector2(0, -1), B = new Vector2(-1, 1), C = new Vector2(0, 1), D = new Vector2(0, 0) };
            Rectangle rect2 = new Rectangle() { A = new Vector2(-0.5f, -1), B = new Vector2(0.5f, 1), C = new Vector2(0.5f, 0.5f), D = new Vector2(0.5f, -1) };
            bool isCollision = CollisionDetector.IsCollision(rect1, rect2);
            Assert.IsTrue(isCollision);
        }

        [Test]
        public void RotatedRectsCollisionTest()
        {
            Rectangle rect1 = new Rectangle() { A = new Vector2(-1, 0), B = new Vector2(0, 1), C = new Vector2(1, 0), D = new Vector2(0, -1) };
            Rectangle rect2 = new Rectangle() { A = new Vector2(0, 0), B = new Vector2(0, 1), C = new Vector2(1, 1), D = new Vector2(1, 0) };
            bool isCollision = CollisionDetector.IsCollision(rect1, rect2);
            Assert.IsTrue(isCollision);
        }

        [Test]
        public void RotatedRectsCollisionTest2()
        {
            Rectangle rect1 = new Rectangle() { A = new Vector2(-1, 0), B = new Vector2(0, 1), C = new Vector2(1, 0), D = new Vector2(0, -1) };
            Rectangle rect2 = new Rectangle() { A = new Vector2(-2, 1), B = new Vector2(-1, 2), C = new Vector2(0, 1), D = new Vector2(-1, 0) };
            bool isCollision = CollisionDetector.IsCollision(rect1, rect2);
            Assert.IsTrue(isCollision);
        }

        [Test]
        public void RotatedRectsCollisionTest3()
        {
            Rectangle rect1 = new Rectangle() { A = new Vector2(-1, 0), B = new Vector2(0, 1), C = new Vector2(1, 0), D = new Vector2(0, -1) };
            Rectangle rect2 = new Rectangle() { A = new Vector2(-1.5f, 1.5f), B = new Vector2(-1, 2), C = new Vector2(-0.5f, 1.5f), D = new Vector2(-1, 1) };
            bool isCollision = CollisionDetector.IsCollision(rect1, rect2);
            Assert.IsFalse(isCollision);
        }
    }
}