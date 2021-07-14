using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;


namespace MyComboBoxRadioButton
{
    /// <summary>
    /// Sadece sık kullanılacak metotları içeren kendi listemizi tanımlıyoruz.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class OurList<T> : IList
    {
        /// <summary>
        /// Linked List veya bir dizi kullanarak kendi listemizi oluşturabilirdik ancak kod kalabalığına gerek yok.
        /// Bu nedenle <seealso cref="List{T}"/> sınıfından faydalandım. 
        /// </summary>
        private readonly List<T> list = new();

        [NonSerialized]
        private object syncRoot;

        public object this[int index]
        {
            get => list[index];
            set => list[index] = (T)value;
        }

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Count => list.Count;

        /// <summary>
        /// Bu koleksiyonun senkronize edilmediğini belirtiyoruz. Yani bu sınıf thread-safe değil. Koleksiyonu 
        /// senkronize etmek için <seealso cref="SyncRoot"/> özelliğini kullanınız.
        /// </summary>
        public bool IsSynchronized => false;

        /// <summary>
        /// Koleksiyona erişimi senkronize etmek için kullanabileceğiniz bir nesneyi geriye döndürür.
        /// </summary>
        public object SyncRoot
        {
            get
            {
                if (syncRoot == null)
                    Interlocked.CompareExchange<object>(ref syncRoot, new object(), null);
                return syncRoot;
            }
        }

        public int Add(object value)
        {
            list.Add((T)value);
            return list.Count - 1;
        }

        public void Clear() => list.Clear();

        public bool Contains(object value) => list.Contains((T)value);

        public void CopyTo(Array array, int index) => list.CopyTo((T[])array, index);

        public IEnumerator GetEnumerator() => list.GetEnumerator();

        public int IndexOf(object value) => list.IndexOf((T)value);

        public void Insert(int index, object value) => list.Insert(index, (T)value);

        public void Remove(object value) => list.Remove((T)value);

        public void RemoveAt(int index) => list.RemoveAt(index);
    }
}