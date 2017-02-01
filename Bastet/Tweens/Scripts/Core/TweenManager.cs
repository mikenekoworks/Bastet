using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bastet.Tweens.Core {

    public class TweenManager : Bastet.GeneralDesign.SingletonMonoBehaviour<TweenManager> {

		List<TweenerBase> tweens = new List<TweenerBase>();

		public void Register( TweenerBase tweener ) {

			tweens.Add( tweener );

		}

		public void Unregister( TweenerBase tweener ) {
			tweens.Remove( tweener );
		}

		// Update is called once per frame
		void Update() {

			for ( int i = 0; i < tweens.Count; ++i ) {

				float delta_time = Time.deltaTime;
				if ( tweens[ i ].unscaledTime == true ) {
					delta_time = Time.unscaledDeltaTime;
				}
				tweens[ i ].OnUpdate( delta_time );

			}

		}


	}

}
