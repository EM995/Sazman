using System.Data.Entity;

namespace Sazman.DataModels.Models
{
    internal class SazmanDbInitializer : DropCreateDatabaseAlways<SazmanContext>
    {
        protected override void Seed(SazmanContext context)
        {
            IList<PersonnelEntity> defaultPersonnel = new List<PersonnelEntity>();

            defaultPersonnel.Add(new PersonnelEntity() 
            { 
                Id = new Guid("9A1C650E-DF1F-4A5B-856D-FB963E0E9D6C"),  
                Nam = "Harry",
                NameXanevadegi = "Potter"
            });

            defaultPersonnel.Add(new PersonnelEntity()
            {
                Id = new Guid("8DDA7930-C5AE-42BF-8B4A-ECBB6726767B"),
                Nam = "Sherlock",
                NameXanevadegi = "Holmes"
            });

            defaultPersonnel.Add(new PersonnelEntity()
            {
                Id = new Guid("87520BF0-974B-44D4-8837-D7C35DB41813"),
                Nam = "Luke",
                NameXanevadegi = "Skywalker"
            });

            context.Personnels.AddRange(defaultPersonnel);

            base.Seed(context);
        }
    }
}
