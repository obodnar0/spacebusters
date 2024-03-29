﻿using System;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Assets.Scripts
{
    public static class Helpers
    {
        public static float Range(this float value, float min, float max)
        {
            return value < min ? min : value > max ? max : value;
        }

        public static Color Opacity(this Color source, float a)
        {
            return new Color(source.r, source.g, source.b, a);
        }

        public static string ClearName(this Object obj)
        {
            return obj.name.Replace(" (Instance)", "");
        }

        public static Material Material(this Renderer renderer, string name)
        {
            return renderer.materials.FirstOrDefault(x => x.ClearName() == name);
        }

        public static double CalculateTemperatureEquilibrium(double starTemperature, double starRadius, double orbitalDistance, double bondAlbedo)
        {
            var res = starTemperature * Math.Sqrt(starRadius / (2 * orbitalDistance)) * Math.Pow(1 - bondAlbedo, 0.25);

            return res;
        }

        public static double CalculateDensity(double mass, double radius)
        {
            var volume = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);

            return mass / volume;
        }

        public static double CalculateOrbitalSpeed(double starMass, double starRadius)
        {
            var gravityConstant = 6.67 * 10e-11;
            var result = Math.Sqrt(gravityConstant * starMass / starRadius);

            return result;
        }
    }
}
