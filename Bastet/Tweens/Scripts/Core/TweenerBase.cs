using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bastet.Tweens.Core {
	public abstract class TweenerBase {

		[SerializeField]
		protected int Id;

		[SerializeField]
		protected GameObject targetObject;

		[SerializeField]
		public float DurationTime;

		[SerializeField]
		protected TypeEasing eaging;

		[SerializeField]
		private AnimationCurve easingCurve;

		[SerializeField]
		protected TypeLoopMode loopMode;

		[SerializeField]
		public bool unscaledTime;

		protected bool isPlaying;
		protected bool isForward;
		protected float startTime;
		protected float amount;
		protected float progress;

		protected float normalizeTime;

		protected bool IsPlayOnAwake;

		public float NormalizeTime
		{
			get
			{
				return normalizeTime;
			}
		}
		[SerializeField]
		public AnimationCurve EasingCurve
		{
			get
			{
				return easingCurve;
			}
			set
			{
				easingCurve = value;
			}
		}

		public bool IsPlaying
		{
			get
			{
				return isPlaying;
			}
		}

		public TypeLoopMode LoopMode
		{
			get
			{
				return loopMode;
			}
			set
			{
				loopMode = value;
			}
		}

		public TweenerBase() {
			easingCurve = new AnimationCurve( new Keyframe( 0.0f, 0.0f ), new Keyframe( 1.0f, 1.0f ) );
		}

		public void PlayForward( float start_time ) {
			isForward = true;

			startTime = start_time;
			progress = startTime / DurationTime;
			amount = CalculateAmountValue();

			Play();
		}
		public void PlayBackward( float start_time ) {
			isForward = false;
			startTime = start_time;
			progress = 1.0f - ( startTime / DurationTime );
			amount = -CalculateAmountValue();

			Play();
		}

		protected float CalculateAmountValue() {
			return 1.0f / DurationTime;
		}
		protected abstract void Play();
		public abstract void Stop();
		public abstract void Sample( float evaluate_time );
		public void OnUpdate( float delta_time ) {

			progress += ( amount * delta_time );

			bool is_finish = false;
			switch ( LoopMode ) {
			case TypeLoopMode.Once:

				if ( progress > 1.0f ) {
					progress = 1.0f;

					is_finish = true;
				}
				break;
			case TypeLoopMode.Loop:
				if ( progress > 1.0f ) {
					progress = progress - Mathf.Floor( progress );
				}
				break;

			case TypeLoopMode.PingPong:

				if ( progress > 1.0f ) {
					progress = progress - Mathf.Floor( progress );
				}

				break;
			}

			normalizeTime = progress;

			Sample( normalizeTime );

			if ( is_finish == true ) {
				isPlaying = false;
			}

		}

	}

}