using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAuthorTask
{
    public class Book
    {
        public int id { get; set; }
        public string name { get; set; }
        public int pages { get; set; }
        public Author author { get; set; }
        public int authorID { get; set; }

        public section Section { get; set; }
        public int sectionid { get; set; }
    }
    public class Author
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public List <Book> books { get; set; }
    }
    public class section
    {
        public int sectionID { get; set; }
        public string name { get; set; }
        public List<Book> books { get; set; }

    }
    public class BookContext : DbContext
    {
        public DbSet<Book>book { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<section> sections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"
                           Server=DESKTOP-SFDKHS6\SQLEXPRESS;
                           Database=AuthorBook;
                           Trusted_Connection=True;");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            section c = new section() { name = "programming" };
            Author a = new Author() { name = "doaa", age = 30 };
            List<Book> b = new List<Book>(){
               new Book() {  name="book1", pages=320,authorID=8, sectionid=1 },
                new Book() {  name="book2", pages=20,authorID=8, sectionid=1 },
                 new Book() {  name="book3", pages=520,authorID=8, sectionid=1 }

        };
            

            BookContext boo = new BookContext();
            //boo.book.AddRange(b);
             var ans = boo.book.FirstOrDefault(x => x.authorID == 8);
            ans.name = "dd";
            boo.book.Update(ans);
            //boo.book.Remove(ans);
            boo.SaveChanges();





            Console.WriteLine("Done");
        }
    }
}
