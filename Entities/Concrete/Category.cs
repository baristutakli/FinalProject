using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete {
    public class Category:IEntity 
    {

        // "Çıplak class kalmasın"-Engin Demiroğ, herhangi bir interface almıyorsa
        // ilerde problem yaşarız
        // IEntity, bir veritabanı nesnesi olduğunu belirtiyor 
        public int CategoryId { get; set; }
        public int CategoryName { get; set; }

    }
}
