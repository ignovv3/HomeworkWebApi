using SEDC.WebApi.Homework2.Models;

namespace SEDC.WebApi.Homework2
{
    public static class StaticDb
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book() { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald" },
            new Book() { Title = "To Kill a Mockingbird", Author = "Harper Lee" },
            new Book() { Title = "1984", Author = "George Orwell" },
            new Book() { Title = "Pride and Prejudice", Author = "Jane Austen" },
            new Book() { Title = "The Catcher in the Rye", Author = "J.D. Salinger" },
            new Book() { Title = "The Hobbit", Author = "J.R.R. Tolkien" },
            new Book() { Title = "Harry Potter and the Sorcerer's Stone", Author = "J.K. Rowling" },
            new Book() { Title = "The Lord of the Rings", Author = "J.R.R. Tolkien" },
            new Book() { Title = "To the Lighthouse", Author = "Virginia Woolf" },
            new Book() { Title = "Brave New World", Author = "Aldous Huxley" }
        };
    }
}
