using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresExercises
{
    public class LRUCache
    {
        record ItemInfo(int value, int queueCounter)
        {
            internal int queueCounter { get; set; } = queueCounter;
        }

        private readonly Queue<int> _keysQueueUsage;
        private readonly int _capacityLimit = 0;
        private readonly Dictionary<int, ItemInfo> lruCache;
        public LRUCache(int capacity)
        {
            _capacityLimit = capacity;
            lruCache = new Dictionary<int, ItemInfo>(capacity);
            _keysQueueUsage = new Queue<int>();
        }

        public int Get(int key)
        {
            if (!lruCache.TryGetValue(key, out var item))
            {
                return -1;
            }
            _keysQueueUsage.Enqueue(key);
            item.queueCounter++;
            return item.value;
        }

        public void Put(int key, int value)
        {
            if (!lruCache.TryGetValue(key, out var item))
            {
                if (lruCache.Count == _capacityLimit)
                {
                    //remove old item
                    ItemInfo lastKeyInfo = null;
                    int lastKey;
                    do
                    {
                        lastKey = _keysQueueUsage.Dequeue();
                        lastKeyInfo = lruCache[lastKey];
                        lastKeyInfo.queueCounter--;
                    } while (lastKeyInfo.queueCounter >= 0);

                    lruCache.Remove(lastKey);
                }
                lruCache[key] = new ItemInfo(value, 0);
                _keysQueueUsage.Enqueue(key);
            }
            else
            {
                lruCache[key] = new ItemInfo(value, 0);
                _keysQueueUsage.Enqueue(key);
            }
        }
    }
}
