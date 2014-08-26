﻿using System.Collections.Generic;
using System.Linq;
using FileBiggy.Contracts;

namespace FileBiggy
{
    public abstract class StoreBase<T> : IBiggyStore<T>
    {
        protected Dictionary<string, string> ConnectionString { get; private set; }

        public StoreBase(
            Dictionary<string, string> connectionString
            )
        {
            ConnectionString = connectionString;
        }

        protected virtual string DatabaseName
        {
            get
            {
                var thingyType = GetType().GenericTypeArguments.Single().Name;
                return Inflector.Inflector.Pluralize(thingyType).ToLower();
            }
        }

        public abstract List<T> Load();
        public abstract void Clear();
        public abstract void Add(T item);
        public abstract void Add(List<T> items);
        public abstract T Update(T item);
        public abstract void Remove(T item);
        public abstract void Remove(IEnumerable<T> items);
        public abstract IQueryable<T> AsQueryable();
    }
}
