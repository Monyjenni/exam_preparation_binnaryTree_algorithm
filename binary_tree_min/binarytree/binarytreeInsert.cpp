//tree.cpp 
//demonstrates binary tree
#include <iostream>
#include <stack>	//use in Tree class displayTree() member function
using namespace std;
////////////////////////////////////////////////////////////////
class Node
 {
 public:
    int iData;                //data item (key)
    double dData;             //data item
    Node* pLeftChild;         //this node's left child
    Node* pRightChild;        //this node's right child
//-----------------------     //constructor
    Node() : iData(0), dData(0.0), pLeftChild(NULL), 
                                   pRightChild(NULL)
       {  }
//-------------------------------------------------------------
    ~Node()                   //destructor
       { cout << "X-" << iData << " "; }
//-------------------------------------------------------------
    void displayNode()        //display ourself: {75, 7.5}
       {
       cout << '{' << iData << ", " << dData << "} ";
       }
 };  //end class Node
////////////////////////////////////////////////////////////////
class Tree
{  private:
      Node* pRoot;              //1st node of tree
   public:
	  Tree() : pRoot(NULL) {  } //constructor
//-------------------------------------------------------------
   Node* find(int key)        //find node with given key
    {                         //(assumes non-empty tree)
    Node* pCurrent = pRoot;            //start at root
    while(pCurrent->iData != key)      //while no match,
       {
       if(key < pCurrent->iData)       //go left?
          pCurrent = pCurrent->pLeftChild;
       else                            //or go right?
          pCurrent = pCurrent->pRightChild;
       if(pCurrent == NULL)            //if no child,
          return NULL;                 //didn't find it
       }
    return pCurrent;                   //found it
    }  //end find()
//-------------------------------------------------------------
   void insert(int id, double dd) //insert new node
      {
      Node* pNewNode = new Node;          //make new node
      pNewNode->iData = id;               //insert data
      pNewNode->dData = dd;
      if(pRoot==NULL)                     //no node in root
         pRoot = pNewNode;
      else                                //root occupied
         {
         Node* pCurrent = pRoot;          //start at root
         Node* pParent;
         while(true)                      //(exits internally)
            {
            pParent = pCurrent;
            if(id < pCurrent->iData)      //go left?
               {
               pCurrent = pCurrent->pLeftChild;
               if(pCurrent == NULL)       //if end of the line,
                  {                       //insert on left
                  pParent->pLeftChild = pNewNode;
                  return;
                  }
               }  //end if go left
            else                          //or go right?
               {
               pCurrent = pCurrent->pRightChild;
               if(pCurrent == NULL)       //if end of the line
                  {                       //insert on right
                  pParent->pRightChild = pNewNode;
                  return;
                  }
               }  //end else go right
            }  //end while
         }  //end else not root
      }  //end insert()
//-------------------------------------------------------------
   void traverse(int traverseType)
      {
      switch(traverseType)
         {
         case 1: cout << "\nPreorder traversal: ";
                 preOrder(pRoot);
                 break;
         case 2: cout << "\nInorder traversal:  ";
                 inOrder(pRoot);
                 break;
         case 3: cout << "\nPostorder traversal: ";
                 postOrder(pRoot);
                 break;
         }
      cout << endl;
      }
//-------------------------------------------------------------
   void preOrder(Node* pLocalRoot)
      {
      if(pLocalRoot != NULL)
         {
         cout << pLocalRoot->iData << " ";    //display node
         preOrder(pLocalRoot->pLeftChild);    //left child
         preOrder(pLocalRoot->pRightChild);   //right child
         }
      }
//-------------------------------------------------------------
   void inOrder(Node* pLocalRoot)
      {
      if(pLocalRoot != NULL)
         {
         inOrder(pLocalRoot->pLeftChild);     //left child
         cout << pLocalRoot->iData << " ";    //display node
         inOrder(pLocalRoot->pRightChild);    //right child
         }
      }
//-------------------------------------------------------------
   void postOrder(Node* pLocalRoot)
      {
      if(pLocalRoot != NULL)
         {
         postOrder(pLocalRoot->pLeftChild);   //left child
         postOrder(pLocalRoot->pRightChild);  //right child
         cout << pLocalRoot->iData << " ";    //display node
         }
      }
//-------------------------------------------------------------
   void displayTree()	//It displays the tree. Reference only
      {
      stack<Node*> globalStack;
      globalStack.push(pRoot);
      int nBlanks = 32;
      bool isRowEmpty = false;

      cout << 
      "......................................................";
      cout << endl;
      while(isRowEmpty==false)
         {
         stack<Node*> localStack;
         isRowEmpty = true;

         for(int j=0; j<nBlanks; j++)
            cout << ' ';

         while(globalStack.empty()==false)
            {
            Node* temp = globalStack.top();
            globalStack.pop();
            if(temp != NULL)
               {
               cout << temp->iData;
               localStack.push(temp->pLeftChild);
               localStack.push(temp->pRightChild);

               if(temp->pLeftChild != NULL ||
                                   temp->pRightChild != NULL)
                  isRowEmpty = false;
               }
            else
               {
               cout << "--";
               localStack.push(NULL);
               localStack.push(NULL);
               }
            for(int j=0; j<nBlanks*2-2; j++)
               cout << ' ';
            }  //end while globalStack not empty
         cout << endl;
         nBlanks /= 2;
         while(localStack.empty()==false)
            {
            globalStack.push( localStack.top() );
            localStack.pop();
            }
         }  //end while isRowEmpty is false
      cout << 
      "......................................................";
      cout << endl;
      }  //end displayTree()
//-------------------------------------------------------------
   void destroy()                         //deletes all nodes
      { destroyRec(pRoot); }              //start at root
//-------------------------------------------------------------
   void destroyRec(Node* pLocalRoot)      //delete nodes in
      {                                   //   this subtree
      if(pLocalRoot != NULL)
         {                                //uses postOrder
         destroyRec(pLocalRoot->pLeftChild);  //left subtree
         destroyRec(pLocalRoot->pRightChild); //right subtree
         delete pLocalRoot;               //delete this node
         }
      }
};  //end class Tree
////////////////////////////////////////////////////////////////
int  main()
{
	Tree   theTree;		//make a tree

	theTree.insert(50, 1.5);	//insert 3 nodes
	theTree.insert(25, 1.7);
	theTree.insert(75, 1.9);

	cout << "Insert a Key to a BST\n" ;
	Node *  found = theTree.find(25); //find node with key 25
	if (found != NULL)
		cout << " Found the node with key 25" << endl;
	else
		cout << "Could not find node with key 25" << endl;
	system("pause") ; 	return 0;
}	// end main()
