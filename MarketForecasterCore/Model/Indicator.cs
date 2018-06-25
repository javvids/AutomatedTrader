using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AutomatedTrader.Sharedkernel.Model;

namespace MarketForeCasterCore.Model
{

    public abstract class Indicator : Entity<string>
    {
        
        public void SetTriggerDetail(TriggerDetail triggerDetail)
        {
            TriggerDetail=triggerDetail;
        }

        public Quote Quote { get; protected set; }

        public TriggerDetail TriggerDetail { get; protected set; }

    }


    public abstract class IndicatorList<T>  :IList<T> where T:Indicator
    {
        public IList<T> _list = new List<T>();

        public abstract void Caclulate(int index);
        
        public T this[int index] { get => _list[index]; set => _list[index]=value; }

        public int Count => _list.Count;

        public bool IsReadOnly => _list.IsReadOnly;

        public void Add(T item)
        {
            _list.Add(item);

            if (_list.Count > 1)
                _list = _list.OrderBy(x => x.Quote.Today).ToList();

            Caclulate(_list.Count-1);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
            if (_list.Count > 1)
                _list = _list.OrderBy(x => x.Quote.Today).ToList();
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
