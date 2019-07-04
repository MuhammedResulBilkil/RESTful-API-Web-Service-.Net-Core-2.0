using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Contracts;

namespace WebApplication1.Controllers
{

    [Route("api/[controller]")]
    public class SensorsController : ControllerBase
    {

        static Random rand = new Random();

        #region Realtime
        //private static List<Sensor> Sensors = new List<Sensor>()
        //{
        //    new Sensor()
        //    {
        //        id = 1,
        //        sensorName = "Sensor 1",
        //        sicaklikDegeri = rand.Next(0,30),
        //        timeStamp = DateTime.Now,
        //        _lineMaterialString = MaterialNames._lineMaterialNames.Find(x => x == "Green"),
        //        _innerFillMaterialString = MaterialNames._innerMaterialNames.Find(x => x == "Blue"),
        //        _pointMaterialString = MaterialNames._pointMaterialNames.Find(x => x == "Red"),
        //        _lineThickness = 5,
        //        _pointSize = 12,
        //        minValue = 5000,
        //        maxValue = -5000,
        //        avrValue = 0,
        //        sum = 0,
        //        count = 0
        //    },
        //    new Sensor
        //    {
        //        id = 2,
        //        sensorName = "Sensor 2",
        //        sicaklikDegeri = rand.Next(0,30),
        //        timeStamp = DateTime.Now,
        //        _lineMaterialString = MaterialNames._lineMaterialNames.Find(x => x == "Blue"),
        //        _innerFillMaterialString = MaterialNames._innerMaterialNames.Find(x => x == "Green"),
        //        _pointMaterialString = MaterialNames._pointMaterialNames.Find(x => x == "Yellow"),
        //        _lineThickness = 5,
        //        _pointSize = 12,
        //        minValue = 5000,
        //        maxValue = -5000,
        //        avrValue = 0,
        //        sum = 0,
        //        count = 0
        //    },
        //    new Sensor
        //    {
        //        id = 3,
        //        sensorName = "Sensor 3",
        //        sicaklikDegeri = rand.Next(0,30),
        //        timeStamp = DateTime.Now,
        //        _lineMaterialString = MaterialNames._lineMaterialNames.Find(x => x == "Red"),
        //        _innerFillMaterialString = MaterialNames._innerMaterialNames.Find(x => x == "Yellow"),
        //        _pointMaterialString = MaterialNames._pointMaterialNames.Find(x => x == "Purple"),
        //        _lineThickness = 5,
        //        _pointSize = 12,
        //        minValue = 5000,
        //        maxValue = -5000,
        //        avrValue = 0,
        //        sum = 0,
        //        count = 0
        //    },
        //    new Sensor
        //    {
        //        id = 4,
        //        sensorName = "Sensor 4",
        //        sicaklikDegeri = rand.Next(0,30),
        //        timeStamp = DateTime.Now,
        //        _lineMaterialString = MaterialNames._lineMaterialNames.Find(x => x == "Purple"),
        //        _innerFillMaterialString = MaterialNames._innerMaterialNames.Find(x => x == "Purple"),
        //        _pointMaterialString = MaterialNames._pointMaterialNames.Find(x => x == "Green"),
        //        _lineThickness = 5,
        //        _pointSize = 12,
        //        minValue = 5000,
        //        maxValue = -5000,
        //        avrValue = 0,
        //        sum = 0,
        //        count = 0
        //    },
        //    new Sensor
        //    {
        //        id = 5,
        //        sensorName = "Sensor 5",
        //        sicaklikDegeri = rand.Next(0,30),
        //        timeStamp = DateTime.Now,
        //        _lineMaterialString = MaterialNames._lineMaterialNames.Find(x => x == "Yellow"),
        //        _innerFillMaterialString = MaterialNames._innerMaterialNames.Find(x => x == "Red"),
        //        _pointMaterialString = MaterialNames._pointMaterialNames.Find(x => x == "Blue"),
        //        _lineThickness = 5,
        //        _pointSize = 12,
        //        minValue = 5000,
        //        maxValue = -5000,
        //        avrValue = 0,
        //        sum = 0,
        //        count = 0
        //    },
        //};

