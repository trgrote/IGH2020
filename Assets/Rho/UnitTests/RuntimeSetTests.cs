using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using rho;

namespace Tests
{
    public class RuntimeSetTests
    {
        internal class RuntimeIntSet : RuntimeSet<int>{}

        [Test]
        public void RumtimeSetAdd()
        {
            var runtimeSet = ScriptableObject.CreateInstance<RuntimeIntSet>();

            Assert.DoesNotThrow(() => runtimeSet.Add(5));
        }

        [Test]
        public void RumtimeSetContains()
        {
            var runtimeSet = ScriptableObject.CreateInstance<RuntimeIntSet>();
            runtimeSet.Add(5);

            Assert.True(runtimeSet.Contains(5));
        }

        [Test]
        public void RumtimeSetRemove()
        {
            var runtimeSet = ScriptableObject.CreateInstance<RuntimeIntSet>();
            runtimeSet.Add(5);
            runtimeSet.Remove(5);

            Assert.False(runtimeSet.Contains(5));
        }
    }
}
