using System.Linq;

namespace TemplateCleanArchitecture.App
{
    public class UserPortal // Entity
    {
        public int UserId { get; set; }
        public string unit { get; set; }
        public string GashtPosti { get; set; }
    }
    public class Portal // Entity
    {
        public int Id { get; set; }
        public string GashtPosti { get; set; }
        public string Name { get; set; } = string.Empty;

        //other property from portal table ... . 
    }
    public class UserPortalReportDto
    {
        public int Id { get; set; }
        public string GashtPosti { get; set; }
        public string Name { get; set; } = string.Empty;


        //other property from portal table  which need.
    }

    public class ServiceReport
    {
        public ServiceReport()
        {
                
        }
        public List<UserPortalReportDto> GetReport(int userId)
        {
            List<UserPortal> userPortalsList = new List<UserPortal>() // get from DbSet
            {
                new UserPortal() { UserId = 1, unit = "13", GashtPosti = "1"},
                new UserPortal() { UserId = 1, unit = "13", GashtPosti = "2"},
                new UserPortal() { UserId = 1, unit = "13", GashtPosti = "3"},
                new UserPortal() { UserId = 1, unit = "13", GashtPosti = "4"},
                new UserPortal() { UserId = 2, unit = "15", GashtPosti = "8"},
                new UserPortal() { UserId = 2, unit = "15", GashtPosti = "10"},
                new UserPortal() { UserId = 2, unit = "15", GashtPosti = "13"},
                new UserPortal() { UserId = 3, unit = "123", GashtPosti = "234"},
                new UserPortal() { UserId = 3, unit = "123", GashtPosti = "235"},
            };

            List<Portal> portalsList = new List<Portal>()
        {
            new Portal() {Id = 1000, GashtPosti="1", Name = "nasser"},
            new Portal() {Id = 1001, GashtPosti="1", Name = "hassan"},
            new Portal() {Id = 1002, GashtPosti="2", Name = "hojjjat"},
            new Portal() {Id = 1003, GashtPosti="3", Name = "hossein"},
            new Portal() {Id = 1004, GashtPosti="2", Name = "hamed"},
            new Portal() {Id = 1005, GashtPosti="1", Name = "vahid"},
            new Portal() {Id = 1006, GashtPosti="3", Name = "samad"},
            new Portal() {Id = 1007, GashtPosti="4", Name = "sarmad"},

            new Portal() {Id = 1008, GashtPosti="8", Name = "seda"},
            new Portal() {Id = 1009, GashtPosti="8", Name = "sokot"},
            new Portal() {Id = 1010, GashtPosti="10", Name = "sabr"},
            new Portal() {Id = 1011, GashtPosti="10", Name = "sadr"},
            new Portal() {Id = 1012, GashtPosti="10", Name = "saf"},
            new Portal() {Id = 1013, GashtPosti="13", Name = "sabt"},


            new Portal() {Id = 1014, GashtPosti="234", Name = "alo"},
            new Portal() {Id = 1015, GashtPosti="234", Name = "zardalo"},
            new Portal() {Id = 1016, GashtPosti="234", Name = "shafalo"},
            new Portal() {Id = 1017, GashtPosti="234", Name = "albalo"},
            new Portal() {Id = 1018, GashtPosti="235", Name = "hollllo"},
            new Portal() {Id = 1019, GashtPosti="2354", Name = "shlil"},

        };

            var userPotal = userPortalsList.Where(u => u.UserId == userId).ToList();

            var result = portalsList
                .Where(w => userPotal.Select(s => s.GashtPosti).Contains(w.GashtPosti))
                .Select(s => new UserPortalReportDto { Id = s.Id, GashtPosti = s.GashtPosti, Name = s.Name })
                .ToList();

            return result;
        }
    }
}
