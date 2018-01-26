#include "BinaryTree.h"
namespace BinaryTree{

    BinaryTree::BinaryTree(void)
    {
    }

    
    ~BinaryTree(void)
    {

    }

    bool BinaryTree::Add(int i)
    {
                     
        return true;
    }
    
    Node* BinaryTree::Traverse(Node* current,int value)
    {
        
        if(!current)
        {
            Node* newNode = new Node(value);
            return newNode;
        }
        
        if(current->value == value)
        {
            return current;
        }
        else if(current->value < value)
        {
            return current   
        }
        else
        {
            
        }


      
    }


}

int main(int argc, const char *argv[])
{
  
  
  BinaryTree::BinaryTree test; 
    return 0;
}
