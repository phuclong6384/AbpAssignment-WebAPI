using AbpAssignment.Content;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpAssignment.EntityFrameworkCore.Content
{
    public class ArticleRepository:
        EfCoreRepository<AbpAssignmentDbContext, Article, Guid>,
        IArticleRepository
    {
        public ArticleRepository(
        IDbContextProvider<AbpAssignmentDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

    }
}
