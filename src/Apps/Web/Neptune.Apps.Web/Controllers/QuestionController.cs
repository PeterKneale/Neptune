using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Neptune.Apps.Web.Models;
using Neptune.Services.Common.Bus;
using Neptune.Services.Profiles.Messages;
using Neptune.Services.Questions.Messages;

namespace Neptune.Apps.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQueryDispatcher _queries;

        public QuestionController(IQueryDispatcher queries)
        {
            _queries = queries;
        }

        public async Task<IActionResult> Index(Guid id)
        {
            var questionResponse = await _queries.Request<GetQuestionRequest, GetQuestionResponse>(new GetQuestionRequest { Id = id });
            var question = questionResponse.Question;

            if (question == null)
            {
                return NotFound();
            }

            var page = new QuestionPageViewModel
            {
                Question = Mapper.Map<QuestionDto, QuestionViewModel>(question)
            };

            var profileResponse = await _queries.Request<GetProfileRequest, GetProfileResponse>(new GetProfileRequest { Id = question.CreatedById });
            if(profileResponse.Profile != null)
            {
                page.UserAsking = Mapper.Map<ProfileDto, UserViewModel>(profileResponse.Profile);
            }
            return View(page);
        }
    }
}
