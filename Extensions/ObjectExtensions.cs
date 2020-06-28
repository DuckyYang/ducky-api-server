using System;
using System.Reflection;
using System.Linq;
using System.ComponentModel;

namespace ducky_api_server.Extensions
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
        /// safely convert object to string 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>return string or empty</returns>
        public static string SafeToString(this object obj)
        {
            string str = string.Empty;
            if (!obj.IsNull())
            {
                str = obj.ToString();
            }
            return str;
        }
        /// <summary>
        /// safely convert object to int 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>return int value or zero</returns>
        public static int ToInt(this object obj)
        {
            bool flag = int.TryParse(obj.SafeToString(), out int result);
            return flag ? result : 0;
        }
        /// <summary>
        /// safely convert object to long 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>return long value or zero</returns>
        public static long ToLong(this object obj)
        {
            bool flag = long.TryParse(obj.SafeToString(), out long result);
            return flag ? result : 0;
        }
        /// <summary>
        /// safely convert object to bool 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>return bool value or false</returns>
        public static bool ToBool(this object obj)
        {
            bool flag = bool.TryParse(obj.SafeToString(), out bool result);
            return flag ? result : false;
        }
        /// <summary>
        /// safely convert object to double 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>return double value or 0</returns>
        public static double ToDouble(this object obj)
        {
            bool flag = double.TryParse(obj.SafeToString(), out double result);
            return flag ? result : 0;
        }
        /// <summary>
        /// safely convert object to float 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>return float value or 0</returns>
        public static float ToFloat(this object obj)
        {
            bool flag = float.TryParse(obj.SafeToString(), out float result);
            return flag ? result : 0;
        }
        /// <summary>
        /// safely convert object to decimal 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>return decimal value or 0</returns>
        public static decimal ToDecimal(this object obj)
        {
            bool flag = decimal.TryParse(obj.SafeToString(), out decimal result);
            return flag ? result : 0;
        }
        /// <summary>
        /// safely convert object to DateTime 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>return DateTime value or DateTime.MinValue</returns>
        public static DateTime ToDateTime(this object obj)
        {
            bool flag = DateTime.TryParse(obj.SafeToString(), out DateTime result);
            return flag ? result : DateTime.MinValue;
        }
        /// <summary>
        /// check object is null or DBNull
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null || obj == DBNull.Value;
        }
        /// <summary>
        /// 判断是否是可以转换为bool类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="result">转换后的结果</param>
        /// <returns></returns>
        public static bool IsBool(this object obj,out bool result)
        {
            return bool.TryParse(obj.SafeToString(), out result);
        }
        /// <summary>
        /// 判断是否是可转bool类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsBool(this object obj)
        {
            return obj.IsBool(out _);
        }
        /// <summary>
        /// 判断是否是可转Int类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="result">转换后的值</param>
        /// <returns></returns>
        public static bool IsInt(this object obj,out int result)
        {
            return int.TryParse(obj.SafeToString(), out result);
        }
        /// <summary>
        /// 判断是否是可转Int类型
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsInt(this object obj)
        {
            return obj.IsInt(out _);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool IsLong(this object obj,out long result)
        {
            return long.TryParse(obj.SafeToString(), out result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsLong(this object obj)
        {
            return obj.IsLong(out _);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool IsFloat(this object obj,out float result)
        {
            return float.TryParse(obj.SafeToString(), out result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsFloat(this object obj)
        {
            return obj.IsFloat(out _);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool IsDouble(this object obj,out double result)
        {
            return double.TryParse(obj.SafeToString(), out result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsDouble(this object obj)
        {
            return obj.IsDouble(out _);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool IsDecimal(this object obj,out decimal result)
        {
            return decimal.TryParse(obj.SafeToString(), out result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsDecimal(this object obj)
        {
            return obj.IsDecimal(out _);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public static bool IsDateTime(this object obj,out DateTime result)
        {
            return DateTime.TryParse(obj.SafeToString(), out result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsDateTime(this object obj)
        {
            return obj.IsDateTime(out _);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsString(this object obj)
        {
            return !obj.IsNull();
        }
        /// <summary>
        /// 判断obj是否可以转成string类型
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsString(this object obj,out string str)
        {
            str = obj.SafeToString();
            return !obj.IsNull();
        }

        public static string ToJson(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(this string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json);
        }
        public static string GetDescription(this Enum value, bool nameInstend = true)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
            {
                return null;
            }
            FieldInfo field = type.GetField(name);
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            if (attribute == null && nameInstend == true)
            {
                return name;
            }
            return attribute == null ? null : attribute.Description;
        }
    }
}