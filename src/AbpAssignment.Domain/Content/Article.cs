using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace AbpAssignment.Content
{
    public class Article : AuditedAggregateRoot<Guid>
    {
        public string Heading { get; set; }

        public string Byline { get; set; }

        public string Body { get; set; }

    }
}
