using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bastet.Tweens.Core;

namespace Bastet.Tweens.Extension {
	public static class TweenPositionExtension {

		public static TweenPosition MoveTo( this Transform trans, Vector3 from, Vector3 to, float duration_time ) {

			TweenPosition tween = new TweenPosition();


			TweenManager.Instance.Register( tween );

			return null;
		}

	}
}