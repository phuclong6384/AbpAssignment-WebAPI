using AutoMapper.Internal.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;

namespace AbpAssignment.Content
{
    [RemoteService(IsEnabled = false)]
    public class ArticleAppService : ApplicationService, IArticleAppService
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleAppService(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task<ArticleDto> GetCmsContent(Guid id) {
            var article = await _articleRepository.GetAsync(id);
            return ObjectMapper.Map<Article, ArticleDto>(article);
        }

        public async Task<List<ArticleDto>> GetAll() {
            var articles = await _articleRepository.GetListAsync();
            return ObjectMapper.Map<List<Article>, List<ArticleDto>>(articles);
        }

        public async Task<ArticleDto> Insert(CreateUpdateArticleDto inputDto)
        {
            var article = ObjectMapper.Map<CreateUpdateArticleDto, Article>(inputDto);
            var newArticle = await _articleRepository.InsertAsync(article);
            return ObjectMapper.Map<Article, ArticleDto>(newArticle);
        }

        public async Task<ArticleDto> Update(Guid id, CreateUpdateArticleDto inputDto)
        {
            var article = await _articleRepository.GetAsync(id);

            article.Heading = inputDto.Heading;
            article.Byline = inputDto.Byline;
            article.Body = inputDto.Body;
            article.LastModificationTime = DateTime.Now;

            var updatedArticle = await _articleRepository.UpdateAsync(article);
            return ObjectMapper.Map<Article, ArticleDto>(updatedArticle);
        }
    }
}
