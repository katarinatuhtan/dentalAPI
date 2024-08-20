using dentalApi.Database;
using dentalApi.Database.Entities;
using dentalApi.DTO;
using dentalApi.Service.dentalApi.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace dentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly DentalContext _context;
        private readonly DentalEmailService _emailService;


        public ReservationsController(DentalContext context, DentalEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // GET: api/<ReservationsController>
        [HttpGet]
        public List<Reservation> Get()
        {
            return _context.Reservations.ToList();
        }

        // GET api/<ReservationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ReservationsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateReservationRequest newReservation)
        {
            var reservation = new Reservation
            {
                FirstName = newReservation.FirstName,
                LastName = newReservation.LastName,
                Email = newReservation.Email,
                Phone = newReservation.Phone,
                Service = newReservation.Service,
                Date = newReservation.Date,
                Note = newReservation.Note
            };

            _context.Reservations.Add(reservation);
            _context.SaveChanges();

            var emailBody = $"<h3>Potvrdite termin za:</h3>" +
                            $"<p>Ime: {reservation.FirstName}</p>" +
                            $"<p>Prezime: {reservation.LastName}</p>" +
                            $"<p>Email: {reservation.Email}</p>" +
                            $"<p>Telefon: {reservation.Phone}</p>" +
                            $"<p>Usluga: {reservation.Service}</p>" +
                            $"<p>Datum: {reservation.Date.ToLocalTime()} (GMT+2)</p>" +
                            $"<p>Napomena: {reservation.Note}</p>";

            await _emailService.SendEmailAsync("katarina.tuhtan@gmail.com", "Novi termin za pregled", emailBody);

            return Ok(reservation);
        }
    

    // PUT api/<ReservationsController>/5
    [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReservationsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
