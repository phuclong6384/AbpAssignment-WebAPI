using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace AbpAssignment.Content
{
    public class ArticleDataSeederContributor
    : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Article, Guid> _articleRepository;

        public ArticleDataSeederContributor(IRepository<Article, Guid> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _articleRepository.GetCountAsync() <= 0)
            {
                await _articleRepository.InsertAsync(
                    new Article
                    {
                        Heading = "ChatGPT maker OpenAI releases ‘not fully reliable’ tool to detect AI generated content",
                        Byline = "Dr.Smith",
                        Body = "OpenAI, the research laboratory behind AI program ChatGPT, has released a tool designed to detect whether text has been written by artificial intelligence, but warns it’s not completely reliable – yet.\r\n\r\nIn a blog post on Tuesday, OpenAI linked to a new classifier tool that has been trained to distinguish between text written by a human and that written by a variety of AI, not just ChatGPT.\r\n\r\nOpen AI researchers said that while it was “impossible to reliably detect all AI-written text”, good classifiers could pick up signs that text was written by AI. The tool could be useful in cases where AI was used for “academic dishonesty” and when AI chatbots were positioned as humans, they said.",
                        CreationTime = DateTime.Now.AddMonths(-2)
                    },
                    autoSave: true
                );

                await _articleRepository.InsertAsync(
                    new Article
                    {
                        Heading = "Judge who told Pence not to overturn election predicts ‘beginning of end of Trump’",
                        Byline = "Martin Pengelly",
                        Body = "The conservative judge who convinced Mike Pence he could not overturn the 2020 election has predicted “the beginning of the end of Donald Trump” – the former president who incited the January 6 insurrection but is now trying to return to the White House.\r\n\r\nSpeaking to the Washington Post, J Michael Luttig also made a common comparison to another notorious former president, Richard Nixon, who resigned in 1974 over the Watergate scandal.\r\n\r\n“What Nixon did was just an ordinary crime,” Luttig said, referring to the cover-up of a break-in at Democratic headquarters. “What Trump has done is quite arguably the worst crime against the United States that a president could commit.”",
                        CreationTime = DateTime.Now.AddDays(-12)
                    },
                    autoSave: true
                );
            }
        }
    }
}
