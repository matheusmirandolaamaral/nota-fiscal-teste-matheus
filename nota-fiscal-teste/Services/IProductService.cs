using nota_fiscal_teste.Model;

namespace nota_fiscal_teste.Services
{
    public interface IProductService
    {
        List<Product> FindAll();
        Product FindById(long id);
        Product Create(Product product);
        Product Update(Product product);
        void Delete(long id);
    }
}
