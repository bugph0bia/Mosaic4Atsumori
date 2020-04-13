using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mosaic4Atsumori
{
    /// <summary>
    /// Colorクラス拡張用
    /// </summary>
    static class ColorUtil
    {
        /// <summary>
        /// RGB値の最大値
        /// </summary>
        public const byte RGBMAX = 255;

        /// <summary>
        /// 色相の最大値
        /// </summary>
        public const float HMAX = 360.0F;

        /// <summary>
        /// 彩度の最大値
        /// </summary>
        public const float SMAX = 1.0F;

        /// <summary>
        /// 明度の最大値
        /// </summary>
        public const float BMAX = 1.0F;

        /// <summary>
        /// HSBからColorを生成
        /// </summary>
        /// <param name="h">色相</param>
        /// <param name="s">彩度</param>
        /// <param name="b">明度</param>
        /// <returns></returns>
        public static Color FromHSB(float h, float s, float b)
        {
            // h を 0.0 ～ 359.0 とする
            h = h % HMAX;

            // 計算用の値
            float h2 = h / 60.0F % 1.0F;
            float tempA = b * RGBMAX;
            float tempB = b * (1.0F - s) * RGBMAX;
            float tempC = b * (1.0F - s * h2) * RGBMAX;
            float tempD = b * (1.0F - s * (1.0F - h2)) * RGBMAX;

            int R, G, B;
            if (s == 0)
            {
                R = (int)tempA;
                G = (int)tempA;
                B = (int)tempA;
            }
            else if (h < 60)
            {
                R = (int)tempA;
                G = (int)tempD;
                B = (int)tempB;
            }
            else if (h < 120)
            {
                R = (int)tempC;
                G = (int)tempA;
                B = (int)tempB;
            }
            else if (h < 180)
            {
                R = (int)tempB;
                G = (int)tempA;
                B = (int)tempD;
            }
            else if (h < 240)
            {
                R = (int)tempB;
                G = (int)tempC;
                B = (int)tempA;
            }
            else if (h < 300)
            {
                R = (int)tempD;
                G = (int)tempB;
                B = (int)tempA;
            }
            else
            {
                R = (int)tempA;
                G = (int)tempB;
                B = (int)tempC;
            }

            return Color.FromArgb(R, G, B);
        }
    }
}
