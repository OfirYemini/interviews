using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises
{
    /// <summary>
    /// uses Linked list for item priority, and lru as dictioanry with pointer to the node on the linked list
    /// </summary>
    public class LRUCache
    {        
        private readonly LinkedList<KeyValuePair<int, int>> _linkedListPriority;
        private readonly int _capacityLimit = 0;
        private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> lruCache;
        public LRUCache(int capacity)
        {
            _capacityLimit = capacity;
            lruCache = new Dictionary<int, LinkedListNode<KeyValuePair<int,int>>>(capacity);
            _linkedListPriority = new LinkedList<KeyValuePair<int, int>>();            
        }

        public int Get(int key)
        {
            if (!lruCache.TryGetValue(key, out var node))
            {
                return -1;
            }
            _linkedListPriority.Remove(node);
            _linkedListPriority.AddFirst(node);
            return node.Value.Value;
        }

        public void Put(int key, int value)
        {
            if (!lruCache.TryGetValue(key, out var node))
            {
                if (lruCache.Count == _capacityLimit)
                {
                    //remove old item
                    var luNode = _linkedListPriority.Last;
                    _linkedListPriority.RemoveLast();
                    lruCache.Remove(luNode.Value.Key);
                }
                var newNode = new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(key,value));
                lruCache[key] = newNode;
                _linkedListPriority.AddFirst(newNode);
            }
            else
            {
                node.Value = new KeyValuePair<int, int>(key,value);
                _linkedListPriority.Remove(node);
                _linkedListPriority.AddFirst(node);
            }
        }
    }


}
