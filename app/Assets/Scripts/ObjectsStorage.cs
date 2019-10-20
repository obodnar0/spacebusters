using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class ObjectsStorage
    {
        private static ObjectsStorage _instance = new ObjectsStorage();

        public static ObjectsStorage Ints => _instance;


        public GameObject Satel1 { get; set; }
        public GameObject Satel2 { get; set; }
        public GameObject Satel3 { get; set; }
        public GameObject Satel4 { get; set; }
        public GameObject Planet { get; set; }
        public GameObject Star { get; set; }
        public GameObject StarCoverage { get; set; }
    }
}
