using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Common
{
    [Serializable]
    public class WebExpception : Exception, ISerializable
    {
        public override string Message
        {
            get
            {
                return base.Message;
            }
        }
        public string Code { get; set; }
        public WebExpception(string code, string message)
            : base(message)
        {
            Code = code;
        }
    }
}
