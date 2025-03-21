using Pratik_DependencyInjection.Service;

namespace Pratik_DependencyInjection.Manager
{
    public class Teacher : ITeacher
    {
        public string firstName { get; set; }
        public string lastName { get; set; }

        public string GetInfo(string firstName, string lastName)
        {
            return "Teacher Name: " + firstName + " " + lastName;
        }
    }
}
