namespace TTechTack.Data.services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDBContext _context;

        public EmployeeService(ApplicationDBContext context)
        {
            _context = context;
        }

       
        public async Task<Employee> Add(Employee employee)
        {
         await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public  Employee Delete(Employee employee)
        {
             _context.Remove(employee);
             _context.SaveChanges();
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            var res = await _context.Employees.ToListAsync();
            return res;
        }

        public async Task<Employee> GetById(int id)
        {
            var res = await _context.Employees.FindAsync(id);
            return res;
        }

        public Employee Update(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();
            return employee;
        }
    }
}
