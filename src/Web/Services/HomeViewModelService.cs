﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.Models;

namespace Web.Services
{
    public class HomeViewModelService : IHomeViewModelService
    {
        private readonly IRepository<Product> _productRepo;
        private readonly IRepository<Category> _categoryRepo;
        private readonly IRepository<Brand> _brandRepo;

        public HomeViewModelService(IRepository<Product> productRepo, IRepository<Category> categoryRepo, IRepository<Brand> brandRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _brandRepo = brandRepo;
        }

        public async Task<HomeViewModel> GetHomeViewModelAsync(int? categoryId, int brandId)
        {
            var specProducts = new HomeFilterSpecification(categoryId, brandId);
            List<Product> products = await _productRepo.GetAllAsync(specProducts);
            HomeViewModel vm = new HomeViewModel()
            {
                Products = products.Select(x => new ProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Price,
                    PictureUri = x.PictureUri
                }).ToList(),
                Categories = (await _categoryRepo.GetAllAsync()).Select(x =>
                    new SelectListItem(x.Name, x.Id.ToString())).ToList(),

                Brands = (await _brandRepo.GetAllAsync()).Select(x =>
                  new SelectListItem(x.Name, x.Id.ToString())).ToList(),
                CategoryId = categoryId,
                BrandId = brandId
            };
            return vm;
        }
    }
}
