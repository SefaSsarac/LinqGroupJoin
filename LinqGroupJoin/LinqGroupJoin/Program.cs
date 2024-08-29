using LinqGroupJoin;

class Program
{
    static void Main()
    {
        // List of students
        List<Student> students = new List<Student>
        {
            new Student { StudentId = 1, StudentName = "Ali", ClassId = 1 },
            new Student { StudentId = 2, StudentName = "Ayşe", ClassId = 2 },
            new Student { StudentId = 3, StudentName = "Mehmet", ClassId = 1 },
            new Student { StudentId = 4, StudentName = "Fatma", ClassId = 3 },
            new Student { StudentId = 5, StudentName = "Ahmet", ClassId = 2 }
        };

        // List of classes
        List<Class> classes = new List<Class>
        {
            new Class { ClassId = 1, ClassName = "Matematik" },
            new Class { ClassId = 2, ClassName = "Türkçe" },
            new Class { ClassId = 3, ClassName = "Kimya" }
        };

        // LINQ Group Join to list students under their respective classes
        var groupJoinResult = from cls in classes
                              join stu in students
                              on cls.ClassId equals stu.ClassId into studentGroup
                              select new
                              {
                                  ClassName = cls.ClassName,
                                  Students = studentGroup
                              };

        // Display the result
        foreach (var cls in groupJoinResult)
        {
            Console.WriteLine($"Class: {cls.ClassName}");
            foreach (var student in cls.Students)
            {
                Console.WriteLine($" - {student.StudentName}");
            }
        }
    }
}