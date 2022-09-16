namespace GameFrameworkAsset
{
    /// <summary>
    /// 资源更新全部完成事件。
    /// </summary>
    public sealed class ResourceUpdateAllCompleteEvent : AEventArgs
    {
        /// <summary>
        /// 初始化资源更新全部完成事件的新实例。
        /// </summary>
        public ResourceUpdateAllCompleteEvent()
        {
        }

        /// <summary>
        /// 创建资源更新全部完成事件。
        /// </summary>
        /// <returns>创建的资源更新全部完成事件。</returns>
        public static ResourceUpdateAllCompleteEvent Create()
        {
            return ReferencePool.Acquire<ResourceUpdateAllCompleteEvent>();
        }

        /// <summary>
        /// 清理资源更新全部完成事件。
        /// </summary>
        public override void Clear()
        {
        }
    }
}