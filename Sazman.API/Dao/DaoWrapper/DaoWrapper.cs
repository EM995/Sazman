using Sazman.DataModels.Models;

namespace Sazman.API.Dao
{
    public class DaoWrapper : IDaoWrapper
    {
        private readonly SazmanContext _context;
        private IPersonnelDao _personnelDao;

        public IPersonnelDao PersonnelDao
        {
            get
            {
                _personnelDao ??= new PersonnelDao(_context);
                return _personnelDao;
            }
        }

        public DaoWrapper(SazmanContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
