using System;
using System.Collections.Generic;

namespace JoshDanTarikProject
{
    class Book
    {
        public string Title;
        public string Author;
        public string Status;
        public double DueDate;

        public Book(string bookTitle, string bookAuthor, string bookStatus, double bookDueDate)
        {
            Title = bookTitle;
            Author = bookAuthor;
            Status = bookStatus;
            DueDate = bookDueDate;
        }

        public override string ToString()
        {
            return $"\nTITLE: {Title} \nAUTHOR: {Author} \nSTATUS: {Status} \nDUEDATE: {DueDate}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Book> testList = new List<Book>();

            Book testbook = new Book("Dune", "Frank Herbert", "Checked-Out", 12.06);
            testList.Add(testbook);
            testList.Add(new Book("Harry Potter & The Sorceror's Stone", "J.K. Rowling", "Checked-Out", 12.06));
            testList.Add(new Book("To Kill a Mockingbird", "Harper Lee", "Checked-Out", 12.06));
            testList.Add(new Book("1984", "George Orwell", "Checked-Out", 12.06));
            testList.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Checked-Out", 12.06));
            testList.Add(new Book("The Catcher and The Rye", "J.D. Salinger", "Checked-Out", 12.06));
            testList.Add(new Book("Little Women", "Louisa May Alcott", "Checked-Out", 12.06));
            testList.Add(new Book("Lord of the Flies", "William Golding", "Checked-Out", 12.06));
            testList.Add(new Book("Fahrenheit 451", "Ray Bradbury", "Checked-Out", 12.06));
            testList.Add(new Book("Jane Eyre", "Charlotte Bronte", "Checked-Out", 12.06));
            testList.Add(new Book("Wuthering Heights", "Emily Bronte", "Checked-Out", 12.06));
            testList.Add(new Book("Brave New World", "Aldous Huxley", "Available", 12.06));

            Console.Write("Welcome to our library! What would you like to do? \n(LIST BOOKS/SEARCH BY AUTHOR/SEARCH BY TITLE KEYWORD/CHECK-OUT/RETURN BOOK): ");
            string userEntry = Console.ReadLine();
            bool goAgain = true;
            int bookSelection = 0;

            if (userEntry == "list books")
            {
                foreach (Book book in testList)
                {
                    Console.WriteLine(book);
                }
            }
            else if (userEntry == "search by author")
            {
                Console.Write("\nPlease enter the name of the author: ");
                userEntry = Console.ReadLine();

                foreach (Book book in testList)
                {
                    if (book.Author.Contains(userEntry))
                    {
                        Console.WriteLine(book.Title);
                    }
                }
            }
            else if (userEntry == "search by title")
            {
                Console.Write("\nPlease enter the name of the book: ");
                userEntry = Console.ReadLine();

                foreach(Book book in testList)
                {
                    if (book.Title.Contains(userEntry))
                    {
                        Console.WriteLine(book.Title);
                    }
                }
            }
            else if (userEntry == "check-out")
            {
                for (int i = 0; i < testList.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - {testList[i].Title} - {testList[i].Author} - {testList[i].Status}");
                }

                do
                {
                    Console.Write("\nWhich book would you like to check-out?: ");
                    bookSelection = int.Parse(Console.ReadLine());
                    if (testList[bookSelection - 1].Status == "Checked-Out")
                    {
                        Console.WriteLine("Sorry, that book is already checked-out.");

                        Console.Write("\nWould you like to attempt to check-out another book? (yes/no): ");
                        userEntry = Console.ReadLine();

                        if (userEntry == "no")
                        {
                            goAgain = false;
                        }

                    }
                    else if (testList[bookSelection - 1].Status == "Available")
                    {
                        testList[bookSelection - 1].Status = "Checked-Out";
                        testList[bookSelection - 1].DueDate = 12.25;
                        Console.WriteLine($"Thanks for checking-out {testList[bookSelection - 1].Title}! It is due on {testList[bookSelection - 1].DueDate}.");
                    }

                    Console.Write("\nWould you like to attempt to check-out another book? (yes/no): ");
                    userEntry = Console.ReadLine();

                    if (userEntry == "no")
                    {
                        goAgain = false;
                    }

                } while (goAgain == true);

            }
            else if (userEntry == "return book")
            {
                do
                {
                    Console.WriteLine("Here are the books currently checked out:");

                    for (int i = 0; i < testList.Count; i++)
                    {
                        if (testList[i].Status == "Checked-Out")
                        {
                            Console.WriteLine($"{i + 1} - {testList[i].Title} - {testList[i].Author} - {testList[i].Status}");
                        }
                    }

                    Console.Write("\nWhich book would you like to return? Please enter the corresponding number: ");
                    bookSelection = int.Parse(Console.ReadLine());

                    testList[bookSelection - 1].Status = "Available";
                    Console.WriteLine($"Thank you for checking-in {testList[bookSelection - 1].Title}!");

                    Console.Write("\nWould you like to return another book? (yes/no): ");
                    userEntry = Console.ReadLine();

                    if (userEntry == "no")
                    {
                        goAgain = false;
                    }

                } while (goAgain == true);
               
            }


        }
    }
}
