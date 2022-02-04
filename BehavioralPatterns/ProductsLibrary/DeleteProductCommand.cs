namespace ProductsLibrary
{
    public class DeleteProductCommand : ICommand
    {
        private Product product;
        private readonly IProductRepository receiver;
        private int id;

        public DeleteProductCommand(int id, IProductRepository receiver)
        {
            this.id = id;
            this.receiver = receiver;            
        }

        public void Execute()
        {
            this.product = receiver.GetById(id);
            receiver.Delete(id);
        }

        public void Undo()
        {
            receiver.Add(product);
        }
    }

}
