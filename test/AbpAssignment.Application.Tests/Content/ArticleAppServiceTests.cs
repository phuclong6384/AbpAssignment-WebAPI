using Moq;
using NSubstitute;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Validation;
using Xunit;

namespace AbpAssignment.Content;

public class ArticleAppServiceTests : AbpAssignmentApplicationTestBase
{
    private readonly IArticleAppService _articleAppService;

    public ArticleAppServiceTests()
    {
        _articleAppService = GetRequiredService<IArticleAppService>();
    }

    [Fact]
    public async Task Shoud_Return_All_Article_When_Call_GetAll()
    {
        //Act
        var actualList = await _articleAppService.GetAll();
        
        //Assert
        actualList.Count.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Get_Article_By_Not_Existed_Id()
    {
        //Arrange
        Guid notExistedInDbArticleId = Guid.NewGuid();

        //Act
        var exception = await Assert.ThrowsAsync<EntityNotFoundException>(
            async () => await _articleAppService.GetCmsContent(notExistedInDbArticleId));

        //Assert
        exception.Id.ShouldBe(notExistedInDbArticleId);
    }

    [Fact]
    public async Task Should_Return_Article_By_Id()
    {
        //Arrange
        var list = await _articleAppService.GetAll();
        Guid validId = list[0].Id;

        //Act
        var articleDto = await _articleAppService.GetCmsContent(validId);

        //Assert
        Assert.NotNull(articleDto);
    }

    [Fact]
    public async Task Should_Create_A_Valid_Article()
    {
        //Arrange
        var expectedHeading = "This data is added by UT";

        //Act
        var newArticleDto = await _articleAppService.Insert(
            new CreateUpdateArticleDto
            {
                Heading = expectedHeading,
                Byline = "UT",
                Body = "Added by UT"
            }
        );

        //Assert
        newArticleDto.Id.ShouldNotBe(Guid.Empty);
        newArticleDto.Heading.ShouldBe(expectedHeading);
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Model_Is_Not_Valid()
    {
        //Arrange
        var invalidArticle = new CreateUpdateArticleDto
        {
            Heading = Helpers.GenerateTestingString(300),
            Byline = Helpers.GenerateTestingString(60),
            Body = Helpers.GenerateTestingString(5000)
        };

        //Act
        var exception = await Assert.ThrowsAsync<AbpValidationException>(
            async() => await _articleAppService.Insert(invalidArticle));

        //Assert
        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == nameof(invalidArticle.Heading)));
        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == nameof(invalidArticle.Byline)));
        exception.ValidationErrors
            .ShouldContain(err => err.MemberNames.Any(mem => mem == nameof(invalidArticle.Body)));
    }

    [Fact]
    public async Task Should_Update_Valid_Article_Sucessfully()
    {
        //Arrange
        var list = await _articleAppService.GetAll();
        var article = list[0];
        string oldHeading = article.Heading;
        string newHeading = "New Heading";

        CreateUpdateArticleDto dto = new CreateUpdateArticleDto() { 
            Heading= newHeading,
            Byline= article.Byline,
            Body = article.Body,
        };

        //Act
        var updatedArticle = await _articleAppService.Update(article.Id, dto);

        //Assert
        updatedArticle.Heading.ShouldNotBe(oldHeading);
        updatedArticle.Heading.ShouldBe(newHeading);
    }

    [Fact]
    public async Task Should_Throw_Exception_When_Update_Not_Existed_Article()
    {
        //Arrange
        var notExistedId = Guid.NewGuid();

        CreateUpdateArticleDto dto = new CreateUpdateArticleDto()
        {
            Heading = "Test",
            Byline = "Test",
            Body = "Test",
        };

        //Act
        var exception = await Assert.ThrowsAsync<EntityNotFoundException>(
            async() => await _articleAppService.Update(notExistedId, dto));

        //Assert
        exception.Id.ShouldBe(notExistedId);
    }
}
