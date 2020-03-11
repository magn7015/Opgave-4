using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLib.Model;

namespace Opgave4.Controllers
{ 
    [Route("api/localbooks")]
    [ApiController]
    public class Book1Controller : ControllerBase
    {
        private static readonly List<Bog> books = new List<Bog>()
        {
            new Bog("Bog1", "Forfatter1", 114, "3928375647382"),
            new Bog("Bog2", "Forfatter2", 25, "1928362392012"),
            new Bog("Bog3", "Forfatter3", 10, "1173844958473"),
            new Bog("Bog4", "Forfatter4", 593, "8392037352718"),
            new Bog("bog5", "Forfatter5", 725, "8302936251627")
        };

        // GET
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return books;

        }

        //GET
        [HttpGet]
        [Route("{isbn13}")]
        public Bog Get(string isbn13)
        {
            return books.Find(i => i.Isbn13 == isbn13);
        }

        // POST
        [HttpPost]
        public void Post([FromBody] Bog value)
        {
            books.Add(value);
        }

        // PUT
        [HttpPut]
        [Route("{isbn13}")]
        public void Put(string isbn13, [FromBody] Bog value)
        {
            Bog book = Get(isbn13);
            if (book != null)
            {
                book.Titel = value.Titel;
                book.Forfatter = value.Forfatter;
                book.Sidetal = value.Sidetal;
                book.Isbn13 = value.Isbn13;
            }
        }

        // DELETE
        [HttpDelete]
        [Route("{isbn13}")]
        public void Delete(string isbn13)
        {
            Bog book = Get(isbn13);
            books.Remove(book);
        }
    }
}
