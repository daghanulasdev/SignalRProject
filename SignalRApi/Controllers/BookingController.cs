using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IMapper _mapper;

        public BookingController(IBookingService bookingService, IMapper mapper)
        {
            _bookingService = bookingService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _mapper.Map<List<ResultBookingDto>>(_bookingService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBooking(CreateBookingDto createBookingDto)
        {
            var values = _mapper.Map<Booking>(createBookingDto);
            _bookingService.TAdd(values);
            return Ok("Hakkımda eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteBooking(int id)
        {
            var values = _bookingService.TGetById(id);
            _bookingService.TDelete(values);
            return Ok("Hakkımda alanı silindi");
        }

        [HttpPut]
        public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            var values = _mapper.Map<Booking>(updateBookingDto);
            _bookingService.TUpdate(values);
            return Ok("Hakkımda alanı güncellendi");
        }
        [HttpGet("GetBooking")]
        public IActionResult GetBooking(int id)
        {
            var values = _mapper.Map<GetBookingDto>(_bookingService.TGetById(id));
            return Ok(values);
        }
    }
}
