using lab4;
using lab4.DAL.DTO;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;
using System.Text.RegularExpressions;
namespace lab4.Controllers
{

    public class CatalogController : ControllerBase
    {
        public static Catalog catalog = new Catalog();
       
        [HttpGet("Get")]
        public IActionResult Get()
        {
            return Ok(catalog.GetAllBooks.ToList());
        }
        
        [HttpPost("Add")]
        public IActionResult Post([FromBody] Book book)
        {
            catalog.AddBook(book);
            return Ok(catalog.GetAllBooks.ToList());
        }

        [HttpGet("Name of book")]
        public IActionResult GetByName(string name)
        {
            var Books = (catalog.GetAllBooks.Where(b => b.name_of_book == name)).ToArray();
            return Ok(Books);
        }
        [HttpGet("Author")]
        public IActionResult GetByAuthor(string author)
        {
            var Books = (catalog.GetAllBooks.Where(b => b.autor == author)).ToArray();
            return Ok(Books);
        }
        [HttpGet("ISBN")]
        public IActionResult GetByISBN(int isbn)
        {
            var Books = catalog.GetAllBooks.Where(b => b.ISBN == isbn).ToArray();
            return Ok(Books);
        }
        [HttpGet("Fragment")]
        public IActionResult GetByFragment(string fragment)
        {
            var Books = (catalog.GetAllBooks.Where(b => b.Text.Contains(fragment)).ToArray());
            return Ok(Books);
        }
        [HttpGet("Key word")]
        public IActionResult GetByKeyWord(string key_word)
        {
            var Books = catalog.GetAllBooks.Where(b => (b.annotation.Contains(key_word) || b.Text.Contains(key_word))|| (b.annotation.Contains(key_word) && b.Text.Contains(key_word))).ToArray();
            return Ok(Books);
        }
    }
}