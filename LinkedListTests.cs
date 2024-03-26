using Assignment3.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    public class LinkedListTests
    {
        private ILinkedListADT linkedList;

        [SetUp]
        public void Setup()
        {
            // Create your concrete linked list class and assign to linkedList.
            this.linkedList = new SLL();

            this.linkedList.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            this.linkedList.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            this.linkedList.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            this.linkedList.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));
        }

        [TearDown]
        public void TearDown()
        {
            this.linkedList.Clear();
        }

        
        [Test]
        public void EmptyLinkedList()
        {
            //Clears list then checks if IsEmpty is true
            this.linkedList.Clear();
            Assert.IsTrue(this.linkedList.IsEmpty());
            Assert.AreEqual(0, this.linkedList.Count());
        }
        [Test]
        public void PrependedItem()
        {
            //Adding to the first node
            this.linkedList.AddFirst(new User(3, "Add First", "TestAddFirst@gmail.com", "123456"));

            var expectedValue1 = new User(3, "Add First", "TestAddFirst@gmail.com", "123456");
            var acutalValue1 = this.linkedList.GetValue(0);

            Assert.That(acutalValue1, Is.EqualTo(expectedValue1));

            //Test the value in index 1, which was previously index 0
            var expectedValue2 = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            var acutalValue2 = this.linkedList.GetValue(1);

            Assert.That(acutalValue2, Is.EqualTo(expectedValue2));

            Assert.AreEqual(5, this.linkedList.Count());

        }
        [Test]
        public void AppendedItem()
        {
            //Appending new user value
            this.linkedList.AddLast(new User(10, "Add Last", "TestAddLast@gmail.com", "098765W@"));

            var expectedValue1 = new User(10, "Add Last", "TestAddLast@gmail.com", "098765W@");
            var acutalValue1 = this.linkedList.GetValue(4);
            Assert.That(acutalValue1, Is.EqualTo(expectedValue1));

            //Test the previous last index 
            var expectedValue2 = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            var actualValue2 = this.linkedList.GetValue(3);
            Assert.That(actualValue2, Is.EqualTo(expectedValue2));

            Assert.AreEqual(5, this.linkedList.Count());
        }

        [Test]
        public void InsertAtIndex()
        {
            //Inserting at Index 2
            this.linkedList.Add(new User(9, "Insert Index1", "TestInsertAtIndex@gmail.com", "0@#@SDW"), 2);
            

            var ExpectedValue1 = new User(9, "Insert Index1", "TestInsertAtIndex@gmail.com", "0@#@SDW");
            var actualValue1 = this.linkedList.GetValue(2);

            Assert.That(actualValue1, Is.EqualTo(ExpectedValue1));

            //Inserting at Index -1 to test Throw exception
            Assert.Throws<IndexOutOfRangeException>(() => this.linkedList.Add(new User(1, "Insert Index Throw", "TestInsertAtIndex@gmail.com", "0@#@SDW"), -1));

            //Testing more inserting at different Index
            this.linkedList.Add(new User(10, "Insert Index1", "TestInsertAtIndex@gmail.com", "0@#@SDW"), 1);
            var ExpectedValue3 = new User(10, "Insert Index1", "TestInsertAtIndex@gmail.com", "0@#@SDW");
            var actualValue3 = this.linkedList.GetValue(1);

            Assert.That(actualValue3, Is.EqualTo(ExpectedValue3));

            Assert.AreEqual(6, this.linkedList.Count());

        }
        [Test]
        public void ReplaceItem()
        {
            //replacement 1
            this.linkedList.Replace(new User(111, "Replacement1", "TestReplacement@gmail.com", "0@#@SDW"), 1);
            var ExpectedValue1 = new User(111, "Replacement1", "TestReplacement@gmail.com", "0@#@SDW");
            var actualValue1 = this.linkedList.GetValue(1);
            Assert.That(actualValue1, Is.EqualTo(ExpectedValue1));

            //Replacement 2
            this.linkedList.Replace(new User(1, "Replacement2", "TestReplacement@gmail.com", "0@#@SDW"), 3);
            var ExpectedValue2 = new User(1, "Replacement2", "TestReplacement@gmail.com", "0@#@SDW");
            var actualValue2 = this.linkedList.GetValue(3);
            Assert.That(actualValue2, Is.EqualTo(ExpectedValue2));

            //Checks Out of range throw
            Assert.Throws<IndexOutOfRangeException>(() => this.linkedList.Replace(new User(8, "Replace3", "Test@gmail.com", "0@#@SDW"), 10));

            //Checks for the list count. 
            Assert.AreEqual(4, this.linkedList.Count());


        }
        [Test]
        public void RemoveFirstItem()
        {
            //Call RemoveFirst Method
            this.linkedList.RemoveFirst();
            
            //Check the new index value of 0 (Originally at index 1)
            var ExpectedValue = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            var actualValue = this.linkedList.GetValue(0);

            //Checks if value at index 0 matches 
            Assert.That(actualValue, Is.EqualTo(ExpectedValue));

            //Originally at index 2, now should be at index 1
            var ExpectedValue2 = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            var actualValue2 = this.linkedList.GetValue(1);

            Assert.That(actualValue2, Is.EqualTo(ExpectedValue2));

            //Checks list length. Orignally 4, now should be 3
            Assert.AreEqual(3, this.linkedList.Count());
        }        
    }
}