using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace AbpAssignment.Content
{
    public class CreateUpdateArticleDto
    { 
        public Guid Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Heading { get; set; }

        [Required]
        [StringLength(50)]
        public string Byline { get; set; }

        [StringLength(4000)]
        public string Body { get; set; }

    }
}
