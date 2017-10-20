using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable_ICloneable
{
    interface IStack<T>
    {
        void Push(T element);
        int Count();
        T Pop();
        T Peek();
        bool Contains(T item);
    }

    public class Object<T>
    {
        public Object(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public Object<T> Next { get; set; }
    }

    public class LinkedList<T> : IEnumerable<T>  // односвязный список
    {
        Object<T> head; // головной/первый элемент
        Object<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента
        public void Add(T data)
        {
            Object<T> Object = new Object<T>(data);

            if (head == null)
            {
                head = Object;
            }
            else
            {
                tail.Next = Object;
            }
            tail = Object;

            count++;
        }

        public T Tail()
        {
            return tail.Data;
        }

        // удаление элемента
        public bool Remove(T data)
        {
            Object<T> current = head;
            Object<T> previous = null;

            while (current != null)
            {
                if (current.Data.Equals(data))
                {
                    // Если узел в середине или в конце
                    if (previous != null)
                    {
                        // убираем узел current, теперь previous ссылается не на current, а на current.Next
                        previous.Next = current.Next;

                        // Если current.Next не установлен, значит узел последний,
                        // изменяем переменную tail
                        if (current.Next == null)
                            tail = previous;
                    }
                    else
                    {
                        // если удаляется первый элемент
                        // переустанавливаем значение head
                        head = head.Next;

                        // если после удаления список пуст, сбрасываем tail
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        // очистка списка
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        // содержит ли список элемент
        public bool Contains(T data)
        {
            Object<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }
        // добвление в начало
        public void AppendFirst(T data)
        {
            Object<T> Object = new Object<T>(data);
            Object.Next = head;
            head = Object;
            if (count == 0)
                tail = head;
            count++;
        }
        // реализация интерфейса IEnumerable
        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Object<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }

    public class MyStack<T> : IStack<T>, ICloneable,IEnumerable
    {
        LinkedList<T> _stack = new LinkedList<T>();

        System.Collections.IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        public object Clone ()
        {
            MyStack<T> _mysteck2 = new MyStack<T>();

            foreach (T new_stack in _stack)
            {
                _mysteck2.Push(new_stack);
            }

            return _mysteck2;
        }

        public void Push(T element)
        {
            _stack.Add(element);
        }

        public T Peek()
        {
            return _stack.Tail();
        }

        public T Pop()
        {
            T t = _stack.Tail();
            _stack.Remove(_stack.Tail());
            return t;
        }

        public int Count()
        {
            int _count = 0;
            foreach (var item in _stack)
            {
                _count++;
            }
            return _count;
        }

        public bool Contains(T element)
        {
            if (_stack.Contains(element))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
    class Program
    {
       
        static void Main(string[] args)
        {
            MyStack<int> _mysteck = new MyStack<int>();
            _mysteck.Push(1);
            _mysteck.Push(2);
            _mysteck.Push(3);
            _mysteck.Push(4);
            MyStack<int> _mysteck2 = (MyStack<int>)_mysteck.Clone();
            Console.WriteLine("Count - " + _mysteck.Count());
            Console.WriteLine("Peek - " + _mysteck.Peek());
            Console.WriteLine("Pop - " + _mysteck.Pop());
            Console.WriteLine("Peek2 - " + _mysteck.Peek());
            Console.WriteLine("Count2 - " + _mysteck.Count());
            _mysteck.Push(66);
            Console.WriteLine("Peek3 - " + _mysteck.Peek());
            bool contains1 = _mysteck.Contains(66);
            Console.WriteLine(contains1 == true ? "66 есть" : "66 отсутствует");

            Console.WriteLine("Pop - " + _mysteck.Pop());

            bool contains2 = _mysteck.Contains(66);
            Console.WriteLine(contains2 == true ? "66 есть" : "66 отсутствует");

            Console.WriteLine("_______________________________________________________");
            
            Console.WriteLine("Count - " + _mysteck2.Count());
            Console.WriteLine("Peek - " + _mysteck2.Peek());
            Console.WriteLine("Pop - " + _mysteck2.Pop());
            Console.WriteLine("Peek2 - " + _mysteck2.Peek());
            Console.WriteLine("Count2 - " + _mysteck2.Count());

            _mysteck2.Push(66);
            Console.WriteLine("Peek3 - " + _mysteck2.Peek());
            bool contains3 = _mysteck2.Contains(66);
            Console.WriteLine(contains3 == true ? "66 есть" : "66 отсутствует");

            Console.WriteLine("Pop - " + _mysteck2.Pop());

            bool contains4 = _mysteck2.Contains(66);
            Console.WriteLine(contains4 == true ? "66 есть" : "66 отсутствует");

            Console.ReadKey();
        }
    }
}
