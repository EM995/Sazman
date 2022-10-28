using Sazman.DataModels.Models;

namespace Sazman.API.Dao
{
    public interface IPersonnelDao
    {
        IEnumerable<PersonnelEntity> GetAllPersonnel();
        PersonnelEntity GetPersonnelById(Guid id);
        void CreatePersonnel(PersonnelEntity personnel);
        void UpdatePersonnel(PersonnelEntity personnel);
        void DeletePersonnel(PersonnelEntity personnel);
    }
}
