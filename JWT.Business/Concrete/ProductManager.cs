using JWT.Business.Interfaces;
using JWT.DataAccess.Interfaces;
using JWT.Entities.Concrete;

namespace JWT.Business.Concrete
{
    public class ProductManager : GenericManager<Product>, IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IGenericDal<Product> genericDal, IProductDal productDal) : base(genericDal)
        {
            //This helps to create own methods and using
            _productDal = productDal;
        }
    }
}
