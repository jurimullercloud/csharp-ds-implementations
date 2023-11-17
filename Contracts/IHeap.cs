namespace DS.Contracts;

public interface IHeap<T> where T: IComparable<T> {
  int Size {get; }
  T[] Build(T[] set);
  T ExtractMax();

}