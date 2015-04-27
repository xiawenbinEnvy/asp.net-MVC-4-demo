
namespace Contract.Contract
{
    public interface IContract { }

    /// <summary>
    /// 契约接口
    /// </summary>
    /// <typeparam name="IRequest">请求类型</typeparam>
    /// <typeparam name="IResponse">响应类型</typeparam>
    public interface IContract<TRequest, TResponse> : IContract
        where TRequest : class,new()
        where TResponse : class,new()
    {
        /// <summary>
        /// 请求实体
        /// </summary>
        TRequest Request { get; set; }
    }
}
