using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Contracts
{
    [JsonObject, Serializable]
    public class Sensor
    {
        public int id { get; set; }
        public string sensorName { get; set; }
        public int sicaklikDegeri { get; set; }
        public DateTime timeStamp { get; set; }
        public string _lineMaterialString { get; set; }
        public string _innerFillMaterialString { get; set; }
        public string _pointMaterialString { get; set; }
        public int _lineThickness { get; set; }
        public int _pointSize { get; set; }
        public int minValue { get; set; }
        public int maxValue { get; set; }
        public float avrValue { get; set; }
        public int sum { get; set; }
        public int count { get; set; }
    }
}
