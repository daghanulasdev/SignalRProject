using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.SocialMediaDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService socialMediaService, IMapper mapper)
        {
            _socialMediaService = socialMediaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _mapper.Map<List<ResultSocialMediaDto>>(_socialMediaService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDto createSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(createSocialMediaDto);
            _socialMediaService.TAdd(values);
            return Ok("Hakkımda eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetById(id);
            _socialMediaService.TDelete(values);
            return Ok("Hakkımda alanı silindi");
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDto updateSocialMediaDto)
        {
            var values = _mapper.Map<SocialMedia>(updateSocialMediaDto);
            _socialMediaService.TUpdate(values);
            return Ok("Hakkımda alanı güncellendi");
        }
        [HttpGet("GetSocialMedia")]
        public IActionResult GetSocialMedia(int id)
        {
            var values = _mapper.Map<GetSocialMediaDto>(_socialMediaService.TGetById(id));
            return Ok(values);
        }
    }
}
