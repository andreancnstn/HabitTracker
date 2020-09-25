using System;
using System.Collections.Generic;
using System.Linq;
using Abc.HabitTracker.Api.BadgeAggregate;
using Abc.HabitTracker.Api.Data;
using Abc.HabitTracker.Api.Factory;
using Abc.HabitTracker.Api.HabitAggregate;

namespace Abc.HabitTracker.Api.Repository
{
    public class LogRepo : ILogRepo
    {
        private readonly Context _context;

        public LogRepo(Context context)
        {
            _context = context;
        }

        public void addLog(Guid habitId, Guid userId)
        {
            Log l = LogFactory.addLog(habitId);
            _context.Logs.Add(l);
        }

        public int checkLogDay(DateTime x)
        {
            var hasil = (DateTime.Now.Date - x.Date).Days;
            return hasil;
        }

        public bool saveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public List<DateTime> searchLog(Guid habitId)
        {
            var x = _context.Logs.Where(x => x.HabitId == habitId);
            var y = from i in x
                    orderby i.DateLog descending
                    select new {
                        i.DateLog
                    };

            List<DateTime> log = new List<DateTime>();
            foreach( var i in y ){
                log.Add(i.DateLog);
            }   

            return log;      
        }

        public DateTime lastLog(Guid habitId)
        {
            var day = searchLog(habitId).FirstOrDefault();
            
            return day;
        }

        public bool countLogGap(Guid habitid)
        {
            List<DateTime> log = searchLog(habitid);
            int temp = 0;
            
            for (int i = 0; i < log.Count; i++)
            {
                temp = (log[i].Date - log[i+1].Date).Days;
                if (temp == 10) 
                {
                    return true;
                }
            }
            return false;
        }
    }
} 
