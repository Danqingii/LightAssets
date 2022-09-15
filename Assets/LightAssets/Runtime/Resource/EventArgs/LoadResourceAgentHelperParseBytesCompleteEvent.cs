namespace LightAssets
{
    /// <summary>
    /// 加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件。
    /// </summary>
    public sealed class LoadResourceAgentHelperParseBytesCompleteEvent : AEventArgs
    {
        /// <summary>
        /// 初始化加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件的新实例。
        /// </summary>
        public LoadResourceAgentHelperParseBytesCompleteEvent()
        {
            Resource = null;
        }

        /// <summary>
        /// 获取加载对象。
        /// </summary>
        public object Resource
        {
            get; private set;
        }

        /// <summary>
        /// 创建加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件。
        /// </summary>
        /// <param name="resource">资源对象。</param>
        /// <returns>创建的加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件。</returns>
        public static LoadResourceAgentHelperParseBytesCompleteEvent Create(object resource)
        {
            LoadResourceAgentHelperParseBytesCompleteEvent e = ReferencePool.Acquire<LoadResourceAgentHelperParseBytesCompleteEvent>();
            e.Resource = resource;
            return e;
        }

        /// <summary>
        /// 清理加载资源代理辅助器异步将资源二进制流转换为加载对象完成事件。
        /// </summary>
        public override void Clear()
        {
            Resource = null;
        }
    }
}