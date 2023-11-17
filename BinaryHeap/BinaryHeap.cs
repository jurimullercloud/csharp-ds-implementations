using DS.Contracts;

public class BinaryHeap<T>: IHeap<T> where T : IComparable<T> {
  public int Size {get; private set;}
  private T[] _heap;
  public BinaryHeap(T[] set) {
    _heap = Build(set);
    Size = _heap.Length;
  }

  public T[] Build(T[] set) {
    for (int i = (set.Length / 2) + 1; i >= 0; i--) {
      maxHeapify(i, set);
    }

    return set;
  }

  public T ExtractMax() {
    var element = _heap[0];
    var last = _heap[_heap.Length - 1];
    _heap[0] = last;
    _heap[_heap.Length - 1] = element;

    Size--;
    // maxHeapify(0, _heap.Slice(0, Size));
    return element;
    throw new NotImplementedException();
  }
  public override string ToString() {
    return $"[{string.Join(",", _heap)}]";
  }

  // will return the new index to swap
  private void maxHeapify(int index_i, T[] set) {

      int? left_idx= index_i * 2 + 1 < set.Length ? index_i * 2 + 1: null;
      int? right_idx = index_i * 2 + 2 < set.Length ? index_i * 2 + 2: null;

      int? swap_idx = right_idx.HasValue && left_idx.HasValue 
        ? set[right_idx.Value].CompareTo(set[left_idx.Value]) > 0 ? right_idx : left_idx 
        : right_idx ?? left_idx;

      if (!swap_idx.HasValue || set[index_i].CompareTo(set[swap_idx.Value]) > 0) 
        return;

      var temp = set[index_i];
      set[index_i] = set[swap_idx.Value];
      set[swap_idx.Value] = temp;

      maxHeapify(swap_idx.Value, set);
  }
}