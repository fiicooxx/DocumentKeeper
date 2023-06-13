using ApplicationCore.Enums;
using ApplicationCore.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using Web.Pages.Documents;

namespace DocumentTests
{
    public class CreateModelTests
    {
        [Fact]
        public void OnPost_WithValidDocumentFile_ShouldAddDocumentAndRedirectToIndexPage()
        {
            // Arrange
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            var createModel = new CreateModel(documentRepositoryMock.Object);

            var documentFileMock = new Mock<IFormFile>();
            documentFileMock.Setup(file => file.Length).Returns(100); // Set the file length to a non-zero value

            var document = new Document
            {
                Title = "TestDocument",
                FileType = "application/pdf",
                Description = "Test Description",
                CreationDate = DateTime.Now,
                Status = DocumentStatus.Public,
                CreatedBy = "admin"
            };

            createModel.DocumentFile = documentFileMock.Object;
            createModel.Document = document;

            // Act
            var result = createModel.OnPost();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var redirectResult = (RedirectToPageResult)result;
            Assert.Equal("../Index", redirectResult.PageName);

            documentRepositoryMock.Verify(repo => repo.AddDocument(It.IsAny<Document>()), Times.Once);
        }

        [Fact]
        public void OnPost_WithNullDocumentFile_ShouldNotAddDocumentAndRedirectToIndexPage()
        {
            // Arrange
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            var createModel = new CreateModel(documentRepositoryMock.Object);
            createModel.DocumentFile = null;

            // Act
            var result = createModel.OnPost();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var redirectResult = (RedirectToPageResult)result;
            Assert.Equal("../Index", redirectResult.PageName);

            documentRepositoryMock.Verify(repo => repo.AddDocument(It.IsAny<Document>()), Times.Never);
        }
    }
}

