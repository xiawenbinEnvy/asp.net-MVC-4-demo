using Contract.Request;
using Contract.Response;

namespace Contract.Contract
{
    /// <summary>
    /// 两数相减服务契约
    /// </summary>
    public class NumberSubContract : IContract<NumberRequest, NumberResponse>
    {
        public NumberRequest Request
        {
            get;
            set;
        }
    }
}
