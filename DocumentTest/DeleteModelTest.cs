using ApplicationCore.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using Web.Pages.Documents;
using Xunit;

namespace DocumentTests
{
    public class DeleteModelTests
    {
        [Fact]
        public void OnGet_WithValidId_ShouldReturnPageResultWithDocument()
        {
            // Arrange
            var documentId = 1;
            var document = new Document { Id = documentId };
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(repo => repo.GetDocumentById(documentId)).Returns(document);
            var deleteModel = new DeleteModel(documentRepositoryMock.Object);

            // Act
            var result = deleteModel.OnGet(documentId);

            // Assert
            Assert.IsType<PageResult>(result);
            Assert.Equal(document, deleteModel.Document);
        }

        [Fact]
        public void OnGet_WithInvalidId_ShouldReturnNotFoundResult()
        {
            // Arrange
            var documentId = 1;
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(repo => repo.GetDocumentById(documentId)).Returns((Document)null);
            var deleteModel = new DeleteModel(documentRepositoryMock.Object);

            // Act
            var result = deleteModel.OnGet(documentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void OnPost_WithValidId_ShouldDeleteDocumentAndRedirectToIndexPage()
        {
            // Arrange
            var documentId = 1;
            var document = new Document { Id = documentId };
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(repo => repo.GetDocumentById(documentId)).Returns(document);
            var deleteModel = new DeleteModel(documentRepositoryMock.Object);

            // Act
            var result = deleteModel.OnPost(documentId);

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var redirectResult = (RedirectToPageResult)result;
            Assert.Equal("../Index", redirectResult.PageName);

            documentRepositoryMock.Verify(repo => repo.DeleteDocument(documentId), Times.Once);
        }

        [Fact]
        public void OnPost_WithInvalidId_ShouldReturnNotFoundResult()
        {
            // Arrange
            var documentId = 1;
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(repo => repo.GetDocumentById(documentId)).Returns((Document)null);
            var deleteModel = new DeleteModel(documentRepositoryMock.Object);

            // Act
            var result = deleteModel.OnPost(documentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
            documentRepositoryMock.Verify(repo => repo.DeleteDocument(documentId), Times.Never);
        }
    }
}

