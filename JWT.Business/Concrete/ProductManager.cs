using JWT.Business.Interfaces;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;

namespace JWT.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        public ProductManager(IGenericDal<Product> genericDal) : base(genericDal)
        {

        }
    }
}
