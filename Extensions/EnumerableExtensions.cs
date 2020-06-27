using System;
using System.Collections.Generic;

namespace ducky_api_server.Extensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 遍历一个列表，执行委托后，返回新列表
        /// </summary>
        /// <typeparam name="To"></typeparam>
        public static List<To> Each<T,To>(this List<T> collections,Func<T,To> func) where T: class,new() where To:class,new()
        {
            List<To> list = new List<To>();
            foreach (var item in collections)
            {
                list.Add(func(item));
            }
            return list;
        }

        public static List<To> Filter<To>(this List<To> collections,Func<To,bool> predicate) where To:class,new()
        {
            if (predicate.IsNull())
            {
                throw new ArgumentNullException();
            }
            var list = new List<To>();
            foreach (var item in collections)
            {
                if (predicate(item))
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}