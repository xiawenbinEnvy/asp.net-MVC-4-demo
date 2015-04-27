
namespace Extension.SerializerProvider
{
    /// <summary>
    /// 序列化工具接口
    /// </summary>
    public interface ISerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="TRequest">请求类型</typeparam>
        /// <param name="request">请求参数</param>
        /// <returns>序列化结果</returns>
        string Serializer<TRequest>(TRequest request);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="TResponse">响应类型</typeparam>
        /// <param name="response">响应内容</param>
        /// <returns>反序列化结果</returns>
        TResponse DeSerializer<TResponse>(string response);
    }
}
