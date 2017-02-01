using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bastet.Tweens.Core {
	public static class EasingFunction {

		/// <summary>
		/// 線形補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float Liner( float start_value, float end_value, float duration_time, float evaluate_time ) {

			if ( evaluate_time < 0.0f ) {
				return start_value;
			}
			float amount = end_value - start_value;
			return amount * Mathf.Clamp( evaluate_time, 0.0f, duration_time ) / duration_time;

		}

		/// <summary>
		/// 二次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InQuadratic( float start_value, float end_value, float duration_time, float evaluate_time ) {
		float amount = end_value - start_value;

			evaluate_time /= duration_time;
			return amount * evaluate_time * evaluate_time + start_value;
		}
		/// <summary>
		/// 二次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float OutQuadratic( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;

			evaluate_time /= duration_time;
			return -amount * evaluate_time * ( evaluate_time - 2 ) + start_value;
		}

		/// <summary>
		/// 二次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InOutQuadratic( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;

			evaluate_time /= duration_time / 2;
			if ( evaluate_time < 1 ) {
				return amount / 2 * evaluate_time * evaluate_time + start_value;
			}

			evaluate_time--;
			return -amount / 2 * ( evaluate_time * ( evaluate_time - 2 ) - 1 ) + start_value;
		}

		/// <summary>
		/// 三次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InCubic( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;

			evaluate_time /= duration_time;
			return amount * evaluate_time * evaluate_time * evaluate_time + start_value;

		}
		/// <summary>
		/// 三次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float OutCubic( float start_value, float end_value, float duration_time, float evaluate_time ) {
		float amount = end_value - start_value;

			evaluate_time /= duration_time;
			return -amount * evaluate_time * ( evaluate_time - 2 ) + start_value;
		}

	/// <summary>
	/// 三次関数補間
	/// </summary>
	/// <param name="start_value">開始値</param>
	/// <param name="end_value">終了値</param>
	/// <param name="duration_time">持続時間</param>
	/// <param name="evaluate_time">評価時間</param>
	/// <returns>評価値</returns>
	public static float InOutCubic( float start_value, float end_value, float duration_time, float evaluate_time ) {
		float amount = end_value - start_value;

			evaluate_time /= duration_time / 2;
			if ( evaluate_time < 1 ) {
				return amount / 2 * evaluate_time * evaluate_time * evaluate_time + start_value;
			}
			evaluate_time -= 2;

			return amount / 2 * ( evaluate_time * evaluate_time * evaluate_time + 2 ) + start_value;

		}

		/// <summary>
		/// 四次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InQuartic( float start_value, float end_value, float duration_time, float evaluate_time ) {
		float amount = end_value - start_value;
			evaluate_time /= duration_time;

			return amount * evaluate_time * evaluate_time * evaluate_time * evaluate_time + start_value;
		}
		/// <summary>
		/// 四次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float OutQuartic( float start_value, float end_value, float duration_time, float evaluate_time ) {
	float amount = end_value - start_value;

			evaluate_time /= duration_time;
			evaluate_time--;

			return -amount * ( evaluate_time * evaluate_time * evaluate_time * evaluate_time - 1 ) + start_value;
		}
		/// <summary>
		/// 四次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InOutQuartic( float start_value, float end_value, float duration_time, float evaluate_time ) {

			float amount = end_value - start_value;

			evaluate_time /= duration_time / 2;
			if ( evaluate_time < 1 ) {
				return amount / 2 * evaluate_time * evaluate_time * evaluate_time * evaluate_time + start_value;
			}
			evaluate_time -= 2;
			return -amount / 2 * ( evaluate_time * evaluate_time * evaluate_time * evaluate_time - 2 ) + start_value;

		}

		/// <summary>
		/// 五次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InQuintic( float start_value, float end_value, float duration_time, float evaluate_time ) {

			float amount = end_value - start_value;

			evaluate_time /= duration_time;
			return amount * evaluate_time * evaluate_time * evaluate_time * evaluate_time * evaluate_time + start_value;

		}

		/// <summary>
		/// 五次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float OutQuintic( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;

			evaluate_time /= duration_time;
			evaluate_time--;
			return amount * ( evaluate_time * evaluate_time * evaluate_time * evaluate_time * evaluate_time + 1 ) + start_value;

		}

		/// <summary>
		/// 五次関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InOutQuintic( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;

			evaluate_time /= duration_time / 2;
			if ( evaluate_time < 1 ) {
				return amount / 2 * evaluate_time * evaluate_time * evaluate_time * evaluate_time * evaluate_time + start_value;
			}
			evaluate_time -= 2;
			return amount / 2 * ( evaluate_time * evaluate_time * evaluate_time * evaluate_time * evaluate_time + 2 ) + start_value;

		}

		/// <summary>
		/// 指数関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InExponential( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;
			return amount * Mathf.Pow( 2, 10 * ( evaluate_time / duration_time - 1 ) ) + start_value;
		}

		/// <summary>
		/// 指数関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float OutExponential( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;
			return amount * ( -Mathf.Pow( 2, -10 * evaluate_time / duration_time ) + 1 ) + start_value;
		}

		/// <summary>
		/// 指数関数補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InOutExponential( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;

			evaluate_time /= duration_time / 2;
			if ( evaluate_time < 1 ) {
				return amount / 2 * Mathf.Pow( 2, 10 * ( evaluate_time - 1 ) ) + start_value;
			}
			evaluate_time--;
			return amount / 2 * ( -Mathf.Pow( 2, -10 * evaluate_time ) + 2 ) + start_value;

		}

		/// <summary>
		/// 正弦波形補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InSine( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;
			return -amount * Mathf.Cos( evaluate_time / duration_time * ( Mathf.PI / 2 ) ) + amount + start_value;
		}

		/// <summary>
		/// 正弦波形補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float OutSine( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;
			return amount * Mathf.Sin( evaluate_time / duration_time * ( Mathf.PI / 2 ) ) + start_value;
		}

		/// <summary>
		/// 正弦波形補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InOutSine( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;
			return -amount / 2 * ( Mathf.Cos( Mathf.PI * evaluate_time / duration_time ) - 1 ) + start_value;
		}

		/// <summary>
		/// 円形補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InCircular( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;

			evaluate_time /= duration_time;
			return -amount * ( Mathf.Sqrt( 1 - evaluate_time * evaluate_time ) - 1 ) + start_value;

		}
		/// <summary>
		/// 円形補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float OutCircular( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;

			evaluate_time /= duration_time;
			evaluate_time--;
			return amount * Mathf.Sqrt( 1 - evaluate_time * evaluate_time ) + start_value;

		}

		/// <summary>
		/// 円形補間
		/// </summary>
		/// <param name="start_value">開始値</param>
		/// <param name="end_value">終了値</param>
		/// <param name="duration_time">持続時間</param>
		/// <param name="evaluate_time">評価時間</param>
		/// <returns>評価値</returns>
		public static float InOutCircular( float start_value, float end_value, float duration_time, float evaluate_time ) {
			float amount = end_value - start_value;

			evaluate_time /= duration_time / 2;
			if ( evaluate_time < 1 ) {
				return -amount / 2 * ( Mathf.Sqrt( 1 - evaluate_time * evaluate_time ) - 1 ) + start_value;
			}
			evaluate_time -= 2;
			return amount / 2 * ( Mathf.Sqrt( 1 - evaluate_time * evaluate_time ) + 1 ) + start_value;

		}


