using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class ForceTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void ForceTestsSimplePasses()
        {
            Line line = new Line { A = 1, B = 1, C = 0, startPoint = new Vector2(-1, 1), endPoint = new Vector2(1, -1) };
            Vector2 refVector = Force.SpecularReflection(new Vector2(4, 0), line);

            var delta = 1E-6;
            var expectedVec = new Vector2(0, -4);

            Assert.AreEqual(refVector.x, expectedVec.x, delta);
            Assert.AreEqual(refVector.y, expectedVec.y, delta);
        }
    }
}
