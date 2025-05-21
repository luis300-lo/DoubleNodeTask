using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleList
{
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        private DoubleNode<T>? _head;
        private DoubleNode<T>? _tail;

        public DoublyLinkedList()
        {
            _head = null;
            _tail = null;
        }

        public void InsertSorted(T data)
        {
            var newNode = new DoubleNode<T>(data);
            if (_head == null)
            {
                _head = _tail = newNode;
                return;
            }

            var current = _head;
            while (current != null && data.CompareTo(current.Data) > 0)
            {
                current = current.Next;
            }

            if (current == _head)
            {
                newNode.Next = _head;
                _head.Prev = newNode;
                _head = newNode;
            }
            else if (current == null)
            {
                _tail!.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
            else
            {
                newNode.Prev = current.Prev;
                newNode.Next = current;
                current.Prev!.Next = newNode;
                current.Prev = newNode;
            }
        }

        public string GetForward()
        {
            var output = string.Empty;
            var current = _head;
            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Next;
            }
            return output.Substring(0, output.Length - 5);

        }

        public string GetBackward()
        {
            var output = string.Empty;
            var current = _tail;
            while (current != null)
            {
                output += $"{current.Data} <=> ";
                current = current.Prev;
            }
            return output.Substring(0, output.Length - 5);
        }

        public void SortDescending()
        {
            var items = new List<T>();
            var current = _head;
            while (current != null)
            {
                items.Add(current.Data);
                current = current.Next;
            }

            items.Sort();
            items.Reverse();

            _head = _tail = null;
            foreach (var item in items)
            {
                InsertAtEnd(item);
            }
        }

        public void InsertAtEnd(T data)
        {
            var newNode = new DoubleNode<T>(data);
            if (_tail == null)
            {
                _head = newNode;
                _tail = newNode;
            }
            else
            {
                _tail.Next = newNode;
                newNode.Prev = _tail;
                _tail = newNode;
            }
        }

        public List<T> GetModes()
        {
            var frequency = new Dictionary<T, int>();
            var current = _head;

            while (current != null)
            {
                if (frequency.ContainsKey(current.Data))
                    frequency[current.Data]++;
                else
                    frequency[current.Data] = 1;

                current = current.Next;
            }

            int maxFreq = 0;
            foreach (var pair in frequency)
            {
                if (pair.Value > maxFreq)
                    maxFreq = pair.Value;
            }

            var modas = new List<T>();
            foreach (var pair in frequency)
            {
                if (pair.Value == maxFreq)
                    modas.Add(pair.Key);
            }

            return modas;
        }

        public void ShowFrequencyGraph()
        {
            var frequency = new Dictionary<T, int>();
            var current = _head;

            while (current != null)
            {
                if (frequency.ContainsKey(current.Data))
                    frequency[current.Data]++;
                else
                    frequency[current.Data] = 1;

                current = current.Next;
            }

            foreach (var pair in frequency)
            {
                Console.WriteLine($"{pair.Key} {new string('*', pair.Value)}");
            }
        }

        public bool Contains(T data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        public void RemoveFirstOccurrence(T data)
        {
            var current = _head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        _head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        _tail = current.Prev;

                    break;
                }
                current = current.Next;
            }
        }

        public void RemoveAllOccurrences(T data)
        {
            var current = _head;
            while (current != null)
            {
                var next = current.Next;
                if (current.Data.Equals(data))
                {
                    if (current.Prev != null)
                        current.Prev.Next = current.Next;
                    else
                        _head = current.Next;

                    if (current.Next != null)
                        current.Next.Prev = current.Prev;
                    else
                        _tail = current.Prev;
                }
                current = next;
            }
        }
    }
}
