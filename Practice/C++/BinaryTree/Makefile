objects = BinaryTree.o Node.o


all: $(objects) 
	g++ Node.o BinaryTree.o -o runtree

BinaryTree.o: BinaryTree.cpp BinaryTree.h
	g++ -c BinaryTree.cpp 

Node.o: Node.cpp Node.h
	g++ -c Node.cpp

clean:
	rm runtree $(objects)
