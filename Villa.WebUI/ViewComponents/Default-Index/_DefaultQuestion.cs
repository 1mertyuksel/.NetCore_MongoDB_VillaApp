using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Villa.Business.Abstract;
using Villa.Dto.Dtos.QuestDtos;

namespace Villa.WebUI.ViewComponents.Default_Index
{
    public class _DefaultQuestion : ViewComponent
    {
        private readonly IQuestService _questionService;
        private readonly IMapper _mapper;

        public _DefaultQuestion(IQuestService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _questionService.TGetListAsync();
            var questionList = _mapper.Map<List<ResultQuestDto>>(values);
            return View(questionList);
        }
    }
}
