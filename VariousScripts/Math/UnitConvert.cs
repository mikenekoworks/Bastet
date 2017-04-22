using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bastet.Math {

    public static class UnitConvert {

        /// <summary>
        /// 1インチは25.4ミリメートル
        /// </summary>
        const float MillimeterPerInch = 25.4f;

        /// <summary>
        /// ミリメートルをピクセルに変換する
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static float MillimeterToPixel( float value, float dpi ) {
            return ( value / MillimeterPerInch ) * dpi;
        }

    }

}   // end of namespace Bastet.Math