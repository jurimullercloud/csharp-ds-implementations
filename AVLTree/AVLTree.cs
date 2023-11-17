namespace DS.AVLTree;


public class Node<T> {
	public T Value {get; set;}	
	public Node<T> Left {get; set;}
	public Node<T> Right {get; set;}
	
	public Node(T val) {
		Value = val; 
	}
}



public class Tree<T> {
	private Node<T>	_root;

	protected Tree<T>(T[] data) {
		// initialize the tree here	
	}
	

}



