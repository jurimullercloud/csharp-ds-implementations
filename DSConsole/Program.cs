// See https://aka.ms/new-console-template for more information
using Trees;

var avlTree = new AVLTree<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10});
Console.WriteLine(avlTree.Dump());