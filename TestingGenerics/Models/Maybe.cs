using System;

namespace TestingGenerics.Models
{
    public class Maybe<T> where T : class
    {
        private readonly T _instance;

        public static Maybe<T> None() => new Maybe<T>();

        public Maybe(T instance)
        {
            _instance = instance;
        }

        private Maybe() {}

        public Maybe<T> Bind(Func<T, Maybe<T>> func)
        {
            return _instance != null ? func(_instance) : None();
        }
        
        public T GetInstance()
        {
            return _instance;
        }

        public bool HasValue()
        {
            return _instance != null;
        }
    }
}
