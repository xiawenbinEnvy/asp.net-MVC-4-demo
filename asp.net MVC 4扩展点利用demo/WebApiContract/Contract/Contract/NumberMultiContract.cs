using Contract.Request;
using Contract.Response;

namespace Contract.Contract
{
    /// <summary>
    /// 两数相乘服务契约
    /// </summary>
    public class NumberMultiContract : IContract<NumberRequest, NumberResponse>
    {
        public NumberRequest Request
        {
            get;
            set;
        }
    }
}
