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
            //Hier brauche ich eine Funktion, die kontrolliert, ob ich jede Karte einmal habe
            CardDeck cd1 = new CardDeck(0);
            CardDeck cd2 = new CardDeck(1);

            foreach(var c in cd1.list)
            {
                if (cd2.list.IndexOf(c) != -1)
                    Assert.AreSame(c, cd2.list.IndexOf(c));
            }       
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