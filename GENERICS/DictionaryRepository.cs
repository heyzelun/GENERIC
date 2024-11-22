namespace GENERICS
{
    using System;
    using System.Collections.Generic;

    public class DictionaryRepository<TKey, TValue> where TKey : IComparable<TKey>
    {
        private Dictionary<TKey, TValue> _items;

        public DictionaryRepository()
        {
            _items = new Dictionary<TKey, TValue>();
        }

        public void Add(TKey id, TValue item)
        {
            if (_items.ContainsKey(id))
            {
                throw new ArgumentException("An item with the same key already exists.");
            }
            _items.Add(id, item);
        }

        public TValue Get(TKey id)
        {
            if (!_items.TryGetValue(id, out TValue item))
            {
                throw new KeyNotFoundException("The specified key does not exist.");
            }
            return item;
        }

        public void Update(TKey id, TValue newItem)
        {
            if (!_items.ContainsKey(id))
            {
                throw new KeyNotFoundException("The specified key does not exist.");
            }
            _items[id] = newItem;
        }

        public void Delete(TKey id)
        {
            if (!_items.Remove(id))
            {
                throw new KeyNotFoundException("The specified key does not exist.");
            }
        }
    }
}

