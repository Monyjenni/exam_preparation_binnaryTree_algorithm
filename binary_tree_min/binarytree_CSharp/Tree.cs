using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarytree_CSharp
{
  internal class Tree
  {
    private Node pRoot;  //1st node of tree
    public Tree()        // empty constructor
    {
    }
    //---------------------------------------------------------
    public Node find(int key)        //find node with given key
    {
      Node pCurrent = pRoot;             //start at root
      while (pCurrent.iData != key)      //while no match
      {
        if (key < pCurrent.iData)        //go left?
          pCurrent = pCurrent.pLeftChild;
        else                             //or go right?
          pCurrent = pCurrent.pRightChild;
        if (pCurrent == null)            //if no child,
          return null;                   //didn't find it
      }
      return pCurrent;                   //found it
    }  //end find()
//---------------------------------------------------------

    public void insert(int id, double dd) //insert new node
    {
      Node pNewNode = new Node();       //make new node
      pNewNode.iData = id;              //insert data
      pNewNode.dData = dd;
      if (pRoot == null)                //no node in root
        pRoot = pNewNode;
      else                              //root occupied
      {
        Node pCurrent = pRoot;          //start at root
        Node pParent;
        while (true)                    //(exits internally)
        {
          pParent = pCurrent;
          if (id < pCurrent.iData)      //go left?
          {
            pCurrent = pCurrent.pLeftChild;
            if (pCurrent == null)       //if end of the line,
            {                           //insert on left
              pParent.pLeftChild = pNewNode;
              return;
            }
          }  //end if go left
          else                          //or go right?
          {
            pCurrent = pCurrent.pRightChild;
            if (pCurrent == null)       //if end of the line
            {                           //insert on right
              pParent.pRightChild = pNewNode;
              return;
            }
          }  //end else go right
        }  //end while
      }  //end else not root
    }  //end insert()
       //-------------------------------------------------------------
    public void traverse(int traverseType)
    {
      switch (traverseType)
      {
        case 1:
          Console.WriteLine("\nPre-order traversal (NLR): ");
          preOrder(pRoot);
          break;
        case 2:
          Console.WriteLine("\nIn-order traversal (LNR): ");
          inOrder(pRoot);
          break;
        case 3:
          Console.WriteLine("\nPost-order traversal (LRN): ");
          postOrder(pRoot);
          break;
      }
      Console.WriteLine("\n");
    }
    //-------------------------------------------------------------
    public void preOrder(Node pLocalRoot)
    { 

    }
    //-------------------------------------------------------------
    public void inOrder(Node pLocalRoot)
    { //Exercise implement inOrder
      
    }
    //-------------------------------------------------------------
    public void postOrder(Node pLocalRoot)
    { //Exercise: implement postOrder

    }
    //-------------------------------------------------------------
    public void displayTree() //display a binary tree, for your self study only
    {
      Stack<Node> globalStack = new Stack<Node>();
     
      globalStack.Push(pRoot);
      int nBlanks = 32;
      bool isRowEmpty = false;
      Console.WriteLine("......................................................");

      while (isRowEmpty == false)
      {
        Stack<Node> localStack = new Stack<Node>();
        isRowEmpty = true;

        for (int j = 0; j < nBlanks; j++)
          Console.Write(' ');
    

        while ((globalStack.Count > 0))
        {
          Node temp = globalStack.Peek();
          globalStack.Pop();
          if (temp != null)
          {
            Console.Write(temp.iData.ToString()+" ");
            localStack.Push(temp.pLeftChild);
            localStack.Push(temp.pRightChild);

            if (temp.pLeftChild != null ||
                                temp.pRightChild != null)
              isRowEmpty = false;
          }
          else
          {
            Console.Write("--");
            localStack.Push(null);
            localStack.Push(null);
          }
          for (int j = 0; j < nBlanks * 2 - 2; j++)
            Console.Write(" ");
        }  //end while globalStack not empty
        Console.Write("\n");
        nBlanks /= 2;
        while (localStack.Count > 0)
        {
          globalStack.Push(localStack.Peek());
          localStack.Pop();
        }
      }  //end while isRowEmpty is false
      Console.WriteLine("......................................................");
    }  //end displayTree()
//-------------------------------------------------------------
// We do not cover delete node operation.
// Deletion is left for your own self study and exploration.
  }
}
