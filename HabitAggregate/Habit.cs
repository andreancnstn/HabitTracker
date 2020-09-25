using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Linq;

//template only. feel free to edit
namespace Abc.HabitTracker.Api.HabitAggregate
{
  public class RequestData
  {
    [JsonPropertyName("name")]
    public String Name { get; set; }

    [JsonPropertyName("days_off")]
    public String[] DaysOff { get; set; }
  }

  public class Habit
  {
        public Habit(Guid iD, string name, short currentStreak, 
        short longestStreak, short logCount, Guid userID, DateTime createdAt)
        {
          if (name.Length < 2 || name.Length > 100) 
            throw new Exception("Habit name must be between 2 and 100 characters");

            this.ID = iD;
            this.Name = name;
            this.CurrentStreak = currentStreak;
            this.LongestStreak = longestStreak;
            this.LogCount = logCount;
            this.UserID = userID;
            this.CreatedAt = createdAt;
        }

    [JsonPropertyName("id")]
    public Guid ID { get; set; }

    [JsonPropertyName("name")][Required]
    public String Name { get; set; }

    [JsonPropertyName("current_streak")]
    public Int16 CurrentStreak { get; set; }

    [JsonPropertyName("longest_streak")]
    public Int16 LongestStreak { get; set; }

    [JsonPropertyName("log_count")]
    public Int16 LogCount { get; set; }

    [JsonPropertyName("user_id")][Required]
    public Guid UserID { get; set; }

    [JsonPropertyName("created_at")][Required]
    public DateTime CreatedAt { get; set; }
  }
}
