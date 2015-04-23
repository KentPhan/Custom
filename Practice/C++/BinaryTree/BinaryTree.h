#include "Node.h"
namespace BinaryTree
{
    class BinaryTree{
          public:
            bool Add(int i);
            bool Remove(int i);
            bool Clear();
            BinaryTree(void);
          private:        
            Node::Node * root; 
    };
}
