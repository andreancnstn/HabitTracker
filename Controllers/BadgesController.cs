using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.HabitTracker.Api.BadgeAggregate;
using Abc.HabitTracker.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Abc.HabitTracker.Api.Controllers
{
  [ApiController]
  public class BadgesController : ControllerBase
  {
        private readonly IBadgeRepo _badgerepo;
        private readonly ILogger<BadgesController> _logger;

        public BadgesController(ILogger<BadgesController> logger, IBadgeRepo badgerepo)
        {
            _badgerepo = badgerepo;
            _logger = logger;
        }

    [HttpGet("api/v1/users/{userID}/badges")]
    public ActionResult<IEnumerable<Badge>> All(Guid userID)
    {
        var listOfUserBadge = _badgerepo.GetAllBadges(userID);
        
        if (listOfUserBadge == null) return NotFound("No badge found for this user");

        var badges = _badgerepo.ListBadge();

        var hasil = from l in listOfUserBadge
                    join b in badges on l.BadgeID equals b.ID
                    where l.BadgeID == b.ID 
                    select new
                    {
                      b.Name,
                      b.Description,
                      l.CreatedAt
                    };

        return Ok(hasil); 
    }
  }
}
