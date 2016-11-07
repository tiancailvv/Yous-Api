using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Routing;
using Yous;
using Yous_Api.Models;

namespace Yous_API.Controllers
{
    public class APIController : ApiController
    {
        [Route("api/GetServiceApiResult")]
        [HttpPost]
        public IHttpActionResult GetServiceApiResult(RequestJson obj)
        {
            string ret = String.Empty;

            #region 发送Request请求
            DateTime reqeustdt = DateTime.Now;
            //Logs.kufaLog("前端调用类型：" + foreendtype + "\r\n前端请求地址：" + target + "\r\n开始发送请求：" + param, WebConfigurationManager.AppSettings["LogUrl"], logfoldername);
            HttpWebRequest proxyRequest = HttpWebRequest.Create("http://"+Url.Request.Headers.Host+"/api/" + obj.code) as HttpWebRequest;
            proxyRequest.Method = "POST";
            proxyRequest.KeepAlive = false;
            proxyRequest.ContentType = "application/json";
            proxyRequest.Timeout = 200000;

            byte[] aryBuf = Encoding.GetEncoding("utf-8").GetBytes(obj.ToString());
            proxyRequest.ContentLength = aryBuf.Length;
            using (Stream writer = proxyRequest.GetRequestStream())
            {
                writer.Write(aryBuf, 0, aryBuf.Length);
                writer.Close();
                writer.Dispose();
            }
        
            #endregion

            #region 返回Response
            using (WebResponse response = proxyRequest.GetResponse())
            {
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                ret = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
            }
            #endregion
            return new TextResult(ret, Request);
        }

        [Route("api/10000001")]
        [HttpPost]
        public ResponseJson GetUser(dynamic obj)
        {
            ResponseJson result = new ResponseJson();
            result.success = true;
            result.message = "ok";
            MySqlDbHelperDB dbhelper = new MySqlDbHelperDB();
            result.data = dbhelper.Fetch<base_area>("select * from base_area");
            return result;
        }

    }
}
