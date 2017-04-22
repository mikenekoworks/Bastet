using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Bastet.Input.Touch;

namespace Bastet.Input.Gesture {

    [System.Serializable]
    public class GestureEventHandler : UnityEvent< int > { }

    [System.Serializable]
    public class GestureSwipeEventHandler : UnityEvent<int, Vector3, float> { }

}