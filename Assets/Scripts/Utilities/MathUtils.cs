using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GGJ
{
    public static class MathUtils
    {
        public static Vector3 GetVectorFromAngle(float angle)
        {
            float angleRad = angle * (Mathf.PI / 180f);
            return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        }

        public static float GetAngleFromVectorFloat(Vector3 direction)
        {
            direction = direction.normalized;
            float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;

            return n;
        }
    }
}
