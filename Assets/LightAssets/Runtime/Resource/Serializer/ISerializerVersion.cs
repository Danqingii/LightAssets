namespace GameFrameworkAsset 
{
    /// <summary>
    /// 版本序列器接口
    /// </summary>
    public interface ISerializerVersion 
    {
        /// <summary>
        /// 获取单机模式版本资源列表序列化器。
        /// </summary>
        PackageVersionListSerializer PackageVersionListSerializer
        {
            get;
        }

        /// <summary>
        /// 获取可更新模式版本资源列表序列化器。
        /// </summary>
        UpdatableVersionListSerializer UpdatableVersionListSerializer
        {
            get;
        }

        /// <summary>
        /// 获取本地只读区版本资源列表序列化器。
        /// </summary>
        LocalVersionListReadOnlySerializer LocalVersionListReadOnlySerializer
        {
            get;
        }

        /// <summary>
        /// 获取本地读写区版本资源列表序列化器。
        /// </summary>
        LocalVersionListReadWriteSerializer LocalVersionListReadWriteSerializer
        {
            get;
        }

        /// <summary>
        /// 获取资源包版本资源列表序列化器。
        /// </summary>
        ResourcePackVersionListSerializer ResourcePackVersionListSerializer
        {
            get;
        }
    }
}