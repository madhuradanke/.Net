using BOL;

namespace SL
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Insert(Product prod);
        void Update(Product prod);
        void Delete(int id);

    }
}
