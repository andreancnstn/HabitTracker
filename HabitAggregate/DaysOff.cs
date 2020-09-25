using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api.HabitAggregate
{   
    public class DaysOff 
    {
        public DaysOff(Guid daysOffID, string daysoff, Guid habitID)
        {
            DaysOffID = daysOffID;
            this.daysoff = daysoff;
            HabitID = habitID;
        }

        [Key]
        public Guid DaysOffID { get; set; }

        [Required]
        public String daysoff { get; set; }

        public Guid HabitID { get; set; }
        [ForeignKey("HabitID")][Required]
        public virtual Habit Habit { get; set; }
    }
}