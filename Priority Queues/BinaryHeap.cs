using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues
{

    public class BinaryHeap
    {
        /// <summary>
        /// Constructs a binary heap containing the given elements.
        /// </summary>
        public BinaryHeap(int[] heapArray)
        {
            this.heapArray = heapArray;
            heapSize = heapArray.Length;
            BinaryHeapHelper.MakeHeap(this.heapArray, heapSize);
        }

        /// <summary>
        /// Creates an empty binary heap.
        /// </summary>
        /// <param name="heapArray"></param>
        public BinaryHeap()
        {
            heapArray = new int[10];
            heapSize = 0;
        }
        int[] heapArray;
        int heapSize;

        /// <summary>
        /// Return the element with the highest priority without removing it.
        ///  <para>BinaryHeapException:</para>
        /// Thrown if the heap is empty.
        /// </summary>
        /// <exception cref="BinaryHeapException"></exception>
        public int Peek()
        {
            if (heapSize == 0)
                throw new BinaryHeapException("Failed to perform the Pop operation since the queue is empty");
            return heapArray[0];
        }

        /// <summary>
        /// Removes and returns the element with the highest priority in the queue.
        /// <para>BinaryHeapException:</para>
        /// Thrown if the heap is empty.
        /// </summary>
        /// <exception cref="BinaryHeapException"></exception>
        public int Pop()
        {
            if (heapSize == 0)
                throw new BinaryHeapException("Failed to perform the Pop operation since the queue is empty");
            int result = heapArray[0];
            heapArray[0] = heapArray[heapSize - 1];
            heapSize--;
            BinaryHeapHelper.SiftDown(0, heapArray, heapSize);
            return result;
        }

        /// <summary>
        /// Insert a new element to the heap, and maintain the heap oreder.
        /// <para>BinaryHeapException:</para>
        /// Thrown if the heap is full.
        /// </summary>
        /// <exception cref="BinaryHeapException"></exception>
        /// </summary>
        public void insert(int element)
        {
            if (heapSize == heapArray.Length)
                throw new BinaryHeapException("Failed to insert because the heap is full");
            heapArray[heapSize] = element;
            heapSize++;
            BinaryHeapHelper.SiftUp(heapSize - 1, heapArray, heapSize);
        }

        /// <summary>
        /// Returns the number of elements in the heap
        /// </summary>
        public int GetSize()
        {
            return heapSize;
        }
    }

    /// <summary>
    /// This class contains helper methods for binary heap operations.
    /// These methods are put in a separate class (and not as private methods of the BinaryHeap class)
    /// in order for them to be unit tested.
    /// </summary>
    public static class BinaryHeapHelper
    {
        /// <summary>
        /// Given an index in the heap array, this method returns the index of the right child of this element.
        /// </summary>
        public static int RightChild(int index)
        {
            return 2 * index + 2;
        }
        /// <summary>
        /// Given an index in the heap array, this method returns the index of the left child of this element.
        /// </summary>
        public static int LeftChild(int index)
        {
            return 2 * index + 1;
        }
        /// <summary>
        /// Given an index in the heap array, this method returns the index of the parent of this element.
        /// </summary>
        public static int Parent(int index)
        {
            return (int)Math.Ceiling((float)index / 2) - 1;
        }
        private static void SwitchElementsInArray(int index1, int index2, int[] array)
        {
            int temp = array[index1];
            array[index1] = array[index2];
            array[index2] = temp;
        }

        /// <summary>
        /// This method helps to maintain the heap order. Given an element in the heap we sift it down the heap until it 
        /// holds the heap property with respect to its children (i.e. it is smaller or equal to its children in case of
        /// a min heap).
        /// </summary>
        /// <param name="index">the index of some element in the heap, for which we suspect the heap property does not hold,
        /// i.e. it might be larger than one of its children (for a min heap).</param>
        /// <param name="heapArray">The array containing the heap.</param>
        public static void SiftDown(int index, int[] heapArray, int heapSize)
        {
            if (LeftChild(index) >= heapSize)
                return;
            if (RightChild(index) >= heapSize)
            {
                if (heapArray[index] > heapArray[LeftChild(index)])
                    SwitchElementsInArray(index, LeftChild(index), heapArray);
                return;
            }

            if (heapArray[index] <= heapArray[LeftChild(index)] && heapArray[index] <= heapArray[RightChild(index)])
                return;
            int smallerChildIndex = heapArray[LeftChild(index)] < heapArray[RightChild(index)] ? LeftChild(index) : RightChild(index);
            SwitchElementsInArray(index, smallerChildIndex, heapArray);
            SiftDown(smallerChildIndex, heapArray, heapSize);
        }

        /// <summary>
        /// This method helps to maintain the heap order. Given an element in the heap we sift it up the heap until it 
        /// holds the heap property with respect to its parent (i.e. it is smaller than its parent in case of
        /// a min heap).
        /// </summary>
        /// <param name="index">the index of some element in the heap, for which we suspect the heap property does not hold,
        /// i.e. it might be smaller than its parent (for a min heap).</param>
        /// <param name="heapArray">The array containing the heap.</param>
        public static void SiftUp(int index, int[] heapArray, int heapSize)
        {
            if (Parent(index) < 0)
                return;

            if (heapArray[index] >= heapArray[Parent(index)])
                return;
            SwitchElementsInArray(index, Parent(index), heapArray);
            SiftUp(Parent(index), heapArray, heapSize);
        }
        /// <summary>
        /// This method builds a heap in the given array in linear time. It uses the sift down operation to iteratively 
        /// "heapify" the array. In iteration i we process the array s.t. all elemtnts at depth d-i have the heap property 
        /// w.r.t their children (where d is the max depth in the heap).
        /// </summary>
        /// <param name="heapArray"></param>
        public static void MakeHeap(int[] heapArray, int heapSize)
        {
            int numOfIterations = (int)Math.Floor(Math.Log(heapSize, 2));

            for (int i = numOfIterations - 1; i >= 0; i--)
            {
                for (int j = (int)Math.Pow(2, i) - 1; j < (int)Math.Pow(2 , i + 1) - 1; j++)
                {
                    //check if the following nodes in the level don't have children (can only happen in the first iteration)
                    if (LeftChild(j) >= heapSize)
                        break;
                    SiftDown(j, heapArray, heapSize);
                }
            }
        }
    }
}

public class BinaryHeapException : Exception
{
    public BinaryHeapException(string message) : base(message)
    {

    }
}

