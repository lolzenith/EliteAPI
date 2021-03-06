namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class ChangeCrewRoleInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Role")]
        public string Role { get; internal set; }
    }
    public partial class ChangeCrewRoleInfo
    {
        internal static ChangeCrewRoleInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeChangeCrewRoleEvent(JsonConvert.DeserializeObject<ChangeCrewRoleInfo>(json, EliteAPI.Events.ChangeCrewRoleConverter.Settings));
    }
    
    internal static class ChangeCrewRoleConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MissingMemberHandling = MissingMemberHandling.Ignore, MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
