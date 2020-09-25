using System;
using Abc.HabitTracker.Api.BadgeAggregate;

namespace Abc.HabitTracker.Api
{
    public class BadgeUseFactory
    {
        
        public static BadgeUse addNewBagdeUse (Guid badgeID, Guid userID)
        {
            return new BadgeUse(badgeID, userID, DateTime.Now);
        }
    }
}