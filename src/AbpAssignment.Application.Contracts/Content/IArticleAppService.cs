using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpAssignment.Content
{
    public interface IArticleAppService: IApplicationService
    {
        Task<ArticleDto> GetCmsContent(Guid id);

        Task<List<ArticleDto>> GetAll();

        //Task InsertOrUpdateCmsContent(string? id, CreateUpdateArticleDto input);
        Task<ArticleDto> Insert(CreateUpdateArticleDto inputDto);
        Task<ArticleDto> Update(Guid id, CreateUpdateArticleDto inputDto);

    }
}
