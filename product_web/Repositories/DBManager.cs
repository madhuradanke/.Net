using BOL;

namespace DAL
{
    public class DBManager : IDBManager
    {
        public DBManager() { }
        public void Delete(int id)
        {
            using (var context = new CollectionContext())
            {
                context.Products.Remove(context.Products.Find(id));
                context.SaveChanges();
            }
        }
        public List<Product> GetAll()
        {   //Deterministic Finalization
            using (var context = new CollectionContext())
            {
                //LINQ
                var products = from product
                                in context.Products
                                  select product;
                return products.ToList<Product>();
            }
        }

        public Product GetById(int id)
        {
            using (var context = new CollectionContext())
            {
                var prod = context.Products.Find(id);
                return prod;
            }
        }
        public void Insert(Product prod)
        {
            using (var context = new CollectionContext())
            {
                context.Products.Add(prod);
                context.SaveChanges();
            }
        }
        public void Update(Product prod)
        {
            using (var context = new CollectionContext())
            {
                var theProd = context.Products.Find(prod.pid);
                theProd.Pname = prod.Pname;
                theProd.Qty = prod.Qty;
                theProd.Price = prod.Price;
                context.SaveChanges();
            }
        }

    }
}
