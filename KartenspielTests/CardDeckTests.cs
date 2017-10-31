using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kartenspiel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kartenspiel.Tests
{
    [TestClass()]
    public class CardDeckTests
    {
        [TestMethod()]
        public void ShuffleCardDeckTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void isEmptyTest()
        {
            Kartenspiel.CardDeck cd = new CardDeck();
            Assert.IsFalse(cd.isEmpty());
            for (int i = 0; i < 31; i++) cd.GetFirstCard();
            Assert.IsTrue(cd.isEmpty());
        }
    }
}