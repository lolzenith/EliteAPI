namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class WingAddInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Name")]
        public string Name { get; internal set; }
    }
    public partial class WingAddInfo
    {
        internal static WingAddInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeWingAddEvent(JsonConvert.DeserializeObject<WingAddInfo>(json, EliteAPI.Events.WingAddConverter.Settings));
    }
    
    internal static class WingAddConverter
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
