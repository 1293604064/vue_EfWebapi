using Infra.Response;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace vue_webApi.MiddleWare
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private static string _emptyCode = String.Empty;
        private static string _timeError = String.Empty;
        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="next"></param>
        /// <param name="authTokenService"></param>
        public AuthMiddleware(RequestDelegate next)
        {
            try
            {
                if (next == null)
                {
                    throw new ArgumentException();
                }
                Result res = new Result();
                res.Code = Code.ValidationFail;
                res.Msg = "Pass in a token";
                res.Data = false;
                _emptyCode = JsonConvert.SerializeObject(res).ToLower();
                res.Msg = "Token token error or expired, please login again";
                _timeError = _emptyCode;
                _next = next;  //中间件必须调用改方法，不然该中间件就属于一个终结点，就会从次中间件直接返回。
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// 中间件逻辑Invoke执行
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == "OPTIONS"
                    || Regex.Match(context.Request.Path, "swagger").Success
                    || PathUri(context))
            {
                await _next(context);
            }
            else if (context.Request.Headers.ContainsKey("token"))
            {
                var token = context.Request.Headers["token"].FirstOrDefault();
                if (string.IsNullOrEmpty(token))
                {
                    context.Response.Headers.Add("access-control-allow-credentials", "true");
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                    context.Response.Headers.Add("content-type", "application/json; charset=utf-8");
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync(_emptyCode);
                }
                else
                {
                    //var user = await _authTokenService.GetUserByToken<T>(token);
                    if (token == "123qwe")
                    {
                        await _next(context);
                    }
                    else
                    {
                        context.Response.Headers.Add("access-control-allow-credentials", "true");
                        context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                        context.Response.Headers.Add("content-type", "application/json; charset=utf-8");
                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync(_timeError);
                    }
                }
            }
            else
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("request error");
            }
        }
        public bool PathUri(HttpContext context)
        {
            return Regex.Match(context.Request.Path, "userlogin").Success
                || Regex.Match(context.Request.Path, "userregister").Success
                 || Regex.Match(context.Request.Path, "getphonecode").Success
                  || Regex.Match(context.Request.Path, "forgetpwd").Success || Regex.Match(context.Request.Path, "validateCode").Success || Regex.Match(context.Request.Path, "GetDisture").Success || Regex.Match(context.Request.Path, "get").Success;
        }

    }
}