//		//! Easing equation for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) ease-in, accelerating from zero velocity. The \a a parameter controls overshoot, the default producing a 10% overshoot.
//		inline float easeInBack( float t, float s = 1.70158f ) {
//			return t * t * ( ( s + 1 ) * t - s );
//		}

//		//! Easing equation for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) ease-in, accelerating from zero velocity. Functor edition. The \a a parameter controls overshoot, the default producing a 10% overshoot.
//		struct EaseInBack {
//			EaseInBack( float s = 1.70158f ) : mS( s ) { }
//			float operator()( float t ) { return easeInBack( t, mS );
//		}
//		float mS;
//	};

//	//! Easing equation for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) ease-out, decelerating from zero velocity. The \a a parameter controls overshoot, the default producing a 10% overshoot.
//	inline float easeOutBack( float t, float s = 1.70158f ) {
//		t -= 1;
//		return ( t * t * ( ( s + 1 ) * t + s ) + 1 );
//	}

//	//! Easing equation for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) ease-out, decelerating from zero velocity. Functor edition. The \a a parameter controls overshoot, the default producing a 10% overshoot.
//	struct EaseOutBack {
//		EaseOutBack( float s = 1.70158f ) : mS( s ) { }
//		float operator()( float t ) { return easeOutBack( t, mS );
//	}
//	float mS;
//};

////! Easing equation for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) ease-in/out, accelerating until halfway, then decelerating. The \a a parameter controls overshoot, the default producing a 10% overshoot.
//inline float easeInOutBack( float t, float s = 1.70158f ) {
//	t *= 2;
//	if ( t < 1 ) {
//		s *= 1.525f;
//		return 0.5f * ( t * t * ( ( s + 1 ) * t - s ) );
//	} else {
//		t -= 2;
//		s *= 1.525f;
//		return 0.5f * ( t * t * ( ( s + 1 ) * t + s ) + 2 );
//	}
//}

////! Easing equation for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) ease-in/out, accelerating until halfway, then decelerating. Functor edition. The \a a parameter controls overshoot, the default producing a 10% overshoot.
//struct EaseInOutBack {
//	EaseInOutBack( float s = 1.70158f ) : mS( s ) { }
//	float operator()( float t ) { return easeInOutBack( t, mS );
//}
//float mS;
//};

////! Easing equation for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) ease-out/in, decelerating until halfway, then accelerating. The \a a parameter controls overshoot, the default producing a 10% overshoot.
//inline float easeOutInBack( float t, float s ) {
//	if ( t < 0.5f ) return easeOutBack( 2 * t, s ) / 2;
//	return easeInBack( 2 * t - 1, s ) / 2 + 0.5f;
//}

////! Easing equation for a back (overshooting cubic easing: (s+1)*t^3 - s*t^2) ease-out/in, decelerating until halfway, then accelerating. Functor edition. The \a a parameter controls overshoot, the default producing a 10% overshoot.
//struct EaseOutInBack {
//	EaseOutInBack( float s = 1.70158f ) : mS( s ) { }
//	float operator()( float t ) { return easeOutInBack( t, mS );
//}
//float mS;
//};

	}

}
