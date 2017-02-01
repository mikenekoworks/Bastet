using UnityEngine;
using System.Collections;

namespace Bastet.GeneralDesign {
	public class Singleton<T> where T : class {

		protected static T instance;

		public static T Instance
		{
			get
			{
				return instance;
			}
		}

		public static void CreateInstance() {
			instance = default( T );
		}

		public static void DestroyInstance() {
			instance = null;
		}

	}

}   // end of namespace Bastet.GeneralDesign
