from typing import Optional

def main():
    runner = Solution()
    node7 = ListNode(9, None)
    node6 = ListNode(9, node7)
    node5 = ListNode(9, node6)
    node4 = ListNode(9, node5)
    node3 = ListNode(9, node4)
    node2 = ListNode(9, node3)
    node1 = ListNode(9, node2)

    node4_1 = ListNode(9, None)
    node3_1 = ListNode(9, node4_1)
    node2_1 = ListNode(9, node3_1)
    node1_1 = ListNode(9, node2_1)

    output = runner.addTwoNumbers(node1, node1_1)
    print(output)


class ListNode:
     def __init__(self, val=0, next=None):
         self.val = val
         self.next = next

class Solution:
    def addTwoNumbers(self, l1: Optional[ListNode], l2: Optional[ListNode]) -> Optional[ListNode]:
        running = True
        tens_flag = False
        output = []
        
        while(running):
            computed_val = 0
            
            # If there is no other node past the current ones, this will be the last run
            if (not l1 or not l1.next) and (not l2 or not l2.next):
                running = False
                
            # Default nodes to zero if they are missing a placevalue 
            val1 = 0 if not l1 else l1.val
            val2 = 0 if not l2 else l2.val
            
            computed_val = val1 + val2
            
            # Add exisitng carry over if any
            if tens_flag:
                computed_val += 1
                tens_flag = False
                
            # Carry over the tens place
            if computed_val >= 10:
                remainder = computed_val - 10
                computed_val = remainder
                tens_flag = True
                
            output.append(ListNode(computed_val, None))
            
            # Add exisitng carry over to new placevalue if this is the last run
            if (not running and tens_flag):
                output.append(ListNode(1, None))
                
            l1 = None if not l1 else l1.next
            l2 = None if not l2 else l2.next
            
        # Link nodes
        length = len(output)
        for index, item in enumerate(output):
            if index == length - 1:
                item.next = None
            else:
                item.next = output[index + 1]
                
        return output[0]


if __name__ == "__main__":
    main()   
        