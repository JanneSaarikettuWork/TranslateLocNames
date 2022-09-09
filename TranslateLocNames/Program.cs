using System;
using System.Collections.Generic;

namespace TranslateLocNames
{
    class Program
    {
        static void Main(string[] args)
        {
            // Construct a name map containing Radea and St*rLims names
            var RadLimsMap = new NameMap<string, string>();

            // Fill the map with location names
            FillLocationNameTranslationData(RadLimsMap);

            // Do some testing
            try
            {
                Console.WriteLine(RadLimsMap.Rad2Lims["102/19"]);
                Console.WriteLine(RadLimsMap.Lims2Rad["JH_LAB 985._"]);
                Console.WriteLine(RadLimsMap.Rad2Lims["This location does not exist"]);
            }
            catch (Exception e)
            {
                Console.WriteLine("Got exception: " + e.Message);
            }

            // Wait for enter before closing the app
            Console.ReadLine();

            /* Output: 
            JH_LAB 102.019._
            985
            Got exception: The given key was not present in the dictionary.
            */

        }

        private static void FillLocationNameTranslationData(NameMap<string, string> radLimsMap)
        {
            //              Radea name       St*rLims name
            radLimsMap.Add("In Transit",    "In Transit");  // There is no real St*rLims name for this?
            radLimsMap.Add("Reception",     "Reception");   // There is no real St*rLims name for this?
            radLimsMap.Add("100/3",         "JH_LAB 100.003._");
            radLimsMap.Add("100/3a",        "JH_LAB 100.003a._");
            radLimsMap.Add("100/6",         "JH_LAB 100.006._");
            radLimsMap.Add("100/7",         "JH_LAB 100.007._");
            radLimsMap.Add("100/24",        "JH_LAB 100.024._");
            radLimsMap.Add("100/24a",       "JH_LAB 100.024a._");
            radLimsMap.Add("100/28",        "JH_LAB 100.028._");
            radLimsMap.Add("100/37",        "JH_LAB 100.037._");
            radLimsMap.Add("100/77",        "JH_LAB 100.077._");
            radLimsMap.Add("100/79",        "JH_LAB 100.079._");
            radLimsMap.Add("100/86",        "JH_LAB 100.086._");
            radLimsMap.Add("100/87",        "JH_LAB 100.087._");
            radLimsMap.Add("100/88",        "JH_LAB 100.088._");
            radLimsMap.Add("100/135",       "JH_LAB 100.135._");
            radLimsMap.Add("102/4",         "JH_LAB 102.004._");
            radLimsMap.Add("102/5",         "JH_LAB 102.005._");
            radLimsMap.Add("102/7",         "JH_LAB 102.007._");
            radLimsMap.Add("102/11",        "JH_LAB 102.011._");
            radLimsMap.Add("102/12",        "JH_LAB 102.012._");
            radLimsMap.Add("102/12ab",      "JH_LAB 102.012ab._");
            radLimsMap.Add("102/19",        "JH_LAB 102.019._");
            radLimsMap.Add("102/24",        "JH_LAB 102.024._");
            radLimsMap.Add("102/24a",       "JH_LAB 102.024a._");
            radLimsMap.Add("102/60",        "JH_LAB 102.060._");
            radLimsMap.Add("102/68",        "JH_LAB 102.068._");
            radLimsMap.Add("102/73",        "JH_LAB 102.073._");
            radLimsMap.Add("102/86",        "JH_LAB 102.086._");
            radLimsMap.Add("102/162",       "JH_LAB 102.162._");
            radLimsMap.Add("102/164",       "JH_LAB 102.164._");
            radLimsMap.Add("103/15",        "JH_LAB 103.015._");
            radLimsMap.Add("103/30",        "JH_LAB 103.030._");
            radLimsMap.Add("103/31",        "JH_LAB 103.031._");
            radLimsMap.Add("103/37",        "JH_LAB 103.037._");
            radLimsMap.Add("103/39",        "JH_LAB 103.039._");
            radLimsMap.Add("103/39c",       "JH_LAB 103.039c._");
            radLimsMap.Add("103/40c",       "JH_LAB 103.040c._");
            radLimsMap.Add("103/41",        "JH_LAB 103.041._");
            radLimsMap.Add("103/42",        "JH_LAB 103.042._");
            radLimsMap.Add("103/42b",       "JH_LAB 103.042b._");
            radLimsMap.Add("103/52",        "JH_LAB 103.052._");
            radLimsMap.Add("103/54",        "JH_LAB 103.054._");
            radLimsMap.Add("103/54d",       "JH_LAB 103.054d._");
            radLimsMap.Add("103/56",        "JH_LAB 103.056._");
            radLimsMap.Add("103/68",        "JH_LAB 103.068._");
            radLimsMap.Add("103/72",        "JH_LAB 103.072._");
            radLimsMap.Add("103/73",        "JH_LAB 103.073._");
            radLimsMap.Add("985",           "JH_LAB 985._");
            radLimsMap.Add("Wellers Wood",  "JH_LAB Wellers Wood._");
        }
    }

    // Implement a map as two dictionaries for fast lookup speed in both directions
    public class NameMap<T1, T2>
    {
        private Dictionary<T1, T2> _rad_2_lims = new Dictionary<T1, T2>();
        private Dictionary<T2, T1> _lims_2_rad = new Dictionary<T2, T1>();

        public NameMap()
        {
            this.Rad2Lims = new Indexer<T1, T2>(_rad_2_lims);
            this.Lims2Rad = new Indexer<T2, T1>(_lims_2_rad);
        }

        public class Indexer<T3, T4>
        {
            private Dictionary<T3, T4> _dictionary;
            public Indexer(Dictionary<T3, T4> dictionary)
            {
                _dictionary = dictionary;
            }
            public T4 this[T3 index]
            {
                get { return _dictionary[index]; }
                set { _dictionary[index] = value; }
            }
        }

        public void Add(T1 t1, T2 t2)
        {
            _rad_2_lims.Add(t1, t2);
            _lims_2_rad.Add(t2, t1);
        }

        public Indexer<T1, T2> Rad2Lims { get; private set; }
        public Indexer<T2, T1> Lims2Rad { get; private set; }
    }
}
