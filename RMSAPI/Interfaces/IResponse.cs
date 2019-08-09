using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RMSAPI.Interfaces
{
    public interface IResponse
    {
        string Message { get; set; }

        bool IsError { get; set; }

        string ErrorMessage { get; set; }

    }

    public interface ISingleResponse<T> : IResponse
    {
        T Model { get; set; }
    }


}
