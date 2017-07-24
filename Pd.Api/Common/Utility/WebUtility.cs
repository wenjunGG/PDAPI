using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Xsl;

namespace Common.Utility
{
    public static class WebUtility
    {
      

        public static string DoGet(string url, IDictionary<string, string> parameters, CookieContainer cookies, string refererUrl, string httpMethod = "GET")
        {
            if (string.IsNullOrEmpty(url))
            {
                return string.Empty;
            }
            string spr = "";
            if (parameters != null)
            {
                spr = "?" + BuildQuery(parameters);
            }
            HttpWebRequest req = GetWebRequest(httpMethod.ToLower() == "get" ? (url + spr) : url, httpMethod);
            if (cookies != null)
            {
                req.CookieContainer = cookies;

            }
            if (string.IsNullOrEmpty(refererUrl))
            {
                try
                {
                    req.Referer = url;
                }
                catch (Exception e)
                {
                    //CRLF 字符。
                }
            }
            else
            {
                req.Referer = refererUrl;
            }
            if (httpMethod.ToLower() == "post")
            {
                byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(spr);
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = requestBytes.Length;
                var requestStream = req.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();
            }
            return GetResponseAsString(req);
        }

        /// <summary>
        /// 组装GET请求URL。
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="parameters">请求参数</param>
        /// <returns>带参数的GET请求URL</returns>
        public static string BuildGetUrl(string url, IDictionary<string, string> parameters)
        {
            if (parameters != null && parameters.Count > 0)
            {
                if (url.Contains("?"))
                {
                    url = url + "&" + BuildQuery(parameters);
                }
                else
                {
                    url = url + "?" + BuildQuery(parameters);
                }
            }
            return url;
        }

        /// <summary>
        /// 组装普通文本请求参数。
        /// </summary>
        /// <param name="parameters">Key-Value形式请求参数字典</param>
        /// <returns>URL编码后的请求数据</returns>
        public static string BuildQuery(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数
                if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(value))
                {
                    if (hasParam)
                    {
                        postData.Append("&");
                    }

                    postData.Append(name);
                    postData.Append("=");
                    postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                    hasParam = true;
                }
            }

