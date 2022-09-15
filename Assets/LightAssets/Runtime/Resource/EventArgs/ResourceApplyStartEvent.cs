namespace LightAssets
{
    /// <summary>
    /// 资源应用开始事件。
    /// </summary>
    public sealed class ResourceApplyStartEvent : AEventArgs
    {
        /// <summary>
        /// 初始化资源应用开始事件的新实例。
        /// </summary>
        public ResourceApplyStartEvent()
        {
            ResourcePackPath = null;
            Count = 0;
            TotalLength = 0L;
        }

        /// <summary>
        /// 获取资源包路径。
        /// </summary>
        public string ResourcePackPath
        {
            get; private set;
        }

        /// <summary>
        /// 获取要应用资源的数量。
        /// </summary>
        public int Count
        {
            get; private set;
        }

        /// <summary>
        /// 获取要应用资源的总大小。
        /// </summary>
        public long TotalLength
        {
            get; private set;
        }

        /// <summary>
        /// 创建资源应用开始事件。
        /// </summary>
        /// <param name="resourcePackPath">资源包路径。</param>
        /// <param name="count">要应用资源的数量。</param>
        /// <param name="totalLength">要应用资源的总大小。</param>
        /// <returns>创建的资源应用开始事件。</returns>
        public static ResourceApplyStartEvent Create(string resourcePackPath, int count, long totalLength)
        {
            ResourceApplyStartEvent e = ReferencePool.Acquire<ResourceApplyStartEvent>();
            e.ResourcePackPath = resourcePackPath;
            e.Count = count;
            e.TotalLength = totalLength;
            return e;
        }

        /// <summary>
        /// 清理资源应用开始事件。
        /// </summary>
        public override void Clear()
        {
            ResourcePackPath = null;
            Count = 0;
            TotalLength = 0L;
        }
    }
}