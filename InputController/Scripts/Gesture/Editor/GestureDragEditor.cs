using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Bastet.Input.Gesture {

    [CustomEditor( typeof( GestureDrag ) )]
    public class GestureDragEditor : Editor {

        SerializedProperty scriptProperty;

        void OnEnable() {
            scriptProperty = serializedObject.FindProperty( "m_Script" );
        }

        void OnDisale() {
        }

        public override void OnInspectorGUI() {

            serializedObject.Update();

            GestureDrag gesture = ( GestureDrag )target;

            // スクリプト名表示
            using ( new EditorGUI.DisabledScope( true ) ) {
                EditorGUILayout.PropertyField( scriptProperty );
            }

            // ここにエディタコードを追加する。
            // DrawDefaultInspectorは必要に応じて削除してください。
            for ( int i = 0; i < gesture.FingerCount; ++i ) {

                EditorGUILayout.LabelField( "Finger Id: " + gesture.GetFingerData( i ).FingerId );

            }
            
            DrawDefaultInspector();
            serializedObject.ApplyModifiedProperties();
        }

    }

}   // end of namespace Bastet.Input.Gesture
