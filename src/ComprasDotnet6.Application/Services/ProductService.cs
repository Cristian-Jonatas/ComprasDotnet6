using AutoMapper;
using ComprasDotnet6.Application.DTOs;
using ComprasDotnet6.Application.Services.Interfaces;
using ComprasDotnet6.Application.ValidationDTOs;
using ComprasDotnet6.Domain.Entities;
using ComprasDotnet6.Domain.Interfaces;

namespace ComprasDotnet6.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail<ProductDTO>("Objeto deve ser informado");

            var result = new ProductDTOValidator().Validate(productDTO);
            if (!result.IsValid)
                return ResultService.RequestError<ProductDTO>("Erro ao validar", result);

            var product = _mapper.Map<Product>(productDTO);
            var data = await _productRepository.CreateAsync(product);
            return ResultService.Ok(_mapper.Map<ProductDTO>(data));
        }

        public async Task<ResultService<ICollection<ProductDTO>>> GetAsync()
        {
            var products = await _productRepository.GetProductAsync();
            if (products == null || products.Count <= 0)
                return ResultService.Fail<ICollection<ProductDTO>>("Não há produtos cadastrados");

            return ResultService.Ok(_mapper.Map<ICollection<ProductDTO>>(products));
        }

        public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail<ProductDTO>("Produto não encontrado");

            return ResultService.Ok(_mapper.Map<ProductDTO>(product));
        }

        public async Task<ResultService> UpdateAsync(ProductDTO productDTO)
        {
            if (productDTO == null)
                return ResultService.Fail("Objeto deve ser informado");

            var validation = new ProductDTOValidator().Validate(productDTO);
            if (!validation.IsValid)
                return ResultService.RequestError("Problemas com a validação dos campos", validation);

            var product = await _productRepository.GetByIdAsync(productDTO.Id);
            if (product == null)
                return ResultService.Fail("Produto não encontrado");

            product = _mapper.Map(productDTO, product);
            await _productRepository.EditAsync(product);
            return ResultService.Ok("Produto editado com sucesso!");
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return ResultService.Fail("Produto não encontrado");

            await _productRepository.DeleteAsync(product);
            return ResultService.Ok($"Produto do Id {id} foi deletado");
        }

    }
}
