class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set;}
    public float Grade { get; set; }
    public override string ToString()
    {
        return $"{FirstName} {LastName}: {Grade:F2}";
    }
}

internal class Program
{
    static void Main()
    {
        int studentsCount = int.Parse(Console.ReadLine());

        List<Student> students = new List<Student>();

        for (int i = 0; i < studentsCount; i++)
        {
            string[] studentsArg = Console.ReadLine()
                .Split()
                .ToArray();

            Student student = new Student();

            student.FirstName = studentsArg[0];
            student.LastName = studentsArg[1];
            student.Grade = float.Parse(studentsArg[2]);

            students.Add(student);
        }

        students = students.OrderByDescending(student => student.Grade).ToList();

        Console.WriteLine(string.Join("\n", students));
    }
}
