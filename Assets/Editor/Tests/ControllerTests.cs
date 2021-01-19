using NUnit.Framework;

namespace Tests {
    
    public class ControllerTest {
        
        public class Merge {

            [Test]
            public void PlaceholderTest() {
                var controller = new Controller();
                Assert.AreEqual(true, false);
            }

            [Test]
            public void ReturnsOneRune() {
                var controller = new Controller();
                Assert.AreEqual(true, false);
            }

            [Test]
            public void DestroysUsedRunes() {
                var controller = new Controller();
                Assert.AreEqual(true, false);
            }

            [Test]
            public void SameRarity() {
                var controller = new Controller();
                Assert.AreEqual(true, false);
            }
        }

        public class PurchaseRunes {

            [Test]
            public void ReturnsFourRunes() {
                var controller = new Controller();
                Assert.AreEqual(true, false);
            }

            [Test]
            public void RunesAreCommonQuality() {
                var controller = new Controller();
                Assert.AreEqual(true, false);
            }

        }

        public class Inventory {

            [Test]
            public void NotEqual() {
                IInventory playerInventory = new PlayerInventory();
                IInventory mergeInventory = new MergeInventory();

                Assert.AreNotEqual(playerInventory, mergeInventory);
            }
        }

        public class Move {
            IInventory playerInventory;
            IInventory mergeInventory;

            public Move() {
                playerInventory = new PlayerInventory();
                mergeInventory = new MergeInventory();
            }


            [Test]
            public void ToAndFromAreNotEqual() {
                Assert.AreNotEqual(playerInventory, mergeInventory);
            }
        }

        public class AddToInventory {

            [Test]
            public void PlaceholderTest() {
                var controller = new Controller();
                Assert.AreEqual(true, false);
            }
        }

        public class RemoveFromInventory {

            [Test]
            public void PlaceholderTest() {
                var controller = new Controller();
                Assert.AreEqual(true, false);
            }
        }
    }
}
