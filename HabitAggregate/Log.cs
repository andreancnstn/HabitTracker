using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api.HabitAggregate
{
    public class Log 
    {
        public Log(Guid logId, DateTime dateLog, Guid habitId)
        {
            LogId = logId;
            DateLog = dateLog;
            HabitId = habitId;
        }

        [Key]
        public Guid LogId { get; set; }
        
        public DateTime DateLog { get; set; }

        [Required]
        [ForeignKey("HabitId")]
        public Habit Habit { get; set; }
        public Guid HabitId { get; set; }
    }
}