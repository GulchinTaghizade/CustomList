using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomList
{
    public class CustomList<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _count;


        // Empty constructor
        public CustomList()
        {
            _items = new T[10];
            _count = 0;
        }

        // Constructor to initialize the list with a default capacity
        public CustomList(int capacity)
        {
            _items = new T[capacity];
            _count = 0;
        }


        // Constructor to initialize the list from an existing collection
        public CustomList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException(nameof(collection));
            }

            // Initialize _items with the collection size
            ICollection<T> col = collection as ICollection<T>;
            if (col != null)
            {
                _items = new T[col.Count];
                col.CopyTo(_items, 0);
                _count = col.Count;
            }
            else
            {
                _count = 0;
                _items = new T[4];
                foreach (T item in collection)
                {
                    Add(item);
                }
            }
        }



        // Property to get the number of elements in the list
        public int Count
        {
            get { return _count; }
        }

        // Property to get the capacity of the list
        public int Capacity
        {
            get { return _items.Length; }
        }

        //Indexer
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }
                return _items[index];
            }

            set
            {
                if (index < 0 || index >= _count)
                {
                    throw new IndexOutOfRangeException();
                }
                _items[index] = value;
            }
        }

        // Method to add an element to the list
        public void Add(T item)
        {

            if (_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }
            _items[_count++] = item;
        }

        // Method to resize the internal array
        private void Resize(int newSize)
        {
            T[] newArray = new T[newSize];
            for (int i = 0; i < _count; i++)
            {
                newArray[i] = _items[i];
            }
            _items = newArray;
        }


        // Method to clear the list
        public void Clear()
        {
            for (int i = 0; i < _count; i++)
            {
                _items[i] = default;
            }
            _count = 0;
        }

        // Method to get the index of an element
        public int IndexOf(T item)
        {
            for (int i = 0; i < _count; i++)
            {
                if (Equals(_items[i], item))
                {
                    return i;
                }
            }
            return -1;
        }

        // Method to check if the list contains an element
        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        // Method to remove an element from the list
        public bool Remove(T item)
        {
            int index = IndexOf(item);
            if (index >= 0)
            {
                for (int i = index; i < _count - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }
                _items[--_count] = default;
                return true;
            }
            return false;
        }

        // Method to remove an element in the given index from the list
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index out of range");
            }

            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }

            _items[--_count] = default; // Clear the last item
        }


        // Implement IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < _count; i++)
            {
                yield return _items[i];
            }
        }

        // Implement IEnumerable
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Method to display the contents of the list
        public void Display()
        {
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine($"Element[{i}] = {_items[i]}");
            }
        }
    }
}