            return postData.ToString();
        }

        /// <summary>
        /// 把响应流转换为文本。
        /// </summary>
        /// <param name="rsp">响应流对象</param>
        /// <param name="encoding">编码方式</param>
        /// <returns>响应文本</returns>
        public static string GetResponseAsString(HttpWebRequest req)
        {
            string responseUri = string.Empty;
            return GetResponseAsString(req, out responseUri);
        }

        public static string GetResponseAsString(HttpWebRequest req, out string responseUri)
        {
            HttpWebResponse rsp;
            responseUri = req.RequestUri.ToString();

            if (responseUri.Contains("detailskip.taobao.com"))
            {

                string xxr = "xxx";
                string xxxxu = xxr;

            }
            string rspString = string.Empty;
            try
            {
                rsp = (HttpWebResponse)req.GetResponse();
                System.IO.Stream stream = null;
                StreamReader reader = null;
                try
                {
                    // 以字符流的方式读取HTTP响应
                    stream = rsp.GetResponseStream();
                    reader = new StreamReader(stream);
                    responseUri = rsp.ResponseUri.ToString();
                    rspString = reader.ReadToEnd();
                }
                finally
                {
                    // 释放资源
                    if (reader != null) reader.Close();
                    if (stream != null) stream.Close();
                    if (rsp != null) rsp.Close();
                }
            }
            catch (Exception e)
            {

                string sss = e.StackTrace;
            }

            return rspString;
        }

        public static HttpWebRequest GetWebRequest(string url, string method)
        {
            HttpWebRequest req = null;

            req = (HttpWebRequest)WebRequest.Create(url);

            req.ServicePoint.Expect100Continue = false;
            req.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
            req.Method = method;
            req.AllowAutoRedirect = true;
            req.KeepAlive = true;
            req.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)";
            //req.Timeout = 1200;
            req.Timeout = 6000000;
            return req;
        }

        public static string NewBuildQuery(IDictionary<string, string> parameters)
        {
            StringBuilder postData = new StringBuilder();
            bool hasParam = false;

            IEnumerator<KeyValuePair<string, string>> dem = parameters.GetEnumerator();
            while (dem.MoveNext())
            {
                string name = dem.Current.Key;
                string value = dem.Current.Value;
                // 忽略参数名或参数值为空的参数

                if (hasParam)
                {
                    postData.Append("&");
                }

                postData.Append(name);
                postData.Append("=");
                postData.Append(HttpUtility.UrlEncode(value, Encoding.UTF8));
                hasParam = true;

            }

            return postData.ToString();
        }

        /// <summary>
        /// Post请求方式 参数为json数据
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="jsonData">json数据参数</param>
        /// <returns></returns>
        public static string GetJsonData(string url, string jsonData)
        {
            string responseContent = null;

            try
            {
                HttpWebRequest req = WebUtility.GetWebRequest(url, "POST");
                //这个在Post的时候，一定要加上，如果服务器返回错误，他还会继续再去请求，不会使用之前的错误数据，做返回数据
                //req.ServicePoint.Expect100Continue = false;
                req.Timeout = 6000000;
                byte[] btParam = Encoding.UTF8.GetBytes("=" + jsonData);
                req.ContentLength = btParam.Length;
                req.GetRequestStream().Write(btParam, 0, btParam.Length);
                HttpWebResponse httpWebResponse = (HttpWebResponse)req.GetResponse();

                StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
                responseContent = streamReader.ReadToEnd();
                httpWebResponse.Close();
                streamReader.Close();
                req.Abort();
                httpWebResponse.Close();

            }
            catch (WebException e)
            {
                e.StackTrace.ToString();
                System.Diagnostics.Trace.WriteLine(e.Message);
            }

            return responseContent;
        }
        /// <summary>
        /// 发送httprequest请求并返回响应流
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpMethod"></param>
        /// <param name="paraList"></param>
        /// <param name="proxy"></param>
        /// <returns></returns>
        public static string Request(string url, string httpMethod, NameValueCollection paraList, NameValueCollection headerParaList, IWebProxy proxy = null)
        {
            var rspString = "";
            //参数字符串
            string paraStr = "";
            foreach (var item in paraList.AllKeys)
            {
                paraStr += item + "=" + paraList[item] + "&";
            }

            paraStr = paraStr.TrimEnd('&');
            var req = WebRequest.Create(url + (httpMethod.ToUpper() == "GET" ? ("?" + paraStr) : "")) as HttpWebRequest;

            req.Method = httpMethod;

            req.Timeout = 10000000;
            if (proxy != null)
                req.Proxy = proxy;

            //添加http头参数
            req.Headers.Add(headerParaList ?? new NameValueCollection());

            //post方式添加参数
            if (httpMethod.ToUpper() == "POST")
            {
                byte[] requestBytes = System.Text.Encoding.UTF8.GetBytes(paraStr);
                req.ContentType = "application/x-www-form-urlencoded";
                req.ContentLength = requestBytes.Length;
                var requestStream = req.GetRequestStream();
                requestStream.Write(requestBytes, 0, requestBytes.Length);
                requestStream.Close();
            }
            try
            {
                var res = req.GetResponse();
                System.IO.Stream stream = null;
                StreamReader reader = null;
                try
                {
                    // 以字符流的方式读取HTTP响应
                    stream = res.GetResponseStream();
                    reader = new StreamReader(stream);
                    rspString = reader.ReadToEnd();
                }
                finally
                {
                    // 释放资源
                    if (reader != null) reader.Close();
                    if (stream != null) stream.Close();
                    if (res != null) res.Close();
                }
            }
            catch(Exception ex)
            {

                rspString = "";
            }
            return rspString;
        }
    }
}
