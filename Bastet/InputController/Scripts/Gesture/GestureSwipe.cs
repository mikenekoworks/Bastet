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
        /// スワイプ方向が継続する角度
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

        public void OnStart( TouchData touch_data ) {

            Debug.Log( "Swipe Start." );

            fingerList.Add( CreateFingerData( touch_data ) );

        }
        public void OnUpdate( TouchData touch_data ) {
            //Debug.Log( "Swipe Update." );

            var finger_data = fingerList.Find( _ => _.FingerId == touch_data.FingerId );
            if ( finger_data == null ) {
                finger_data = CreateFingerData( touch_data );
                fingerList.Add( finger_data );
            }

            if ( touch_data.Phase == TouchPhase.Stationary ) {
                // 座標が動いていないので終了。
                if ( cachedDebugGLRenderer != null ) {
                    cachedDebugGLRenderer.AddLine( finger_data.StartPosition, finger_data.LastPosition, Color.red );
                }
                return;
            }


            finger_data.IsAvailable = false;

            if ( isReverseDirectionReset == true ) {

                Vector3 pos_diff = touch_data.Position;
                pos_diff -= finger_data.LastPosition;
                pos_diff.Normalize();

                float last_angle = Mathf.Atan2( finger_data.Direction.y, finger_data.Direction.x ) * Mathf.Rad2Deg;
                float new_angle = Mathf.Atan2( pos_diff.y, pos_diff.x ) * Mathf.Rad2Deg;

                float angle = Vector3.Dot( finger_data.Direction, pos_diff );

                if ( angle < 0 ) {
                    // スワイプの起点変更
                    finger_data.StartPosition = touch_data.Position;
                }

            }
            finger_data.LastPosition = touch_data.Position;

            if ( cachedDebugGLRenderer != null ) {
                cachedDebugGLRenderer.AddLine( finger_data.StartPosition, finger_data.LastPosition, Color.red );
            }

            //finger_data.LastPosition = touch_data.Position;
            //finger_data.Direction = finger_data.LastPosition - finger_data.StartPosition;

            //Debug.Log( new_pos_diff );

            //// 長辺を調べる。
            //if ( Mathf.Abs( new_pos_diff.x ) < Mathf.Abs( new_pos_diff.y ) ) {
            //    // 縦方向に長いのは判定としていらないので開始座標を更新する
            //    startPosition = new_pos;
            //    lastPosition = new_pos;

            //    return;
            //}

            // 横に長いので左右のどちらを向いているかを取得
            //float sign = Mathf.Sign( new_pos_diff.x );

            //// 前回の方向と比較
            //if ( LastPosition == StartPosition ) {
            //    // 前回と座標が同じ場合はLastの座標だけを更新して終了。
            //    lastPosition = new_pos;
            //    return;

            //}

            // 違いがある場合は向きとかを判定するよ。
            //Vector2 last_pos_diff = LastPosition - StartPosition;
            //float last_sign = Mathf.Sign( last_pos_diff.x );

            //if ( ( ( sign < 0 ) && ( last_sign < 0 ) ) || ( ( sign >= 0 ) && ( last_sign >= 0 ) ) ) {
            //    // ベクトルが同じ方向
            //} else {
            //    // ベクトルが違う方向なら終端を更新
            //    startPosition = new_pos;
            //    lastPosition = new_pos;
            //    return;
            //}

            //lastPosition = new_pos;

            //// 指定された閾値（mm）をインチ換算してDPIから必要なピクセル値に戻す
            //float need_pixel = MathUtility.MillimeterToPixel( Managers.MusicDataManager.Instance.Params.SwipeThreshould );
            //var v = ( LastPosition - StartPosition );

            //if ( Mathf.Abs( v.x ) > need_pixel ) {

            //    // スワイプが成功したよ
            //    isAvailable = true;

            //    if ( v.x < 0.0f ) {
            //        swipeDirection = NoteSwipeDirectionType.Left;
            //    } else {
            //        swipeDirection = NoteSwipeDirectionType.Right;
            //    }
            //}

        }
        public void OnFinish( TouchData touch_data ) {
            Debug.Log( "Swipe Finish." );

            // データ削除前にやることがあるなら先にやる

            // データの削除
            fingerList.RemoveAll( _ => _.FingerId == touch_data.FingerId );

        }

    }

}