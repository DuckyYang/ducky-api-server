using ducky_api_server.Model;
using Microsoft.AspNetCore.Mvc;

namespace ducky_api_server.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ResponseModel Success()
        {
            return new ResponseModel
            {
                Code = 200,
                Success = true,
                Content = null,
                Count = 0,
                Total = 0,
                Message = "请求成功"
            };
        }
        protected ResponseModel Success(object obj)
        {
            return new ResponseModel
            {
                Code = 200,
                Success = true,
                Content = obj,
                Count = 0,
                Total = 0,
                Message = "请求成功"
            };
        }
        protected ResponseModel Success(object obj, long total)
        {
            return new ResponseModel
            {
                Code = 200,
                Success = true,
                Content = obj,
                Count = 0,
                Total = total,
                Message = "请求成功"
            };
        }
        protected ResponseModel Success(object obj, long total, long count)
        {
            return new ResponseModel
            {
                Code = 200,
                Success = true,
                Content = obj,
                Count = count,
                Total = total,
                Message = "请求成功"
            };
        }
        /// <summary>
        /// 接口执行失败
        /// </summary>
        /// <returns></returns>
        protected ResponseModel Fail()
        {
            return new ResponseModel
            {
                Code = 200,
                Message = "请求失败",
                Success = false,
                Content = null,
                Count = 0,
                Total = 0
            };
        }
        /// <summary>
        /// 接口执行失败
        /// </summary>
        /// <param name="message">失败原因</param>
        /// <returns></returns>
        protected ResponseModel Fail(string message)
        {
            return new ResponseModel
            {
                Code = 200,
                Message = message,
                Success = false,
                Content = null,
                Count = 0,
                Total = 0
            };
        }
    }
}