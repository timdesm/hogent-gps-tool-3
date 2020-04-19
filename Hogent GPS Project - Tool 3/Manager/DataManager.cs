using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hogent_GPS_Project___Tool_3
{
    class DataManager
    {
        public class JsonGraaf
        {
            public int ID { get; set; }
            public Dictionary<JsonKnoop, IList<JsonSegment>> Map { get; set; }
        }

        public class JsonKnoop
        {
            public int ID { get; set; }
            public JsonPunt Point { get; set; }
        }

        public class JsonSegment
        {
            public int ID { get; set; }
            public JsonKnoop Start { get; set; }
            public JsonKnoop End { get; set; }
            public IList<JsonPunt> Points { get; set; }
        }

        public class JsonPunt
        {
            public double X { get; set; }
            public double Y { get; set; }
        }

        public static JsonGraaf buildGraaf(String data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.ContractResolver = new DictionaryAsArrayResolver();

            JsonGraaf graaf = JsonConvert.DeserializeObject<JsonGraaf>(data, settings);
            return graaf;
        }

        class DictionaryAsArrayResolver : DefaultContractResolver
        {
            protected override JsonContract CreateContract(Type objectType)
            {
                if (objectType.GetInterfaces().Any(i => i == typeof(IDictionary) ||
                   (i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IDictionary<,>))))
                {
                    return base.CreateArrayContract(objectType);
                }

                return base.CreateContract(objectType);
            }
        }

        public static void printMap(Dictionary<JsonKnoop, IList<JsonSegment>> map) {
            Console.WriteLine("----- [MAP] -----                                                         ");
            Console.WriteLine("Total nodes: " + map.Keys.Count);
            Console.WriteLine("Total segments: " + map.Sum(x => x.Value.Count));
            foreach (JsonKnoop node in map.Keys)
                printSegmentList(node, map[node]);
        }

        public static void printSegmentList(JsonKnoop knoop, IList<JsonSegment> segments)
        {
            Console.WriteLine($"Node[{knoop.ID},[{knoop.Point.X},{knoop.Point.Y}]");
            foreach (JsonSegment segment in segments)
                printSegment(segment);
        }

        public static void printSegment(JsonSegment segment)
        {
            Console.WriteLine($"    [Segment:{segment.ID},start:{segment.Start.ID},end:{segment.End.ID}]");
            foreach (JsonPunt point in segment.Points)
                printPoint(point);
        }

        public static void printPoint(JsonPunt point)
        {
            Console.WriteLine($"        ({point.X},{point.Y})");
        }
    }
}
