using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public interface IResult
    {

        // Temel voidler için başlangıç
        // set işlemini ise yapıcı metot içinde yazacağız
        bool Success { get; }
        string Message { get; }
    }
}
