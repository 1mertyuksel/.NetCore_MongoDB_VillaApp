using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.QuestDtos;
using Villa.Entity.Entities;

public class QuestionController : Controller
{
    private readonly IQuestService _questionService;
    private readonly IMapper _mapper;

    public QuestionController(IQuestService questionService, IMapper mapper)
    {
        _questionService = questionService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var values = await _questionService.TGetListAsync();
        var questionList = _mapper.Map<List<ResultQuestDto>>(values);
        return View(questionList);
    }

    public async Task<IActionResult> DeleteQuestion(ObjectId id)
    {
        await _questionService.TDeleteAsync(id);
        return RedirectToAction("Index");
    }

    public IActionResult CreateQuestion()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuestion(CreateQuestDto createQuestDto)
    {
        var newQuestion = _mapper.Map<Quest>(createQuestDto);
        await _questionService.TCreateAsync(newQuestion);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> UpdateQuestion(ObjectId id)
    {
        var value = await _questionService.TGetByIdAsync(id);
        var question = _mapper.Map<UpdateQuestDto>(value);
        return View(question);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateQuestion(UpdateQuestDto updateQuestDto)
    {
        var question = _mapper.Map<Quest>(updateQuestDto);
        await _questionService.TUpdateAsync(question);
        return RedirectToAction("Index");
    }
}
