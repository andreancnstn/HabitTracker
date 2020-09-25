using System;
using Abc.HabitTracker.Api.HabitAggregate;

namespace Abc.HabitTracker.Api.Factory
{
    public class LogFactory
    {
        public static Log addLog(Guid habitId)
        {
            return new Log(Guid.NewGuid(), DateTime.Now, habitId);
        }
    }
}