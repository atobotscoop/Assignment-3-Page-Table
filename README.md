# Assignment-3-Page-Table
Show the user how paging can be demonstrated using simple code.

In this program we take in a variety of addresses (valid or invalid) and use the addresses to display how a page table is used. We will call the function LogicalToPhysicalAdress to convert the logical address to physical. In this function we will aslo determine weather adresses are invalid or use too much memory(we set it at a bar of xFF which also gets us the correct answers in the end).

Within this function we wil also use division to find the page number and modulo to find the offset. We will use the page number to get the frame number aswell(For simplicity we set them equal to each other). Then put the framebase into the dictionary which acts as our page table.
