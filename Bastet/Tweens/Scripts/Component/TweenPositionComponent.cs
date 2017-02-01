using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bastet.Tweens.Core;

namespace Bastet.Tweens.Component {
	public class TweenPositionComponent : MonoBehaviour {

		public Vector3 From;
		public Vector3 To;

		public float DurationTime;
		public TypeLoopMode LoopMode;
		public TypeEasing Easing = TypeEasing.Linear;
		public AnimationCurve EasingCurve = AnimationCurve.Linear( 0.0f, 0.0f, 1.0f, 1.0f );
		public bool IsPlayOnAwake;

		TweenPosition cachedTweener;

		// Use this for initialization
		void Awake() {
			if ( IsPlayOnAwake == true ) {
				Play();
			}

		}

		public void Play() {

			if ( cachedTweener == null ) {
				cachedTweener = new TweenPosition();
			}
			cachedTweener.DurationTime = DurationTime;
			cachedTweener.LoopMode = LoopMode;
			cachedTweener.From = From;
			cachedTweener.To = To;
			cachedTweener.EasingCurve = EasingCurve;

			TweenManager.Instance.Register( cachedTweener );

		}

	}
}
