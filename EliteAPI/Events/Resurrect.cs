namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class ResurrectInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Option")]
        public string Option { get; internal set; }
        [JsonProperty("Cost")]
        public long Cost { get; internal set; }
        [JsonProperty("Bankrupt")]
        public bool Bankrupt { get; internal set; }
    }
    public partial class ResurrectInfo
    {
        internal static ResurrectInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokeResurrectEvent(JsonConvert.DeserializeObject<ResurrectInfo>(json, EliteAPI.Events.ResurrectConverter.Settings));
    }
    
    internal static class ResurrectConverter
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
