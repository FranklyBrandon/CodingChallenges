
public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int val=0, ListNode next=null) 
    {
        this.val = val;
        this.next = next;
    }
}
 
public class Solution 
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
    {
        var running = true;      
        var tensFlag = false;
        var output = new List<ListNode>();
        
        while(running) 
        {
            // If there is no other node past the current ones, this will be the last run
            if (l1?.next == null && l2?.next == null)
                running = false;
        
            // Default nodes to zero if they are missing a placevalue
            var value1 = l1?.val == null ? 0 : l1.val;
            var value2 = l2?.val == null ? 0 : l2.val;
            
            var computedValue = value1 + value2;
            
            // Add exisitng carry over if any
            if(tensFlag)
            {
                computedValue++;
                tensFlag = false;
            }
            
            // Carry over the tens place
            if(computedValue >= 10)
            {
                computedValue = computedValue - 10;
                tensFlag = true;
            }
            
            output.Add(new ListNode(computedValue, null));
            
            // Add exisitng carry over to new placevalue if this is the last run
            if (!running && tensFlag)
                output.Add(new ListNode(1, null));
            
            l1 = l1?.next;
            l2 = l2?.next;
        }
        
        // Link output nodes
        int len = output.Count;
        for(int i = 0; i <= len - 1; i++)
        {
            if(i == len - 1)
                output[i].next = null;
            else
                output[i].next = output[i +1];
        }
        
        return output.First();    
    }
}