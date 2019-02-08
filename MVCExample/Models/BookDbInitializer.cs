using MVCExample.Models.BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCExample.Models
{
    public class BookDbInitializer : CreateDatabaseIfNotExists<BookContext>
    //public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "War and Peace", Author = "Leo Tolstoy", Price = 220 });
            db.Books.Add(new Book { Name = "Fathers and Sons", Author = "Ivan Turgenev", Price = 180 });
            db.Books.Add(new Book { Name = "The Seagull", Author = "Anton Chekhov", Price = 150 });

            base.Seed(db);
        }
    }
}