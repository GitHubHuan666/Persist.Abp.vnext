using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Linq;

namespace Persist.Abp.vnext.Domain.Author.Repository
{
    public interface   IAtuthorRepository : IRepository<Entities.Author,string>
    {
        
    }
}
