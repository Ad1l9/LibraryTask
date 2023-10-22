using ConsoleApp18.Exceptions;
using ConsoleApp18.Models;
using System.ComponentModel.Design;
using System.Text;
using System.Text.RegularExpressions;
using static System.Reflection.Metadata.BlobBuilder;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Library> libraries = new List<Library>();

            List<Category> categories = new List<Category>();

            List<Book> books = new List<Book>();

            Menu(libraries,categories,books);

        }

        public static void Menu(List<Library> libraries, List<Category> categories, List<Book> books)
        {
            Console.Clear();
            Console.WriteLine($@"
==========================
        ANA MENYU
==========================

[1] Yeni kitabxana yarat
[2] Yeni kateqoriya yarat
[3] Yeni kitab yarat
[4] Kitabxanaya daxil ol
[0] Proqramdan chix
");
            Console.Write(">>>");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                choice++;
                Choose(choice, libraries, categories, books);
            }
            else Menu(libraries, categories, books);
        }

        public static void Choose(int choice, List<Library> libraries, List<Category> categories, List<Book> books)
        {
            switch (choice)
            {
                case 1:
                    Console.WriteLine("#SeeYouAgain");
                    break;
                
                case 2:
                    Console.Clear();
                    Console.Write($@"
============================
    Yeni Kitabxana Yarat
============================

Kitabxananin adini daxil et:");

                    string libraryName = Format(Console.ReadLine(),true);

                    try
                    {
                        if (!String.IsNullOrWhiteSpace(libraryName))
                        {
                            Library library = new Library(libraryName);

                            libraries.Add(library);

                            Console.WriteLine($"'{libraryName}' adli kitabxana yaradildi");
                        }
                        else throw new WrongInputException("Kitabxana adi duzgun deyil");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    Menu(libraries, categories, books);

                    break;

                case 3:
                    Console.Clear();
                    Console.Write($@"
============================
    Yeni Kateqoriya Yarat
============================

Kateqoriyanin adini daxil et:");
                    string categoryName = Format(Console.ReadLine());
                    try
                    {
                        if (!String.IsNullOrWhiteSpace(categoryName))
                        {
                            Category category = new(categoryName);

                            if (!categories.Contains(category))
                            {
                                categories.Add(category);
                                Console.WriteLine($"'{categoryName}' adli kateqoriya yaradildi");
                            }
                            else Console.WriteLine("Bu kateqoriya movcuddur");

                        }
                        else throw new WrongInputException("Kateqoriya adi duzgun deyil");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    Menu(libraries, categories, books);
                    break;

                case 4:
                    if (categories.Count == 0)
                    {
                        Console.WriteLine("Kitab yaratmaq ucun Kateqoriya movcud deyil!!!(*Kateqoriya yaradin)");
                    }
                    else
                    {
                        Console.Clear();
                        Console.Write($@"
============================
    Yeni Kitab Yarat
============================

Kitabin adini daxil et:");
                        string bookName = Format(Console.ReadLine());
                        Console.Write("Yazari Kimdir:");
                        string authorName = Format(Console.ReadLine(),true);
                        try
                        {
                            if (!String.IsNullOrWhiteSpace(bookName) && !String.IsNullOrWhiteSpace(authorName))
                            {
                                Console.WriteLine("Kateqoriya sech:");
                                foreach (Category cat in categories)
                                {
                                    Console.WriteLine(cat);
                                }
                                Console.Write("Id daxil edin:");
                                int.TryParse(Console.ReadLine(), out int catId);
                                foreach (Category cat in categories)
                                {
                                    if (catId == cat.Id)
                                    {
                                        Book book = new Book(bookName, authorName, cat);
                                        if (!books.Contains(book))
                                        {
                                            books.Add(book);
                                            Console.WriteLine($"'{bookName}' adli kitaf yaradildi");
                                        }
                                        else Console.WriteLine("Bu kitab artiq yaradilib");
                                        Console.WriteLine("[Press Enter]");
                                        Console.ReadLine();
                                        Menu(libraries, categories, books);
                                    }
                                }
                                Console.WriteLine("Kateqoriya tapilmadi");
                                Console.WriteLine("Kitab yaradilmadi");
                            }
                            else throw new WrongInputException("Kitab adi veya yazici adi duzgun daxil edilmeyib");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine("Kitab yaradilmadi");
                        }
                    }

                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    Menu(libraries, categories, books);
                    break;

                case 5:

                    try
                    {
                        if (libraries.Count > 0)
                        {
                            Console.WriteLine("Kitabxana sech:");
                            foreach (Library lib in libraries)
                            {
                                Console.WriteLine(lib);
                            }
                            Console.Write("Id daxil edin:");
                            int.TryParse(Console.ReadLine(), out int libId);
                            foreach (Library lib in libraries)
                            {
                                if (libId == lib.Id)
                                {
                                    Console.WriteLine("[Press Enter]");
                                    Console.ReadLine();
                                    LibMenu(lib, categories, books);
                                }
                            }
                            throw new LibraryNotFoundException("Kitabxana tapilmadi");
                        }

                        else
                        {
                           throw new LibraryNotFoundException("Kitabxana yaradilmayib");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }


                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    Menu(libraries, categories, books);
                    break;

                default:
                    Menu(libraries, categories, books);
                    break;
            }
        }



        public static void LibMenu(Library library, List<Category> categories, List<Book> books)
        {

            Console.Clear();
            Console.WriteLine($@"
==========================
       Library Menu
==========================

[1] Kitab elave et
[2] Kitablari goster
[0] Kitabxanadan chix
");
            Console.Write(">>>");
            if (int.TryParse(Console.ReadLine(), out int libchoice))
            {
                libchoice++;
                LibChoose(libchoice, library, categories, books);
            }
            else LibMenu(library, categories, books);
        }

        public static void LibChoose(int choice, Library library, List<Category> categories, List<Book> books)
        {
            switch (choice)
            {
                case 1:
                    break;

                case 2:
                    try
                    {
                        if (books.Count > 0)
                        {
                            Console.WriteLine("Kitab sech:");
                            foreach (Book book in books)
                            {
                                Console.WriteLine(book);
                            }
                            Console.WriteLine("Id daxil edin:");
                            int.TryParse(Console.ReadLine(), out int bookId);
                            foreach (Book book in books)
                            {
                                if (bookId == book.Id && !library.Contains(book))
                                {
                                    library.AddBook(book);
                                    Console.WriteLine("Kitab elave edildi");
                                    Console.WriteLine("[Press Enter]");
                                    Console.ReadLine();
                                    LibMenu(library, categories, books);
                                }
                            }
                            throw new BookNotFoundException("Kitab tapilmadi");
                        }
                        else
                        {
                            throw new BookNotFoundException("Kitab yoxdur");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    LibMenu(library, categories, books);

                    break;

                case 3:
                    library.ListAllBooks();

                    Console.WriteLine("[Press Enter]");
                    Console.ReadLine();
                    LibMenu(library, categories, books);
                    break;

                default:
                    LibMenu(library, categories, books);
                    break;
            }
        }
        public static string Format(string word,bool isName=false)
        {
            word = word.Trim().ToUpper();
            string[] wordarray = word.Split(' ');

            StringBuilder result = new StringBuilder();


            foreach (var item in wordarray)
            {
                if (!string.IsNullOrEmpty(item))
                {
                    string newItem = item[0] + item.Substring(1).ToLower();
                    result.Append(newItem+' ') ;
                }
            }
            if (isName)
            {
                string pattern = @"^(([a-zA-Z]{2,15})[ ]){1,}$";
                Regex rg = new Regex(pattern);
                if (rg.IsMatch(result.ToString()))
                {
                    return result.ToString();
                }
                else return "";
            }
            return result.ToString();
        }
    }
}