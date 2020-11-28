using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TaskPractice.RequestResponse
{
    public class Error :Exception
    {
        public int code { get; set; }
        public string error { get; set; }

        public Error(string errorMessage)
        {
            code = (int)HttpStatusCode.BadRequest;
            this.error = errorMessage;
        }

        public Error(int code, string errorMessage)
        {
            this.code = code;
            this.error = errorMessage;
        }
        public static Error LoginUnsuccess()
        {
            return new Error((int)HttpStatusCode.NotFound, "Girmiş olduğunuz bilgiler hatalı. Lütfen giriş bilgilerinizi kontrol ediniz.");
        }
    }
}
