using UnityEngine;
using System.Collections;

namespace Bastet.GeneralDesign {
	public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour {

		protected static T instance;

		public static T Instance
		{
			get
			{
				if ( instance == null ) {
					instance = ( T )FindObjectOfType( typeof( T ) );

					if ( instance == null ) {
						Debug.LogError( typeof( T ) + " is not instancing." );

						return null;
					}

				}

				return instance;
			}
		}

	}
}   // end of namespace Bastet.GeneralDesign