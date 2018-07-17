using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumMinimum_Of_AllSubarrays_Of_SizeK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 8, 5, 10, 7, 9, 4, 15, 12, 90, 13 };//{ 1, 2, 3, 1, 4, 5, 2, 3, 6 };//{ 12, 1, 78, 90, 57, 89, 56 };
            int n = arr.Length;
            int k = 3;
            PrintKMax(arr, n, k);
            Console.WriteLine();
            PrintKMin(arr, n, k);
        }

        // A Dequeue (Double ended queue) based method for printing maixmum element of
        // all subarrays of size k
        static void PrintKMax(int[] arr, int n, int k)
        {
            // Create a Double Ended Queue, Qi that will store indexes of array elements
            // The queue will store indexes of useful elements in every window and it will
            // maintain decreasing order of values from front to rear in Qi, i.e., 
            // arr[Qi.front[]] to arr[Qi.rear()] are sorted in decreasing order
            //std::deque<int> Qi(k);
            DeQueue Qi = new DeQueue(); 

            /* Process first k (or first window) elements of array */
            int i;
            for (i = 0; i < k; ++i)
            {
                // For very element, the previous smaller elements are useless so
                // remove them from Qi
                while (!Qi.IsEmpty() && (arr[i] >= arr[Qi.Back().Data]))
                    Qi.Eject();  // Remove from rear

                // Add new element at rear of queue
                Qi.Inject(i);
            }

            // Process rest of the elements, i.e., from arr[k] to arr[n-1]
            for (; i < n; ++i)
            {
                // The element at the front of the queue is the largest element of
                // previous window, so print it
                Console.WriteLine("**** " +  arr[Qi.Front().Data] + " ");

                // Remove the elements which are out of this window
                // ##3
                while ((!Qi.IsEmpty()) && Qi.Front().Data <= (i - k))
                    Qi.Pop();  // Remove from front of queue

                // Remove all elements smaller than the currently
                // being added element (remove useless elements)
                while ((!Qi.IsEmpty()) && arr[i] >= arr[Qi.Back().Data])
                    Qi.Eject();

                // Add current element at the rear of Qi
                Qi.Inject(i);
            }

            // Print the maximum element of last window
            Console.Write("**** " + arr[Qi.Front().Data]);
        }

        static void PrintKMin(int[] arr, int n, int k)
        {
            // Create a Double Ended Queue, Qi that will store indexes of array elements
            // The queue will store indexes of useful elements in every window and it will
            // maintain decreasing order of values from front to rear in Qi, i.e., 
            // arr[Qi.front[]] to arr[Qi.rear()] are sorted in decreasing order
            //std::deque<int> Qi(k);
            DeQueue Qi = new DeQueue();

            /* Process first k (or first window) elements of array */
            int i;
            for (i = 0; i < k; ++i)
            {
                // For very element, the previous smaller elements are useless so
                // remove them from Qi
                while (!Qi.IsEmpty() && (arr[i] <= arr[Qi.Back().Data]))
                    Qi.Eject();  // Remove from rear

                // Add new element at rear of queue
                Qi.Inject(i);
            }

            // Process rest of the elements, i.e., from arr[k] to arr[n-1]
            for (; i < n; ++i)
            {
                // The element at the front of the queue is the largest element of
                // previous window, so print it
                Console.WriteLine("**** " + arr[Qi.Front().Data] + " ");

                // Remove the elements which are out of this window
                while ((!Qi.IsEmpty()) && Qi.Front().Data <= (i - k))
                    Qi.Pop();  // Remove from front of queue

                // Remove all elements smaller than the currently
                // being added element (remove useless elements)
                while ((!Qi.IsEmpty()) && arr[i] <= arr[Qi.Back().Data])
                    Qi.Eject();

                // Add current element at the rear of Qi
                Qi.Inject(i);
            }

            // Print the maximum element of last window
            Console.Write(arr[Qi.Front().Data]);
        }
    }



    public class QNode
    {
        public int Data { get; set; }
        public QNode Next { get; set; }
        public QNode Prev { get; set; }

        public QNode(int data)
        {
            this.Data = data;
            this.Next = null;
            this.Prev = null;
        }
    }

    public class DeQueue
    {
        private QNode Head = null;
        private QNode Tail = null;

        public void Push(int data)
        {
            Console.WriteLine("Pushing - {0} to front.", data);
            var newNode = new QNode(data);

            if (null == Head)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                Head.Prev = newNode;
                newNode.Next = Head;
                Head = newNode;
            }
        }

        public QNode Pop()
        {
            if (null == Head)
            {
                Console.WriteLine("Queue is Empty!");
                return null;
            }
            Console.WriteLine("Popping - {0} from Front.", Head.Data);

            var tempHead = Head;
            Head = Head.Next;
            Head.Prev = null;

            if (null == Head)
            {
                Tail = null;
            }
            return tempHead;
        }

        public void Inject(int data)
        {
            Console.WriteLine("Injecting - {0} in the end.", data);
            var newNode = new QNode(data);
            if (null == Head)
            {
                Head = newNode;
                Tail = newNode;
            }
            else
            {
                newNode.Prev = Tail;
                Tail.Next = newNode;
                Tail = newNode;
            }
        }

        public QNode Eject()
        {
            var tempTail = Tail;
            if (null == tempTail)
            {
                Console.WriteLine("Queue Empty!");
                return null;
            }
            Console.WriteLine("Ejecting - {0} in the end.", this.Tail.Data);
            Tail = Tail.Prev;
            if (null == Tail)
            {
                Head = null;
            }
            else
            {
                Tail.Next = null;
            }
            return tempTail;
        }

        public QNode Front()
        {
            return Head;
        }

        public QNode Back()
        {
            return Tail;
        }

        public bool IsEmpty()
        {
            return (Head == null);
        }
        public void PrintQueue(bool printUsingPrev)
        {
            QNode tempNode = null;
            if (!printUsingPrev)
                tempNode = Head;
            else
                tempNode = Tail;

            var sb = new StringBuilder();
            while (null != tempNode)
            {
                //Console.WriteLine(tempHead.Data);
                sb.Append(tempNode.Data);
                sb.Append("->");
                if (!printUsingPrev)
                    tempNode = tempNode.Next;
                else
                    tempNode = tempNode.Prev;
            }
            sb.Append("NULL");
            if (!printUsingPrev)
                Console.WriteLine("Deque (Using NEXT): {0}", sb.ToString());
            else
                Console.WriteLine("Deque (Using PREV): {0}", sb.ToString());

            if (null != Head)
                Console.WriteLine("Front is @ {0}", null != Head ? Head.Data.ToString() : "NULL");
            if (null != Tail)
                Console.WriteLine("Tail is @ {0}", null != Tail ? Tail.Data.ToString() : "NULL");
        }
    }
}


//http://www.geeksforgeeks.org/maximum-of-all-subarrays-of-size-k/

//Average Difficulty : 3.4/5.0
//Based on 152 vote(s)

/*

 ##3 --> 
    At max we compare k elements in subarray to find max.
    So, for current index, at max k previous elements inlcuding k can be compared.
    Hence exclude all which comes before. 
    And iteratively keep removing from front until above condition satisfies.
 */
