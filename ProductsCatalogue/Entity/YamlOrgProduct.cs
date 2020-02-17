using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;

namespace ProductsCatalogue.Entity
{
    //class YamlOrgProduct
    //{
    //    [JsonProperty("tags")]
    //    public string Tags { get; set; }

    //    [JsonProperty("name")]
    //    public string ProductName { get; set; }

    //    [JsonProperty("twitter")]
    //    public string TwitterUser { get; set; }
    //}

    public class Start
    {
        public int Index { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }

    public class End
    {
        public int Index { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }

    public class Tags
    {
        public string Value { get; set; }
        public int Style { get; set; }
        public int NodeType { get; set; }
        public object Anchor { get; set; }
        public object Tag { get; set; }
        public Start Start { get; set; }
        public End End { get; set; }
        public List<object> AllNodes { get; set; }
    }

    public class Start2
    {
        public int Index { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }

    public class End2
    {
        public int Index { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }

    public class Name
    {
        public string Value { get; set; }
        public int Style { get; set; }
        public int NodeType { get; set; }
        public object Anchor { get; set; }
        public object Tag { get; set; }
        public Start2 Start { get; set; }
        public End2 End { get; set; }
        public List<object> AllNodes { get; set; }
    }

    public class Start3
    {
        public int Index { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }

    public class End3
    {
        public int Index { get; set; }
        public int Line { get; set; }
        public int Column { get; set; }
    }

    public class Twitter
    {
        public string Value { get; set; }
        public int Style { get; set; }
        public int NodeType { get; set; }
        public object Anchor { get; set; }
        public object Tag { get; set; }
        public Start3 Start { get; set; }
        public End3 End { get; set; }
        public List<object> AllNodes { get; set; }
    }

    public class YamlOrgProduct
    {
        public Tags tags { get; set; }
        public Name name { get; set; }
        public Twitter twitter { get; set; }
    }
}
