namespace GameFrameworkAsset
{
    /// <summary>
    /// 单机模式版本资源列表序列器
    /// </summary>
    public class PackageVersionListSerializer : ASerializer<PackageVersionList>
    {
        private static readonly byte[] Header = new byte[] { (byte)'G', (byte)'F', (byte)'P' };

        public PackageVersionListSerializer() 
        {
            
        }
        
        /// <summary>
        /// 获取单机模式版本资源列表头标识。
        /// </summary>
        protected override byte[] GetHeader() 
        {
            return Header;
        }
    }
}