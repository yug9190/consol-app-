using System;

class Program
{
    static MovieCollection movies = new MovieCollection();
    static MemberCollection members = new MemberCollection();

    static void Main()
    {
        while (true)
        {  
            Console.WriteLine("\nCOMMUNITY LIBBRARY MOVIE DVD MANAGEMENT SYSTEM");
            Console.WriteLine("Main Menu");
            Console.WriteLine("1. Staff");
            Console.WriteLine("2. Member");
            Console.WriteLine("0. End the program");
            Console.Write("Enter your choice ==> ");
            string choice = Console.ReadLine();

            if (choice == "0") break;
            else if (choice == "1") StaffMenu();
            else if (choice == "2") MemberMenu();
        }
    }

    static void StaffMenu()
    {
        while (true)
        {
            Console.WriteLine("\nStaff Menu");
            Console.WriteLine("1. Add DVDs");
            Console.WriteLine("2. Remove DVDs");
            Console.WriteLine("3. Register new member");
            Console.WriteLine("4. Remove member");
            Console.WriteLine("5. Find member contact");
            Console.WriteLine("6. Find members renting a movie");
            Console.WriteLine("0. Return");
            Console.Write("Enter your choice ==> ");
            string choice = Console.ReadLine();

            if (choice == "0") break;
            else if (choice == "1")
            {
                Console.Write("Title: "); string title = Console.ReadLine();
                Console.Write("Genre: "); string genre = Console.ReadLine();
                Console.Write("Classification: "); string classification = Console.ReadLine();
                Console.Write("Duration: "); int duration = int.Parse(Console.ReadLine());
                Console.Write("Total Copies: "); int total = int.Parse(Console.ReadLine());
                movies.Add(new Movie(title, genre, classification, duration, total));
            }
            else if (choice == "2")
            {
                Console.Write("Title: ");
                if (!movies.Remove(Console.ReadLine()))
                    Console.WriteLine("Movie not found.");
            }
            else if (choice == "3")
            {
                Console.Write("First Name: ");
                Console.Write("Last Name: ");
                Console.Write("Phone: ");
                members.Add(new Member(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()));
            }
            else if (choice == "4")
            {
                Console.Write("Full Name: ");
                if (!members.Remove(Console.ReadLine()))
                    Console.WriteLine("Member not found.");
            }
            else if (choice == "5")
            {
                Console.Write("Full Name: ");
                Member m = members.FindByName(Console.ReadLine());
                Console.WriteLine(m != null ? m.PhoneNumber : "Not found.");
            }
            else if (choice == "6")
            {
                Console.Write("Movie title: ");
                Movie m = movies.FindByTitle(Console.ReadLine());
                if (m == null) Console.WriteLine("Movie not found.");
                else
                {
                    foreach (var mem in members.GetAllBorrowing(m))
                        Console.WriteLine(mem.FullName);
                }
            }
        }
    }

    static void MemberMenu()
    {
        Console.Write("Enter your full name: ");
        Member member = members.FindByName(Console.ReadLine());
        if (member == null) { Console.WriteLine("Member not found."); return; }

        while (true)
        {
            Console.WriteLine("\nMember Menu");
            Console.WriteLine("1. Browse all movies");
            Console.WriteLine("2. Display info about a movie");
            Console.WriteLine("3. Borrow a movie");
            Console.WriteLine("4. Return a movie");
            Console.WriteLine("5. List current borrowings");
            Console.WriteLine("6. Display top 3 rented movies");
            Console.WriteLine("0. Return");
            Console.Write("Enter your choice ==> ");
            string choice = Console.ReadLine();

            if (choice == "0") break;
            else if (choice == "1")
            {
                foreach (var m in movies.GetAllSorted()) Console.WriteLine(m);
            }
            else if (choice == "2")
            {
                Console.Write("Movie title: ");
                var m = movies.FindByTitle(Console.ReadLine());
                Console.WriteLine(m != null ? m.ToString() : "Not found.");
            }
            else if (choice == "3")
            {
                Console.Write("Movie title: ");
                var m = movies.FindByTitle(Console.ReadLine());
                Console.WriteLine(member.BorrowMovie(m) ? "Borrowed." : "Failed.");
            }
            else if (choice == "4")
            {
                Console.Write("Movie title: ");
                var m = movies.FindByTitle(Console.ReadLine());
                Console.WriteLine(member.ReturnMovie(m) ? "Returned." : "Not found in borrow list.");
            }
            else if (choice == "5")
            {
                foreach (var m in member.GetBorrowedMovies()) Console.WriteLine(m);
            }
            else if (choice == "6")
            {
                foreach (var m in movies.Top3Movies())
                    if (m != null)
                        Console.WriteLine($"{m.Title} - Borrowed {m.BorrowCount} times");
            }
        }
    }
}
