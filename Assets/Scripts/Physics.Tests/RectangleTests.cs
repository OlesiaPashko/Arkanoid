using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class RectangleTests
    {

        [Test]
        public void GetLinesTest()
        {
            var A = new Vector2(0, 0);
            var B = new Vector2(0, 1);
            var C = new Vector2(1, 1);
            var D = new Vector2(1, 0);
            Rectangle rect = new Rectangle() { A = A, B = B, C = C, D = D };
            LineSegment[] lines = rect.GetLines();
            LineSegment[] expected = new LineSegment[]
            {
                new LineSegment(A, B),
                new LineSegment(A, D),
                new LineSegment(C, B),
                new LineSegment(C, D)
            };
            CollectionAssert.AreEquivalent(expected, lines);
        }
    }
}
