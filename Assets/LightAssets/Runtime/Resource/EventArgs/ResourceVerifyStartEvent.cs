namespace GameFrameworkAsset
{
    /// <summary>
    /// 资源校验开始事件。
    /// </summary>
    public sealed class ResourceVerifyStartEvent : AEventArgs
    {
        /// <summary>
        /// 初始化资源校验开始事件的新实例。
        /// </summary>
        public ResourceVerifyStartEvent()
        {
            Count = 0;
            TotalLength = 0L;
        }

        /// <summary>
        /// 获取要校验资源的数量。
        /// </summary>
        public int Count
        {
            get; private set;
        }

        /// <summary>
        /// 获取要校验资源的总大小。
        /// </summary>
        public long TotalLength
        {
            get; private set;
        }

        /// <summary>
        /// 创建资源校验开始事件。
        /// </summary>
        /// <param name="count">要校验资源的数量。</param>
        /// <param name="totalLength">要校验资源的总大小。</param>
        /// <returns>创建的资源校验开始事件。</returns>
        public static ResourceVerifyStartEvent Create(int count, long totalLength)
        {
            ResourceVerifyStartEvent e = ReferencePool.Acquire<ResourceVerifyStartEvent>();
            e.Count = count;
            e.TotalLength = totalLength;
            return e;
        }

        /// <summary>
        /// 清理资源校验开始事件。
        /// </summary>
        public override void Clear()
        {
            Count = 0;
            TotalLength = 0L;
        }
    }
}