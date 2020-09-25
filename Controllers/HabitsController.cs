using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abc.HabitTracker.Api.HabitAggregate;
using Abc.HabitTracker.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Abc.HabitTracker.Api.Controllers
{
  [ApiController]
  public class HabitsController : ControllerBase
  {
    private readonly ILogger<HabitsController> _logger;
    private readonly IBadgeRepo _badgerepo;
    private readonly ILogRepo _logrepo;
    private readonly IHabitRepo _habitrepo;

    public HabitsController(ILogger<HabitsController> logger, IHabitRepo habitRepo, IBadgeRepo badgeRepo,
        ILogRepo logRepo)
        {
        _habitrepo = habitRepo;
        _logger = logger;
        _badgerepo = badgeRepo;
        _logrepo = logRepo;
    }

    [HttpGet("api/v1/users/{userID}/habits")]
    public ActionResult<IEnumerable<Habit>> All(Guid userID)
    {
        var habits = _habitrepo.GetAllHabitByUserId(userID);
        
        if(habits != null) 
        {
            //get all Habit ID
            var habitid = from h in habits
                    where habits != null
                    select new
                    {
                        h.ID
                    };

            List<DaysOff> list = new List<DaysOff>();

            //input all day off from one habit ID to a list
            foreach(var x in habitid)
            {
                list.Add(_habitrepo.GetHabitDaysOff(x.ID));
            }

            //change the list into IEnumerable
            IEnumerable<DaysOff> day = list;

            //choose data to show
            var hasil = from h in habits
                join l in day on h.ID equals l.HabitID
                where h.ID == l.HabitID
                select new
                {
                    Habit_Name = h.Name,
                    Habit_Days_off = l.daysoff,
                    h.LogCount,
                    h.CurrentStreak,
                    h.LongestStreak,
                    CreatedAt = h.CreatedAt.ToString("MM/dd/yyyy HH:mm:ss")
                };

            return Ok(hasil);
        }
        return NotFound("User not found");
    }

    [HttpGet("api/v1/users/{userID}/habits/{id}")]
    public ActionResult<Habit> Get(Guid userID, Guid id)
    {
        var habits = _habitrepo.GetSpecificHabitByIdAndUserId(id, userID);
        if (habits != null){
            
            //add habit into a list
            List<Habit> habit = new List<Habit>();
            habit.Add(habits);

            //add habit day off into a list
            List<DaysOff> list = new List<DaysOff>();
            list.Add(_habitrepo.GetHabitDaysOff(id));

            //adding data to a list so we can choose what data we want to show
            var hasil = from h in habit
                join l in list on h.ID equals l.HabitID
                where h.ID == l.HabitID
                select new
                {
                    Habit_Name = h.Name,
                    Habit_Days_off = l.daysoff,
                    h.LogCount,
                    h.CurrentStreak,
                    h.LongestStreak,
                    CreatedAt = h.CreatedAt.ToString("MM/dd/yyyy HH:mm:ss")
                };

            return Ok(hasil);
        }

        return NotFound("Habit or User not found");
    }

    [HttpPost("api/v1/users/{userID}/habits")]
    public ActionResult<Habit> AddNewHabit(Guid userID, [FromBody] RequestData data)
    {
        _habitrepo.addNewHabit(data.Name, userID, data.DaysOff);
        _habitrepo.saveChanges();

        return Ok("Successfully creating new habit");
    }

    [HttpPut("api/v1/users/{userID}/habits/{id}")]
    public ActionResult<Habit> UpdateHabit(Guid userID, Guid id, [FromBody] RequestData data)
    {
        var habits = _habitrepo.GetSpecificHabitByIdAndUserId(id, userID);

        if (habits == null) return NotFound();

        _habitrepo.UpdateHabit(id, userID, data.Name, data.DaysOff);
        _habitrepo.saveChanges();

           // return Ok(Get(userID, id)); // want to implement this
            List<Habit> habit = new List<Habit>();
            habit.Add(habits);

            List<DaysOff> list = new List<DaysOff>();
            list.Add(_habitrepo.GetHabitDaysOff(id));

            var hasil = from h in habit
                join l in list on h.ID equals l.HabitID
                where h.ID == l.HabitID
                select new
                {
                    Habit_Name = h.Name,
                    Habit_Days_off = l.daysoff,
                    h.LogCount,
                    h.CurrentStreak,
                    h.LongestStreak,
                    CreatedAt = h.CreatedAt.ToString("MM/dd/yyyy HH:mm:ss")
                };

        return Ok(hasil);
    }

    [HttpDelete("api/v1/users/{userID}/habits/{id}")]
    public ActionResult<Habit> DeleteHabit(Guid userID, Guid id)
    {
        var habit = _habitrepo.GetSpecificHabitByIdAndUserId(id, userID);
    
        if (habit == null) return NotFound("Habit or user not found");

        _habitrepo.DeleteHabit(id, userID);
        _habitrepo.saveChanges();

        return Ok("Habit Deleted");
    }

    [HttpPost("api/v1/users/{userID}/habits/{id}/logs")]
    public ActionResult<Habit> Log(Guid userID, Guid id)
    {
        var habit = _habitrepo.GetSpecificHabitByIdAndUserId(id, userID);
    
        if (habit == null) return NotFound("Habit or user not found");

        _logrepo.addLog(id, userID);
        _habitrepo.addStreakandLog(id, userID);
        _logrepo.saveChanges();

        return Ok("Log Added");
    }
  }
}
