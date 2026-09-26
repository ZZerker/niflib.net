/*
 * DAWN OF LIGHT - The first free open source DAoC server emulator
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
 *
 */

namespace Niflib
{
    using System.Numerics;

    // Keep scalar evaluation order so polygon caches and rasterization retain their rounding.
    public static class NumericsTransform
    {
        public static Matrix4x4 Multiply(Matrix4x4 left, Matrix4x4 right)
        {
            Matrix4x4 result;
            result.M11 = left.M11 * right.M11 + left.M12 * right.M21 + left.M13 * right.M31 + left.M14 * right.M41;
            result.M12 = left.M11 * right.M12 + left.M12 * right.M22 + left.M13 * right.M32 + left.M14 * right.M42;
            result.M13 = left.M11 * right.M13 + left.M12 * right.M23 + left.M13 * right.M33 + left.M14 * right.M43;
            result.M14 = left.M11 * right.M14 + left.M12 * right.M24 + left.M13 * right.M34 + left.M14 * right.M44;
            result.M21 = left.M21 * right.M11 + left.M22 * right.M21 + left.M23 * right.M31 + left.M24 * right.M41;
            result.M22 = left.M21 * right.M12 + left.M22 * right.M22 + left.M23 * right.M32 + left.M24 * right.M42;
            result.M23 = left.M21 * right.M13 + left.M22 * right.M23 + left.M23 * right.M33 + left.M24 * right.M43;
            result.M24 = left.M21 * right.M14 + left.M22 * right.M24 + left.M23 * right.M34 + left.M24 * right.M44;
            result.M31 = left.M31 * right.M11 + left.M32 * right.M21 + left.M33 * right.M31 + left.M34 * right.M41;
            result.M32 = left.M31 * right.M12 + left.M32 * right.M22 + left.M33 * right.M32 + left.M34 * right.M42;
            result.M33 = left.M31 * right.M13 + left.M32 * right.M23 + left.M33 * right.M33 + left.M34 * right.M43;
            result.M34 = left.M31 * right.M14 + left.M32 * right.M24 + left.M33 * right.M34 + left.M34 * right.M44;
            result.M41 = left.M41 * right.M11 + left.M42 * right.M21 + left.M43 * right.M31 + left.M44 * right.M41;
            result.M42 = left.M41 * right.M12 + left.M42 * right.M22 + left.M43 * right.M32 + left.M44 * right.M42;
            result.M43 = left.M41 * right.M13 + left.M42 * right.M23 + left.M43 * right.M33 + left.M44 * right.M43;
            result.M44 = left.M41 * right.M14 + left.M42 * right.M24 + left.M43 * right.M34 + left.M44 * right.M44;
            return result;
        }

        public static Vector3 TransformCoordinate(Vector3 value, Matrix4x4 transform)
        {
            var x = value.X * transform.M11 + value.Y * transform.M21 + value.Z * transform.M31 + transform.M41;
            var y = value.X * transform.M12 + value.Y * transform.M22 + value.Z * transform.M32 + transform.M42;
            var z = value.X * transform.M13 + value.Y * transform.M23 + value.Z * transform.M33 + transform.M43;
            var w = value.X * transform.M14 + value.Y * transform.M24 + value.Z * transform.M34 + transform.M44;
            var inverse = 1f / w;
            return new Vector3(x * inverse, y * inverse, z * inverse);
        }

        public static Vector3 Transform(Vector3 value, Matrix4x4 transform)
        {
            return new Vector3(
                value.X * transform.M11 + value.Y * transform.M21 + value.Z * transform.M31 + transform.M41,
                value.X * transform.M12 + value.Y * transform.M22 + value.Z * transform.M32 + transform.M42,
                value.X * transform.M13 + value.Y * transform.M23 + value.Z * transform.M33 + transform.M43);
        }

        public static Vector3 TransformNormal(Vector3 value, Matrix4x4 transform)
        {
            return new Vector3(
                value.X * transform.M11 + value.Y * transform.M21 + value.Z * transform.M31,
                value.X * transform.M12 + value.Y * transform.M22 + value.Z * transform.M32,
                value.X * transform.M13 + value.Y * transform.M23 + value.Z * transform.M33);
        }
    }
}
