using Data_Structures;
namespace UTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void MergeSorted_ListA_Null_ThrowsException()
    {
        LinkedList listA = null;
        LinkedList listB = new LinkedList();
        listB.InsertInOrder(1);

        listA.MergeSorted(listA, listB, SortDirection.Ascending);
    }

    [TestMethod]
    [ExpectedException(typeof(NullReferenceException))]
    public void MergeSorted_ListB_Null_ThrowsException()
    {
        LinkedList listA = new LinkedList();
        listA.InsertInOrder(1);
        LinkedList listB = null;

        listA.MergeSorted(listA, listB, SortDirection.Ascending);
    }

    [TestMethod]
    public void MergeSorted_ListA_And_ListB_Ascending()
    {
        LinkedList listA = new LinkedList();
        listA.InsertInOrder(0);
        listA.InsertInOrder(2);
        listA.InsertInOrder(6);
        listA.InsertInOrder(10);
        listA.InsertInOrder(25);

        LinkedList listB = new LinkedList();
        listB.InsertInOrder(3);
        listB.InsertInOrder(7);
        listB.InsertInOrder(11);
        listB.InsertInOrder(40);
        listB.InsertInOrder(50);

        listA.MergeSorted(listA, listB, SortDirection.Ascending);

        CollectionAssert.AreEqual(new int[] { 0, 2, 3, 6, 7, 10, 11, 25, 40, 50 }, listA.ToArray());
    }

    [TestMethod]
    public void MergeSorted_ListA_And_ListB_Descending()
    {
        LinkedList listA = new LinkedList();
        listA.InsertInOrder(10);
        listA.InsertInOrder(15);

        LinkedList listB = new LinkedList();
        listB.InsertInOrder(9);
        listB.InsertInOrder(40);
        listB.InsertInOrder(50);

        listA.MergeSorted(listA, listB, SortDirection.Descending);

        CollectionAssert.AreEqual(new int[] { 50, 40, 15, 10, 9 }, listA.ToArray());
    }

    [TestMethod]
    public void MergeSorted_ListA_Empty_And_ListB_Descending()
    {
        LinkedList listA = new LinkedList();
        LinkedList listB = new LinkedList();
        listB.InsertInOrder(9);
        listB.InsertInOrder(40);
        listB.InsertInOrder(50);

        listA.MergeSorted(listA, listB, SortDirection.Descending);

        CollectionAssert.AreEqual(new int[] { 50, 40, 9 }, listA.ToArray());
    }

    [TestMethod]
    public void MergeSorted_ListA_And_ListB_Empty_Ascending()
    {
        LinkedList listA = new LinkedList();
        listA.InsertInOrder(10);
        listA.InsertInOrder(15);

        LinkedList listB = new LinkedList(); 

        listA.MergeSorted(listA, listB, SortDirection.Ascending);

        CollectionAssert.AreEqual(new int[] { 10, 15 }, listA.ToArray());
    }
}
