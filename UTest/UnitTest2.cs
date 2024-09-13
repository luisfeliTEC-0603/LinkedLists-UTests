using Data_Structures;
namespace UTest;

[TestClass]
public class UnitTest2
{
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void Invert_NullList_ThrowsException()
    {
        LinkedList list = null;
        list.Invert();
    }

    [TestMethod]
    public void Invert_EmptyList_RemainsEmpty()
    {
        LinkedList list = new LinkedList();

        list.Invert();

        CollectionAssert.AreEqual(new int[] { }, list.ToArray());
    }

    [TestMethod]
    public void Invert_ListWithMultipleElements_InvertsCorrectly()
    {
        LinkedList list = new LinkedList();
        list.InsertLast(1);
        list.InsertLast(0);
        list.InsertLast(30);
        list.InsertLast(50);
        list.InsertLast(2);

        list.Invert();

        CollectionAssert.AreEqual(new int[] { 2, 50, 30, 0, 1 }, list.ToArray());
    }

    [TestMethod]
    public void Invert_SingleElementList_RemainsSame()
    {
        LinkedList list = new LinkedList();
        list.InsertInOrder(2);

        list.Invert();

        CollectionAssert.AreEqual(new int[] { 2 }, list.ToArray());
    }
}
