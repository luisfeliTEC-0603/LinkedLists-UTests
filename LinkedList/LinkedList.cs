
namespace Data_Structure
{
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
        private int lenght;

        public LinkedList()
        {
            head = null;
            middle = null;
            tail = null; 
            lenght = 0; 
        }

        public bool isEmpty => lenght <= 0; 

        public void InsertInOrder(int value)
        {
            Node newNode = new Node(value);

            if (isEmpty) head = tail = middle = newNode;
            else 
            {
                Node current = head;

                while (current != null) 
                {
                    if (current.Value >= value || current == tail)
                    {
                        newNode.Prev = current;
                        newNode.Next = current.Next;
                        current.Next.Prev = newNode;
                        current.Next = newNode;

                        if (current == tail) tail = newNode;

                        break;
                    }

                    current = current.Next;
                }            
            }

            lenght++;

            if (lenght % 2 == 1) middle = middle.Next;
        }

        public int DeleteFirst()
        {
            if (isEmpty) throw new InvalidOperationException("The list is empty.");

            int value = head.Value;

            if (lenght == 1) head = tail = middle = null;
            else
            {
                head = head.Next;
                head.Prev = tail;

                if (lenght % 2 == 0) middle = middle.Next;
            }

            lenght--;
            return value;
        }

        public int DeleteLast()
        {
            if (isEmpty) throw new InvalidOperationException("The list is empty.");

            int value = tail.Value;

            if (lenght == 1) head = tail = middle = null;
            else
            {
                tail = tail.Prev;
                tail.Next = head;

                if (lenght % 2 == 0) middle = middle.Prev;
            }

            lenght--;
            return value;
        }

        /*
        public bool DeleteValue(int value)
        {

        }

        public int GetMiddle()
        {

        }
        */

        public void MergeSorted(LinkedList listA, LinkedList listB)
        {
            if (listA == null || listB == null) throw new ArgumentNullException("Lists must be non-null.");
        }

        public void Invert()
        {
            if (isEmpty) return;

            Node current = head;
            Node temp = null;

            while (current != null)
            {
                temp = current.Prev;
                current.Prev = current.Next;
                current.Next = temp;
                current = current.Prev;
            }

            if (temp != null) head = temp.Prev;
        }
    }
}