        #endregion

        #region Not Realtime
        private static List<Sensor> Sensors = new List<Sensor>();
        #endregion

        // GET api/sensors
        [HttpGet]
        public JsonResult Get()
        {
            #region Realtime
            //foreach (Sensor sensor in Sensors)
            //{
            //    sensor.timeStamp = DateTime.Now;
            //    sensor.sicaklikDegeri = rand.Next(0, 30);

            //    if (sensor.maxValue < sensor.sicaklikDegeri)
            //        sensor.maxValue = sensor.sicaklikDegeri;

            //    if (sensor.minValue > sensor.sicaklikDegeri)
            //        sensor.minValue = sensor.sicaklikDegeri;

            //    sensor.sum += sensor.sicaklikDegeri;
            //    sensor.count++;
            //    sensor.avrValue = (float) sensor.sum / sensor.count;
            //}
            #endregion
            return new JsonResult(Sensors);
        }

        // GET api/sensors/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Sensor sensor = Sensors.Single(p => p.id == id);
            return new JsonResult(sensor);
        }

        //// GET api/sensors/5/2
        //[HttpGet("{id}/{secondId}")]
        //public JsonResult Get(int id, int secondId)
        //{
        //    Sensor sensor = Sensors.Single(p => p.id == id && p.secondId == secondId);
        //    return new JsonResult(sensor);
        //}

        #region Realtime
        //// POST api/sensors
        //[HttpPost]
        //public JsonResult Post([FromBody] Sensor newSensor)
        //{
        //    Sensors.Add(newSensor);
        //    return new JsonResult(Sensors);
        //}
        #endregion

        #region Not Realtime
        // POST api/sensors
        [HttpPost]
        public JsonResult Post()
        {
            int foo = 1;
            int foo1 = 1;

            int i = 1;
            for (i = 1; i <= 500; i++)
            {
                Sensor sensor = new Sensor();

                sensor.id = i;
                sensor.sensorName = string.Format("Sensor {0}", foo);
                foo++;
                if (foo >= 5)
                    foo = 1;


                sensor.sicaklikDegeri = rand.Next(0, 30);

                sensor.timeStamp = DateTime.Now + System.TimeSpan.FromSeconds(foo1 * 10000);

                if (i % 4 == 0)
                    foo1++;

                sensor._lineMaterialString = MaterialNames._lineMaterialNames[rand.Next(0, 7)];
                // sensor._innerFillMaterialString = MaterialNames._innerMaterialNames[rand.Next(0, 5)];
                sensor._pointMaterialString = MaterialNames._pointMaterialNames[rand.Next(0, 6)];

                sensor._lineThickness = 8;
                sensor._pointSize = 15;

                Sensors.Add(sensor);
            }

            return new JsonResult(Sensors);
        }
        #endregion




        #region PUT Method
        //// PUT api/sensors/5
        //[HttpPut("{id}")]
        //public JsonResult Put(int id, [FromBody] string newMaterial)
        //{
        //    Sensor sensor = Sensors.Single(p => p.id == id);
        //    sensor._lineMaterialString = newMaterial;
        //    return new JsonResult(sensor);
        //} 
        #endregion

        // PUT api/sensors/5
        [HttpPut("{id}")]
        public JsonResult Put(int id, [FromBody] Sensor newSensor)
        {
            Sensor sensor = Sensors.Single(p => p.id == id);
            sensor.sicaklikDegeri = newSensor.sicaklikDegeri;
            sensor.timeStamp = newSensor.timeStamp;
            return new JsonResult(sensor);
        }

        //// PUT api/sensors/5/2
        //[HttpPut("{id}/{secondId}")]
        //public JsonResult Put(int id, int secondId, [FromBody] string dateTime)
        //{
        //    Sensor sensor = Sensors.Single(p => p.id == id && p.secondId == secondId);
        //    sensor.sicaklikDegeri = 55;
        //    sensor.timeStamp = DateTime.Parse(dateTime);
        //    return new JsonResult(sensor);
        //}

        // DELETE api/sensors/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Sensor sensor = Sensors.Single(p => p.id == id);
            Sensors.Remove(sensor);
        }
    }
}
