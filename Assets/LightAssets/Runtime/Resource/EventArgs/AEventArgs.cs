using System;

namespace LightAssets 
{
    /// <summary>
    /// 抽象事件基类。
    /// </summary>
    public abstract class AEventArgs : EventArgs,IReference 
    {
        protected AEventArgs()
        {
        }

        /// <summary>
        /// 清理引用。
        /// </summary>
        public abstract void Clear();
    }
}