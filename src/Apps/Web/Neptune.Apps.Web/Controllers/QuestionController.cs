using System;
using System.Linq;
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

            
            var profileResponse = await _queries.Request<GetProfileRequest, GetProfileResponse>(new GetProfileRequest { Id = question.CreatedById });
            var profile = profileResponse.Profile;

            var page = new QuestionPageViewModel
            {
                Question = new QuestionViewModel
                {
                    Id = question.Id,
                    Title = question.Title
                },
                UserAsking = new UserViewModel
                {
                    Id = profile.Id,
                    Name = profile.Name,
                    TotalGoldBadges = profile.Badges.Count(x => x.Badge.Rank == BadgeRank.Gold),
                    TotalSilverBadges = profile.Badges.Count(x => x.Badge.Rank == BadgeRank.Silver),
                    TotalBronzeBadges = profile.Badges.Count(x => x.Badge.Rank == BadgeRank.Bronze)
                }
            };

            return View(page);
        }
    }
}
