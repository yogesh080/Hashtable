﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable_day15
{
   public class MyMapMode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        
        public MyMapMode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];

        }
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            //to identify the hashcode of perticular hashcode key
            return Math.Abs(position);
        }
        //itentify key value pair
        public V Get(K key)
        {
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K,V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        public void Add(K key, V value)
        {
            int postion = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(postion);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };

            linkedList.AddLast(item);
        }

        public void Remove(K Key)
        {
            int postion = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(postion);
            bool itemFound = false;
            KeyValue<K,V> foundItem = default(KeyValue<K, V>);
            foreach(KeyValue<K, V> items in linkedList)
            {
                if (items.Key.Equals(Key))
                {
                    itemFound = true;
                    foundItem = items;
                }
                if (itemFound)
                {
                    linkedList.Remove(foundItem);
                }
            }
        }


        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];    
            if(linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
    }
    public struct KeyValue<k, v>
    {
        public k Key { get; set; }
        public v Value { get; set; }
    }
}
