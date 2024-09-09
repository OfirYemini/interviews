// See https://aka.ms/new-console-template for more information
using Arrays;
using Arrays.LinkedLists;
using DataStructuresExercises;
using DataStructuresExercises.Trees;
using System.Reflection.Emit;

Console.WriteLine("Hello, World!");

var arrays = new DataStructures.Arrays();
var stringQuestions = new StringsQuestions();
//var middleLinkedList = new MiddleOfLinkedList();
//var solution = arrays.TwoSum([2, 7,11,15],9);
//var solution = arrays.TwoSum([2, 7, 11, 15], 9);
//var solution = middleLinkedList.MiddleNode(new int[] { 1, 2, 3, 4 });
//var solution = stringQuestions.LengthOfLongestSubstring2("kdgjkjhglfp"); // ascii array to hold last position of char
//stringQuestions.IsValidParentheses("(]");
//stringQuestions.GroupAnagrams2(new[] { "eat", "tea", "tan", "ate", "nat", "bat" });
//var lruCache = new LRUCache(2);
//lruCache.Put(2, 1); // cache is {2=1}
//lruCache.Put(1, 1); // cache is {2=1, 1=1}
//lruCache.Put(2, 3); // cache is {2=3, 1=1}
//lruCache.Put(4, 1); // cache is {1=1, 2=2}
//var x = lruCache.Get(1);    // return 1
//x = lruCache.Get(2);    // return 1


//Console.WriteLine(lruCache.Get(4));// return 4
//Console.WriteLine(string.Join(",",solution));
int[] data = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10,11,12,13,14 };
int breadthSize = 2;  // Each node can have up to 3 children

TreeNode<int> root = data.BuildTree(breadthSize);
TreeExtensions.PrintTree(root);
root.BreadthFirstSearch((num) => { 
    Console.WriteLine($"got to num {num}");    
},7);
root.DeepFirstSearch((num) => {
    Console.WriteLine($"got to num {num}");
}, 7);
