using System;
using System.Collections.Generic;

class AssignmentThreePaging
{
    //Dictionary that will represent the page table
    static Dictionary<int, int> pageTable = new Dictionary<int, int>();
    //pageSize determines the page size of 1024 bytes that we will use in the program
    static int pageSize = 1024;

    static void Main()
    {
        //Holder for the addresses contained in the assignment
        int[] logicalAddresses = { 0x3A7F, 0xABCD, 0x5678 };

        //A foreach loop to iterate through the list and transfer the logical adress into physical
        foreach (int logicalAddress in logicalAddresses)
        {
            //Call the function to transfer
            LogicalToPhysicalAddress(logicalAddress);
        }
    }

    static void LogicalToPhysicalAddress(int logicalAddress)
    {
        // Ensure that the logical address is within a valid range
        if (logicalAddress < 0 || logicalAddress >= (pageSize * 0xFF))
        {   
            //We went over the set limit of 8 bit
            Console.WriteLine($"Error: ADDRES iNVALID!!!");
            //Exit theprogram
            return;
        }

        //We will use 0xFF do make sure tha the lsest 8 bits are kept for page Number and the offset

        //It was my mistake for doing the assignment last minute, but the page number calculation does not match what it listed on the HW, but i used to correct calculation?

        //Calculate the page number by dividing the page size by the logical adress
        int pageNumber = (logicalAddress / pageSize) & 0xFF;
        //Calculate the offset by taking the logical adress modulo page size
        int offset = (logicalAddress % pageSize) & 0xFF;
        //Declare a frame int for use in calculating the physical adress
        int frameBase;

        //Check if the page is present in the memory (The dictionary)
        if (!pageTable.ContainsKey(pageNumber))
        {
            // If there is insufficient memory to store all pages
            if (pageTable.Count >= 0xFF)
            {
                //We have an 8 bit ctoff
                Console.WriteLine("Error: NOT ENOUGH MEMORY!!!");
                //Exit the program
                return;
            }
            //If it is borken we pretend that we are loading a second storage
            frameBase = LoadPage(pageNumber);
        }
        else
        {
            //If the page is found in the memory (dictionary)
            frameBase = pageTable[pageNumber];
        }

        //Here we will find the physical adress. Was not asked to display it so I left it here
        int physicalAddress = (frameBase + offset);

        //Out put the final results
        Console.WriteLine($"Logical Address: 0x{logicalAddress:X} => Page Number: 0x{pageNumber:X}, Offset: 0x{offset:X}");
        //Console.WriteLine("Logical Address: ", logicalAddress, "=> Page Number:", pageNumber, "Offset: ", offset);
    }

    static int LoadPage(int pageNumber)
    {
        //For ease of use we set the frame number equal to the page number. This could be different if we wanted to
        int frameBase = pageNumber;

        //Add the mapping to the page atble dictionary
        pageTable[pageNumber] = frameBase;
        
        //return the frame number
        return frameBase;
    }
}

