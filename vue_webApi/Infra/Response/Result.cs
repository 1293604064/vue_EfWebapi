using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Response
{
    public class Result
    {
        public Code Code;

        public string Msg;

        public object Data;
    }
    public enum Code
    {
        Success = 200,
        ValidationFail = 401,
        Fail = 500
    }
}
