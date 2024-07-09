using BOL;
using DAL;

namespace SL

{
    public class ProductService : IProductService
    {
        DBManager dbManager = new DBManager();
        public void Delete(int id)
        {
            dbManager.Delete(id);
        }

        public List<Product> GetAll()
        {
           // List<Product> products = dbManager.GetAll();
            return dbManager.GetAll();

        }

        public Product GetById(int id)
        {
            return dbManager.GetById(id);
        }

        public void Insert(Product prod)
        {
            dbManager.Insert(prod);
        }

        public void Update(Product prod)
        {
              dbManager.Update(prod);
        }
    }
}
