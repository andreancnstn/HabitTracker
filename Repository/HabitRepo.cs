using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Abc.HabitTracker.Api.BadgeAggregate;
using Abc.HabitTracker.Api.Data;
using Abc.HabitTracker.Api.Factory;
using Abc.HabitTracker.Api.HabitAggregate;

namespace Abc.HabitTracker.Api.Repository
{
    public class HabitRepo : IHabitRepo
    {
        private readonly IBadgeRepo _badgerepo;
        private readonly Context _context;
        private readonly ILogRepo _logrepo;

        public HabitRepo(Context context, IBadgeRepo badgeRepo, ILogRepo logRepo)
        {
            _badgerepo = badgeRepo;
            _context = context;
            _logrepo = logRepo;
        }

        public void addNewHabit(string name, Guid userID, string[] days)
        {
            if (name == null){
                throw new ArgumentException("name cannot be empty");
            }

            Habit h = HabitFactory.addNewHabit(userID, name);
            _context.Habits.Add(h);

            DaysOffValue dv = HabitFactory.value(days);

            if(!days.Equals(null))
            {
                DaysOff d = HabitFactory.AssignDaysOff(h.ID, dv.value);
                _context.daysOffs.Add(d);
            }
        }

        public void addStreakandLog(Guid habitId, Guid userId)
        {
            var habit = GetSpecificHabitByIdAndUserId(habitId, userId);
            var logcheck = _logrepo.searchLog(habitId);
            int checkTime;

            if (logcheck == null) {
                checkTime = -1;
            }
            else{
                var logtime = _logrepo.lastLog(habitId);
                checkTime = _logrepo.checkLogDay(logtime);
            }

            if(checkTime == 1)
            {
                //first add log count 
                habit.LogCount += 1;

                //check if streak reset or below, so longestStreak didnt get reset
                if (habit.CurrentStreak == 0){
                    habit.LongestStreak = habit.LongestStreak;
                }
                else if (habit.LongestStreak > habit.CurrentStreak){
                    habit.LongestStreak = habit.LongestStreak;
                }

                //after checking, adding current streak
                habit.CurrentStreak += 1;

                //checking if streak is surpass longestStreak, make it right again
                if (habit.LongestStreak < habit.CurrentStreak) {
                    habit.LongestStreak = habit.CurrentStreak;
                }
            }
            else if (checkTime == 0)    //didnt add log count since it is on the same day
            {
                habit.LogCount = habit.LogCount;
                habit.CurrentStreak = habit.CurrentStreak;
                habit.LongestStreak = habit.LongestStreak;
            }
            else if (checkTime > 1)     //skip 1 or more days
            {
                var daysoff = GetHabitDaysOff(habitId);
                var x = new { daysoff.daysoff };
                string[] strArrayOne = new string[] {""};
                strArrayOne = x.daysoff.Split(", ");
                List<int> day = new List<int>();

                foreach( var y in strArrayOne)
                {
                    if(y.Equals("Mon")) day.Add(1);
                    else if(y.Equals("Tue")) day.Add(2);
                    else if(y.Equals("Wed")) day.Add(3);
                    else if(y.Equals("Thu")) day.Add(4);
                    else if(y.Equals("Fri")) day.Add(5);
                    else if(y.Equals("Sat")) day.Add(6);
                    else if(y.Equals("Sun")) day.Add(7);
                }

                var logtime = _logrepo.lastLog(habitId);
                checkTime = _logrepo.checkLogDay(logtime);

                if(logtime == DateTime.MinValue)
                {
                    habit.LogCount += 1;
                    habit.CurrentStreak += 1;
                    habit.LongestStreak = habit.CurrentStreak;
                }
                else if(checkTime == 2)
                {
                    for (int i = 0; i < strArrayOne.Count(); i++){
                        if((int)logtime.DayOfWeek == day[i]) {
                            habit.LogCount += 1;
                            habit.CurrentStreak += 1;
                            habit.LongestStreak = habit.CurrentStreak;
                            break;
                        }
                    }
                }
                else
                {
                    habit.LogCount += 1;
                    habit.CurrentStreak = 0;
                    habit.LongestStreak = habit.LongestStreak;
                }
    
            }
            else {
                habit.LogCount += 1;
                habit.CurrentStreak += 1;
                habit.LongestStreak = habit.CurrentStreak;
            }

            if (habit.CurrentStreak == 4 || habit.CurrentStreak == 10)
            {
                _badgerepo.BadgeAssignment(userId, habitId, habit.CurrentStreak);
            }
            else
            {
                List<Guid> userBadge = _badgerepo.listOfUserBadge(userId);
                var badge = _badgerepo.ListBadge();

                var WorkaholicBadgeId = Guid.Parse("C300B347-299B-4965-9BCE-615B7F74C7AD");

                if(!userBadge.Contains(WorkaholicBadgeId))
                {
                    var daysoff = GetHabitDaysOff(habitId);
                    var x = new { daysoff.daysoff }; 
                    List<DateTime> log = _logrepo.searchLog(habitId);
                    int temp = 0;
                    string[] strArrayOne = new string[] {""};
                    strArrayOne = x.daysoff.Split(", ");
                    List<int> day = new List<int>();
                    List<int> logDay = new List<int>();

                    foreach( var z in log ) {
                        logDay.Add((int)z.DayOfWeek);
                    }

                    foreach( var y in strArrayOne)
                    {
                        if(y.Equals("Mon")) day.Add(1);
                        else if(y.Equals("Tue")) day.Add(2);
                        else if(y.Equals("Wed")) day.Add(3);
                        else if(y.Equals("Thu")) day.Add(4);
                        else if(y.Equals("Fri")) day.Add(5);
                        else if(y.Equals("Sat")) day.Add(6);
                        else if(y.Equals("Sun")) day.Add(7);
                    }

                    for(int i = 0; i<logDay.Count(); i++) {
                        for(int j = 0; j < day.Count; j++) {
                            if(logDay[i] == day[j]) temp++;
                            if(temp == 10) {
                                BadgeUse bu = BadgeUseFactory.addNewBagdeUse(WorkaholicBadgeId, userId);
                                _context.BadgeUses.Add(bu);
                                break;
                            }
                        }
                    }
               }
            }
        }

        public void DeleteHabit(Guid habitId, Guid userID)
        {
            var habit = GetSpecificHabitByIdAndUserId(habitId, userID);
            _context.Habits.Remove(habit);
        }

        public IEnumerable<Habit> GetAllHabitByUserId(Guid userId)
        {
            var habits = _context.Habits.Where(u => u.UserID == userId);
            return habits;
        }

        public DaysOff GetHabitDaysOff (Guid habitId)
        {
            return _context.daysOffs.Where(h => h.HabitID == habitId).FirstOrDefault();
        }

        public Habit GetSpecificHabitByIdAndUserId(Guid habitId, Guid UserId)
        {
            return _context.Habits.FirstOrDefault(x => x.ID == habitId && x.UserID == UserId);
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateHabit(Guid habitId, Guid userID, string newName, string[] days)
        {
            var habit = GetSpecificHabitByIdAndUserId(habitId, userID);
            var daysoff = GetHabitDaysOff(habitId);

            DaysOffValue dv = HabitFactory.value(days);
            habit.Name = newName;
            daysoff.daysoff = dv.value;
        }
    }
}