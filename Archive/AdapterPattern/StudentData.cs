namespace AdapterPattern
{
    public class StudentData
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentCode { get; set; } // 6-number unique code with programme code: 006116IABB
        public string ProgrammeCode { get; set; }
        public string ProgrammeName { get; set; }
        public string Faculty { get; set; }
    }
}