using static System.Console;

using Student_Management_System.Exc;
using System.Text.RegularExpressions;

namespace Student_Management_System.SubClass
{
    public class Student_Core
    {
        public List<Student> Students { get; set; }

        public Student_Core()
        {
            Students = new List<Student>();
        }

        public void Add(Student student)
        {
            Students.Add(student);
            WriteLine("Student Has Been Added Successfully");
            WriteLine();
        }

        public void Display()
        {
            if (Students.Count==0)
            {
                WriteLine("There are currently no students to Display");
            }
            else
            {
                foreach (Student s in Students)
                {
                    WriteLine(s.ToString());
                }
            }
        }

        public void Search(string id)
        {
            bool found = false;

            if (Students.Count==0)
            {
                WriteLine("There are currently no students to Search");
            }
            else
            {
                for (int i = 0; i<Students.Count; i++)
                {
                    if (Students[i].id==id)
                    {
                        found = true;
                        WriteLine($"Student: {Students[i].ToString()}");

                        break;
                    }
                }

                if (!found)
                {
                    WriteLine("Student: No Results");
                }
            }
        }

        public void Remove(string id)
        {
            bool found = false;

            if (Students.Count==0)
            {
                WriteLine("There are currently no students to Remove");
            }
            else
            {
                for (int i = 0; i<Students.Count; i++)
                {
                    if (Students[i].id==id)
                    {
                        found = true;
                        Students.RemoveAt(i);
                        WriteLine("Student Has Been Removed Successfully");

                        break;
                    }
                }
                if (!found)
                {
                    WriteLine($"Student with such an ID was not found");
                }
            }
        }

        public bool Validate_id(string id)
        {
            string pattern = @"^S\d{5}$";

            Regex r = new Regex(pattern);

            if (String.IsNullOrEmpty(id))
            {
                throw new Personal("ID cannot be empty");
            }
            if (!r.IsMatch(id))
            {
                throw new Personal("Invalid ID. ID must start with an \'S\' followed by 5 digits");
            }

            return true;
        }

        public bool Id_Exists(string id)
        {
            foreach (Student s in Students)
            {
                if (s.id == id)
                    return true;
            }
            return false;
        }
    }
}