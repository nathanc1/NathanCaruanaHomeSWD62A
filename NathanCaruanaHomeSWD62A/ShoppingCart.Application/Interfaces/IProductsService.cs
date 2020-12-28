
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingCart.Application.Interfaces
{
    public interface IProductsService
    {
        //to expose directly your class as it was created originally to create your database is not good practice
        //hence we create a replica of that class removing any properties which may disclose some confidential or
        //uwanted information
        //typical e.g. if you have User class, would you pass on the password? Answer no, that's why we create, 
        //these ViewModels.

        //To understand the role of ViewModel(s) better, think of Views in a relational database 
        IQueryable<ProductViewModel> GetProducts();

        ProductViewModel GetProduct(Guid id);

      //  void RateProduct(Guid id, string comment, double rating);



    }
}
