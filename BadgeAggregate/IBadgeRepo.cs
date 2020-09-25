using System;
using System.Collections.Generic;
using Abc.HabitTracker.Api.BadgeAggregate;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IBadgeRepo
    {
        IEnumerable<BadgeUse> GetAllBadges(Guid userID);
        IEnumerable<Badge> ListBadge();
        void BadgeAssignment(Guid userId, Guid habitId, int streak);
        List<Guid> listOfUserBadge(Guid userId);
    } 
}