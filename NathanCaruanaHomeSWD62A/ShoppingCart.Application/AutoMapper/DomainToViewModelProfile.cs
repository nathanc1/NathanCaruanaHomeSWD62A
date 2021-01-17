﻿using AutoMapper;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Model;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Product, ProductViewModel>(); //Product >>>> ProductViewModel
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Member, MemberViewModel>();
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderDetails, OrderDetailViewModel>();
            CreateMap<Cart, CartViewModel>();
        }
    }
}
