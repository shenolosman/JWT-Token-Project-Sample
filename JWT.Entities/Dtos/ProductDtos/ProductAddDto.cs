using JWT.Entities.Interfaces;

namespace JWT.Entities.Dtos.ProductDtos
{
    public class ProductAddDto : IDto
    {
        public string Name { get; set; }
    }
}
