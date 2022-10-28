namespace Sazman.API.Dao
{
    public interface IDaoWrapper
    {
        IPersonnelDao PersonnelDao { get; }

        void Save(); 
    }
}
