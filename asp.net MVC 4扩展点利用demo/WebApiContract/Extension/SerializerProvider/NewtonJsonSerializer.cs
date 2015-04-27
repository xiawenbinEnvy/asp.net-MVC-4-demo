using Newtonsoft.Json;

namespace Extension.SerializerProvider
{
    /// <summary>
    /// NewtonJson工具序列化
    /// </summary>
    public class NewtonJsonSerializer : ISerializer
    {
        public string Serializer<TRequest>(TRequest request)
        {
            return JsonConvert.SerializeObject(request);
        }

        public TResponse DeSerializer<TResponse>(string response)
        {
            return JsonConvert.DeserializeObject<TResponse>(response);
        }
    }
}
