using lab4.Controllers;
using lab4;
using Microsoft.AspNetCore.Mvc;

namespace lab4Tests
{
    [TestClass]
    public class CatalogControllerTest
    {
        [TestMethod]
        public void GetByName_ReturnsCorrectBooks()
        {
            // Arrange
            var controller = new CatalogController();
            var book1 = new Book("Book1", "Autor1", 123456789, "Annotation1", "Summary1", "Text1");
            var book2 = new Book("Book2", "Autor2", 1234567890, "Annotation2", "Summary2", "Text2");
            var book3 = new Book("Book1", "Autor1", 123456789, "Annotation1", "Summary1", "Text1");

            // Act
            var result = controller.GetByName("Book 1") as OkObjectResult;
            var books = result.Value as Book[];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, books.Length);
            CollectionAssert.Contains(books, book1);
            CollectionAssert.Contains(books, book3);
        }
        public void GetByAuthor_ReturnsCorrectBooks()
        {
            // Arrange
            var controller = new CatalogController();
            var book1 = new Book("Book1", "Autor1", 123456789, "Annotation1", "Summary1", "Text1");
            var book2 = new Book("Book2", "Autor2", 1234567890, "Annotation2", "Summary2", "Text2");
            var book3 = new Book("Book1", "Autor1", 123456789, "Annotation1", "Summary1", "Text1");

            // Act
            var result = controller.GetByAuthor("Autor1") as OkObjectResult;
            var books = result.Value as Book[];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, books.Length);
            CollectionAssert.Contains(books, book1);
            CollectionAssert.Contains(books, book3);
        }
        public void GetByISBN_ReturnsCorrectBooks()
        {
            // Arrange
            var controller = new CatalogController();
            var book1 = new Book("Book1", "Autor1", 123456789, "Annotation1", "Summary1", "Text1");
            var book2 = new Book("Book2", "Autor2", 1234567890, "Annotation2", "Summary2", "Text2");
            var book3 = new Book("Book1", "Autor1", 123456789, "Annotation1", "Summary1", "Text1");

            // Act
            var result = controller.GetByISBN(123456789) as OkObjectResult;
            var books = result.Value as Book[];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, books.Length);
            CollectionAssert.Contains(books, book1);
            CollectionAssert.Contains(books, book3);
        }
        public void GetByAnnotation_ReturnsCorrectBooks()
        {
            // Arrange
            var controller = new CatalogController();
            var book1 = new Book("Book1", "Autor1", 123456789, "Annotation1 ", "Summary1", "Text1 fragment");
            var book2 = new Book("Book2", "Autor2", 1234567890, "Annotation2", "Summary2", "Text2");
            var book3 = new Book("Book1", "Autor1", 123456789, "Annotation1", "Summary1", "Text1 fragment");

            // Act
            var result = controller.GetByFragment("fragment") as OkObjectResult;
            var books = result.Value as Book[];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, books.Length);
            CollectionAssert.Contains(books, book1);
            CollectionAssert.Contains(books, book3);
        }
        public void GetByKeyWord_ReturnsCorrectBooks()
        {
            // Arrange
            var controller = new CatalogController();
            var book1 = new Book("Book1", "Autor1", 123456789, "Annotation1 KeyWord", "Summary1", "Text1");
            var book2 = new Book("Book2", "Autor2", 1234567890, "Annotation2", "Summary2", "Text2");
            var book3 = new Book("Book1", "Autor1", 123456789, "Annotation1", "Summary1", "Text1 KeyWord");

            // Act
            var result = controller.GetByKeyWord("KeyWord") as OkObjectResult;
            var books = result.Value as Book[];

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(200, result.StatusCode);
            Assert.AreEqual(2, books.Length);
            CollectionAssert.Contains(books, book1);
            CollectionAssert.Contains(books, book3);
        }
    }
}