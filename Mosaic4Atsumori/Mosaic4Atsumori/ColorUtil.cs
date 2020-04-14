using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Mosaic4Atsumori
{
    /// <summary>
    /// Color拡張用クラス
    /// </summary>
    static class ColorUtil
    {
        #region 定数

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

        #endregion

        #region メソッド

        /// <summary>
        /// HSBからColorを生成
        /// </summary>
        /// <param name="h">色相</param>
        /// <param name="s">彩度</param>
        /// <param name="b">明度</param>
        /// <returns>生成した色データ</returns>
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

        /// <summary>
        /// 色相のステップ値を取得
        /// </summary>
        /// <param name="c">色データ</param>
        /// <param name="stepCount">ステップ総数</param>
        /// <returns>ステップ値</returns>
        public static int GetHueStep(Color c, int stepCount)
        {
            // ステップ値を算出
            int step = (int)(c.GetHue() / HMAX * stepCount);
            // ステップ値がMAXなら-1する
            if (step == stepCount) step -= 1;
            return step;
        }

        /// <summary>
        /// 彩度のステップ値を取得
        /// </summary>
        /// <param name="c">色データ</param>
        /// <param name="stepCount">ステップ総数</param>
        /// <returns>ステップ値</returns>
        public static int GetSaturationStep(Color c, int stepCount)
        {
            // ステップ値を算出
            int step = (int)(c.GetSaturation() / SMAX * stepCount);
            // ステップ値がMAXなら-1する
            if (step == stepCount) step -= 1;
            return step;
        }

        /// <summary>
        /// 明度のステップ値を取得
        /// </summary>
        /// <param name="c">色データ</param>
        /// <param name="stepCount">ステップ総数</param>
        /// <returns>ステップ値</returns>
        public static int GetBrightnessStep(Color c, int stepCount)
        {
            // ステップ値を算出
            int step = (int)(c.GetBrightness() / BMAX * stepCount);
            // ステップ値がMAXなら-1する
            if (step == stepCount) step -= 1;
            return step;
        }

        /// <summary>
        /// HSB値の全ステップ値の等価チェック
        /// </summary>
        /// <param name="lhs">左辺値</param>
        /// <param name="rhs">右辺値</param>
        /// <param name="HStepCount">色相のステップ総数</param>
        /// <param name="SStepCount">彩度のステップ総数</param>
        /// <param name="BStepCount">明度のステップ総数</param>
        /// <returns>等価性</returns>
        public static bool EqualHSBSteps(Color lhs, Color rhs, int HStepCount, int SStepCount, int BStepCount)
        {
            return GetHueStep(lhs, HStepCount) == GetHueStep(rhs, HStepCount) &&
                    GetSaturationStep(lhs, SStepCount) == GetSaturationStep(rhs, SStepCount) &&
                    GetBrightnessStep(lhs, BStepCount) == GetBrightnessStep(rhs, BStepCount);
        }

        /// <summary>
        /// 補色を返す（彩度と明度はMAX）
        /// </summary>
        /// <param name="c">色データ</param>
        /// <returns>色データ</returns>
        public static Color GetComplementaryColor(Color c)
        {
            return ColorUtil.FromHSB(c.GetHue() + (ColorUtil.HMAX / 2.0F), ColorUtil.SMAX, ColorUtil.BMAX);
        }
 
        #endregion
    }
}
