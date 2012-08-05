// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ProductsListViewModel.cs" company="The Advisory Board Company">
//   Copyright 2010-2011
// </copyright>
// <summary>
//   Defines the ProductsListViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SportsStore.WebUI.Models
{
    using System.Collections.Generic;
    using SportsStore.Domain.Entities;

    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public PagingInfo PagingInfo { get; set; }

        public string CurrentCategory { get; set; }
        

    }
}