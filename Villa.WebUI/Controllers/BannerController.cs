using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.BannerDtos;
using Villa.Entity.Entities;

namespace Villa.WebUI.Controllers
{
    public class BannerController : Controller
    {

        private readonly IBannerService _bannerService;
        private readonly IMapper  _mapper ;
        public BannerController(IBannerService bannerService , IMapper mapper)
        {
            _bannerService = bannerService;
            _mapper = mapper;
            
        }

        public async Task<IActionResult> Index()
        {
            var values = await _bannerService.TGetListAsync();
            var bannerList = _mapper.Map<List<ResultBannerDto>>(values);
            return View(bannerList);
        }
    }
}
