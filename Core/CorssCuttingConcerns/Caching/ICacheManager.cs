using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CorssCuttingConcerns.Caching
{
    /// <summary>
    /// Teknoloji bağımsız bir interface
    /// </summary>
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key); şeklinde de yazılabilir.
        void Add(string key, object value, int duration);

        bool IsAdd(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern); //türüne göre silelim. Örneğin; isminde categori olanları uçur



    }
}
