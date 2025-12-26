using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{

    public enum EducationStage { elementary, secondary, higher }

    public class Student : IComparable<Student>
    {
        private static int charCounter = 0;
        public string FIO;
        public int grade;
        public double performance;
        public EducationStage stage;

        public Student()
        {
            this.FIO = ((char)('A' + charCounter)).ToString();
            charCounter++;
            Random rnd = new Random();
            this.grade = rnd.Next(1, 12);
            this.performance = Math.Round(rnd.NextDouble() * 5, 1);
            SetStage();
        }

        public Student(string fio, int grade, double performance)
        {
            this.FIO = fio;
            this.grade = grade;
            this.performance = performance;
            SetStage();
        }

        private void SetStage()
        {
            if (grade <= 4) stage = EducationStage.elementary;
            else if (grade <= 8) stage = EducationStage.secondary;
            else stage = EducationStage.higher;
        }

        public void Pass()
        {
            grade++;
            SetStage();
        }

        public int CompareTo(Student other)
        {
            if (this.stage != other.stage)
                return this.stage.CompareTo(other.stage);
            if (this.grade != other.grade)
                return this.grade.CompareTo(other.grade);
            return this.FIO.CompareTo(other.FIO);
        }

        public override string ToString()
        {
            string s = "";
            if (stage == EducationStage.elementary) s = "младшая школа";
            if (stage == EducationStage.secondary) s = "средняя школа";
            if (stage == EducationStage.higher) s = "старшая школа";
            return FIO + ", " + s + ", " + grade + " класс, " + performance + " балла";
        }
    }
    public class School
    {
        public string Name;
        public List<Student> listStudents = new List<Student>();

        public School(string name)
        {
            this.Name = name;
        }

        public void Add(Student stud)
        {
            listStudents.Add(stud);
        }

        public void Sort()
        {
            listStudents.Sort();
        }

        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < listStudents.Count; i++)
            {
                result += (i + 1) + ". " + listStudents[i].ToString() + "\n";
            }
            return result;
        }
    }
    class Program
    {
        static void Main()
        {
            Student studA = new Student();
            Student studB = new Student();
            Student studBagaev = new Student("Багаев Аслан", 4, 4);
            Student studAbaev = new Student("Абаев Георгий", 4, 3.4);
            Student studAtaev = new Student("Атаев Сослан", 4, 3);

            School school = new School("ФизМат");
            school.Add(studB);
            school.Add(studBagaev);
            school.Add(studAbaev);
            school.Add(studA);
            school.Add(studAtaev);

            Console.WriteLine(school);
            school.Sort();
            Console.WriteLine(school);
        }
    }

}
