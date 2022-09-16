﻿namespace GameFrameworkAsset 
{
    /// <summary>
    /// 可更新模式版本资源列表序列化器。
    /// </summary>
    public sealed class UpdatableVersionListSerializer : ASerializer<UpdatableVersionList>
    {
        private static readonly byte[] Header = new byte[] { (byte)'G', (byte)'F', (byte)'U' };

        /// <summary>
        /// 初始化可更新模式版本资源列表序列化器的新实例。
        /// </summary>
        public UpdatableVersionListSerializer()
        {
        }

        /// <summary>
        /// 获取可更新模式版本资源列表头标识。
        /// </summary>
        /// <returns>可更新模式版本资源列表头标识。</returns>
        protected override byte[] GetHeader()
        {
            return Header;
        }
    }
}