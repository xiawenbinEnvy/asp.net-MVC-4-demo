using Contract.Contract;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Extension.WebApiExtension
{
    /// <summary>
    /// 自定义HttpMessageHandler，在HttpRequest的Header中插入当前契约类型名称来查找路由
    /// </summary>
    public class ContractInfoHttpMessageHandler : DelegatingHandler
    {
        /// <summary>
        /// 当前契约类型名称
        /// </summary>
        private string contractInfo = null;

        public ContractInfoHttpMessageHandler(IContract contract)
            : base()
        {
            if (contract == null) throw new Exception("Contract为空");
            this.contractInfo = contract.GetType().Name;
        }
        /// <summary>
        /// 在HttpRequest的Header中插入当前契约类型名称
        /// </summary>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("ContractInfo", this.contractInfo);
            return base.SendAsync(request, cancellationToken);
        }
    }
}
