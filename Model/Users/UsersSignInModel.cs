namespace ducky_api_server.Model.Users
{
    public class UsersSignInModel
    {
        /// <summary>
        /// 登录用户名,支持使用邮箱或手机号登录
        /// </summary>
        /// <value></value>
        public string Account { get; set; }
        /// <summary>
        /// 密码,密文32位md5
        /// </summary>
        /// <value></value>
        public string Password { get; set; }
    }
}