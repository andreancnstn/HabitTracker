using System;
using System.Collections.Generic;
using System.Linq;
using Abc.HabitTracker.Api.BadgeAggregate;
using Abc.HabitTracker.Api.Data;

namespace Abc.HabitTracker.Api.Repository
{
    public class BadgeRepo : IBadgeRepo
    {
        private readonly Context _context;
        private readonly ILogRepo _logrepo;

        public BadgeRepo(Context context, ILogRepo logRepo)
        {
            _context = context;
            _logrepo = logRepo;
        }
        
        public void BadgeAssignment(Guid userId, Guid habitId, int streak)
        {
            List<Guid> userBadge = listOfUserBadge(userId);
            var badge = ListBadge();
            if (streak == 4)
            {
                var DominatingBadgeId = Guid.Parse("3FDFE700-D823-49A9-97CB-14DC44B7ED76");
                if (!userBadge.Contains(DominatingBadgeId))
                {
                    BadgeUse bu = BadgeUseFactory.addNewBagdeUse(DominatingBadgeId, userId);
                    _context.BadgeUses.Add(bu);
                }
            }
            else if (streak == 10)
            {
                var EpicComebackBadgeId = Guid.Parse("9535D8EA-03EA-4B70-B7D4-0C6FC93A4710");
                
                if (_logrepo.countLogGap(habitId))
                {
                    if(!userBadge.Contains(EpicComebackBadgeId))
                    {
                        BadgeUse bu = BadgeUseFactory.addNewBagdeUse(EpicComebackBadgeId, userId);
                        _context.BadgeUses.Add(bu);
                    }
                }
            }
        }

        public IEnumerable<BadgeUse> GetAllBadges(Guid userID)
        {
            var userbadge = _context.BadgeUses.Where(x => x.UserID == userID);
            
            return userbadge;
        }

        public IEnumerable<Badge> ListBadge()
        {
            return _context.Badges.ToList();
        }

        public List<Guid> listOfUserBadge(Guid userId)
        {
            List<Guid> list = new List<Guid>();
            var Badge = _context.BadgeUses.Where(x => x.UserID == userId);
            var temp = from x in Badge
                        select new {
                            x.BadgeID
                        };
            foreach ( var x in temp)
            {
                list.Add(x.BadgeID);
            }
            return list;
        }
    }
}