objects = BinaryTree.o Node.o


all: $(objects) 
	g++ Node.o BinaryTree.o -o runtree

BinaryTree.o: BinaryTree.cpp BinaryTree.h
	g++ BinaryTree.cpp BinaryTree.h -o BinaryTree.o

Node.o: Node.cpp Node.h
	g++ Node.cpp Node.h -o Node.o

clean:
	rm runtree $(objects)
