using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace TaskPractice.RequestResponse
{
    public class RE<T>
    {
        public int code { get; set; }
        public T data { get; set; }
        public string error { get; set; }

        public string errorCode { get; set; }

        public RE<T> BadRequest(string error = null)
        {
            this.code = (int)HttpStatusCode.BadRequest;
            this.error = error;
            return this;
        }
        public RE<T> OK()
        {
            this.code = (int)HttpStatusCode.OK;
            return this;
        }

        public RE<T> OK(T data)
        {
            this.data = data;
            this.code = (int)HttpStatusCode.OK;
            return this;
        }

        public RE<T> Exception(Exception ex)
        {
            this.code = (int)HttpStatusCode.BadRequest;
            this.error = "Bir hata oluştu! Lütfen tekrar deneyin.";

            var error = ex as Error;
            if (error != null)
            {
                this.code = error.code;
                this.error = error.error;
            }

            return this;
        }
    }
}
