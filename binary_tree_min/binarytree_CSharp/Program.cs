using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarytree_CSharp
{
  internal class Program
  {
    static void Main(string[] args)
    {
      int value;
      char choice = 's';
      Node found;
      Tree theTree = new Tree();             //create tree    

      theTree.insert(50, 5.0);               //insert nodes
      theTree.insert(25, 2.5);
      theTree.insert(75, 7.5);
      theTree.insert(12, 1.2);
      theTree.insert(62, 1.1);
      theTree.insert(37, 3.7);
      theTree.insert(43, 4.3);
      theTree.insert(30, 3.0);
      theTree.insert(33, 3.3);
      theTree.insert(87, 8.7);
      theTree.insert(93, 9.3);
      theTree.insert(97, 9.7);
      Console.WriteLine("A BST has been created (no duplicate allowed).");
      while (choice != 'q')               //interact with user
      {                                   //until user types 'q'
        Console.WriteLine("Enter first letter of your choice.");
        Console.WriteLine("show, insert, find, traverse or quit.");

        choice = char.Parse(Console.ReadLine());
        switch (choice)
        {
          case 's':                        //show the tree
            theTree.displayTree();
            break;
          case 'i':                        //insert a node
            Console.Write("Enter a value to be inserted into the BST: ");
            value = int.Parse(Console.ReadLine());
            theTree.insert(value, value + 0.9);
            break;
          case 'f':                        //find a node
            Console.Write("Enter a value to find in the BST: ");
            value = int.Parse(Console.ReadLine());
            found = theTree.find(value);
            if (found != null)
            {
              Console.Write(value.ToString() + " is found.");
              found.displayNode();
              Console.WriteLine("");
            }
            else
              Console.WriteLine("Could not find " + value + "\n");
            break;
          case 't':                        //traverse the tree
            Console.Write("Enter travere type [1=Pre-Order(NLR), 2=In-Order(LNR), 3=PostOrder(LRN)]: ");
            value = int.Parse(Console.ReadLine());
            theTree.traverse(value);
            break;
          case 'q':                        //quit the program
            //theTree.destroy();
            Console.WriteLine("\n");
            break;
          default:
            Console.WriteLine("Invalid entry.");
            break;
        }  //end switch
      }  //end while

    }
  }
}
