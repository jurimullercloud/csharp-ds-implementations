using System.Collections;
using System.Text;
using DS.Contracts;

namespace Trees;


// Augmented Data Structure - ADT
public class AVLTreeNode<T> where T: IComparable<T>{
  public T? Value {get; set;}
  public int Balance {get; set;}
  public int Height {get; set;}

  private AVLTreeNode<T>? _left;
  private AVLTreeNode<T>? _right;
  public AVLTreeNode<T>? Parent {get; set;}
  public AVLTreeNode<T>? Left {get => _left; set {
    if (value is null) Balance = Right?.Balance + 1 ?? 0;

    Balance = Balance + 1 - (Right?.Balance ?? 0);
    _left = value;
  }}

  public AVLTreeNode<T>? Right {get => _right; set {
    if (value is null) Balance = Left?.Balance + 1 ?? 0;

    Balance = Balance + 1 - (Left?.Balance ?? 0);
    _right = value;
  }}

  public AVLTreeNode(T value) {
    Value = value;
    if (Left is null && Right is null) 
      Balance = 0;
    else if (Left is null || Right is null) // -> this can happen only at one layer above leafs.  
                                            //     node
                                            //  node  null
                                            // thus Balance is 1 always. 
      Balance = 1;
    else Balance = Math.Abs(Left!.Balance - Right!.Balance);
  }

  public string Dump() 
    => $"({Value})";

  public string DumpChildren() 
    => $"({Left?.Dump()},{Right?.Dump()})";
}


public class AVLTree<T> : IEnumerable<T> where T : IComparable<T>  {
  public int Height {get; private set;} 
  public int Size  {get; private set;}
  private AVLTreeNode<T> rootNode;

  public AVLTree(T[] data)
  {
    rootNode = Build(data, 0, data.Length - 1)!;
    Size = data.Length;
  }

  // assuming a sorted array as input
  public AVLTreeNode<T>? Build (T[] data, int startIdx, int endIdx) {
    AVLTreeNode<T> parent;
    if (startIdx > endIdx) return null;
    // check if node is leaf
    var middleIdx = (endIdx + startIdx) / 2;
    if (data.Length == 1) {
      parent = new AVLTreeNode<T>(data[0]);
      parent.Left = null; parent.Right = null;
    } else {
      parent = new AVLTreeNode<T>(data[middleIdx]);
      parent.Left = Build(data, startIdx, middleIdx-1);
      parent.Right = Build(data, middleIdx+1, endIdx);     
      if (parent.Left != null) parent.Left.Parent = parent;
      if (parent.Right != null) parent.Right.Parent = parent;
    }

    // set the tree height
    if (parent.Left is null && parent.Right is null) {
      Height = 0;
      parent.Height = Height;
    } else {
      Height = Math.Max(parent.Left?.Height ?? 0, parent.Right?.Height ?? 0) + 1;
      parent.Height = Height;
    }

    return parent;
  }

  public AVLTreeNode<T> Delete(T value) {
    throw new NotImplementedException();
  }

  public AVLTreeNode<T> FindNode(T value)
  {
      throw new NotImplementedException();
  }

  public IEnumerator<T> GetEnumerator()
  {
      throw new NotImplementedException();
  }

  public void Insert(T value)
  {
    FixBalance(rootNode);
  }


  public AVLTreeNode<T> SubtreeLeft(T key) {
    throw new NotImplementedException();
  }


  public AVLTreeNode<T> SubtreeRight(T key) {
    throw new NotImplementedException();
  }

  IEnumerator IEnumerable.GetEnumerator()
  {
    throw new NotImplementedException();
  }

  public string Dump() {
    var sb = new StringBuilder();
    sb.AppendLine(rootNode.Dump());
    var counter = 0;
    List<AVLTreeNode<T>> parents = new() {rootNode};
    while(counter < Height) { 
      if (parents.Any())
        sb.AppendLine(string.Join(", ", parents.Select(p => p.DumpChildren())));
      
      List<AVLTreeNode<T>> nextParents = new();
      foreach(AVLTreeNode<T> parent in parents) { 
        if (parent.Left != null && parent.Left.Height > 0) 
          nextParents.Add(parent.Left);
        if (parent.Right != null && parent.Right.Height > 0)
          nextParents.Add(parent.Right);
      }
      parents = nextParents;
      counter++;
    }

    return sb.ToString();
  }

  private void FixBalance(AVLTreeNode<T> node) {
    throw new NotImplementedException();
  }
}
