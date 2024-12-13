using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Villa.Business.Abstract;
using Villa.Business.Validators;
using Villa.Dto.Dtos.SubHeaderDtos;
using Villa.Entity.Entities;

public class SubHeaderController : Controller
{
    private readonly ISubHeaderService _subHeaderService;
    private readonly IMapper _mapper;

    public SubHeaderController(ISubHeaderService subHeaderService, IMapper mapper)
    {
        _subHeaderService = subHeaderService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _subHeaderService.TGetListAsync();
        var subHeaderList = _mapper.Map<List<ResultSubHeaderDto>>(values);
        return View(subHeaderList);
    }

    public async Task<IActionResult> DeleteSubHeader(ObjectId id)
    {
        await _subHeaderService.TDeleteAsync(id);
        return RedirectToAction("Index");
    }

    public IActionResult CreateSubHeader()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubHeader(CreateSubHeaderDto createSubHeaderDto)
    {
        if (!ModelState.IsValid)
        {
            return View(createSubHeaderDto);
        }
        var newSubHeader = _mapper.Map<SubHeader>(createSubHeaderDto);
        var validator = new SubHeaderValidator();
        var result = validator.Validate(newSubHeader);
        if (!result.IsValid)
        {
            result.Errors.ForEach(x =>
            {
                ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
            });
            return View();
        }
        await _subHeaderService.TCreateAsync(newSubHeader);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> UpdateSubHeader(ObjectId id)
    {
        var value = await _subHeaderService.TGetByIdAsync(id);
        if (value == null)
        {
            return NotFound();
        }
        var subHeader = _mapper.Map<UpdateSubHeaderDto>(value);
        return View(subHeader);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateSubHeader(UpdateSubHeaderDto updateSubHeaderDto)
    {
        if (!ModelState.IsValid)
        {
            return View(updateSubHeaderDto);
        }
        var subHeader = _mapper.Map<SubHeader>(updateSubHeaderDto);
        await _subHeaderService.TUpdateAsync(subHeader);
        return RedirectToAction("Index");
    }
}
