using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Response
{
    public class ResponseItemManager
    {
        public ResponseItemManager()
        {

        }

        public ResponseItem Ok()
        {
            return new ResponseItem { Status = "OK" };
        }
        public ResponseItem Eror()
        {
            return new ResponseItem { Status = "NotOK", };
        }
        public ResponseItem<T> Ok<T>(T data)
        {
            return new ResponseItem<T> { Status = "OK", Data = data };
        }
    }
}
