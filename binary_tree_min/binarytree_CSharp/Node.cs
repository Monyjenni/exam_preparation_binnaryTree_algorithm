using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace binarytree_CSharp
{
  internal class Node
  {   
    public int iData;          //data item (key)
    public double dData;       //data item
    public Node pLeftChild;    //pointer to this node's left child
    public Node pRightChild;   //pointer to this node's right child
                              
    //constructor
    public Node()
    {
      iData= 0;
      dData= 0;
      pLeftChild= null;
      pRightChild= null;
    }
    public Node(int iData, double dData)
    {
      this.iData = iData;
      this.dData = dData;
      pLeftChild= null;
      pRightChild= null;
    }

    //-------------------------------------------------------------
    public string displayNode() //returns the data stored in this node
    {
      return ("(" + iData.ToString() + ", " + dData.ToString() + ")");
    }
  }
}
