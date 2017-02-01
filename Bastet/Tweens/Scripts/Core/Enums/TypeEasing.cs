using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bastet.Tweens.Core {
	public enum TypeEasing {
		Linear,				/// <summary>線形補間</summary>
		InQuadratic,        /// <summary>二次関数補間</summary>
		OutQuadratic,       /// <summary>二次関数補間</summary>
		InOutQuadratic,     /// <summary>二次関数補間</summary>
		InCubic,            /// <summary>三次関数補間</summary>
		OutCubic,           /// <summary>三次関数補間</summary>
		InOutCubic,         /// <summary>三次関数補間</summary>
		InQuartic,          /// <summary>四次関数補間</summary>
		OutQuartic,         /// <summary>四次関数補間</summary>
		InOutQuartic,       /// <summary>四次関数補間</summary>
		InQuintic,          /// <summary>五次関数補間</summary>
		OutQuintic,         /// <summary>五次関数補間</summary>
		InOutQuintic,       /// <summary>五次関数補間</summary>
		InExponential,      /// <summary>指数関数補間</summary>
		OutExponential,     /// <summary>指数関数補間</summary>
		InOutExponential,   /// <summary>指数関数補間</summary>
		InSine,             /// <summary>正弦波形補間</summary>
		OutSine,            /// <summary>正弦波形補間</summary>
		InOutSine,          /// <summary>正弦波形補間</summary>
		InCircular,         /// <summary>円補間</summary>
		OutCircular,        /// <summary>円補間</summary>
		InOutCircular,      /// <summary>円補間</summary>
		Custom,
	}

}