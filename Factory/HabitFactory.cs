using System;
using Abc.HabitTracker.Api.HabitAggregate;

namespace Abc.HabitTracker.Api.Factory
{
    public class HabitFactory
    {
        public static Habit addNewHabit(Guid user_id, string habitName)
        {
            return new Habit(Guid.NewGuid(), habitName, 0, 0, 0, user_id, DateTime.Now);
        }

        public static DaysOff AssignDaysOff(Guid habitid, string days)
        {
            return new DaysOff(Guid.NewGuid(), days, habitid);
        }

        public static DaysOffValue value(string[] value)
        {
            return new DaysOffValue(value);
        }
    }
}