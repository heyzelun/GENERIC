namespace GENERICS
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public override string ToString()
        {
            return $"\t{ProductId} \t\t{ProductName}";
        }
    }
}

