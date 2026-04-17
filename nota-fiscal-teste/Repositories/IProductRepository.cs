using nota_fiscal_teste.Model;

namespace nota_fiscal_teste.Repositories
{
    public interface IProductRepository
    {
        List<Product> FindAll();
        Product FindById(long id);
        Product Create(Product product);
        Product Update(Product product);
        void Delete(long id);
    }
}
