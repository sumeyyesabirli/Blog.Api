using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ResponseItem<T>
    {
        public T Data { get; set; }
        public IList<ResponseMessage> Messages { get; set; }
        public string Status { get; set; }
        public int? Count { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class ResponseItem : ResponseItem<object>
    {
    }

}
