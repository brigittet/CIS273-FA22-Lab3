using System;
using System.Collections;
using System.Collections.Generic;

namespace Set
{
    public class Set<T> : ISet<T>
    {
        private HashSet<T> hashSet;

        public Set()
        {
            hashSet = new HashSet<T>();
        }

        public int Size => Elements.Count;

        public List<T> Elements
        {
            get
            {
                List<T> items = new List<T>();
                //do work
                foreach (var item in hashSet)
                {
                    items.Add(item);
                }
                //return result
                return items;
            }
        }

        public void Add(ISet<T> s)
        {
            foreach (var item in s)
            {
                this.Add(item);
            }
        }

        public void Add(T value)
        {
            hashSet.Add(value);
        }

        public bool Contains(T value)
        {
            if( hashSet.Contains(value))
            {
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return hashSet.GetEnumerator();
        }

        public void Remove(ISet<T> s)
        {
            foreach (var item in s)
            {
                this.Remove(item);
            }
        }

        public void Remove(T value)
        {
            hashSet.Remove(value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public static Set<T> Union(ISet<T> set1, ISet<T> set2)
        {
            Set<T> union = new Set<T>();
            foreach (var item1 in set1)
            {
                foreach (var item2 in set2)
                {
                    union.Add(item1);
                    if (set1.Contains(item2) == false) {
                        union.Add(item2);
                    }
                }
            }
            return union;
        }

        public static Set<T> Intersection(ISet<T> set1, ISet<T> set2)
        {
            Set<T> intersect = new Set<T>();
            foreach (var item1 in set1)
            {
                foreach (var item2 in set2)
                {
                    if (item1.Equals(item2))
                    {
                        intersect.Add(item1);
                    }
                }
            }
            return intersect;
        }
    }
}
