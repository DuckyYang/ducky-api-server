namespace ducky_api_server.Extensions
{
    /// <summary>
    /// 系统消息类
    /// </summary>
    public class SystemMessage
    {
        /// <summary>
        /// 用户名或密码不能为空
        /// </summary>
        public static string AccountOrPasswordCanNotBeEmpty = "用户名或密码不能为空";
        /// <summary>
        /// 用户名或密码错误
        /// </summary>
        public static string AccountOrPasswordError = "用户名或密码错误";
        /// <summary>
        /// 您的账号已被锁定,请联系管理员解锁!
        /// </summary>
        public static string AccountHasBeenLocked = "您的账号已被锁定,请联系管理员解锁!";
        /// <summary>
        /// 用户名或密码错误超过8次,账号已被锁定,请联系管理员解锁!
        /// </summary>
        public static string AccountOrPasswordErrorTooMuchAndBeLocked = "用户名或密码错误超过8次,账号已被锁定,请联系管理员解锁!";
        /// <summary>
        /// 缺少关键参数
        /// </summary>
        public static string MissingKeyParameters = "缺少关键参数";
        /// <summary>
        /// 系统内部异常,未成功发送请求
        /// </summary>
        public static string SystemInnerErrorRequestSendFail = "系统内部异常,未成功发送请求";
                /// <summary>
        /// 未从系统中找到当前请求配置
        /// </summary>
        public static string SystemDoesNotHaveRequestConfig = "未从系统中找到当前请求配置";
    }
}