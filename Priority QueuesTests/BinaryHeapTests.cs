using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityQueues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueues.Tests
{
    [TestClass()]
    public class BinaryHeapTests
    {
        [TestMethod()]
        public void BinaryHeapArrayCtorTest()
        {
            BinaryHeap binaryHeap = new BinaryHeap(new int[] { 11, 5, 33, 65, 10, 653, 14, 3, 16, 5, 4 });
            if (binaryHeap.GetSize() != 11)
                Assert.Fail();
            if (binaryHeap.Pop() != 3)
                Assert.Fail();
            if (binaryHeap.Pop() != 4)
                Assert.Fail();
            if (binaryHeap.Pop() != 5)
                Assert.Fail();
            if (binaryHeap.Pop() != 5)
                Assert.Fail();
            if (binaryHeap.Pop() != 10)
                Assert.Fail();
            if (binaryHeap.Pop() != 11)
                Assert.Fail();
            if (binaryHeap.Pop() != 14)
                Assert.Fail();
            if (binaryHeap.Pop() != 16)
                Assert.Fail();
            if (binaryHeap.Pop() != 33)
                Assert.Fail();
            if (binaryHeap.Pop() != 65)
                Assert.Fail();
            if (binaryHeap.Pop() != 653)
                Assert.Fail();
        }


        [TestMethod()]
        public void BinaryHeapPeekTest()
        {
            int[] array = new int[] { 11, 5, 33, 65, 10, 653, 14, 3, 16, 5, 4 };
            BinaryHeap binaryHeap = new BinaryHeap(array);
            if (binaryHeap.Peek() != 3)
                Assert.Fail();
        }

        [TestMethod()]
        public void BinaryHeapEmptyPeekTest()
        {
            BinaryHeap binaryHeap = new BinaryHeap();
            try
            {
                binaryHeap.Peek();
            }
            catch (BinaryHeapException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void BinaryHeapPopTest()
        {
            int[] array = new int[] { 11, 5, 33, 65, 10, 653, 14, 3, 16, 5, 4 };
            BinaryHeap binaryHeap = new BinaryHeap(array);
            if (binaryHeap.Pop() != 3)
                Assert.Fail();
            if (binaryHeap.Pop() != 4)
                Assert.Fail();
        }

        [TestMethod()]
        public void BinaryHeapEmptyPopTest()
        {
            BinaryHeap binaryHeap = new BinaryHeap();
            try
            {
                binaryHeap.Pop();
            }
            catch (BinaryHeapException)
            {
                return;
            }
            Assert.Fail();
        }

        [TestMethod()]
        public void BinaryHeapDefaultCtorTest()
        {
            BinaryHeap binaryHeap = new BinaryHeap();
            if (binaryHeap.GetSize() != 0)
                Assert.Fail();
        }

        [TestMethod()]
        public void insertSingleElementTest()
        {
            BinaryHeap heap = new BinaryHeap();
            heap.insert(13);
            if (heap.GetSize() != 1 || heap.Peek() != 13)
                Assert.Fail();
            heap.insert(15);
            if (heap.GetSize() != 2 || heap.Peek() != 13)
                Assert.Fail();
            heap.insert(18);
            if (heap.GetSize() != 3 || heap.Pop() != 13 || heap.Pop() != 15 || heap.Pop() != 18)
                Assert.Fail();


            heap = new BinaryHeap(new int[] { 1, 17, 13, 54, 74, 32, 22, 12, 14 });
            heap.Pop();
            heap.insert(81);
            if (heap.Pop() != 12)
                Assert.Fail();
            if (heap.Pop() != 13)
                Assert.Fail();
            if (heap.Pop() != 14)
                Assert.Fail();
            if (heap.Pop() != 17)
                Assert.Fail();
            if (heap.Pop() != 22)
                Assert.Fail();
            if (heap.Pop() != 32)
                Assert.Fail();
            if (heap.Pop() != 54)
                Assert.Fail();
            if (heap.Pop() != 74)
                Assert.Fail();
            if (heap.Pop() != 81)
                Assert.Fail();
        }

        [TestMethod()]
        public void insertIntoFullHeapTest()
        {
            BinaryHeap binaryHeap = new BinaryHeap(new int[] { 1, 2, 3 });
            try
            {
                binaryHeap.insert(4);
            }
            catch (BinaryHeapException)
            {
                return;
            }
            Assert.Fail();
        }
        
    }
}