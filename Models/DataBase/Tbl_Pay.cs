namespace Project.Models.DataBase
{
    public class Tbl_Pay
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int Price { get; set; }
        public string PhoneNumber { get; set; }
        public string Detail { get; set; }
        public DateTime Time { get; set; }
        public bool Status { get; set; }
    }
}