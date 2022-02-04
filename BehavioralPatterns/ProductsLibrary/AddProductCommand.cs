namespace ProductsLibrary
{
    public class AddProductCommand : ICommand
    {
        private readonly Product product;
        private readonly IProductRepository receiver;

        public AddProductCommand(Product product, IProductRepository receiver)
        {
            this.product = product;
            this.receiver = receiver;
        }

        public void Execute()
        {
            receiver.Add(this.product);
        }

        public void Undo()
        {
            receiver.Delete(product.Id);
        }
    }


}
