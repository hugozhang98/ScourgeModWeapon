using System;
using Microsoft.Xna.Framework;

namespace ScourgeModWeapon.Helper
{
    public static class ShapeHelper
    {
        /// <summary>
        /// 返回椭圆轨迹上的坐标。angle 为 0 时在最右侧；正值为顺时针旋转。
        /// 所有角度均使用弧度，ellipseRotation 默认为 0（椭圆水平）。
        /// </summary>
        public static Vector2 GetEllipse(
            Vector2 center,
            float radiusX,
            float radiusY,
            float angle,
            float ellipseRotation = 0f
        )
        {
            float x = MathF.Cos(angle) * radiusX;
            float y = MathF.Sin(angle) * radiusY;
            float cos = MathF.Cos(ellipseRotation);
            float sin = MathF.Sin(ellipseRotation);

            return center + new Vector2(x * cos - y * sin, x * sin + y * cos);
        }
    }
}
