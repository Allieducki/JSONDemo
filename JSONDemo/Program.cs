using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JSONDemo
{
    class Rocket
    {
        public string Type { get; set; } = "";
        public double Height { get; set; } = 0.0;  // meters
        public int Weight { get; set; } = 0;       // ton
    }

    class Student
    {
        public string Name { get; set; } = "";
        public double[] Numbers { get; set; } = { 2.3, 4.7, 8.6 };
    }

    class Program
    {
        static void Main(string[] args)
        {

            Rocket r = new Rocket();
            r.Type = "Big New Year";
            r.Weight = 1;
            r.Height = 0.34;

            string jsonRef1 = JsonConvert.SerializeObject(r);
            Console.WriteLine(jsonRef1);
            Console.WriteLine("**************************************");

            string[] names = { "n1", "n2", "n3" };

            string jsonRef2 = JsonConvert.SerializeObject(names);
            Console.WriteLine(jsonRef2);
            Console.WriteLine("**************************************");

            Student s = new Student();
            s.Name = "Peterson";

            string jsonRef3 = JsonConvert.SerializeObject(s);
            Console.WriteLine(jsonRef3);
            Console.WriteLine("**************************************");

            List<Rocket> rockets = new List<Rocket>()
            {
                new Rocket { Type="Saturn V",Height=110,Weight=2936},
                new Rocket { Type="V-2",Height=14,Weight=13},
                new Rocket { Type="Falcon 9",Height=53,Weight=290}
            };

            string jsonRef4 = JsonConvert.SerializeObject(rockets);
            Console.WriteLine(jsonRef4);
            Console.WriteLine("**************************************");



            // Deserializing method 1 with JsonConvert:

            string jsonStudent = @"{
                                    'Name': 'Gert',
                                    'Numbers': [3,2,4,5]
                                 }";

            Student s2 = JsonConvert.DeserializeObject<Student>(jsonStudent);
            Console.WriteLine("The name is: " + s2.Name);
            Console.WriteLine("The first number is: " + s2.Numbers[0]);
            Console.WriteLine("The second number is: " + s2.Numbers[1]);
            Console.WriteLine("The third number is: " + s2.Numbers[2]);
            Console.WriteLine("The fourth number is: " + s2.Numbers[3]);
            Console.WriteLine("************************************");


            // Deserializing method 2 with Linq parsing to: JObject JArray, JToken etc

            JObject jo = JObject.Parse(jsonStudent);

            string studentName = (string)jo["Name"]; // notice case sensitive!!
            Console.WriteLine(studentName);

            string studentNumber = (string)jo["Numbers"][2];


            Console.WriteLine(studentNumber);

            Console.WriteLine("************************************");
            // LINQ query
            var numbers =
            from c
            in jo["Numbers"]
            orderby c ascending
            select c;

            foreach (var c in numbers)
            {
                Console.WriteLine(c);
            }
            // Exercise open Weather website: find data different chunks of data !!!

            Console.WriteLine("************************************");
            

            #region JSONEarthquake
            string jsonEarthquake = @"{
                                    'type':'FeatureCollection',
                                    'metadata':{
                                    'generated':1603965623000,
                                    'url':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/4.5_day.geojson',
                                    'title':'USGS Magnitude 4.5+ Earthquakes, Past Day',
                                    'status':200,
                                    'api':'1.10.3',
                                    'count':16
                                    },
                                    'features':[
                                    {
                                    'type':'Feature',
                                    'properties':{
                                    'mag':4.9,
                                    'place':'24 km NE of Khorugh, Tajikistan',
                                    'time':1603963963603,
                                    'updated':1603964864040,
                                    'tz':null,
                                    'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7f1',
                                    'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7f1.geojson',
                                    'felt':null,
                                    'cdi':null,
                                    'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':369,
            'net':'us',
            'code':'7000c7f1',
            'ids':',us7000c7f1,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':1.855,
            'rms':1.04,
            'gap':54,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 4.9 - 24 km NE of Khorugh, Tajikistan'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               71.7774,
               37.6247,
               51.44
            ]
         },
         'id':'us7000c7f1'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':4.5,
            'place':'57 km E of Luganville, Vanuatu',
            'time':1603958434172,
            'updated':1603960099040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7ef',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7ef.geojson',
            'felt':null,
            'cdi':null,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':312,
            'net':'us',
            'code':'7000c7ef',
            'ids':',us7000c7ef,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':0.496,
            'rms':0.74,
            'gap':59,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 4.5 - 57 km E of Luganville, Vanuatu'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               167.6949,
               -15.5972,
               117.94
            ]
         },
         'id':'us7000c7ef'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':5,
            'place':'South Shetland Islands',
            'time':1603957252224,
            'updated':1603958436040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7e8',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7e8.geojson',
            'felt':null,
            'cdi':null,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':385,
            'net':'us',
            'code':'7000c7e8',
            'ids':',us7000c7e8,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':0.278,
            'rms':0.7,
            'gap':99,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 5.0 - South Shetland Islands'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               -58.3891,
               -62.4843,
               10
            ]
         },
         'id':'us7000c7e8'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':4.6,
            'place':'3 km WSW of Wawa, Philippines',
            'time':1603956187467,
            'updated':1603958577928,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7e7',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7e7.geojson',
            'felt':4,
            'cdi':3.8,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':327,
            'net':'us',
            'code':'7000c7e7',
            'ids':',us7000c7e7,',
            'sources':',us,',
            'types':',dyfi,origin,phase-data,',
            'nst':null,
            'dmin':7.989,
            'rms':0.96,
            'gap':114,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 4.6 - 3 km WSW of Wawa, Philippines'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               121.0198,
               13.7241,
               10
            ]
         },
         'id':'us7000c7e7'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':5.1,
            'place':'South Shetland Islands',
            'time':1603954966825,
            'updated':1603956294040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7dw',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7dw.geojson',
            'felt':null,
            'cdi':null,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':400,
            'net':'us',
            'code':'7000c7dw',
            'ids':',us7000c7dw,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':0.231,
            'rms':0.95,
            'gap':57,
            'magType':'mww',
            'type':'earthquake',
            'title':'M 5.1 - South Shetland Islands'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               -58.1761,
               -62.28,
               10
            ]
         },
         'id':'us7000c7dw'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':4.8,
            'place':'1 km NW of Talaga, Philippines',
            'time':1603949143896,
            'updated':1603957145499,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7dk',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7dk.geojson',
            'felt':12,
            'cdi':4.1,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':359,
            'net':'us',
            'code':'7000c7dk',
            'ids':',us7000c7dk,',
            'sources':',us,',
            'types':',dyfi,origin,phase-data,',
            'nst':null,
            'dmin':8.947,
            'rms':0.68,
            'gap':111,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 4.8 - 1 km NW of Talaga, Philippines'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               120.9268,
               13.743,
               10
            ]
         },
         'id':'us7000c7dk'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':4.9,
            'place':'South Sandwich Islands region',
            'time':1603946683161,
            'updated':1603947528040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7da',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7da.geojson',
            'felt':null,
            'cdi':null,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':369,
            'net':'us',
            'code':'7000c7da',
            'ids':',us7000c7da,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':7.276,
            'rms':0.94,
            'gap':77,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 4.9 - South Sandwich Islands region'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               -25.2451,
               -57.947,
               35
            ]
         },
         'id':'us7000c7da'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':4.9,
            'place':'219 km NNW of Lorengau, Papua New Guinea',
            'time':1603925242358,
            'updated':1603926228040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7at',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7at.geojson',
            'felt':null,
            'cdi':null,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':369,
            'net':'us',
            'code':'7000c7at',
            'ids':',us7000c7at,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':2.009,
            'rms':0.86,
            'gap':67,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 4.9 - 219 km NNW of Lorengau, Papua New Guinea'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               146.6541,
               -0.1518,
               10
            ]
         },
         'id':'us7000c7at'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':5.3,
            'place':'Easter Island region',
            'time':1603922889652,
            'updated':1603923956040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7a6',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7a6.geojson',
            'felt':null,
            'cdi':null,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':432,
            'net':'us',
            'code':'7000c7a6',
            'ids':',us7000c7a6,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':3.233,
            'rms':0.63,
            'gap':105,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 5.3 - Easter Island region'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               -111.6762,
               -29.7306,
               10
            ]
         },
         'id':'us7000c7a6'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':5.4,
            'place':'South Shetland Islands',
            'time':1603922424300,
            'updated':1603929717646,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c79x',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c79x.geojson',
            'felt':null,
            'cdi':null,
            'mmi':4.336,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':449,
            'net':'us',
            'code':'7000c79x',
            'ids':',us7000c79x,',
            'sources':',us,',
            'types':',origin,phase-data,shakemap,',
            'nst':null,
            'dmin':0.206,
            'rms':1.23,
            'gap':66,
            'magType':'mww',
            'type':'earthquake',
            'title':'M 5.4 - South Shetland Islands'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               -58.2464,
               -62.3067,
               10
            ]
         },
         'id':'us7000c79x'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':4.7,
            'place':'South Shetland Islands',
            'time':1603922220779,
            'updated':1603930298040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c7ai',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c7ai.geojson',
            'felt':null,
            'cdi':null,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':340,
            'net':'us',
            'code':'7000c7ai',
            'ids':',us7000c7ai,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':0.253,
            'rms':0.82,
            'gap':82,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 4.7 - South Shetland Islands'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               -58.1285,
               -62.2805,
               5.48
            ]
         },
         'id':'us7000c7ai'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':4.9,
            'place':'Mid-Indian Ridge',
            'time':1603897931090,
            'updated':1603918612040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c6uy',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c6uy.geojson',
            'felt':null,
            'cdi':null,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':369,
            'net':'us',
            'code':'7000c6uy',
            'ids':',us7000c6uy,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':20.763,
            'rms':0.91,
            'gap':62,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 4.9 - Mid-Indian Ridge'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               69.2325,
               -23.8019,
               10
            ]
         },
         'id':'us7000c6uy'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':5.8,
            'place':'63 km N of La Serena, Chile',
            'time':1603896790766,
            'updated':1603905724419,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c6u9',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c6u9.geojson',
            'felt':42,
            'cdi':5.4,
            'mmi':5.572,
            'alert':'green',
            'status':'reviewed',
            'tsunami':0,
            'sig':540,
            'net':'us',
            'code':'7000c6u9',
            'ids':',us7000c6u9,',
            'sources':',us,',
            'types':',dyfi,losspager,moment-tensor,origin,phase-data,shakemap,',
            'nst':null,
            'dmin':0.55,
            'rms':0.71,
            'gap':91,
            'magType':'mww',
            'type':'earthquake',
            'title':'M 5.8 - 63 km N of La Serena, Chile'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               -71.214,
               -29.3296,
               43.8
            ]
         },
         'id':'us7000c6u9'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':5.8,
            'place':'65 km SSW of Sola, Vanuatu',
            'time':1603894376275,
            'updated':1603920480040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c6sn',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c6sn.geojson',
            'felt':null,
            'cdi':null,
            'mmi':3.751,
            'alert':'green',
            'status':'reviewed',
            'tsunami':0,
            'sig':518,
            'net':'us',
            'code':'7000c6sn',
            'ids':',us7000c6sn,',
            'sources':',us,',
            'types':',losspager,moment-tensor,origin,phase-data,shakemap,',
            'nst':null,
            'dmin':1.015,
            'rms':0.78,
            'gap':53,
            'magType':'mww',
            'type':'earthquake',
            'title':'M 5.8 - 65 km SSW of Sola, Vanuatu'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               167.3852,
               -14.4415,
               178.34
            ]
         },
         'id':'us7000c6sn'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':5.4,
            'place':'Pacific-Antarctic Ridge',
            'time':1603887921135,
            'updated':1603923538722,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c6qt',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c6qt.geojson',
            'felt':null,
            'cdi':null,
            'mmi':0,
            'alert':'green',
            'status':'reviewed',
            'tsunami':0,
            'sig':449,
            'net':'us',
            'code':'7000c6qt',
            'ids':',us7000c6qt,',
            'sources':',us,',
            'types':',losspager,origin,phase-data,shakemap,',
            'nst':null,
            'dmin':18.26,
            'rms':0.53,
            'gap':118,
            'magType':'mww',
            'type':'earthquake',
            'title':'M 5.4 - Pacific-Antarctic Ridge'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               -156.5043,
               -63.5089,
               10
            ]
         },
         'id':'us7000c6qt'
      },
      {
         'type':'Feature',
         'properties':{
            'mag':4.5,
            'place':'247 km E of Levuka, Fiji',
            'time':1603884075556,
            'updated':1603885286040,
            'tz':null,
            'url':'https://earthquake.usgs.gov/earthquakes/eventpage/us7000c6q7',
            'detail':'https://earthquake.usgs.gov/earthquakes/feed/v1.0/detail/us7000c6q7.geojson',
            'felt':null,
            'cdi':null,
            'mmi':null,
            'alert':null,
            'status':'reviewed',
            'tsunami':0,
            'sig':312,
            'net':'us',
            'code':'7000c6q7',
            'ids':',us7000c6q7,',
            'sources':',us,',
            'types':',origin,phase-data,',
            'nst':null,
            'dmin':3.427,
            'rms':0.66,
            'gap':79,
            'magType':'mb',
            'type':'earthquake',
            'title':'M 4.5 - 247 km E of Levuka, Fiji'
         },
         'geometry':{
            'type':'Point',
            'coordinates':[
               -178.3532,
               -17.915,
               526.66
            ]
         },
         'id':'us7000c6q7'
      }
   ],
   'bbox':[
      -178.3532,
      -63.5089,
      5.48,
      167.6949,
      37.6247,
      526.66
   ]
}";
            #endregion

            JObject jo2 = JObject.Parse(jsonEarthquake);
            string jsonplace;
            string jsonmag;

            var elements =
                from c
                in jo2["features"]
                select c;
            
            for(int i = 0; i < elements.Count(); i++)
            {
                jsonplace = (string)jo2["features"][i]["properties"]["place"];
                Console.WriteLine("place: "+jsonplace);
                jsonmag = (string)jo2["features"][i]["properties"]["mag"];
                Console.WriteLine("magnitude: "+jsonmag+"\n");

            }
            Console.Read();

            /*foreach (var c in elements)
            {
                Console.WriteLine(c);
            }*/
        }
    }
}
