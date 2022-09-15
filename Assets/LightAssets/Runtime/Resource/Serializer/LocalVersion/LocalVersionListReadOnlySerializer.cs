namespace LightAssets 
{
    /// <summary>
    /// 本地只读版本序列器
    /// </summary>
    public class LocalVersionListReadOnlySerializer : ASerializer<LocalVersionList>
    {
        private static readonly byte[] Header = new byte[] { (byte)'G', (byte)'F', (byte)'R' };

        /// <summary>
        /// 初始化本地只读区版本资源列表序列化器的新实例。
        /// </summary>
        public LocalVersionListReadOnlySerializer()
        {
        }

        /// <summary>
        /// 获取本地只读区版本资源列表头标识。
        /// </summary>
        /// <returns>本地只读区版本资源列表头标识。</returns>
        protected override byte[] GetHeader()
        {
            return Header;
        }
    }
}