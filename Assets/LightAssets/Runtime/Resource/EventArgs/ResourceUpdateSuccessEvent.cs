﻿namespace GameFrameworkAsset
{
    /// <summary>
    /// 资源更新成功事件。
    /// </summary>
    public sealed class ResourceUpdateSuccessEvent : AEventArgs
    {
        /// <summary>
        /// 初始化资源更新成功事件的新实例。
        /// </summary>
        public ResourceUpdateSuccessEvent()
        {
            Name = null;
            DownloadPath = null;
            DownloadUri = null;
            Length = 0;
            CompressedLength = 0;
        }

        /// <summary>
        /// 获取资源名称。
        /// </summary>
        public string Name
        {
            get; private set;
        }

        /// <summary>
        /// 获取资源下载后存放路径。
        /// </summary>
        public string DownloadPath
        {
            get; private set;
        }

        /// <summary>
        /// 获取下载地址。
        /// </summary>
        public string DownloadUri
        {
            get; private set;
        }

        /// <summary>
        /// 获取资源大小。
        /// </summary>
        public int Length
        {
            get; private set;
        }

        /// <summary>
        /// 获取压缩后大小。
        /// </summary>
        public int CompressedLength
        {
            get; private set;
        }

        /// <summary>
        /// 创建资源更新成功事件。
        /// </summary>
        /// <param name="name">资源名称。</param>
        /// <param name="downloadPath">资源下载后存放路径。</param>
        /// <param name="downloadUri">资源下载地址。</param>
        /// <param name="length">资源大小。</param>
        /// <param name="compressedLength">压缩后大小。</param>
        /// <returns>创建的资源更新成功事件。</returns>
        public static ResourceUpdateSuccessEvent Create(string name, string downloadPath, string downloadUri, int length, int compressedLength)
        {
            ResourceUpdateSuccessEvent e = ReferencePool.Acquire<ResourceUpdateSuccessEvent>();
            e.Name = name;
            e.DownloadPath = downloadPath;
            e.DownloadUri = downloadUri;
            e.Length = length;
            e.CompressedLength = compressedLength;
            return e;
        }

        /// <summary>
        /// 清理资源更新成功事件。
        /// </summary>
        public override void Clear()
        {
            Name = null;
            DownloadPath = null;
            DownloadUri = null;
            Length = 0;
            CompressedLength = 0;
        }
    }
}
