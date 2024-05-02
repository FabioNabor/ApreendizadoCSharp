using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.Model;
using GeekShopping.ProductAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {

        private readonly MySQLContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(MySQLContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<ProductVO> Create(ProductVO vo)
        {
            Product produtos = _mapper.Map<Product>(vo);
            _context.Products.Add(produtos);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(produtos);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                Product produtos = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync() ?? new Product();
                if (produtos.Id <= 0) { return false; }
                _context.Products.Remove(produtos);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            List<Product> produtos = await _context.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(produtos);
        }

        public async Task<ProductVO> FindById(long id)
        {
            Product produtos = await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync() ?? new Product();
            return _mapper.Map<ProductVO>(produtos);
        }

        public async Task<ProductVO> Update(ProductVO vo)
        {
            Product produtos = _mapper.Map<Product>(vo);
            _context.Products.Update(produtos);
            await _context.SaveChangesAsync();
            return _mapper.Map<ProductVO>(produtos);
        }
    }
}
