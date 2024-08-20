using System.ComponentModel.DataAnnotations;

namespace dentalApi.Database.Entities
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get;  set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Service {  get; set; }
        public DateTime Date {  get; set; }
        public string? Note { get; set; }

    }
}
