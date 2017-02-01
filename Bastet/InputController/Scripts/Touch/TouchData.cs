using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bastet.Input.Touch {

    public class TouchData {
        public int FingerId;
        public TouchPhase Phase;

        public int NoResponseCount;

        private Vector2 position;
        private Vector2 deltaPosition;

        public Vector2 Position {
            get {
                return position;
            }
            set {
                deltaPosition = value - position;
                position = value;
            }
        }
        public Vector2 DeltaPosition {
            get {
                return deltaPosition;
            }
        }

        public TouchData( UnityEngine.Touch touch ) {
            FingerId = touch.fingerId;
            Phase = touch.phase;
            Position = touch.position;
        }

        public TouchData( int finger_id, Vector2 pos ) {
            FingerId = finger_id;
            Position = pos;

            Phase = TouchPhase.Began;
        }

    }

}   // end of namespace Bastet.Input.Touch