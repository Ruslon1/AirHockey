using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Extensions
{
    public static class Extensions
    {
        public static void CalculatePathTime(this ref float time, Vector3 position, Vector3 pointPosition, float coefficient = 1f)
        {
            time = Vector3.Distance(position, pointPosition) * coefficient;
        }
    }
}
