namespace LightAssets
{
    /// <summary>
    /// 加载资源代理辅助器异步加载资源完成事件。
    /// </summary>
    public sealed class LoadResourceAgentHelperLoadCompleteEvent : AEventArgs
    {
        /// <summary>
        /// 初始化加载资源代理辅助器异步加载资源完成事件的新实例。
        /// </summary>
        public LoadResourceAgentHelperLoadCompleteEvent()
        {
            Asset = null;
        }

        /// <summary>
        /// 获取加载的资源。
        /// </summary>
        public object Asset
        {
            get; private set;
        }

        /// <summary>
        /// 创建加载资源代理辅助器异步加载资源完成事件。
        /// </summary>
        /// <param name="asset">加载的资源。</param>
        /// <returns>创建的加载资源代理辅助器异步加载资源完成事件。</returns>
        public static LoadResourceAgentHelperLoadCompleteEvent Create(object asset)
        {
            LoadResourceAgentHelperLoadCompleteEvent e = ReferencePool.Acquire<LoadResourceAgentHelperLoadCompleteEvent>();
            e.Asset = asset;
            return e;
        }

        /// <summary>
        /// 清理加载资源代理辅助器异步加载资源完成事件。
        /// </summary>
        public override void Clear()
        {
            Asset = null;
        }
    }
}