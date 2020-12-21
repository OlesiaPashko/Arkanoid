using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CollisionDetectorTests
    {

        [Test]
        public void IsCollisionLineAndCircle_Negative()
        {
            LineSegment line1 = new LineSegment(new Vector2(1, -1), new Vector2(1, 1));
            Circle circle = new Circle() { radius = 0.5f, position = new Vector2(-1, 0) };
            Assert.IsFalse(CollisionDetector.IsCollision(line1, circle));
        }

        [Test]
        public void IsCollisionLineAndCircle_Positive()
        {
            LineSegment line1 = new LineSegment(new Vector2(1, -1), new Vector2(1, 1));
            Circle circle = new Circle() { radius = 0.5f, position = new Vector2(0.5f, 0) };
            Assert.IsTrue(CollisionDetector.IsCollision(line1, circle));
        }

        [Test]
        public void AlignedRectsCollision_Negative()
        {
            Rectangle rect1 = new Rectangle() { A = new Vector2(0, 0), B = new Vector2(0, 2), C = new Vector2(2, 2), D = new Vector2(2, 0) };
            Rectangle rect2 = new Rectangle() { A = new Vector2(3, 0), B = new Vector2(3, 4), C = new Vector2(7, 4), D = new Vector2(7, 0) };
            bool isCollision = CollisionDetector.IsCollision(rect1, rect2);
            Assert.IsFalse(isCollision);
        }

        [Test]
        public void AlignedRectsCollision_Positive()
        {
            Rectangle rect1 = new Rectangle() { A = new Vector2(0, 0), B = new Vector2(0, 1), C = new Vector2(1, 1), D = new Vector2(1, 0) };
            Rectangle rect2 = new Rectangle() { A = new Vector2(1, 1), B = new Vector2(1, 3), C = new Vector2(3, 3), D = new Vector2(3, 1) };
            bool isCollision = CollisionDetector.IsCollision(rect1, rect2);
            Assert.IsTrue(isCollision);
        }

        [Test]
        public void RotatedRectsCollision_PositiveOverlap()
        {
            Rectangle rect1 = new Rectangle() { A = new Vector2(0, -1), B = new Vector2(-1, 1), C = new Vector2(0, 1), D = new Vector2(1, -1) };
            Rectangle rect2 = new Rectangle() { A = new Vector2(-0.5f, -1), B = new Vector2(0.5f, 1), C = new Vector2(0.5f, 0.5f), D = new Vector2(0.5f, -1.5f) };
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
