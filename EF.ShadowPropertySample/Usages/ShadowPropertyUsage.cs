using EF.ShadowPropertySample.Dal;
using EF.ShadowPropertySample.Models;
using static Microsoft.EntityFrameworkCore.EF;

namespace EF.ShadowPropertySample.Usages
{
    internal class ShadowPropertyUsage
    {
        private readonly ShadowPropertyContext _context;

        public ShadowPropertyUsage(ShadowPropertyContext context)
        {
            _context = context;
        }

        public Person GetLatestPerson()
        {
            //Shadow properties can be referenced in LINQ queries via the EF.Property static method:
            return _context.People.OrderBy(contact => Property<DateTime>(contact, "CreatedDateTime")).FirstOrDefault();
        }
    }
}
