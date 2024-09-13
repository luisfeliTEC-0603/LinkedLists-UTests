using Data_Structures;
namespace UTest;

[TestClass]
public class UnitTest3
{
    [TestClass]
    public class LinkedListTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetMiddle_EmptyList_ThrowsException()
        {
            LinkedList list = new LinkedList();
            list.GetMiddle();
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void GetMiddle_NullList_ThrowsException()
        {
            LinkedList list = null;
            list.GetMiddle();
        }

        [TestMethod]
        public void GetMiddle_SingleElement_ReturnsElement()
        {
            LinkedList list = new LinkedList();
            list.InsertInOrder(1);

            Assert.AreEqual(1, list.GetMiddle());
        }

        [TestMethod]
        public void GetMiddle_TwoElements_ReturnsSecondElement()
        {
            LinkedList list = new LinkedList();
            list.InsertInOrder(1);
            list.InsertInOrder(2);

            Assert.AreEqual(1, list.GetMiddle());
        }

        [TestMethod]
        public void GetMiddle_ThreeElements_ReturnsMiddleElement()
        {
            LinkedList list = new LinkedList();
            list.InsertInOrder(0);
            list.InsertInOrder(1);
            list.InsertInOrder(2);

            Assert.AreEqual(1, list.GetMiddle());
        }

        [TestMethod]
        public void GetMiddle_FourElements_ReturnsSecondMiddleElement()
        {
            LinkedList list = new LinkedList();
            list.InsertInOrder(9);
            list.InsertInOrder(12);
            list.InsertInOrder(11);
            list.InsertInOrder(13);

            Assert.AreEqual(11, list.GetMiddle());
        }
    }
}   