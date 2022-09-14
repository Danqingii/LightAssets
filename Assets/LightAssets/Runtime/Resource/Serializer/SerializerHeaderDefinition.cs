namespace LightAssets 
{
    /// <summary>
    /// 串化器 头部自定义 可自行修改
    /// </summary>
    internal static class SerializerHeaderDefinition 
    {
        /// <summary>
        /// 单机模式版本资源列表序列化器
        /// </summary>
        public static byte[] PackageVersionListHeader = new byte[] { (byte)'G', (byte)'F', (byte)'P' };
    }
}