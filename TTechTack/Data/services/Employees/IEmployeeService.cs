namespace TTechTack.Data.services.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();

        Task<Employee> Add(Employee employee);
        Task<Employee> GetById(int id);
        Employee Update(Employee employee);

        Employee Delete(Employee employee);
    }
}
