using System;
using System.Collections.Generic;
using System.Linq;

namespace JoshDanTarikProject
{
    class Book
    {
        public string Title;
        public string Author;
        public string Status;
        public DateTime DueDate;

        public Book(string bookTitle, string bookAuthor, string bookStatus)
        {
            Title = bookTitle;
            Author = bookAuthor;
            Status = bookStatus;
        }

        public override string ToString()
        {
            return $"\nTITLE: {Title} \nAUTHOR: {Author} \nSTATUS: {Status}";
        }
    }

    class Program
    {
        static bool isValidCommand(string entry)
        {
            if (entry == "list books")
            {
                return true;
            }
            else if (entry == "search by author")
            {
                return true;
            }
            else if (entry == "search by title")
            {
                return true;
            }
            else if (entry == "check-out")
            {
                return true;
            }
            else if (entry == "return book")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool isValidBook(string entry, List<Book> bookList)
        {
            foreach (Book book in bookList)
            {
                if (book.Title.Contains(entry))
                {
                    return true;
                }
            }
            return false;
        }

        static bool isValidAuthor(string entry, List<Book> bookList)
        {
            foreach (Book book in bookList)
            {
                if (book.Author.Contains(entry))
                {
                    return true;
                }
            }
            return false;
        }

        static int ReadInt()
        {
            bool done = false;
            int result = 0;
            while (!done)
            {
                string entry = Console.ReadLine();
                try
                {
                    result = int.Parse(entry);
                    done = true;
                }
                catch (Exception ex)
                {
                    Console.Write("\nSorry, that isn't a valid book number. Please try again: ");
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            DateTime testDateTime = DateTime.Now;

            DateTime dueDateTime = testDateTime.AddDays(14);

            List<Book> testList = new List<Book>();

            Book testbook = new Book("Dune", "Frank Herbert", "Checked-Out");
            testList.Add(testbook);
            testList.Add(new Book("Harry Potter & The Sorcerer's Stone", "J.K. Rowling", "Available"));
            testList.Add(new Book("Harry Potter & The Chamber of Secrets", "J.K. Rowling", "Available"));
            testList.Add(new Book("Harry Potter & The Prisoner of Azkaban", "J.K. Rowling", "Available"));
            testList.Add(new Book("Harry Potter & The Goblet of Fire", "J.K. Rowling", "Available"));
            testList.Add(new Book("Harry Potter & The Order of The Phoenix", "J.K. Rowling", "Available"));
            testList.Add(new Book("Harry Potter & The Half Blood Prince", "J.K. Rowling", "Available"));
            testList.Add(new Book("Harry Potter & The Deathly Hallows", "J.K. Rowling", "Checked-Out"));
            testList.Add(new Book("To Kill a Mockingbird", "Harper Lee", "Checked-Out"));
            testList.Add(new Book("1984", "George Orwell", "Checked-Out"));
            testList.Add(new Book("Animal Farm", "George Orwell", "Available"));
            testList.Add(new Book("Down and Out in Paris and London", "George Orwell", "Available"));
            testList.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Available"));
            testList.Add(new Book("The Catcher and The Rye", "J.D. Salinger", "Checked-Out"));
            testList.Add(new Book("Little Women", "Louisa May Alcott", "Available"));
            testList.Add(new Book("Lord of the Flies", "William Golding", "Available"));
            testList.Add(new Book("Fahrenheit 451", "Ray Bradbury", "Checked-Out"));
            testList.Add(new Book("Jane Eyre", "Charlotte Bronte", "Available"));
            testList.Add(new Book("Wuthering Heights", "Emily Bronte", "Checked-Out"));
            testList.Add(new Book("Brave New World", "Aldous Huxley", "Available"));

            bool goAgain2 = true;
            Console.WriteLine("Welcome to our library!");
                        
            do
            {
                Console.Write("What would you like to do? \n(LIST BOOKS/SEARCH BY AUTHOR/SEARCH BY TITLE/CHECK-OUT/RETURN BOOK): ");
                string userEntry = Console.ReadLine().ToLower();
                bool goAgain = true;
                int bookSelection = 0;

                while (isValidCommand(userEntry) == false)
                {
                    Console.Write("\nThat was not a valid command. What would you like to do? \n(LIST BOOKS/SEARCH BY AUTHOR/SEARCH BY TITLE/CHECK-OUT/RETURN BOOK): ");
                    userEntry = Console.ReadLine().ToLower();
                    isValidCommand(userEntry);
                }

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

                    while (isValidAuthor(userEntry, testList) == false)
                    {
                        Console.WriteLine("Sorry, we do not have a book that matches your search. Please try again: ");
                        userEntry = Console.ReadLine();
                    }

                    foreach (Book book in testList)
                    {
                        if (book.Author.Contains(userEntry))
                        {
                            Console.WriteLine($"{book.Title} by {book.Author} - {book.Status}");
                        }
                    }
                }
                else if (userEntry == "search by title")
                {
                    Console.Write("\nPlease enter the name of the book: ");
                    userEntry = Console.ReadLine();

                    while (isValidBook(userEntry, testList) == false)
                    {
                        Console.WriteLine("Sorry, we do not have a book that matches your search. Please try again: ");
                        userEntry = Console.ReadLine();
                    }

                    foreach (Book book in testList)
                    {
                        if (book.Title.Contains(userEntry))
                        {
                            Console.WriteLine($"{book.Title} by {book.Author} - {book.Status}");
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
                        Console.Write("\nPlease enter the number of the book you would like to check-out: ");
                        bookSelection = ReadInt();

                        bool myBool = false;
                        while (myBool == false)
                        {
                            if (bookSelection - 1 <= testList.Count)
                            {
                                myBool = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that wasn't a valid entry. Please enter the number of the book you would like to check-out: ");
                                bookSelection = ReadInt();
                            }
                        }

                        if (testList[bookSelection - 1].Status == "Checked-Out")
                        {
                            Console.WriteLine("Sorry, that book is already checked-out.");
                        }
                        else if (testList[bookSelection - 1].Status == "Available")
                        {
                            testList[bookSelection - 1].Status = "Checked-Out";
                            testList[bookSelection - 1].DueDate = dueDateTime;
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
                        bookSelection = ReadInt();
                        bool myBool = false;
                        while (myBool == false)
                        {
                            if (bookSelection - 1 <= testList.Count)
                            {
                                myBool = true;
                            }
                            else
                            {
                                Console.WriteLine("Sorry, that wasn't a valid entry. Please enter the number of the book you would like to check-out: ");
                                bookSelection = ReadInt();
                            }
                        }

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
                Console.Write("\nWould you like to go back to the menu? (yes/no): ");
                userEntry = Console.ReadLine().ToLower();

                if (userEntry == "no")
                {
                    goAgain2 = false;
                }
                Console.Clear();
            } while (goAgain2 == true);
        }
    }
}


