﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace distanceConverter {
     public static class FeetConverter {
        //private const double ratio = 0.3048;    // 定数
        public static readonly double ratio = 0.3048;   // 定数(外部にも公開する場合)

        // フィートからメートルを求める
        public static double FromMeter(double meter) {
            return meter * ratio;
        }

        // メートルからフィートを求める
        public static double ToMeter(double feet) {
            return feet / ratio;
        }
    }
}
