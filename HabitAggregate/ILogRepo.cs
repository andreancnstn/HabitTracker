using System;
using System.Collections.Generic;
using Abc.HabitTracker.Api.HabitAggregate;

namespace Abc.HabitTracker.Api.Repository
{
    public interface ILogRepo
    {
        void addLog(Guid habitId, Guid userId);
        List<DateTime> searchLog(Guid habitId);
        bool saveChanges();
        int checkLogDay(DateTime x);
        DateTime lastLog(Guid habitId);
        bool countLogGap(Guid habitid);
    } 
}