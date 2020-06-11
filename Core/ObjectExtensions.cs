using System;
using System.Reflection;
using System.Linq;

namespace ducky_api_server.Core
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// 判断字符串是否为null或空
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        /// <summary>
        /// 判断对象是否为null
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }
    }
}