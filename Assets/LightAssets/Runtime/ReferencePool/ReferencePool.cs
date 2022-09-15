using System;
using System.Collections.Generic;

namespace LightAssets 
{
    /// <summary>
    /// 引用池
    /// </summary>
    internal static class ReferencePool 
    {
        private static readonly Dictionary<Type, Collection> s_Pool = new Dictionary<Type, Collection>();
        
        public static bool EnableStrictCheck 
        {
            get;
            set;
        }

        public static void Clear() {
            foreach (Collection collection in s_Pool.Values)
            {
                collection.RemoveAll();
            }
            s_Pool.Clear();
        }

        public static T Acquire<T>() where T : class, IReference, new()
        {
            return GetCollection(typeof(T)).Acquire<T>();
        }
        
        public static IReference Acquire(Type reference) 
        { 
            StrictCheck(reference);
            return GetCollection(reference).Acquire();
        }
        
        public static void Release(IReference reference)
        {
            if (reference == null)
            {
                throw new Exception("Reference is invalid.");
            }
            Type referenceType = reference.GetType();
            StrictCheck(referenceType);
            GetCollection(referenceType).Release(reference);
        }
        
        public static void Add<T>(int count) where T : class, IReference, new()
        {
            GetCollection(typeof(T)).Add<T>(count);
        }

        public static void Add(Type referenceType, int count)
        {
            StrictCheck(referenceType);
            GetCollection(referenceType).Add(count);
        }

        public static void Remove<T>(int count) where T : class, IReference
        {
            GetCollection(typeof(T)).Remove(count);
        }

        public static void Remove(Type referenceType, int count)
        {
            StrictCheck(referenceType);
            GetCollection(referenceType).Remove(count);
        }

        public static void RemoveAll<T>() where T : class, IReference
        {
            GetCollection(typeof(T)).RemoveAll();
        }

        public static void RemoveAll(Type referenceType)
        {
            StrictCheck(referenceType);
            GetCollection(referenceType).RemoveAll();
        }

        private static Collection GetCollection(Type referenceType) {
            if (referenceType == null)
            {
                throw new Exception("ReferenceType is invalid.");
            }
            
            if (!s_Pool.TryGetValue(referenceType, out var collection))
            {
                collection = new Collection(referenceType);
                s_Pool.Add(referenceType, collection);
            }
            return collection;
        }

        private static void StrictCheck(Type referenceType) 
        {
            if (!EnableStrictCheck) {
                return;
            }

            if (referenceType == null) {
                throw new Exception("Reference type is invalid.");
            }

            if (referenceType.IsAbstract || !referenceType.IsClass) {
                throw new Exception("Reference type is not a non-abstract class type.");
            }

            if (!typeof(IReference).IsAssignableFrom(referenceType)) {
                throw new Exception($"Reference type '{referenceType.FullName}' is invalid.");
            }
        }
        
        private sealed class Collection 
        {
            private readonly Queue<IReference> m_References;
            private readonly Type m_ReferenceType;

            public Collection(Type referenceType) {
                m_ReferenceType = referenceType;
                m_References = new Queue<IReference>();
            }
            
            public int UsingCount {
                get; private set;
            }

            public int AcquireCount {
                get; private set;
            }

            public int ReleaseCount {
                get; private set;
            }

            public int AddCount {
                get; private set;
            }

            public int RemoveCount {
                get; private set;
            }

            public T Acquire<T>() where T : class, IReference,new()
            {
                if (typeof(T) != m_ReferenceType) {
                    throw new Exception("类型不可用");
                }
                UsingCount++;
                AcquireCount++;
                if (m_References.Count > 0)
                {
                    return (T)m_References.Dequeue();
                }
                AddCount++;
                return new T();
            }
            
            public IReference Acquire()
            {
                UsingCount++;
                AcquireCount++;
                if (m_References.Count > 0)
                {
                    return m_References.Dequeue();
                }
                AddCount++;
                return (IReference)Activator.CreateInstance(m_ReferenceType);
            }

            public void Release(IReference reference) {
                reference.Clear();
                if (m_References.Contains(reference)) {
                    throw new Exception("引用已存在");
                }
                m_References.Enqueue(reference);
                UsingCount--;
                ReleaseCount++;
            }

            public void Add<T>(int count) where T : class, IReference,new() 
            {
                if (typeof(T) != m_ReferenceType) {
                    throw new Exception("类型不可用");
                }
                while (count-- > 0) {
                    m_References.Enqueue(new T());
                    AddCount++;
                }
            }

            public void Add(int count) {
                while (count-- > 0) {
                    m_References.Enqueue((IReference)Activator.CreateInstance(m_ReferenceType));
                    AddCount++;
                }
            }

            public void Remove(int count) {
                count = count > m_References.Count ? m_References.Count : count;
                RemoveCount += count;
                while (count-- > 0) {
                    m_References.Dequeue();
                }
            }

            public void RemoveAll() {
                RemoveCount += m_References.Count;
                m_References.Clear();
            }
        }
    }
}