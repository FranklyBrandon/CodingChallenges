public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) {
        this.val = val;
        this.next = next;
    }
}
 
public class Solution {
    public ListNode MiddleNode(ListNode head) {
        // Traverse nodes to find the count
        int count = 1;
        var current = head;
        while(current.next != null)
        {
            count++;
            current = current.next;
        }
        
        decimal place = (count / 2);
        int wholePlace;
        
        // Select the second middle if there are two middle nodes
        if(place % 1 == 0)
            wholePlace = (int)(place + 1);
        // Otherwise round up to find the middle node split between two equal number of nodes
        else
            wholePlace = (int)Math.Ceiling(place);
        
        // Traverse nodes again to return the calculated middle node
        count = 1;
        current = head;
        while(current.next != null)
        {
            if(count == wholePlace)
                break;
            else              
            {
                count++;
                current = current.next;
            }
        }
        
        return current;
    }
}