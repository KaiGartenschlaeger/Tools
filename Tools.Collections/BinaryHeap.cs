using System;
using System.Collections;
using System.Collections.Generic;

namespace Tools.Collections
{
    /// <summary>
    /// Stellt einen binärbaum dar.
    /// </summary>
    public class BinaryHeap<T> : IEnumerable<T>
    {
        #region Fields

        private IComparer<T> m_comparer;
        private List<T> m_items;

        #endregion

        #region Constructor

        public BinaryHeap()
            : this(Comparer<T>.Default)
        {
        }

        public BinaryHeap(IComparer<T> comp)
        {
            m_comparer = comp;
            m_items = new List<T>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Liefert die Anzahl an Elemente in der Liste.
        /// </summary>
        public int Count
        {
            get { return m_items.Count; }
        }

        /// <summary>
        /// Entfernt alle Elemente aus der Liste.
        /// </summary>
        public void Clear()
        {
            m_items.Clear();
        }

        /// <summary>
        /// Setzt die Kapazität der Liste auf die tatsächliche Anzahl an Elemente in der Liste.
        /// </summary>
        public void TrimExcess()
        {
            m_items.TrimExcess();
        }

        /// <summary>
        /// Fügt ein Element hinzu.
        /// </summary>
        public void Insert(T newItem)
        {
            int i = Count;
            m_items.Add(newItem);
            while (i > 0 && m_comparer.Compare(m_items[(i - 1) / 2], newItem) > 0)
            {
                m_items[i] = m_items[(i - 1) / 2];
                i = (i - 1) / 2;
            }
            m_items[i] = newItem;
        }

        /// <summary>
        /// Liefert das oberste Element aus der Liste ohne es zu entfernen.
        /// </summary>
        public T Peek()
        {
            if (m_items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }
            return m_items[0];
        }

        /// <summary>
        /// Entfernt das oberste Element auf der Liste.
        /// </summary>
        public T RemoveRoot()
        {
            if (m_items.Count == 0)
            {
                throw new InvalidOperationException("The heap is empty.");
            }

            // Get the first item
            T rslt = m_items[0];

            // Get the last item and bubble it down.
            T tmp = m_items[m_items.Count - 1];
            m_items.RemoveAt(m_items.Count - 1);

            if (m_items.Count > 0)
            {
                int i = 0;
                while (i < m_items.Count / 2)
                {
                    int j = (2 * i) + 1;
                    if ((j < m_items.Count - 1) && (m_comparer.Compare(m_items[j], m_items[j + 1]) > 0))
                    {
                        ++j;
                    }
                    if (m_comparer.Compare(m_items[j], tmp) >= 0)
                    {
                        break;
                    }
                    m_items[i] = m_items[j];
                    i = j;
                }
                m_items[i] = tmp;
            }

            return rslt;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var i in m_items)
            {
                yield return i;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}