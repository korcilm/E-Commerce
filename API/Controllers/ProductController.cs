using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
using API.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;
        public ProductController(IGenericRepository<Product> productRepository, IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository, IMapper mapper)
        {
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductReturnToDto>>> GetProducts([FromQuery]ProductSpecParams productSpecParams)
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification(productSpecParams);
            var countSpec = new ProductWithfiltersForCountSpecification(productSpecParams);
            var totalItems = await _productRepository.CountAsync(countSpec);
            var products = await _productRepository.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductReturnToDto>>(products);
            
            return Ok(new Pagination<ProductReturnToDto>(productSpecParams.PageIndex,productSpecParams.PageSize,totalItems,data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReturnToDto>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandSpecification(id);
            // return await _productRepository.GetEntityWithSpec(spec);
            var product= await _productRepository.GetEntityWithSpec(spec);
            //return new ProductReturnToDto
            //{
            //    Id=product.Id,
            //    Name=product.Name,
            //    Decription=product.Decription,
            //    Price=product.Price,
            //    PictureUrl=product.PictureUrl,
            //    ProductBrand= product.ProductBrand!=null? product.ProductBrand.Name:string.Empty,
            //    ProductType= product.ProductType != null? product.ProductType.Name:string.Empty,
            //};
            return _mapper.Map<Product, ProductReturnToDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }
    }
}
