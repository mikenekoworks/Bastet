using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bastet.Extensions {

    public static class GameObjectExtension {

        public static T GetOrAddComponent<T>( this GameObject go ) where T : Component {

            T component = go.GetComponent<T>();
            if ( component == null ) {
                component = go.AddComponent<T>();
            }

            return component;

        }

    }

}