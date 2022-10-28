using Sazman.DataModels.Models;

namespace Sazman.API.Dao
{
    public class PersonnelDao : BaseDao<PersonnelEntity>, IPersonnelDao
    {
        public PersonnelDao(SazmanContext context)
            : base(context)
        {
        }

        public IEnumerable<PersonnelEntity> GetAllPersonnel() =>
            FindAll()
            .ToList();

        public PersonnelEntity GetPersonnelById(Guid id) =>
            FindByCondition(p => p.Id.Equals(id))
            .FirstOrDefault();

        public void CreatePersonnel(PersonnelEntity personnel) =>
            Create(personnel);

        public void UpdatePersonnel(PersonnelEntity personnel) =>
            Update(personnel.Id, personnel);

        public void DeletePersonnel(PersonnelEntity personnel) =>
            Delete(personnel);
    }
}
