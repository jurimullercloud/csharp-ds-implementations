namespace DS.Contracts;

public interface ITree<TVal, TNode>
: IEnumerable<TVal> 
	where TNode: INode<TVal> 
	where TVal: IComparable<TVal> {
	int Height {get;}
	int Size {get;}

	TNode Build(TVal[] data);
	void Insert(TVal value);
	TNode Delete(TVal value);
	TNode FindNode(TVal value);	
	string Dump();

}