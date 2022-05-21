using JWT.Entities.Interfaces;

namespace JWT.Entities.Dtos.ProductDtos
{
    public class ProductUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
