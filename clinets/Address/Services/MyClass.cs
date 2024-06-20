
using Newtonsoft.Json;
namespace Address.Services
{


    public class MyClass
    {
        public string SerializeObject(object value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }

}
