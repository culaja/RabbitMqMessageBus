using Newtonsoft.Json;
using static System.Text.Encoding;
using static Common.Result;
using static Newtonsoft.Json.JsonConvert;

namespace Common
{
    public static class EventSerialization
    {
        private static readonly JsonSerializerSettings Settings = new JsonSerializerSettings()
        {
            TypeNameHandling = TypeNameHandling.All
        };
        
        public static byte[] Serialize(this IMessage m)
            => ASCII.GetBytes(SerializeObject(m, Settings));
        
        public static Result<IMessage> Deserialize(this byte[] str)
        {
            try
            {
                var message = (IMessage)DeserializeObject(
                    ASCII.GetString(str),
                    Settings);

                return Ok(message);
            }
            catch (JsonReaderException e)
            {
                return Fail<IMessage>(e.Message);
            }
        }
    }
}