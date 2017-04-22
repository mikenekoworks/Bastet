using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bastet.Input.Touch;

namespace Bastet.Input.Gesture {

    public class GestureSwipe : MonoBehaviour, IGesture {

        public class FingerData {
            public int FingerId;
            private Vector3 startPosition;
            private Vector3 lastPosition;
            private Vector3 direction;
            private float length;

            public Vector3 StartPosition {
                get {
                    return startPosition;
                }
                set {
                    startPosition = value;
                    direction = ( lastPosition - startPosition ).normalized;
                    length = ( lastPosition - startPosition ).magnitude;
                }
            }
            public Vector3 LastPosition {
                get {
                    return lastPosition;
                }
                set {
                    lastPosition = value;
                    direction = ( lastPosition - startPosition ).normalized;
                    length = ( lastPosition - startPosition ).magnitude;
                }
            }

            public Vector3 Direction {
                get {
                    return direction;
                }
            }
            public float Length {
                get {
                    return length;
                }
            }
            public bool IsAvailable;
        }

        private List < FingerData > fingerList = new List<FingerData>();

        /// <summary>
        /// スワイプ方向が反対方向を向いたときスタート位置をリセットするか？
        /// </summary>
        [SerializeField]
        private bool isReverseDirectionReset;

        /// <summary>
        /// スワイプを検知する距離（単位はミリメートル）
        /// </summary>
        [SerializeField]
        private float distanceThreshold;

        [SerializeField]
        public GestureEventHandler EventSwipeStart;
        [SerializeField]
        public GestureSwipeEventHandler EventSwipeDetect;
        [SerializeField]
        public GestureEventHandler EventSwipeFinish;

        /// <summary>
        /// スワイプのデバッグ表示をGLで行うか？
        /// </summary>
        [SerializeField]
        private bool enableDebugGLRenderer;

        [SerializeField]
        private  Bastet.Graphics.GLRendering.GLRenderer cachedDebugGLRenderer;

        public int FingerCount {
            get {
                return fingerList.Count;
            }
        }

        public FingerData GetFingerData( int index ) {
            return fingerList[ index ];
        }

        private FingerData CreateFingerData( TouchData touch_data ) {
            FingerData new_finger = new FingerData();
            new_finger.FingerId = touch_data.FingerId;
            new_finger.StartPosition = touch_data.Position;
            new_finger.LastPosition = touch_data.Position;

            return new_finger;
        }

        /// <summary>
        /// スワイプの開始
        /// </summary>
        /// <param name="touch_data"></param>
        public void OnStart( TouchData touch_data ) {

            Debug.Log( "Swipe Start." );

            fingerList.Add( CreateFingerData( touch_data ) );

            EventSwipeStart.Invoke( touch_data.FingerId );

        }

        /// <summary>
        /// スワイプ情報の更新
        /// </summary>
        /// <param name="touch_data"></param>
        public void OnUpdate( TouchData touch_data ) {
            //Debug.Log( "Swipe Update." );

            var finger_data = fingerList.Find( _ => _.FingerId == touch_data.FingerId );
            if ( finger_data == null ) {
                finger_data = CreateFingerData( touch_data );
                fingerList.Add( finger_data );
            }

            if ( touch_data.Phase == TouchPhase.Stationary ) {
#if DEBUG
                // 座標が動いていないので終了。
                if ( cachedDebugGLRenderer != null ) {
                    cachedDebugGLRenderer.AddLine( finger_data.StartPosition, finger_data.LastPosition, Color.red );
                }
#endif
                return;
            }


            finger_data.IsAvailable = false;

            if ( isReverseDirectionReset == true ) {

                Vector3 pos_diff = touch_data.Position;
                pos_diff -= finger_data.LastPosition;
                pos_diff.Normalize();

                //float last_angle = Mathf.Atan2( finger_data.Direction.y, finger_data.Direction.x ) * Mathf.Rad2Deg;
                //float new_angle = Mathf.Atan2( pos_diff.y, pos_diff.x ) * Mathf.Rad2Deg;

                float angle = Vector3.Dot( finger_data.Direction, pos_diff );

                if ( angle < 0 ) {
                    // スワイプの起点変更
                    finger_data.StartPosition = touch_data.Position;
                }

            }
            finger_data.LastPosition = touch_data.Position;

            // イベントを発火
            if ( Math.UnitConvert.MillimeterToPixel( distanceThreshold, Screen.dpi ) < finger_data.Length ) {
                finger_data.IsAvailable = true;
                EventSwipeDetect.Invoke( finger_data.FingerId, finger_data.Direction, finger_data.Length );
            }

#if DEBUG
            if ( cachedDebugGLRenderer != null ) {
                cachedDebugGLRenderer.AddLine( finger_data.StartPosition, finger_data.LastPosition, Color.red );
            }
#endif
        }

        /// <summary>
        /// スワイプ処理の終了
        /// </summary>
        /// <param name="touch_data"></param>
        public void OnFinish( TouchData touch_data ) {
            Debug.Log( "Swipe Finish." );

            // データ削除前にやることがあるなら先にやる
            var finger_data = fingerList.Find( _ => _.FingerId == touch_data.FingerId );
            if ( finger_data == null ) {
                return;
            }

            finger_data.LastPosition = touch_data.Position;

            // イベントを発火
            if ( distanceThreshold < finger_data.Length ) {
                finger_data.IsAvailable = true;
                EventSwipeDetect.Invoke( finger_data.FingerId, finger_data.Direction, finger_data.Length );
            }

            EventSwipeFinish.Invoke( finger_data.FingerId );

            // データの削除
            fingerList.RemoveAll( _ => _.FingerId == touch_data.FingerId );

        }

    }

}