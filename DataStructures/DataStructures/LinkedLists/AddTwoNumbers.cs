namespace Arrays.LinkedLists;

public class GeneralLinkedListQuestions
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) {
        var currentL1Node = l1;
        var currentL2Node = l2;
        int delta = 0;
        var currentNodeSum = (currentL1Node?.val ?? 0) + (currentL2Node?.val ?? 0) + delta;
        ListNode? rootNode = new ListNode(currentNodeSum % 10);
        delta = (int)(currentNodeSum / 10);
        ListNode? sumNode = rootNode;
        while (currentL1Node?.next != null || currentL2Node?.next != null)
        {
            currentL1Node = currentL1Node?.next;
            currentL2Node = currentL2Node?.next;
            currentNodeSum = (currentL1Node?.val ?? 0) + (currentL2Node?.val ?? 0) + delta;
            sumNode.next = new ListNode(currentNodeSum % 10);
            sumNode = sumNode.next;
            delta = (int)(currentNodeSum / 10);
        }
        if(delta > 0)
            sumNode.next = new ListNode(delta);
        
        return rootNode;
    }
    
    
    
}