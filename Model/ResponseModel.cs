namespace ducky_api_server.Model
{
    public class ResponseModel
    {
        /// <summary>
        /// HttpStatus 
        /// </summary>
        /// <value></value>
        public int Code { get; set; }
        /// <summary>
        /// 响应信息
        /// </summary>
        /// <value></value>
        public string Message { get; set; }
        /// <summary>
        /// 响应内容
        /// </summary>
        /// <value></value>
        public object Content { get; set; }
        /// <summary>
        /// 接口是否执行成功
        /// </summary>
        /// <value></value>
        public bool Success { get; set; }
        /// <summary>
        /// 总数
        /// </summary>
        /// <value></value>
        public long Total { get; set; }
        /// <summary>
        /// 合计
        /// </summary>
        /// <value></value>
        public long Count { get; set; }
    }
}