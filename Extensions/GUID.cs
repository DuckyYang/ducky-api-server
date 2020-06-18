using System;

namespace ducky_api_server.Extensions
{
    public class GUID
    {
        public static string New
        {
            get
            {
                return Guid.NewGuid().ToString().ToUpper().Replace("-","");
            }
        }
    }
}