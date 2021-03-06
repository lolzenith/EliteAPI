namespace EliteAPI.Events
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class PromotionInfo : IEvent
    {
        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; internal set; }
        [JsonProperty("event")]
        public string Event { get; internal set; }
        [JsonProperty("Federation")]
        public long Federation { get; internal set; }
    }
    public partial class PromotionInfo
    {
        internal static PromotionInfo Process(string json, EliteDangerousAPI api) => api.Events.InvokePromotionEvent(JsonConvert.DeserializeObject<PromotionInfo>(json, EliteAPI.Events.PromotionConverter.Settings));
    }
    
    internal static class PromotionConverter
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
