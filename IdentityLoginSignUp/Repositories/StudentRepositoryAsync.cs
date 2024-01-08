using IdentityLoginSignUp.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using IdentityLoginSignUp.Interfaces;

namespace IdentityLoginSignUp.Repositories
{
    public class StudentRepositoryAsync : GenericRepositoryAsync<Student>, IStudentRepositoryAsync
    {
        private readonly DbSet<Student> _customer;
        public StudentRepositoryAsync(ApplicationDBContext dbContext) : base(dbContext)
        {
            _customer = dbContext.Set<Student>();
        }
    }
}