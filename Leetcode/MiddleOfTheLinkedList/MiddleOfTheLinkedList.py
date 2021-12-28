from typing import Optional
import math

# Definition for singly-linked list.
class ListNode:
     def __init__(self, val=0, next=None):
         self.val = val
         self.next = next

class Solution:
    def middleNode(self, head: Optional[ListNode]) -> Optional[ListNode]:        
        # Traverse nodes to find the count
        current = head
        count = 1
        while(current.next):
            count += 1
            current = current.next
        
        place = (count / 2)
        # Select the second middle if there are two middle nodes
        if (place.is_integer()):
            place += 1
        # Otherwise round up to find the middle node split between two equal number of nodes
        else: 
            place = int(math.ceil(place))
            
        # Traverse nodes again to return the calculated middle node
        current = head
        count = 1
        while(current.next):
            if (count == place):
                return current
            else:
                count += 1
                current = current.next