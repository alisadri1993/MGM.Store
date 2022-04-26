using Store.Business.Entities;

namespace Store.Business.Interfaces;
public interface IProductRepository
{
    Task<int> Save(Product product);
    Task<int> Delete(int id);
    Task<Product> GetById(int id);


}
