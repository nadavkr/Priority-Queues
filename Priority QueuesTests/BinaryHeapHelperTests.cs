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
    public class BinaryHeapHelperTests
    {
        [TestMethod()]
        public void RightChildTest()
        {
            if (BinaryHeapHelper.RightChild(0) != 2 || BinaryHeapHelper.RightChild(1) != 4 || BinaryHeapHelper.RightChild(3) != 8)
                Assert.Fail();
        }
        [TestMethod()]
        public void LeftChildTest()
        {
            if (BinaryHeapHelper.LeftChild(0) != 1 || BinaryHeapHelper.LeftChild(1) != 3 || BinaryHeapHelper.LeftChild(3) != 7)
                Assert.Fail();
        }

        [TestMethod()]
        public void ParentTest()
        {
            if (BinaryHeapHelper.Parent(1) != 0 || BinaryHeapHelper.Parent(2) != 0 || BinaryHeapHelper.Parent(3) != 1 || BinaryHeapHelper.Parent(4) != 1 || BinaryHeapHelper.Parent(9) != 4 || BinaryHeapHelper.Parent(10) != 4)
                Assert.Fail();
        }

        [TestMethod()]
        public void SiftDownTest()
        {
            int[] array = new int[] { 11, 5, 33, 65, 10, 653, 14, 3, 16, 5, 4 };
            BinaryHeapHelper.SiftDown(1, array, 11);
            if (array[1] != 5)
                Assert.Fail();
            BinaryHeapHelper.SiftDown(2, array, 11);
            if (array[2] != 14 || array[6] != 33)
                Assert.Fail();
            BinaryHeapHelper.SiftDown(0, array, 11);
            if (array[0] != 5 || array[1] != 10 || array[4] != 4 || array[10] != 11)
                Assert.Fail();

            array = new int[] { 11, 5, 33, 65, 10, 653, 14, 3, 16, 5, 4, 1, 1, 1 };
            BinaryHeapHelper.SiftDown(2, array, 11);
            if (array[2] != 14 || array[6] != 33)
                Assert.Fail();
        }

        [TestMethod()]
        public void MakeHeapTest()
        {
            int[] array = new int[] { 11, 5, 33, 65, 10, 653, 14, 3, 16, 5, 4 };
            BinaryHeapHelper.MakeHeap(array, 11);
            if (array[0] != 3 || array[1] != 4 || array[2] != 14 ||
                array[3] != 5 || array[4] != 5 || array[5] != 653 || array[6] != 33 ||
                array[7] != 65 || array[8] != 16 || array[9] != 11 || array[10] != 10)
                Assert.Fail();

            array = new int[] { 11 };
            BinaryHeapHelper.MakeHeap(array, 1);
            if (array[0] != 11)
                Assert.Fail();

            array = new int[] { 12, 11, 2 };
            BinaryHeapHelper.MakeHeap(array, 3);
            if (array[0] != 2 || array[1] != 11 || array[2] != 12)
                Assert.Fail();

            array = new int[] { 12, 13 };
            BinaryHeapHelper.MakeHeap(array, 2);
            if (array[0] != 12 || array[1] != 13)
                Assert.Fail();

            array = new int[] { 12, 11, 16 };
            BinaryHeapHelper.MakeHeap(array, 3);
            if (array[0] != 11 || array[1] != 12 || array[2] != 16)
                Assert.Fail();
        }

        [TestMethod()]
        public void SiftUpTest()
        {
            int[] array = new int[] { 11, 5, 33, 65, 10, 653, 14, 3, 10, 5, 4 };
            BinaryHeapHelper.SiftUp(2, array, 11);
            if (array[2] != 33)
                Assert.Fail();
            BinaryHeapHelper.SiftUp(1, array, 11);
            if (array[0] != 5 || array[1] != 11)
                Assert.Fail();
            BinaryHeapHelper.SiftUp(8, array, 11);
            if (array[8] != 65 || array[3] != 11 || array[1] != 10 || array[0] != 5)
                Assert.Fail();

            //array = new int[] { 11, 5, 33, 65, 10, 653, 14, 3, 16, 5, 4, 1, 1, 1 };
            //BinaryHeapHelper.SiftUp(2, array, 11);
            //if (array[2] != 14 || array[6] != 33)
            //    Assert.Fail();
        }
    }
}