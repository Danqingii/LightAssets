using System;

namespace LightAssets
{
    /// <summary>
    /// 抽象对象基类。
    /// </summary>
    public abstract class AObject : IReference 
    {
        /// <summary>
        /// 获取对象名称。
        /// </summary>
        public string Name 
        {
            get; private set;
        }

        /// <summary>
        /// 获取对象。
        /// </summary>
        public object Target
        {
            get; private set;
        }

        /// <summary>
        /// 获取或设置对象是否被加锁。
        /// </summary>
        public bool Locked
        {
            get; set;
        }

        /// <summary>
        /// 获取或设置对象的优先级。
        /// </summary>
        public int Priority
        {
            get; set;
        }

        /// <summary>
        /// 获取自定义释放检查标记。
        /// </summary>
        public virtual bool CustomCanReleaseFlag 
        {
            get;
            set;
        } = true;

        /// <summary>
        /// 获取对象上次使用时间。
        /// </summary>
        public DateTime LastUseTime 
        {
            get; internal set;
        }
        
        public AObject() 
        {
            Name = null;
            Target = null;
            Locked = false;
            Priority = 0;
            LastUseTime = default(DateTime);
        }

        /// <summary>
        /// 初始化对象基类。
        /// </summary>
        /// <param name="name">对象名称。</param>
        /// <param name="target">对象。</param>
        /// <param name="locked">对象是否被加锁。</param>
        /// <param name="priority">对象的优先级。</param>
        protected void Initialize(string name, object target, bool locked, int priority)
        {
            if (target == null)
            {
                throw new Exception($"Target '{name}' is invalid.");
            }

            Name = name ?? string.Empty;
            Target = target;
            Locked = locked;
            Priority = priority;
            LastUseTime = DateTime.UtcNow;
        }

        /// <summary>
        /// 清理对象基类。
        /// </summary>
        public virtual void Clear()
        {
            Name = null;
            Target = null;
            Locked = false;
            Priority = 0;
            LastUseTime = default(DateTime);
        }

        /// <summary>
        /// 获取对象时的事件。
        /// </summary>
        protected internal virtual void OnSpawn()
        {
        }

        /// <summary>
        /// 回收对象时的事件。
        /// </summary>
        protected internal virtual void OnUnspawn()
        {
        }

        /// <summary>
        /// 释放对象。
        /// </summary>
        /// <param name="isShutdown">是否是关闭对象池时触发。</param>
        protected internal abstract void Release(bool isShutdown);
    }
    
    
}