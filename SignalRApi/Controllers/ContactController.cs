using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _mapper.Map<List<ResultContactDto>>(_contactService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDto createContactDto)
        {
            var values = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(values);
            return Ok("Hakkımda eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetById(id);
            _contactService.TDelete(values);
            return Ok("Hakkımda alanı silindi");
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDto updateContactDto)
        {
            var values = _mapper.Map<Contact>(updateContactDto);
            _contactService.TUpdate(values);
            return Ok("Hakkımda alanı güncellendi");
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var values = _mapper.Map<GetContactDto>(_contactService.TGetById(id));
            return Ok(values);
        }
    }
}
