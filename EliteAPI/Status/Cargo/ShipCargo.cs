﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Somfic.Logging;

namespace EliteAPI.Status.Cargo
{
    public class ShipCargo
    {
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; internal set; }
        
        [JsonProperty("event")]
        public string Event { get; internal set; }
        
        [JsonProperty("Vessel")]
        public string Vessel { get; internal set; }
        
        [JsonProperty("Count")]
        public long Count { get; internal set; }
        
        [JsonProperty("Inventory")]
        public List<Item> Inventory { get; internal set; }
        
        public static ShipCargo Process(string json) => JsonConvert.DeserializeObject<ShipCargo>(json, JsonConverter.Settings);

        public static ShipCargo FromFile(FileInfo file, EliteDangerousAPI api)
        {
            if (!File.Exists(file.FullName))
            {
                Logger.Log(Severity.Error, "Could not find Cargo.json.", new FileNotFoundException("Cargo.json could not be found.", file.FullName)); 
                return new ShipCargo();
            }

            var json = FileReader.ReadAllText(file.FullName);

            try
            {
                return Process(json);
            }
            catch (Exception ex)
            {
                Logger.Log(Severity.Warning, "Could not update Cargo.json.", ex);
            }

            return new ShipCargo();
        }
    }

}