using Contract.Contract;
using Extension.SerializerProvider;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Extension.WebApiExtension
{
    /// <summary>
    /// HttpClient的代理
    /// </summary>
    public class HttpClientProxy
    {
        /// <summary>
        /// WebApi服务地址
        /// </summary>
        private string webApiHostUrl = null;
        /// <summary>
        /// 序列化器
        /// </summary>
        private ISerializer serializerProvider = null;

        private string mediaType = "application/json";

        public HttpClientProxy(string webApiHostUrl, ISerializer serializerProvider = null)
        {
            if (webApiHostUrl == null)
                throw new Exception("缺少服务地址");

            this.webApiHostUrl = webApiHostUrl;
            if (serializerProvider != null)
                this.serializerProvider = serializerProvider;
            else
                this.serializerProvider = new NewtonJsonSerializer();
        }

        /// <summary>
        /// 调用服务
        /// </summary>
        /// <typeparam name="Request">请求类型</typeparam>
        /// <typeparam name="Response">响应类型</typeparam>
        /// <param name="contract">契约实体</param>
        /// <returns>响应实体</returns>
        public async Task<Response> Execute<Request, Response>(IContract<Request, Response> contract)
            where Request : class,new()
            where Response : class,new()
        {
            if (contract == null) throw new Exception("契约不可为空");
            if (contract.Request == null) throw new Exception("契约参数不可为空");
            if (serializerProvider == null) throw new Exception("序列化器不可为空");

            ContractInfoHttpMessageHandler handler = new ContractInfoHttpMessageHandler(contract)
            {
                InnerHandler = new HttpClientHandler()
            };

            using (HttpClient httpClient = new HttpClient(handler))
            {
                string requestContent = serializerProvider.Serializer(contract.Request);

                using (StringContent httpContent = new StringContent(requestContent, Encoding.UTF8, mediaType))
                {
                    //更好的做法是，根据http动词，选择相应的http方法，此处先简化
                    var response = await httpClient.PostAsync(webApiHostUrl, httpContent);
                    if (response == null) throw new Exception("调用服务发生异常");

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        return serializerProvider.DeSerializer<Response>(responseContent);
                    }
                    else
                    {
                        throw new Exception(string.Format("调用服务发生异常，HttpStatus：{0}", response.StatusCode));
                    }
                }
            }
        }
    }
}
