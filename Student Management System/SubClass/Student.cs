namespace Student_Management_System.SubClass
{
    public class Student
    {
        public string name { get; set; }
        public string id { get; set; }
        public int[] grades { get; set; }

        public Student(string id, string name, int[] grade)
        {
            this.name=name;
            this.id=id;
            this.grades=grade;
        }

        public double Ave()
        {
            return (double)grades.Sum()/grades.Length;
        }

        public override string ToString()
        {
            return $"ID: {id} || Name: {name} || Grades: {String.Join(" ", grades)} || Average {Ave():F2}%";
        }
    }
}