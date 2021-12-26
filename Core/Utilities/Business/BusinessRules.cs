using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        /// <summary>
        ///  Params verdiğiniz zaman run içerisine istediğin kadar IResult verebiliyortsun.
        ///  
        /// </summary>
        /// <param name="logics"></param>
        /// <returns></returns>
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                // parametre ile gönderilen iş kurallarından başarısız olanı gönderiyoruz.
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }


    }
}
