using AbpAssignment.Content;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbpAssignment
{
    public class ArticleApplicationAutoMapperProfile: Profile
    {
        public ArticleApplicationAutoMapperProfile()
        {
            CreateMap<Article, ArticleDto>();
            CreateMap<CreateUpdateArticleDto, Article>();
        }
    }
}
