using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpAssignment.Content
{
    public class ArticleDto: AuditedEntityDto<Guid>
    {
        public string Heading { get; set; }

        public string Byline { get; set; }

        public string Body { get; set; }
    }
}
