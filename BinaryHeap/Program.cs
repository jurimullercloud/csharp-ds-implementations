// See https://aka.ms/new-console-template for more information

int[] set = new int[] {3, 4,8, 9, 7, 2, 10, 14, 16};
Console.WriteLine($"[{string.Join(",", set)}]");
var heap = new BinaryHeap<int>(set);
Console.WriteLine(heap);