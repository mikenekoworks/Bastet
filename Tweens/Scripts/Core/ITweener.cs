using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bastet {
	public interface ITweener {

		void Play();

		void Stop();

		void Sample( float evaluate_time );

		void OnUpdate();
	}

}