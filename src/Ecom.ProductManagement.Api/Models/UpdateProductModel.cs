using System;

namespace Ecom.ProductManagement.Api.Models
{
    public class UpdateProductModel
    {
        public string ArticleNumber { get; internal set; }
        public Guid Id { get; internal set; }
    }
}