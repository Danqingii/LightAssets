namespace LightAssets
{
    /// <summary>
    /// 资源校验失败事件。
    /// </summary>
    public sealed class ResourceVerifyFailureEvent : AEventArgs
    {
        /// <summary>
        /// 初始化资源校验失败事件的新实例。
        /// </summary>
        public ResourceVerifyFailureEvent()
        {
            Name = null;
        }

        /// <summary>
        /// 获取资源名称。
        /// </summary>
        public string Name
        {
            get; private set;
        }

        /// <summary>
        /// 创建资源校验失败事件。
        /// </summary>
        /// <param name="name">资源名称。</param>
        /// <returns>创建的资源校验失败事件。</returns>
        public static ResourceVerifyFailureEvent Create(string name)
        {
            ResourceVerifyFailureEvent e = ReferencePool.Acquire<ResourceVerifyFailureEvent>();
            e.Name = name;
            return e;
        }

        /// <summary>
        /// 清理资源校验失败事件。
        /// </summary>
        public override void Clear()
        {
            Name = null;
        }
    }
}