namespace Data_Structures;

public enum SortDirection
{
    Ascending,
    Descending,
}

public class LinkedList
{
    public class Node 
    {
        public int Value;
        public Node Next;
        public Node Prev;

        public Node(int value)
        {
            Value = value;
        }
    }

    private Node head;
    private Node middle;
    private Node tail;
    private int length;

    public LinkedList()
    {
        head = null;
        middle = null;
        tail = null; 
        length = 0; 
    }

    private bool isEmpty => length <= 0; 

    private void Destroy()
    {
        head = null;
        middle = null;
        tail = null; 
        length = 0; 
    }

    public void InsertInOrder(int value)
    {
        Node newNode = new Node(value);

        if (isEmpty) 
        {
            head = tail = middle = newNode;
            head.Next = head;
            head.Prev = head;
        }
        else 
        {
            Node current = head;

            do
            {
                if (current.Value >= value)
                {
                    newNode.Prev = current.Prev;
                    newNode.Next = current;
                    current.Prev.Next = newNode;
                    current.Prev = newNode;

                    if (current == head) head = newNode;
                    break;
                }
                else if (current == tail) 
                {
                    newNode.Prev = tail;
                    newNode.Next = head;
                    tail.Next = newNode;
                    tail = newNode;
                    head.Prev = tail;
                    break;
                }

                current = current.Next;
            } while (current != head);    
        }

        length++;

        if (length % 2 == 1) middle = middle.Next;
    }

    public void InsertLast(int value)
    {
        Node newNode = new Node(value);

        if (isEmpty) 
        {
            head = tail = middle = newNode;
            head.Next = head;
            head.Prev = head;
        }
        else
        {
            newNode.Next = head;
            newNode.Prev = tail;
            head.Prev = newNode;
            tail.Next = newNode;
            tail = newNode;

        }

        length++;

        if (length % 2 == 1) middle = middle.Next;
    }

    public int DeleteFirst()
    {
        if (isEmpty) throw new InvalidOperationException("The list is empty.");

        int value = head.Value;

        if (length == 1) Destroy();
        else
        {
            head = head.Next;
            head.Prev = tail;
        }

        length--;
        if (length % 2 == 1) middle = middle.Next;

        return value;
    }

    public int DeleteLast()
    {
        if (isEmpty) throw new InvalidOperationException("The list is empty.");

        int value = tail.Value;

        if (length == 1) Destroy();
        else
        {
            tail = tail.Prev;
            tail.Next = head;
        }

        length--;
        if (length % 2 == 0) middle = middle.Prev;

        return value;
    }
    
    public int DeleteValue(int value)
    {
        if (isEmpty) throw new InvalidOperationException("The list is empty.");

        Node current = head;

        do
        {
            if (current.Value == value)
            {
                if (current == head) return DeleteFirst();
                if (current == tail) return DeleteLast();

                int deletedValue = current.Value;
                current.Prev.Next = current.Next;
                current.Next.Prev = current.Prev;

                if (length % 2 == 1) middle = middle.Prev;
                length--;
                return deletedValue;
            }

            current = current.Next;
        } while (current != head);

        throw new InvalidOperationException($"Value {value} not found in the list.");
    }

    public int GetMiddle()
    {
        if (isEmpty || this == null) throw new NullReferenceException("List must not be null or empty.");
        return middle.Value;
    }

    public void MergeSorted(LinkedList listA, LinkedList listB, SortDirection direction)
    {
        if (listA == null || listB == null) throw new NullReferenceException("Lists must be non-null.");

        if (listA.isEmpty && listB.isEmpty) throw new InvalidOperationException("List must not be empty.");

        if (listA.isEmpty)
        {
            Node currentB = listB.head;
            do
            {
                listA.InsertInOrder(currentB.Value);
                currentB = currentB.Next;
            } while (currentB != listB.head);

            listB.Destroy();
        }
        else
        {
            if (!listB.isEmpty)
            {
                Node currentB = listB.head;
                do
                {
                    listA.InsertInOrder(currentB.Value);
                    currentB = currentB.Next;
                } while (currentB != listB.head);
            }
        }

        if (direction == SortDirection.Descending)
        {
            listA.Invert();
        }
    }
    
    public void Invert()
    {
        if (this == null) throw new NullReferenceException("List must be non-null.");

        if (isEmpty) return;

        Node current = head;
        Node temp = null;

        do
        {
            temp = current.Prev;
            current.Prev = current.Next;
            current.Next = temp;
            current = current.Prev;
        } while (current != head);

        if (temp != null) 
        {
            head = temp.Prev;
            tail =  head.Prev;
            if (length % 2 == 0) middle = middle.Prev;
        }
    }
    
    public int[] ToArray()
    {
        int[] result = new int[length];
        
        Node current = head;
        for (int i = 0; i < length; i++)
        {
            result[i] = current.Value;
            current = current.Next;
        }

        return result;
    }

}