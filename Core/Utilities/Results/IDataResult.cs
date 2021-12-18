using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    // Hani tipi döndüreceğimizi de söylüyoruz
    public interface IDataResult<T>:IResult
    {
        T Data { get; }
    }
}
