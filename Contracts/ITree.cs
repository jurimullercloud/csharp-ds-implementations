namespace DS.Contracts;

public interface ITree<T>: IEnumerable<T> {
	ITree<T> Build(T[] data);

	void Insert(T value);
	Node<T> Delete(T value);
	Node<T> FindNode(T value);	
}