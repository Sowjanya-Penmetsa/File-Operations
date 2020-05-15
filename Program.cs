using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Transactions;

namespace operations
{
    class Program
    {
        public static List<string> ListOfBooks = new List<string>();
        public static String path = "C:/Users/Anvesh Penmetsa/Desktop/files/BooksDB.txt";
        //public static String Choice;
        static void Main(string[] args)
        {
            int Choice;
            DisplayMenu();
            Choice = Convert.ToInt32(Console.ReadLine());
           while(Choice!=5)
           {
                switch(Choice)
                {
                    case 1:
                        AddBook();
                        break;
                    case 2:
                        DisplayBooks();
                        break;
                    case 3:
                        SearchBook();
                        break;
                    case 4:
                        DeleteBook();
                        break;
                    case 5:
                       // Exit1();
                        break;
                    default:
                        {
                            Console.WriteLine("you have entered  wrong choice");
                            Console.ReadLine();
                            break;
                        }
                        break;
                }

                Console.Clear();
                DisplayMenu();
                Choice = Convert.ToInt32(Console.ReadLine()); //Console.ReadLine();
           }
        }
        public static void DisplayMenu()
        {
            Console.WriteLine("Operations to be performed on the file");
            Console.WriteLine();
            Console.WriteLine("1. Add new book entry to the file: ");
            Console.WriteLine("2. Display the data in the file: ");
            Console.WriteLine("3. Search for a book in the file based on title ");
            Console.WriteLine("4. Delete the book from the file based on book ID");
            Console.WriteLine("5: Quit the program");
            Console.WriteLine();

            Console.WriteLine("Enter your choice:");


        }
        public static void GetBooks()
        {
           
            String str= File.ReadAllText(path);
            ListOfBooks = File.ReadAllLines(path).ToList();
        }
        public static void AddBook()
        {
            GetBooks();
            Console.WriteLine("enter the id of the book");
            string bid = Console.ReadLine();
            Console.WriteLine("enter the name of the book");
            string title = Console.ReadLine();
            Console.WriteLine("enter the name of the author ");
            string author = Console.ReadLine();

            ListOfBooks.Add("Book ID:" + bid +"   "+"Title:" +title+"   "+ "Author:"+ author);
            File.WriteAllLines("C:/Users/Anvesh Penmetsa/Desktop/files/BooksDB.txt", ListOfBooks);
        }
        public static void DisplayBooks()
        {
            GetBooks();
            string str = File.ReadAllText(path);
            Console.WriteLine(str);
            Console.ReadLine();
        }
        public static void SearchBook()
        {
            GetBooks();
            Console.WriteLine("enter the name of the book to search");
            String text = Console.ReadLine();
            int count = 0;
                foreach (string line in ListOfBooks.ToList())
                {
                    if (line.Contains(text))
                    {
                        count++;
                        Console.WriteLine("The " + text + " is available");
                    break;
                        
                    }
                    
                }
                if (count == 0)
                Console.WriteLine(" The " + text + " is not available");
                Console.ReadLine();


        }

        public static void DeleteBook()

        {
            GetBooks();
            Console.WriteLine("Enter the ID of the book to be deleted:");
            String search = Console.ReadLine();
            foreach (string Delbook in ListOfBooks.ToList())
            {
                if (Delbook.Contains(search))
                {
                    ListOfBooks.Remove(Delbook);
                }

            }        
            File.WriteAllLines("C:/Users/Anvesh Penmetsa/Desktop/files/BooksDB.txt", ListOfBooks);
            Console.ReadLine();

                    
                
            
        }
       
    }
}
