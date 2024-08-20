namespace dentalApi.DTO
{
    public class CreateReservationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Service { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}
