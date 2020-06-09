using Library.Domain.Entities;
using Library.Infra.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace Library.Test.ConsoleTests
{
    class InsertSQLDataTest
    {
        static void Main(string[] args)
        {
            InsertData();
            PrintData();
            Console.ReadKey();
        }

        private static void InsertData()
        {
            //using (var context = new LibraryContext())
            {
                // Creates the database if not exists
                //context.Database.EnsureCreated();
                //// Adds a publisher
                //var publisher = new Publisher
                //{
                //    Name = "Mariner Books"
                //};
                //context.Publisher.Add(publisher);
                //// Adds some books
                //context.Book.Add(new Book
                //{
                //    //Info = "{\"ISBN\": \"978-0544003415\", \"Title\": \"The Lord of the Rings\", \"Author\": \"J.R.R. Tolkien\", \"Language\": \"English\", \"Pages\": {\"Vol1\": \"405\", \"Vol2\": \"395\", \"Vol3\": \"416\"}}",
                //    //Publisher = publisher
                //});
                //context.Book.Add(new Book
                //{
                //    //Info = "{ \"ISBN\" : \"978-0547247762\", \"Title\" : \"The Sealed Letter\", \"Author\" : \"Emma Donoghue\", \"Language\" : \"English\", \"Pages\" : 416 }",
                //    //Publisher = publisher
                //});
                ////Saves changes
                //context.SaveChanges();
            }
        }
        private static void PrintData()
        {
            // Gets and prints all books in database
            //using (var context = new LibraryContext())
            {
                //var books = context.Book.Include(p => p.Publisher);
                //foreach (var book in books)
                //{
                //    var data = new StringBuilder();
                //    //data.AppendLine($"Info: {book.Info}");
                //    Console.WriteLine(data.ToString());
                //}
            }

        }
    }
}
