using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Tamagotchi.Assets.Entities;

public class tamagotchi_spec {
    [Test]
    public void tamagotchi_specSimplePasses() {
        // Use the Assert class to test conditions.
        var tama = new TamagotchiController("Ryan");
        Assert.AreEqual("Ryanf", tama.Name);
        Assert.IsNotEmpty(tama.CreatedDate);
    }

    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode
    [UnityTest]
    public IEnumerator tamagotchi_specWithEnumeratorPasses() {
        // Use the Assert class to test conditions.
        // yield to skip a frame
        yield return null;
    }
}
