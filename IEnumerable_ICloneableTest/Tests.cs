using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEnumerable_ICloneable;
using NUnit.Framework;

namespace IEnumerable_ICloneableTest
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Push1andCount()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            Assert.AreEqual(_mysteck.Count(),1);
        }

        [Test]
        public void Push0andCount0()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            Assert.AreEqual(_mysteck.Count(), 0);
        }
        
        [Test]
        public void Push0andCount()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            Assert.AreEqual(_mysteck.Count(), 0);
        }

        [Test]
        public void Push2andPeek()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            _mysteck.Push(20);
            Assert.AreEqual(_mysteck.Peek(), 20);
        }
        
        [ExpectedException()]
        public void Push0andPeeknull()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Peek();
        }

        [ExpectedException()]
        public void Push0andPop2()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Pop();
            _mysteck.Pop();
        }

        [Test]
        public void Push2andPopandCount()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            _mysteck.Push(20);
            _mysteck.Pop();
            Assert.AreEqual(_mysteck.Count(), 1);
        }

        [Test]
        public void Push2andPopandPeek()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            _mysteck.Push(20);
            _mysteck.Pop();
            Assert.AreEqual(_mysteck.Peek(), 1);
        }

        [Test]
        public void Push2andContains_true()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            _mysteck.Push(20);
            Assert.AreEqual(_mysteck.Contains(20), true);
        }

        [Test]
        public void Push2andContains_false()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            _mysteck.Push(20);
            Assert.AreEqual(_mysteck.Contains(22), false);
        }

        [Test]
        public void Push1Clone()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            MyStack<int> _mysteck2 = (MyStack<int>)_mysteck.Clone();

            Assert.AreEqual(_mysteck.Peek(), _mysteck2.Peek());
        }
        [Test]
        public void Push2PopClone()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            _mysteck.Push(2);
            _mysteck.Pop();
            MyStack<int> _mysteck2 = (MyStack<int>)_mysteck.Clone();

            Assert.AreEqual(_mysteck2.Peek(), 1);
        }
        
        [Test]
        public void Push2Count()
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            _mysteck.Push(2);
            _mysteck.Push(3);
            _mysteck.Push(4);
            MyStack<int> _mysteck2 = (MyStack<int>)_mysteck.Clone();

            Assert.AreEqual(_mysteck.Count(), _mysteck2.Count());
        }
    }
}
