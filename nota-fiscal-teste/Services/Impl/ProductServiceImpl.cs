using nota_fiscal_teste.Model;
using nota_fiscal_teste.Repositories;

namespace nota_fiscal_teste.Services.Impl
{
    public class ProductServiceImpl : IProductService
    {

        private IProductRepository _repository;
        public ProductServiceImpl(IProductRepository repository)
        {
            _repository = repository;
        }
        public List<Product> FindAll()
        {
            return _repository.FindAll();
        }

        public Product FindById(long id)
        {
            return _repository.FindById(id);
        }
        public Product Create(Product product)
        {
            return _repository.Create(product);
        }

        public Product Update(Product product)
        {
            return _repository.Update(product);
        }
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}
