namespace Telefon_Rehberi.WebApp.Models.ServiceModel
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public int PersonUUID { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
    }
}
