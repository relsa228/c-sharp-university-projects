using System;
using LR_4.Interfaces;

namespace LR_4.Collections
{
    public class MyCustomCollection<T> : ICustomCollection<T> where T : IComparable
    {
        public int Count { get; set; }
        public int Cursor;
        private Node<T> _head;

        public MyCustomCollection()
        {
            Count = 0;
            Cursor = 0;
            _head = null;
        }
        
        public T this[int index]
        {
            get
            {
                ref Node<T> temp = ref _head;
                for (int i = 0; i < index; i++)
                    temp = ref temp.PNext;
                return temp.Data;
            }
            set
            {
                ref Node<T> temp = ref _head;
                for (int i = 0; i < index; i++)
                    temp = ref temp.PNext;
                temp.Data = value;
            }
        }

        public void Reset()
        {
            Cursor = 0;
        }

        public void Next()
        {
            if (Cursor == Count - 1)
                Cursor = 0;
            else
                Cursor++;
        }

        public T Current()
        {
            return this[Cursor];
        }

        public void Add(T item)
        {
            if (Count == 0)
            {
                _head = new Node<T>();
                _head.Data = item;
                _head.PPrev = null;
            }
            else
            {
                ref Node<T> temp = ref _head;
                for (int i = 0; i < Count; i++)
                {
                    if (temp.PNext == null)
                    {
                        temp.PNext = new Node<T>();
                        temp.PNext.PPrev = temp;
                        temp.PNext.Data = item;
                    }
                    else
                        temp = ref temp.PNext;
                }
            }
            Count++;
        }

        public void Remove(T item)
        {
            ref Node<T> temp = ref _head;
            for (int i = 0; i < Count; i++)
            {
                if (temp.Data.CompareTo(item) == 0)
                {
                    if (temp.PNext == null)
                        temp.PPrev.PNext = null;
                    else
                    {
                        temp.PPrev.PNext = temp.PNext;
                        temp.PPrev.PNext.PPrev = temp.PPrev;
                    }
                }
                else
                    temp = ref temp.PNext;
            }

            Count--;
        }

        public void RemoveCurrent()
        {
            this.Remove(this[Cursor]);
            Count--;
        }
    }
}