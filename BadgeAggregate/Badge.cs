using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.BadgeAggregate
{
  public class Badge
  {
    [JsonPropertyName("id")]
    public Guid ID { get; set; }

    [JsonPropertyName("name")]
    public String Name { get; set; }

    [JsonPropertyName("description")]
    public String Description { get; set; }
  }
}
