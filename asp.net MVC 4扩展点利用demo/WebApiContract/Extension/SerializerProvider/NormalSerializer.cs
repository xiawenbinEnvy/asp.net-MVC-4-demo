using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Extension.SerializerProvider
{
    public class NormalSerializer : ISerializer
    {
        public string Serializer<TRequest>(TRequest request)
        {
            var json = string.Empty;
            var serializer = new DataContractJsonSerializer(request.GetType());
            using (var memoryStream = new MemoryStream())
            {
                serializer.WriteObject(memoryStream, request);
                json = Encoding.UTF8.GetString(memoryStream.ToArray());
            }
            return json;
        }

        public TResponse DeSerializer<TResponse>(string response)
        {
            throw new NotImplementedException();
        }
    }
}
