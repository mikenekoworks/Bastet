using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Bastet.Input.Touch;

namespace Bastet.Input.Gesture {

    [System.Serializable]
    public class GestureEvent : UnityEvent< int > { }

    [System.Serializable]
    public class GestureSwipeEvent : UnityEvent<int, Vector3, float> { }

}