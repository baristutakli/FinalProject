using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICategoryDal:IEntityRepository<Category>

    {

        /*
         IProduct ile I category de sadece içerideki tip değişiyor 
        Her nesnemize bunları yazmamak için generic yapısını kullanacağız
        bunun için bir tane interface yapacağız ve generic olacak
        Category veya product yerine T yazacağız
        Bu yapının adı Generic repository design pattern

        IEntity dememizin sebebi ileride bu customer veya başka bir şey olabilir olabilir
         */

    }
}
