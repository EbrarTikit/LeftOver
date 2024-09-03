using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace CleanArchitecture.Core.Entities
{
    public abstract class BaseEntity
    {
        public virtual int Id { get; set; }
    }
}
