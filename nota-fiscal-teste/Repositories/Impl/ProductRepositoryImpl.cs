using nota_fiscal_teste.Model;
using nota_fiscal_teste.Model.Context;

namespace nota_fiscal_teste.Repositories.Impl
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private MSSQLContext _context;

        public ProductRepositoryImpl(MSSQLContext context)
        {
            _context = context;
        }
        public List<Product> FindAll()
        {
            return _context.Products.ToList();
        }

        public Product FindById(long id)
        {
            return _context.Products.Find(id);
        }

        public Product Create(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            var existingProduct = _context.Products.Find(product.Id);
            if (existingProduct == null) return null;

            _context.Entry(existingProduct).CurrentValues.SetValues(product);
            _context.SaveChanges();
            return product;
        }
        public void Delete(long id)
        {
            var existingProduct = _context.Products.Find(id);
            if(existingProduct == null) return;

            _context.Remove(existingProduct);
            _context.SaveChanges();

        }
    }
}
