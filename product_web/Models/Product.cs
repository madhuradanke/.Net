namespace BOL
{
    public class Product
    {
        public int pid  { get; set; }
        public string? Pname {  get; set; }
        public int Qty { get; set; }
        public double Price {  get; set; }

        public Product(int pid, string? pname, int qty, double price)
        {
            this.pid = pid;
            Pname = pname;
            Qty = qty;
            Price = price;
        }

        public Product(string? pname, int qty, double price)
        {
            Pname = pname;
            Qty = qty;
            Price = price;
        }
    }
}
