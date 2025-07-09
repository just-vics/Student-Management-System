using static System.Console;

using Student_Management_System.Exc;
using Student_Management_System.SubClass;

namespace Student_Management_System.Main
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string id = "";
            string name = "";
            int max = 0;

            Student_Core manage = new Student_Core();

            intro();
            Thread.Sleep(2000);
            Clear();

            while (true)
            {
                menu();
                int choice = gets();
                WriteLine();

                switch (choice)
                {
                    case 1:

                        bool valid = false;
                        do
                        {
                            try
                            {
                                Write("Enter Student ID {S12345}: ");
                                id = ReadLine().ToUpper();
                                valid = manage.Validate_id(id);

                                if (manage.Id_Exists(id))
                                    throw new Personal($"ID already exists.");
                            }
                            catch (Personal ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine();

                                valid = false;
                            }
                        } while (!valid);

                        do
                        {
                            try
                            {
                                Write("Name: ");
                                name = ReadLine();
                                valid=String.IsNullOrEmpty(name);
                                if (valid)
                                    throw new Personal("Name cannot be Empty");
                            }
                            catch (Personal ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine();
                            }
                        } while (valid);

                        do
                        {
                            try
                            {
                                Write("How many grades do you want enter: ");
                                if (!int.TryParse(ReadLine(), out max))
                                    throw new Personal("Grades must be an integer and cannot be empty.");

                                valid = true;
                            }
                            catch (Personal ex)
                            {
                                WriteLine(ex.Message);
                                WriteLine();
                                valid = false;
                            }
                        } while (!valid);

                        int[] grades = new int[max];

                        for (int i = 0; i<grades.Length; i++)
                        {
                            do
                            {
                                try
                                {
                                    Write($"Enter grade {i+1}: ");
                                    if (!int.TryParse(ReadLine(), out grades[i]))
                                        throw new Personal("Grade must be an integer and cannot be empty.");
                                    valid = true;
                                }
                                catch (Personal ex)
                                {
                                    WriteLine(ex.Message);
                                    WriteLine();
                                    valid = false;
                                }
                            } while (!valid);
                        }

                        Student student = new Student(id, name, grades);
                        manage.Add(student);

                        break;

                    case 2:
                        manage.Display();
                        WriteLine();

                        break;

                    case 3:
                        Write("Enter Student ID you want to search: ");
                        string search = ReadLine();

                        manage.Search(search);
                        WriteLine();

                        break;

                    case 4:
                        Write("Enter Student ID you want to remove: ");
                        string remove = ReadLine();

                        manage.Remove(remove);
                        WriteLine();

                        break;

                    case 5:
                        WriteLine("Leaving the System..........");
                        return;

                    default:
                        WriteLine("Invalid choice, Enter between 1-5");
                        WriteLine();

                        break;
                }
            }
        }

        public static void intro()
        {
            WriteLine("========Student Management========");
        }

        public static void menu()
        {
            WriteLine("1.Add Student");
            WriteLine("2.Display Students");
            WriteLine("3.Search Student");
            WriteLine("4.Remove Student");
            WriteLine("5.Exit");
        }

        public static int gets()
        {
            int choice = 0;
            bool valid = false;

            do
            {
                try
                {
                    Write("Enter your choice: ");
                    if (!int.TryParse(ReadLine(), out choice))
                        throw new Personal("Choice must be an integer and cannot be empty.");
                    valid = true;
                }
                catch (Personal ex)
                {
                    WriteLine();
                    WriteLine(ex.Message);
                    WriteLine();

                    valid = false;
                }
            } while (!valid);

            return choice;
        }
    }
}