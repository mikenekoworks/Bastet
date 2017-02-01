using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Bastet.Extensions;

namespace Bastet.Input.Gesture {

    [CustomEditor( typeof( GestureSwipe ) )]
    public class GestureSwipeEditor : Editor {

        SerializedProperty scriptProperty;
        SerializedProperty isReverseDirectionResetProperty;
        SerializedProperty angleThreshouldProperty;
        SerializedProperty enableDebugLineRendererProperty;
        SerializedProperty cachedDebugLineRendererProperty;

        void OnEnable() {
            scriptProperty = serializedObject.FindProperty( "m_Script" );
            isReverseDirectionResetProperty = serializedObject.FindProperty( "isReverseDirectionReset" );
            enableDebugLineRendererProperty = serializedObject.FindProperty( "enableDebugGLRenderer" );
            cachedDebugLineRendererProperty = serializedObject.FindProperty( "cachedDebugGLRenderer" );
        }

        void OnDisale() {
        }

        public override void OnInspectorGUI() {

            serializedObject.Update();

            GestureSwipe gesture = ( GestureSwipe )target;

            // スクリプト名表示
            using ( new EditorGUI.DisabledScope( true ) ) {
                EditorGUILayout.PropertyField( scriptProperty );
            }

            EditorGUILayout.PropertyField( isReverseDirectionResetProperty );

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField( enableDebugLineRendererProperty );
            if ( EditorGUI.EndChangeCheck() == true ) {
                
                if ( enableDebugLineRendererProperty.boolValue == true ) {

                    var comp = Camera.main.gameObject.GetOrAddComponent<Bastet.Graphics.GLRendering.GLRenderer>();
                    cachedDebugLineRendererProperty.objectReferenceValue = comp;

                    if ( comp.DrawMaterial == null ) {
                        comp.DrawMaterial = new Material( Shader.Find ("Unlit/Color") );
                    }

                } else {
                    cachedDebugLineRendererProperty.objectReferenceValue = null;
                }


            }

            // ここにエディタコードを追加する。
            // DrawDefaultInspectorは必要に応じて削除してください。
            for ( int i = 0; i < gesture.FingerCount; ++i ) {

                EditorGUILayout.LabelField( "Finger Id: " + gesture.GetFingerData( i ).FingerId );

            }
            
            //DrawDefaultInspector();
            serializedObject.ApplyModifiedProperties();
        }

    }

}   // end of namespace Bastet.Input.Gesture
