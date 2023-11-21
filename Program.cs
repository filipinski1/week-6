using System;

namespace week_6
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Book book1 = new Book("Bible", "God", "123499999");
            Book book2 = new Book("Harry Potter", "Rowling", "54355435167689");
            Book[] libraryBooks = { book1, book2 };

            Library myLibrary = new Library("New Library", libraryBooks);
            myLibrary.Display();

            Book newBook = new Book("C# Programming", "John Doe", "1234567890123");
            myLibrary.AddBook(newBook);

            myLibrary.Display();
        }


        class Book
        {

            public string Title { get; set; }
            public string Author { get; set; }

            private string isbn;  // Private field to store ISBN

            public string ISBN
            {
                get => isbn;
                set
                {

                    if (!string.IsNullOrEmpty(value) && value.Length <= 13)
                    {
                        isbn = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid ISBN. It should have a maximum length of 13.");
                    }
                }
            }




            public Book(string title, string author, string iSBN)
            {
                Title = title;
                Author = author;
                ISBN = iSBN;

            }
            public void Display()
            {
                Console.WriteLine($"Title:{Title},Author:{Author}, ISBN:{ISBN}");
            }


        }
        class Library
        {
            public string Name { get; set; }
            private Book[] books;

            public Book[] Books
            {
                get => books;
                set
                {
                    if (value.Length <= 1000)
                    {
                        books = value;
                    }
                    else
                    {
                        Console.WriteLine("Library is full");


                    }
                }
            }
            public Library(string name, Book[] books)
            {
                Name = name;
                Books = books;
            }
            public void AddBook (Book newBook)
            {
                if (Books.Length <1000)
                {
                    Book[] updatedBooks = new Book[Books.Length + 1];
                    Array.Copy(Books, updatedBooks, Books.Length);
                    updatedBooks[Books.Length] = newBook;

                    Books = updatedBooks;
                    Console.WriteLine($"Book {newBook.Title} added to the library");
                }
                else
                {
                    Console.WriteLine("Library is full");
                }
            }
            public void Display()
            {
                Console.WriteLine($"Library Name {Name} books name {Books.Length}");
                foreach (var book in Books)
                {
                    book.Display();
                }
            }
        }
    }
}


