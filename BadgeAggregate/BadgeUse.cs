using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Abc.HabitTracker.Api.HabitAggregate;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abc.HabitTracker.Api.BadgeAggregate
{
  public class BadgeUse
  {
    public BadgeUse(Guid badgeID, Guid userID, DateTime createdAt)
    {
      BadgeID = badgeID;
      UserID = userID;
      CreatedAt = createdAt;
    }

    [Key]
    public int BadgeUsesID { get; set; }

    [Required]
    public Guid BadgeID { get; set; }

    [Required]
    public Guid UserID { get; set; }

    [Required]
    public DateTime CreatedAt { get; set; }

    [ForeignKey("BadgeID")]
    public Badge Badge { get; set; }
  }
}
