using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logging
{
    interface ILoger
    {
        void Warn(object msg);
        void Info(object msg);
        void Debug(object msg);
        void Error(object msg);
    }
}
