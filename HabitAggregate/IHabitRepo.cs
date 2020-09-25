using System;
using System.Collections.Generic;
using Abc.HabitTracker.Api.HabitAggregate;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IHabitRepo
    {
        bool saveChanges();
        IEnumerable<Habit> GetAllHabitByUserId(Guid userId);
        Habit GetSpecificHabitByIdAndUserId(Guid habitId, Guid UserId);
        DaysOff GetHabitDaysOff(Guid habitId);
        void addNewHabit(string name, Guid userID, string[] days);
        void UpdateHabit(Guid habitId, Guid userID, string newName, string[] days);
        void DeleteHabit(Guid habitId, Guid userID);
        void addStreakandLog(Guid habitId, Guid userId);
    }
}