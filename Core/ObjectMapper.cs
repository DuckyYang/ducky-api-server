using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ducky_api_server.Core
{
    public static class ObjectMapper
    {
         /// <summary>
        /// 映射集合
        /// </summary>
        /// <typeparam name="To"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static List<To> MapList<To>(this IEnumerable<object> from) where To: new()
        {
            return from.Select(r => { return r.Map<To>(); }).ToList();
        }
        /// <summary>
        /// 映射对象，只能映射同名的属性
        /// </summary>
        /// <typeparam name="To">目标对象</typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static To Map<To>(this object from) where To : new()
        {
            if (from.IsNull())
            {
                return default;
            }

            To to = new To();
            return (To)MapProperties(from, to);
        }
        /// <summary>
        /// 映射对象，只能映射同名的属性
        /// </summary>
        /// <typeparam name="To">目标对象</typeparam>
        /// <typeparam name="From">源对象</typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static To Map<To, From>(this From from) where To : new()
        {
            if (from.IsNull())
            {
                return default;
            }
            To to = new To();
            return (To)MapProperties(from, to);
        }
        /// <summary>
        /// 克隆一个对象
        /// </summary>
        /// <param name="from"></param>
        /// <returns></returns>
        public static object Clone(this object from)
        {
            var type = from.GetType();
            if (from.IsNull() || !type.IsClass)
            {
                return default;
            }
            var to = type.Assembly.CreateInstance(type.FullName);

            return MapProperties(from, to);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="from"></param>
        /// <returns></returns>
        public static T Clone<T>(this T from) where T : class, new()
        {
            return (T)Clone((object)from);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private static object MapProperties(object from, object to)
        {
            var fromPis = from.GetType().GetProperties();
            var toPis = to.GetType().GetProperties();

            //遍历from的属性
            foreach (var fromProperty in fromPis)
            {
                if (!fromProperty.CanRead)
                {
                    continue;
                }
                var toProperty = toPis.FirstOrDefault(r => r.Name == fromProperty.Name);
                if (!toProperty.IsNull())
                {
                    if (!toProperty.CanWrite)
                    {
                        continue;
                    }
                    //获取原数据
                    object val = fromProperty.GetValue(from);
                    //如果是泛型
                    if (fromProperty.PropertyType.IsGenericType)
                    {
                        //获取泛型集合的类型T
                        var type = fromProperty.PropertyType.GetGenericArguments()[0];
                        //获取val中的每项内容并clone
                        if (!val.IsNull())
                        {
                            IEnumerable list = val as IEnumerable;
                            var modelList = Activator.CreateInstance(typeof(List<>).MakeGenericType(new Type[] { type }));
                            var addMethod = modelList.GetType().GetMethod("Add");
                            foreach (var item in list)
                            {
                                addMethod.Invoke(modelList, new object[] { Clone(item) });
                            }
                            toProperty.SetValue(to, modelList);
                        }
                        else
                        {
                            toProperty.SetValue(to, null);
                        }
                    }
                    //如果属性类型是class而且不是string类型
                    else if (fromProperty.PropertyType.IsClass && fromProperty.PropertyType.FullName != "System.String")
                    {
                        var newVal = Clone(val);
                        toProperty.SetValue(to, newVal);
                    }
                    else //基础类型
                    {
                        //判断属性类型，尝试转换
                        to.SetPropertyValue(toProperty, val);
                    }
                }
            }

            return to;
        }
        /// <summary>
        /// 设置一个对象中的某个属性的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="to"></param>
        /// <param name="toProperty"></param>
        /// <param name="val"></param>
        public static void SetPropertyValue<T>(this T to, PropertyInfo toProperty, object val)
        {
            //判断属性类型，尝试转换
            switch (Type.GetTypeCode(toProperty.PropertyType))
            {
                case TypeCode.Boolean:
                    {
                        if (val.IsBool(out bool newVal))
                        {
                            toProperty.SetValue(to, newVal);
                        }
                    }
                    break;
                case TypeCode.Int32:
                    {
                        if (val.IsInt(out int newVal))
                        {
                            toProperty.SetValue(to, newVal);
                        }
                    }
                    break;
                case TypeCode.Int64:
                    {
                        if (val.IsLong(out long newVal))
                        {
                            toProperty.SetValue(to, newVal);
                        }
                    }
                    break;
                case TypeCode.Single:
                    {
                        if (val.IsFloat(out float newVal))
                        {
                            toProperty.SetValue(to, newVal);
                        }
                    }
                    break;
                case TypeCode.Double:
                    {
                        if (val.IsDouble(out double newVal))
                        {
                            toProperty.SetValue(to, newVal);
                        }
                    }
                    break;
                case TypeCode.Decimal:
                    {
                        if (val.IsDecimal(out decimal newVal))
                        {
                            toProperty.SetValue(to, newVal);
                        }
                    }
                    break;
                case TypeCode.DateTime:
                    {
                        if (val.IsDateTime(out DateTime newVal))
                        {
                            toProperty.SetValue(to, newVal);
                        }
                    }
                    break;
                case TypeCode.String:
                    {
                        if (val.IsString(out string newVal))
                        {
                            toProperty.SetValue(to, newVal);
                        }
                    }
                    break;
                case TypeCode.Object:
                    {
                        toProperty.SetValue(to, val);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}