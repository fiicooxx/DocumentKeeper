using ApplicationCore.Models;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using Web.Pages.Documents;

namespace DocumentTest
{
    public class EditModelTests
    {
        [Fact]
        public void OnGet_WithValidId_ShouldReturnPageResultWithDocument()
        {
            // Arrange
            var documentId = 1;
            var document = new Document { Id = documentId };
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(repo => repo.GetDocumentById(documentId)).Returns(document);
            var editModel = new EditModel(documentRepositoryMock.Object);

            // Act
            var result = editModel.OnGet(documentId);

            // Assert
            Assert.IsType<PageResult>(result);
            Assert.Equal(document, editModel.Document);
        }

        [Fact]
        public void OnGet_WithInvalidId_ShouldReturnNotFoundResult()
        {
            // Arrange
            var documentId = 1;
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(repo => repo.GetDocumentById(documentId)).Returns((Document)null);
            var editModel = new EditModel(documentRepositoryMock.Object);

            // Act
            var result = editModel.OnGet(documentId);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void OnPost_WithValidModel_ShouldUpdateDocumentAndRedirectToIndexPage()
        {
            // Arrange
            var documentId = 1;
            var existingDocument = new Document { Id = documentId };
            var updatedDocument = new Document { Id = documentId, Title = "Updated Title", Description = "Updated Description" };
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            documentRepositoryMock.Setup(repo => repo.GetDocumentById(documentId)).Returns(existingDocument);
            var editModel = new EditModel(documentRepositoryMock.Object);
            editModel.Document = updatedDocument;

            // Act
            var result = editModel.OnPost();

            // Assert
            Assert.IsType<RedirectToPageResult>(result);
            var redirectResult = (RedirectToPageResult)result;
            Assert.Equal("../Index", redirectResult.PageName);

            documentRepositoryMock.Verify(repo => repo.UpdateDocument(existingDocument), Times.Once);
            Assert.Equal(updatedDocument.Title, existingDocument.Title);
            Assert.Equal(updatedDocument.Description, existingDocument.Description);
        }

        [Fact]
        public void OnPost_WithInvalidModel_ShouldReturnPageResult()
        {
            // Arrange
            var documentId = 1;
            var documentRepositoryMock = new Mock<IDocumentRepository>();
            var editModel = new EditModel(documentRepositoryMock.Object);
            editModel.ModelState.AddModelError("Title", "Title is required");

            // Act
            var result = editModel.OnPost();

            // Assert
            Assert.IsType<PageResult>(result);
            documentRepositoryMock.Verify(repo => repo.UpdateDocument(It.IsAny<Document>()), Times.Never);
        }
    }
}
