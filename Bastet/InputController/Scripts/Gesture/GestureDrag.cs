using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bastet.Input.Touch;

namespace Bastet.Input.Gesture {

    public class GestureDrag : MonoBehaviour, IGesture {

        public class FingerData {
            public int FingerId;
            public Vector3 StartPosition;
            public Vector3 Position;
        }

        private List < FingerData > fingerList = new List<FingerData>();

        public int FingerCount {
            get {
                return fingerList.Count;
            }
        }

        public FingerData GetFingerData( int index ) {
            return fingerList[ index ];
        }

        public void OnStart( TouchData touch_data ) {
            Debug.Log( "DragStart" );

            FingerData new_finger = new FingerData();
            new_finger.FingerId = touch_data.FingerId;
            new_finger.StartPosition = touch_data.Position;
            new_finger.Position = touch_data.Position;

            fingerList.Add( new_finger );

        }
        public void OnUpdate( TouchData touch_data ) {
            Debug.Log( "DragUpdate" );

            var finger_data = fingerList.Find( _ => _.FingerId == touch_data.FingerId );
            if ( finger_data != null ) {
                finger_data.Position = touch_data.Position;
            }

        }

        public void OnFinish( TouchData touch_data ) {
            Debug.Log( "DragEnd" );

            // データ削除前にやることがあるなら先にやる

            // データの削除
            fingerList.RemoveAll( _ => _.FingerId == touch_data.FingerId );

        }

    }

}