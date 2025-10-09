using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongManager.Desktop.Models
{
    public abstract class BaseEntity<TPrimaryKey> : IBaseEntity
    {
        [PrimaryKey]
        public virtual TPrimaryKey Id { get; set; } = default!;
        public DateTime CreationTime { get; set; }
        public DateTime? LastModified { get; set; }
        public DateTime? DeletionTime { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
