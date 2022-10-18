using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace ProductManagement.Categories
{
    /// <summary>
    /// Product Class, inherited from  AuditedAggregateRoot<Guid>, 
    /// and Guid is the Primary key of the entity
    /// AuditedAggregateRoot has many properties：CreationTime、CreatorId、LastModificationTime and LastModifierId
    /// </summary>
    public class Category : AuditedAggregateRoot<Guid>
    {
        /// <summary>
        /// Category Name
        /// </summary>
        public string Name { get; set; }
    }
}
