using AutoMapper;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Model;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{
    public class ViewModelToDomainProfile: Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<ProductViewModel, Product>();
            CreateMap<OrderViewModel, Order>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<MemberViewModel, Member>();
            CreateMap<CartViewModel, Cart>();
            CreateMap<OrderDetailViewModel, OrderDetails>();
        }
    }
}
