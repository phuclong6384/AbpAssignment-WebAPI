using AbpAssignment.Content;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace AbpAssignment.Controllers
{
    [Route("api/module/[controller]")]
    public class ContentController: AbpAssignmentController
    {
        private IArticleAppService _articleAppService;
        public ContentController(IArticleAppService articleAppService) { 
            _articleAppService = articleAppService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ArticleDto> GetCmsContent(Guid id) {
            var articleDto = await _articleAppService.GetCmsContent(id);

            return articleDto;
        }

        [HttpGet]
        public async Task<List<ArticleDto>> GetAll()
        {
            var articleDtos = await _articleAppService.GetAll();

            return articleDtos;
        }

        [HttpPost]
        public async Task<ActionResult<ArticleDto>> InsertOrUpdateCmsContent(Guid? id, [FromBody] CreateUpdateArticleDto input)
        {
            if(ModelState.IsValid == false) return BadRequest(ModelState);

            if (id.HasValue == false)
            {
                var dto = await _articleAppService.Insert(input);
                return Ok(dto);
            }
            else
            {
                var dto = await _articleAppService.Update(id.Value, input);
                return Ok(dto);
            }
            
        }
    }
}
