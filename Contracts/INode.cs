using System.Text;

namespace DS.Contracts;


public interface INode<T> where T : IComparable<T> {
  T Value {get;}
  
  INode<T>? Parent {get;}
  INode<T>? Left {get;}
  INode<T>? Right {get;}
}