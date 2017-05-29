namespace VinculacionBackend.Services
{
    public class StudentReportModel
    {
        public string [] StudentNumber;
        public int FirstPeriod ;
        public int SecondPeriod ;
        public int FourthPeriod ;
        public int FifthPeriod ;
    }
    public class StudentsServices : IStudentsServices
    {


        public void AddMany(StudentAddManyEntryModel entries)
        {
            entries.Select( new User
            {
                Name = entry.Name,
                AccountId = entry.AccountId
            }).ToList().Forach(add);
        }

    
    }
}