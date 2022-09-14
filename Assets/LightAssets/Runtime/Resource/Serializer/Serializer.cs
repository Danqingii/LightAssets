using System;
using System.Collections.Generic;
using System.IO;

namespace LightAssets
{
    /// <summary>
    /// 串化器
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class Serializer<T> 
    {
        private readonly byte[] m_HeaderByte;
        private readonly Dictionary<byte, SerializeCallback> m_SerializeCallbacks;
        private readonly Dictionary<byte, DeserializeCallback> m_DeserializeCallbacks;
        private readonly Dictionary<byte, TryGetValueCallback> m_TryGetValueCallbacks;
        private byte m_LatestSerializeCallbackVersion;
        
        /// <summary>
        /// 初始化序列化
        /// </summary>
        /// <param name="header">序列器头部标识 必须3个长度的byte</param>
        public Serializer(byte[] header) 
        {
            if (header == null || header.Length != 3) 
            {
                m_HeaderByte = Array.Empty<byte>();
                throw new Exception("The sequencer header is not available.");
            }
            
            m_HeaderByte = header;
            m_SerializeCallbacks = new Dictionary<byte, SerializeCallback>(3);
            m_DeserializeCallbacks = new Dictionary<byte, DeserializeCallback>(3);
            m_TryGetValueCallbacks = new Dictionary<byte, TryGetValueCallback>(3);
            m_LatestSerializeCallbackVersion = 0;
        }
        
        /// <summary>
        /// 序列化回调函数。
        /// </summary>
        /// <param name="stream">目标流。</param>
        /// <param name="data">要序列化的数据。</param>
        /// <returns>是否序列化数据成功。</returns>
        public delegate bool SerializeCallback(Stream stream, T data);

        /// <summary>
        /// 反序列化回调函数。
        /// </summary>
        /// <param name="stream">指定流。</param>
        /// <returns>反序列化的数据。</returns>
        public delegate T DeserializeCallback(Stream stream);

        /// <summary>
        /// 尝试从指定流获取指定键的值回调函数。
        /// </summary>
        /// <param name="stream">指定流。</param>
        /// <param name="key">指定键。</param>
        /// <param name="value">指定键的值。</param>
        /// <returns>是否从指定流获取指定键的值成功。</returns>
        public delegate bool TryGetValueCallback(Stream stream, string key, out object value);
        
        /// <summary>
        /// 注册序列化回调函数。
        /// </summary>
        /// <param name="version">序列化回调函数的版本。</param>
        /// <param name="callback">序列化回调函数。</param>
        public void RegisterSerializeCallback(byte version, SerializeCallback callback)
        {
            if (callback == null)
            {
                throw new Exception("Serialize callback is invalid.");
            }

            m_SerializeCallbacks[version] = callback;
            if (version > m_LatestSerializeCallbackVersion)
            {
                m_LatestSerializeCallbackVersion = version;
            }
        }

        /// <summary>
        /// 注册反序列化回调函数。
        /// </summary>
        /// <param name="version">反序列化回调函数的版本。</param>
        /// <param name="callback">反序列化回调函数。</param>
        public void RegisterDeserializeCallback(byte version, DeserializeCallback callback)
        {
            if (callback == null)
            {
                throw new Exception("Deserialize callback is invalid.");
            }

            m_DeserializeCallbacks[version] = callback;
        }

        /// <summary>
        /// 注册尝试从指定流获取指定键的值回调函数。
        /// </summary>
        /// <param name="version">尝试从指定流获取指定键的值回调函数的版本。</param>
        /// <param name="callback">尝试从指定流获取指定键的值回调函数。</param>
        public void RegisterTryGetValueCallback(byte version, TryGetValueCallback callback)
        {
            if (callback == null)
            {
                throw new Exception("Try get value callback is invalid.");
            }

            m_TryGetValueCallbacks[version] = callback;
        }

        /// <summary>
        /// 序列化数据到目标流中。
        /// </summary>
        /// <param name="stream">目标流。</param>
        /// <param name="data">要序列化的数据。</param>
        /// <returns>是否序列化数据成功。</returns>
        public bool Serialize(Stream stream, T data)
        {
            CheckHeader();
            if (m_SerializeCallbacks.Count <= 0)
            {
                throw new Exception("No serialize callback registered.");
            }

            return Serialize(stream, data, m_LatestSerializeCallbackVersion);
        }

        /// <summary>
        /// 序列化数据到目标流中。
        /// </summary>
        /// <param name="stream">目标流。</param>
        /// <param name="data">要序列化的数据。</param>
        /// <param name="version">序列化回调函数的版本。</param>
        /// <returns>是否序列化数据成功。</returns>
        public bool Serialize(Stream stream, T data, byte version)
        {
            CheckHeader();
            byte[] header = m_HeaderByte;
            stream.WriteByte(header[0]);
            stream.WriteByte(header[1]);
            stream.WriteByte(header[2]);
            stream.WriteByte(version);
            SerializeCallback callback = null;
            if (!m_SerializeCallbacks.TryGetValue(version, out callback))
            {
                throw new Exception($"Serialize callback '{version}' is not exist.");
            }

            return callback(stream, data);
        }

        /// <summary>
        /// 从指定流反序列化数据。
        /// </summary>
        /// <param name="stream">指定流。</param>
        /// <returns>反序列化的数据。</returns>
        public T Deserialize(Stream stream) 
        {
            CheckHeader();
            byte[] header = m_HeaderByte;
            byte header0 = (byte)stream.ReadByte();
            byte header1 = (byte)stream.ReadByte();
            byte header2 = (byte)stream.ReadByte();
            if (header0 != header[0] || header1 != header[1] || header2 != header[2])
            {
                throw new Exception($"Header is invalid, need '{(char)header[0]}{(char)header[1]}{(char)header[2]}', current '{(char)header0}{(char)header1}{(char)header2}'.");
            }

            byte version = (byte)stream.ReadByte();
            DeserializeCallback callback = null;
            if (!m_DeserializeCallbacks.TryGetValue(version, out callback))
            {
                throw new Exception($"Deserialize callback '{version}' is not exist.");
            }

            return callback(stream);
        }

        /// <summary>
        /// 尝试从指定流获取指定键的值。
        /// </summary>
        /// <param name="stream">指定流。</param>
        /// <param name="key">指定键。</param>
        /// <param name="value">指定键的值。</param>
        /// <returns>是否从指定流获取指定键的值成功。</returns>
        public bool TryGetValue(Stream stream, string key, out object value)
        {
            CheckHeader();
            value = null;
            byte[] header = m_HeaderByte;
            byte header0 = (byte)stream.ReadByte();
            byte header1 = (byte)stream.ReadByte();
            byte header2 = (byte)stream.ReadByte();
            if (header0 != header[0] || header1 != header[1] || header2 != header[2])
            {
                return false;
            }

            byte version = (byte)stream.ReadByte();
            TryGetValueCallback callback = null;
            if (!m_TryGetValueCallbacks.TryGetValue(version, out callback))
            {
                return false;
            }

            return callback(stream, key, out value);
        }

        private void CheckHeader() 
        {
            if (m_HeaderByte == Array.Empty<byte>()) 
            {
                throw new Exception("The sequencer header is not available.");
            }
        }
    }
}