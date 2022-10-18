using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using ProductManagement.Categories;


namespace ProductManagement.Products
{
    /// <summary>
    /// this is Product Class, inherited from FullAuditedAggregateRoot
    /// it has more properties such as IsDeleted、DeletionTime and DeleterId
    /// FullAuditedAggregateRoot instantiated interface of ISoftDelete
    /// </summary>
    public class Product : FullAuditedAggregateRoot<Guid>
    {
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool IsFreeCargo { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ProductStockState StockState
        {
            get; set;
        }
    }
     
}
