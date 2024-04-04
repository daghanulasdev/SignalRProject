using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.FeatureDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _featureService;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _mapper.Map<List<ResultFeatureDto>>(_featureService.TGetListAll());
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var values = _mapper.Map<Feature>(createFeatureDto);
            _featureService.TAdd(values);
            return Ok("Hakkımda eklendi.");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var values = _featureService.TGetById(id);
            _featureService.TDelete(values);
            return Ok("Hakkımda alanı silindi");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var values = _mapper.Map<Feature>(updateFeatureDto);
            _featureService.TUpdate(values);
            return Ok("Hakkımda alanı güncellendi");
        }
        [HttpGet("GetFeature")]
        public IActionResult GetFeature(int id)
        {
            var values = _mapper.Map<GetFeatureDto>(_featureService.TGetById(id));
            return Ok(values);
        }
    }
}
