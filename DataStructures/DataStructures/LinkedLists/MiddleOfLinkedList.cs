using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays.LinkedLists
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    internal class MiddleOfLinkedList
    {
        public ListNode MiddleNode(ListNode head)
        {
            if (head.next == null) return head;
            ListNode current = head;
            ListNode fast = head;
            do
            {
                current = current.next;
                fast = fast.next.next;
            } while (fast !=null && fast.next != null);
            return current;
        }
    }
}
