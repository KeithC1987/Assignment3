using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Assignment3.ILinkedListADT;

namespace Assignment3
{
    public class SLL
    {
        public int count = 0;
        public Node head;

        public SLL()
        {
            count = 0;
            head = null;
        }

        public void Add(int index, User user_data)
        {
            if (index < 1)
                Console.WriteLine("Invalid position");

            //if index is 1 then new node is 
            // set infornt of head node
            //head node is changing.
            if (index == 1)
            {
                var newNode = new Node(user_data);
                newNode.next = head;
                head = newNode;
            }
            else
            {
                while (index-- != 0)
                {
                    if (index == 1)
                    {
                        // adding Node at required position
                        Node newNode = new Node(user_data);

                        // Making the new Node to point to 
                        // the old Node at the same position 
                        newNode.next = head.next;

                        // Replacing current with new Node 
                        // to the old Node to point to the new Node 
                        head.next = newNode;
                        break;
                    }
                    head = head.next;
                }
                if (index != 1)
                    Console.WriteLine("Position out of range");
            }
        }
        public void AddFirst(User user_data)
        {
            count++;
            Node t_node = head;
            Node n_node = new Node(user_data);

            if (head == null)
            {
                head = n_node;
                return;
            }

            while (t_node.next != null)
            {
                t_node = t_node.next;
            }
            t_node.next = n_node;
        }
        public void AddLast(User user_data)
        {
            count++;
            Node node = new Node(user_data);
            node.next = head;
            head = node;
        }
        public void Remove(int index)
        {
            count--;
            // If linked list is empty
            if (head == null)
                return;

            // Store head node
            Node t_node = head;

            // If head needs to be removed
            if (index == 0)
            {

                // Change head
                head = t_node.next;
                return;
            }

            // Find previous node of the node to be deleted
            for (int i = 0; t_node != null && i < index - 1;
                 i++)
                t_node = t_node.next;

            // If position is more than number of nodes
            if (t_node == null || t_node.next == null)
                return;

            // Node temp->next is the node to be deleted
            // Store pointer to the next of node to be deleted
            Node next_node = t_node.next.next;

            // Unlink the deleted node from list
            t_node.next = next_node;
        }//TODO
        public void RemoveFirst()
        {
            count--;
            if (head == null)
            {
                Console.WriteLine("This list is empty.");
            }
            else
            {
                head = head.next;
                Console.WriteLine("\nRemoved the first node.\n");
            }
        }
        public void RemoveLast()
        {
            count--;
            Node current_node = null;
            Node previous_node = null;

            if (head == null)
            {
                Console.WriteLine("This list is empty.");
            }
            else if (head.next == null)
            {
                current_node = head;
                head = null;
            }
            else
            {
                current_node = head;
                while (current_node.next != null)
                {
                    previous_node = current_node;
                    current_node = current_node.next;
                }
                previous_node.next = null;
                Console.WriteLine("\nRemoved the last node.\n");
            }
        }
        public int Count()
        {
            return count;
        }
        public void Replace(User user_data, int index) { }//TODO
        public User GetValue(int index)
        {
            Node current_node = head;
            int current_index = 0;//represents the current index
            if (head != null)
            {
                while (current_node != null)
                {
                    //checking the value of each node to see if it's equal to the index
                    if (current_index == index)
                    {
                        return current_node.value;
                    }
                    //if the count isn't equal to the index, you keep moving along
                    else
                    {
                        current_index++;
                        //move current node to the next node
                        current_node = current_node.next;
                    }
                }
            }
            return null;
        }
        public int IndexOf(User user_data) 
        {
            Node current_node = head;
            int t_count = 0;
            while (current_node != null)
            {
                if (current_node.value == user_data)
                {
                    return t_count;
                }
                t_count++;
                current_node = current_node.next;
            }
            Console.WriteLine($"Cannot find {user_data}!");
            return 0;
        }
        public bool IsEmpty()
        {
            if (head != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public void Clear()
        {
            //theres not much to it, if the head is null, the list is empty! right?
            head = null;
        }
        public bool Contains(User user_data)
        {
            Node current_node = head;
            while (current_node != null)
            {
                if (current_node.value == user_data)
                {
                    return true;
                }
                current_node = current_node.next;
            }
            return false;
        }

        //BONUS METHOD
        public void Convert(SLL sLL)
        {
            ArrayList array_list = new ArrayList();

            for (int i = 0; i < sLL.count; i++)
            {
                array_list.Add(sLL.GetValue(i));
            }

            for (int i = 0; i < array_list.Count; i++)
            {
                Console.WriteLine(array_list[i]);
            }
        }//TODO

    }
}
