using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bastet.Input.Touch {
	public static class TouchInputUpdater {


		const int MOUSE_FINGER_ID = -1;

		static List<TouchData> touches = new List<TouchData>();

		public static TouchEventHandler EventTouchBegan = new TouchEventHandler();
		public static TouchEventHandler EventTouchMoved = new TouchEventHandler();
		public static TouchEventHandler EventTouchStationary = new TouchEventHandler();
		public static TouchEventHandler EventTouchEnd = new TouchEventHandler();

		public static int GetTouchDataCount() {
			return touches.Count;
		}

		public static TouchData GetTouchData( int index ) {
			return touches[ index ];
		}

        public static void DebugTouchData( int finger_id, Vector3 pos, TouchPhase phase ) {

            var touch_data = touches.Find( _ => _.FingerId == finger_id );
            if ( touch_data != null ) {
                TouchData new_touch = new TouchData( finger_id, pos );
                touches.Add( new_touch );
            }

            touch_data.Phase = phase;

            switch ( phase ) {
            case TouchPhase.Began:
                EventTouchBegan.Invoke( touch_data );
                break;
            case TouchPhase.Moved:
                EventTouchMoved.Invoke( touch_data );
                break;
            case TouchPhase.Stationary:
                EventTouchStationary.Invoke( touch_data );
                break;
            case TouchPhase.Ended:
            case TouchPhase.Canceled:
                EventTouchEnd.Invoke( touch_data );
                break;
            }

        }

		// Update is called once per frame
		public static void Update() {
            touches.RemoveAll( _ => ( ( _.Phase == TouchPhase.Ended ) || ( _.Phase == TouchPhase.Canceled ) || _.NoResponseCount > 10 ) );
            for ( int i = 0; i < touches.Count; ++i ) {
                ++touches[ i ].NoResponseCount;
            }

#if UNITY_EDITOR
			for ( int i = 0; i < 3; ++i ) {

				if ( UnityEngine.Input.GetMouseButtonDown( i ) == true ) {

					TouchData new_touch = new TouchData( MOUSE_FINGER_ID - i, UnityEngine.Input.mousePosition );
					touches.Add( new_touch );

					EventTouchBegan.Invoke( new_touch );

					continue;

				}
				if ( UnityEngine.Input.GetMouseButton( i ) == true ) {

					var touch_data = touches.Find( _ => _.FingerId == MOUSE_FINGER_ID - i );
					if ( touch_data != null ) {

						touch_data.Position = UnityEngine.Input.mousePosition;
                        touch_data.NoResponseCount = 0;
						if ( touch_data.DeltaPosition == Vector2.zero ) {
							touch_data.Phase = TouchPhase.Stationary;
                            EventTouchStationary.Invoke( touch_data );
						} else {
							touch_data.Phase = TouchPhase.Moved;
							EventTouchMoved.Invoke( touch_data );
						}

						continue;
					}

				}

				if ( UnityEngine.Input.GetMouseButtonUp( i ) == true ) {
					var touch_data = touches.Find( _ => _.FingerId == MOUSE_FINGER_ID - i );
					if ( touch_data != null ) {
						touch_data.Position = UnityEngine.Input.mousePosition;
                        touch_data.NoResponseCount = 0;
                        touch_data.Phase = TouchPhase.Ended;

						EventTouchEnd.Invoke( touch_data );
						continue;
					}
				}

			}
#else
			var touches = UnityEngine.Input.touches;
			for ( int i = 0; i < touches.Length; ++i ) {
				switch ( touches[ i ].phase ) {
				case TouchPhase.Began:
					TouchData new_touch = new TouchData( touches[ i ] );
					touches.Add( new_touch );
					break;
				case TouchPhase.Moved:
				case TouchPhase.Stationary:
					var touch_data = touches.Find( _ => _.FingerId == touches[ i ].fingerId );
					if ( touch_data != null ) {
                        touch_data.NoResponseCount = 0;
						touch_data.Position = touches[ i ].position;
						touch_data.Phase = touches[ i ].phase;
					} else {
						// TouchPhase.Beganがこないままこのフェイズがくるときがある。
						TouchData new_touch = new TouchData( touches[ i ] );
						touches.Add( new_touch );
					}
					break;
				case TouchPhase.Ended:
				case TouchPhase.Canceled:
					var touch_data = touches.Find( _ => _.FingerId == touches[ i ].fingerId );
					if ( touch_data != null ) {
                        touch_data.NoResponseCount = 0;
						touch_data.Position = touches[ i ].position;
						touch_data.Phase = touches[ i ].phase;
					}
					break;
				}
			}
#endif
        }


	}

}   // end of namespace Bastet.Input.Touch