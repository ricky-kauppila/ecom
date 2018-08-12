using System;

namespace Ecom.ProductManagement
{
    public class Product
    {
        public Product(Guid id, string articleNumber)
        {
            this.Id = id;
            this.ArticleNumber = articleNumber;
        }

        public Guid Id { get; set; }
        
        public string ArticleNumber { get; }
    }
}