using ConsumeApi.Client;
using ConsumeApi.Models;
namespace ConsumeApi.Bussines
{
    public class BL
    {
        CL obj = new CL();

        public List<Employee> GetAllEmployees()
        {
            return obj.GAE();
        }

        public bool AddEmployee(Employee emp)
        {
            return (obj.AE(emp));
        }

        public Employee GetEmployee(int id)
        {
            return (obj.GE(id));
        }

        public bool UpdateEmployee(int id, Employee emp)
        {
            return (obj.UE(id, emp));
        }

        public bool DeleteEmployee(int id)
        {
            return (obj.DE(id));
        }
    }
}
