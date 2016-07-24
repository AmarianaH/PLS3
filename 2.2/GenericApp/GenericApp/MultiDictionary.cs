using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GenericApp
{
    public class MultiDictionary <K,V> : IMultiDictionary<K,V> , IEnumerable<KeyValuePair<K, IEnumerable<V>>>
        where K : struct
        where V : new()
        
    {
        public Dictionary<K, LinkedList<V>> Mydictionary = new Dictionary<K, LinkedList<V>>();
        //static ReaderWriterLockSlim _syncLock  = new ReaderWriterLockSlim();
         
        public int Count
        {
            get
            {
                var e = Mydictionary.Keys.Count;
                e += Mydictionary.Values.Count;
                return (e);
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                ICollection<K> keys= Mydictionary.Keys;
                return keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {

                var keyss = Keys.SelectMany(k => Mydictionary[k]).ToList();
                return keyss;
            } 
        }
               
        public void Add(K key, V value)
        {
            if (Mydictionary.ContainsKey(key))
            {
                Mydictionary[key].AddLast(value);
            }
            else
            {
                LinkedList<V> vals = new LinkedList<V>();
                vals.AddLast(value);
                Mydictionary.Add(key, vals);
            } 
            
        }

        public void Clear()
        {
            Mydictionary.Clear();
        }

        public bool Contains(K key, V value) =>
            (Mydictionary.ContainsKey(key) && Mydictionary[key].Contains(value));
                

        public bool ContainsKey(K key) =>
            Mydictionary.ContainsKey(key);

        public void CreateNewValue(K key) 
        {
            V v = new V();
            //V v = default(V);
            //Add(key,v);
            if (Mydictionary.ContainsKey(key))
                Mydictionary[key].AddLast(v);
            else
            {
                LinkedList<V> newVals = new LinkedList<V>();
                newVals.AddLast(v);
                Mydictionary.Add(key, newVals);
            }
        }

        public IEnumerator<KeyValuePair<K, IEnumerable<V>>> GetEnumerator()
        {
                foreach (var key in Mydictionary)
                    //foreach (var value in key.Value)
                        yield return new KeyValuePair<K, IEnumerable<V>>(key.Key, key.Value);

        }

        public bool Remove(K key)
        {
            if(!Mydictionary.ContainsKey(key)) return false;
            return (Mydictionary.Remove(key));
        }

        public bool Remove(K key, V value)
        {
            if (Mydictionary.ContainsKey(key) & Mydictionary[key].Contains(value) ){
                return Mydictionary[key].Remove(value);
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Mydictionary.GetEnumerator();
        }
    }
}
