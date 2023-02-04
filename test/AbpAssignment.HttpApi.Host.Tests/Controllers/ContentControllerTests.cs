using AbpAssignment.Content;
using AbpAssignment.Controllers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Validation;
using Xunit;

namespace AbpAssignment.HttpApi.Host.Tests.Controllers
{
    public class ContentControllerTests: AbpAssignmentHttpApiHostTestBase
    {
        private readonly IArticleAppService _articleAppService;
        private ContentController _contentController;
        public ContentControllerTests()
        {
            _articleAppService = GetRequiredService<IArticleAppService>();
            _contentController = new ContentController(_articleAppService);
        }

        [Fact]
        public async Task Shoud_Return_All_Article_When_Call_GetAll()
        {
            //Act
            var actualList = await _contentController.GetAll();

            //Assert
            actualList.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Shoud_Return_Article_When_GetCmsContent_By_Id()
        {
            //Arrange
            var list = await _articleAppService.GetAll();
            if(list.Count == 0)
            {
                return;
            }

            //Act
            var article = await _contentController.GetCmsContent(list[0].Id);

            //Assert
            article.Id.ShouldBe(list[0].Id);
        }

        [Fact]
        public async Task Shoud_Throw_Exception_When_Post_Invalid_Input_Dto()
        {
            //Arrange
            var dto = new CreateUpdateArticleDto()
            {
                Heading = Helpers.GenerateTestingString(300),
                Byline = Helpers.GenerateTestingString(60),
                Body = Helpers.GenerateTestingString(5000)
            };

            //Act
            var exception = await Assert.ThrowsAsync<AbpValidationException>(
                async () => await _contentController.InsertOrUpdateCmsContent(null, dto));

            //Assert
            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == nameof(dto.Heading)));
            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == nameof(dto.Byline)));
            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(mem => mem == nameof(dto.Body)));
        }

        [Fact]
        public async Task Shoud_Insert_Or_Update_When_Pass_Valid_Input()
        {
            //Arrange
            var dto = new CreateUpdateArticleDto()
            {
                Heading = Helpers.GenerateTestingString(50),
                Byline = Helpers.GenerateTestingString(10),
                Body = Helpers.GenerateTestingString(500)
            };

            var articles = await _articleAppService.GetAll();
            Should.NotThrow(async () => await _contentController.InsertOrUpdateCmsContent(null, dto));
            Should.NotThrow(async () => await _contentController.InsertOrUpdateCmsContent(articles[0].Id, dto));
        }
    }
}
