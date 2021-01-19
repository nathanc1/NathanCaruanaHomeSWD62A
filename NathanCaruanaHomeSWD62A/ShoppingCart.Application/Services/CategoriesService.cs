using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Services
{
   public class CategoriesService : ICategoriesService
    {
        private ICategoriesRepository _categoryRepo;
        private IMapper _mapper;
        public CategoriesService(ICategoriesRepository categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public IQueryable<CategoryViewModel> GetCategories()
        {
            return _categoryRepo.GetCategories().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);

           /* var list = from p in _categoryRepo.GetCategories()
                       select new CategoryViewModel()
                       {
                           Id = p.Id,
                           Name = p.Name
                       };
            return list;
           */
        }
    }
}
