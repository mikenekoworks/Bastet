using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bastet.Input.Gesture;

namespace Bastet.Input.Touch {
	public class TouchManager : MonoBehaviour {

		public TouchEventHandler EventTouchBegan;
        public TouchEventHandler EventTouchMoved;
        public TouchEventHandler EventTouchStationary;
        public TouchEventHandler EventTouchEnd;

        [SerializeField]
        private GestureSwipe cachedSwipeComponent;
        [SerializeField]
        private GestureDrag cachedDragComponent;

        public bool EnableGestureSwipe;
        public bool EnableGestureFlick;
        public bool EnableGesturePinch;
        public bool EnableGestureDrag;

		// Use this for initialization
		void Start() {
		}

        public void OnTouchBegan( TouchData touch_data ) {
            EventTouchBegan.Invoke( touch_data );
        }
        public void OnTouchMoved( TouchData touch_data ) {
            EventTouchMoved.Invoke( touch_data );
        }
        public void OnTouchStationary( TouchData touch_data ) {
            EventTouchStationary.Invoke( touch_data );
        }
        public void OnTouchEnd( TouchData touch_data ) {
            EventTouchEnd.Invoke( touch_data );
        }

        void AddGestureEvent( IGesture gesture ) {

            EventTouchBegan.AddListener( gesture.OnStart );
            EventTouchMoved.AddListener( gesture.OnUpdate );
            EventTouchStationary.AddListener( gesture.OnUpdate );
            EventTouchEnd.AddListener( gesture.OnFinish );
        }
        void RemoveGestureEvent( IGesture gesture ) {

            EventTouchBegan.RemoveListener( gesture.OnStart );
            EventTouchMoved.RemoveListener( gesture.OnUpdate );
            EventTouchStationary.RemoveListener( gesture.OnUpdate );
            EventTouchEnd.RemoveListener( gesture.OnFinish );
        }


        void OnEnable() {
            TouchInputUpdater.EventTouchBegan.AddListener( OnTouchBegan );
            TouchInputUpdater.EventTouchMoved.AddListener( OnTouchMoved );
            TouchInputUpdater.EventTouchStationary.AddListener( OnTouchStationary );
            TouchInputUpdater.EventTouchEnd.AddListener( OnTouchEnd );

            if ( EnableGestureSwipe == true ) {
                cachedSwipeComponent = GetComponent<GestureSwipe>();

                AddGestureEvent( cachedSwipeComponent );
                
            }
            if ( EnableGestureDrag == true ) {
                cachedDragComponent = GetComponent<GestureDrag>();
                AddGestureEvent( cachedDragComponent );
            }            

        }

        void OnDisable() {
            TouchInputUpdater.EventTouchBegan.RemoveListener( OnTouchBegan );
            TouchInputUpdater.EventTouchMoved.RemoveListener( OnTouchMoved );
            TouchInputUpdater.EventTouchStationary.RemoveListener( OnTouchStationary );
            TouchInputUpdater.EventTouchEnd.RemoveListener( OnTouchEnd );

            if ( cachedSwipeComponent != null ) {
                RemoveGestureEvent( cachedSwipeComponent );
            }

            if ( cachedDragComponent != null ) {
                RemoveGestureEvent( cachedDragComponent );
            }
        }


		// Update is called once per frame
		void Update() {
			TouchInputUpdater.Update();
		}

	}

}   // end of namespace Bastet.Input.Touch