using Contract.Request;
using Contract.Response;
using System;

namespace Contract.Contract
{
    /// <summary>
    /// 两数相加服务契约
    /// </summary>
    public class NumberAddContract : IContract<NumberRequest, NumberResponse>
    {
        public NumberRequest Request
        {
            get;
            set;
        }
    }
}
