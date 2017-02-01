using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using Bastet.Input.Gesture;
using Bastet.Extensions;

namespace Bastet.Input.Touch {

	[CustomEditor( typeof( TouchManager ) )]
	public class TouchManagerEditor : Editor {

		SerializedProperty scriptProperty;

        bool eventFoldout = false;
        SerializedProperty eventTouchBeganProperty;
        SerializedProperty eventTouchMovedProperty;
        SerializedProperty eventTouchStationaryProperty;
        SerializedProperty eventTouchEndProperty;

        SerializedProperty enableGestureSwipeProperty;
        SerializedProperty enableGestureFlickProperty;
        SerializedProperty enableGesturePinchProperty;
        SerializedProperty enableGestureDragProperty;

        SerializedProperty cachedGestureSwipeProperty;
        SerializedProperty cachedGestureDragProperty;

		void OnEnable() {
			scriptProperty = serializedObject.FindProperty( "m_Script" );

            eventTouchBeganProperty = serializedObject.FindProperty( "EventTouchBegan" );
            eventTouchMovedProperty = serializedObject.FindProperty( "EventTouchMoved" );
            eventTouchStationaryProperty = serializedObject.FindProperty( "EventTouchStationary" );
            eventTouchEndProperty = serializedObject.FindProperty( "EventTouchEnd" );

            enableGestureSwipeProperty = serializedObject.FindProperty( "EnableGestureSwipe" );
            enableGestureFlickProperty = serializedObject.FindProperty( "EnableGestureFlick" );
            enableGesturePinchProperty = serializedObject.FindProperty( "EnableGesturePinch" );
            enableGestureDragProperty = serializedObject.FindProperty( "EnableGestureDrag" );

            cachedGestureSwipeProperty = serializedObject.FindProperty( "cachedSwipeComponent" );
            cachedGestureDragProperty = serializedObject.FindProperty( "cachedDragComponent" );
        }


        //private static T GetOrAddComponent<T>( GameObject go ) where T : Component {

        //    T component = go.GetComponent<T>();
        //    if ( component == null ) {
        //        component = go.AddComponent< T >();
        //    }

        //    return component;

        //}

		public override void OnInspectorGUI() {

            TouchManager manager = (TouchManager)target;

			serializedObject.Update();
			using ( new EditorGUI.DisabledScope( true ) ) {
				EditorGUILayout.PropertyField( scriptProperty );
			}

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField( enableGestureSwipeProperty );
            if ( EditorGUI.EndChangeCheck() == true ) {
                if ( enableGestureSwipeProperty.boolValue == true ) {
                    cachedGestureSwipeProperty.objectReferenceValue = manager.gameObject.GetOrAddComponent<GestureSwipe>();
                } else {
                    cachedGestureSwipeProperty.objectReferenceValue = null;
                }
            }

            using ( new EditorGUI.DisabledScope( true ) ) {
                EditorGUILayout.PropertyField( enableGestureFlickProperty );
                EditorGUILayout.PropertyField( enableGesturePinchProperty );
            }

            EditorGUI.BeginChangeCheck();
            EditorGUILayout.PropertyField( enableGestureDragProperty );
            if ( EditorGUI.EndChangeCheck() == true ) {
                if ( enableGestureDragProperty.boolValue == true ) {
              
                    var comp =  manager.gameObject.GetOrAddComponent<GestureDrag>();
                    cachedGestureDragProperty.objectReferenceValue = comp;

                } else {
                    cachedGestureDragProperty.objectReferenceValue = null;
                }
            }

            eventFoldout = EditorGUILayout.Foldout( eventFoldout, "Touch Events" );
            if ( eventFoldout == true ) {

                EditorGUILayout.PropertyField( eventTouchBeganProperty );
                EditorGUILayout.PropertyField( eventTouchMovedProperty );
                EditorGUILayout.PropertyField( eventTouchStationaryProperty );
                EditorGUILayout.PropertyField( eventTouchEndProperty );

            }

//			DrawDefaultInspector();
			serializedObject.ApplyModifiedProperties();
		}

	}

}   // end of namespace Bastet.Input.Touch
