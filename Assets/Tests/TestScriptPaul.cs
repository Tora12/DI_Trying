﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TestScriptPaul
    {
        // A Test behaves as an ordinary method
        [Test]
        public void TestScriptPaulSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator TestScriptPaulWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            GameObject gameObject = Resources.Load<GameObject>("Prefabs/Enemies/Enemies/Tower_GaussGun.prefab");
            yield return null;
        }
    }
}
