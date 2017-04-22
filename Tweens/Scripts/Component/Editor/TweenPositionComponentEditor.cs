using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Bastet.Tweens.Core;

namespace Bastet.Tweens.Component {

	[CustomEditor( typeof( TweenPositionComponent ) )]
	public class TweenPositionComponentEditor : Editor {

		SerializedProperty scriptProperty;

		SerializedProperty fromProperty;
		SerializedProperty toProperty;
		SerializedProperty durationTimeProperty;
		SerializedProperty loopModeProperty;
		SerializedProperty easingProperty;
		SerializedProperty curveProperty;
		SerializedProperty isPlayOnAwakeProperty;

		void OnEnable() {
			scriptProperty = serializedObject.FindProperty( "m_Script" );
			fromProperty = serializedObject.FindProperty( "From" );
			toProperty = serializedObject.FindProperty( "To" );
			durationTimeProperty = serializedObject.FindProperty( "DurationTime" );
			loopModeProperty = serializedObject.FindProperty( "LoopMode" );
			easingProperty = serializedObject.FindProperty( "Easing" );
			curveProperty = serializedObject.FindProperty( "EasingCurve" );
			isPlayOnAwakeProperty = serializedObject.FindProperty( "IsPlayOnAwake" );
		}

		public override void OnInspectorGUI() {
			serializedObject.Update();
			using ( new EditorGUI.DisabledScope( true ) ) {
				EditorGUILayout.PropertyField( scriptProperty );
			}

			EditorGUILayout.PropertyField( fromProperty );
			EditorGUILayout.PropertyField( toProperty );
			EditorGUILayout.PropertyField( durationTimeProperty );
			EditorGUILayout.PropertyField( loopModeProperty );

			// アニメーションカーブの変更
			EditorGUI.BeginChangeCheck();
			EditorGUILayout.PropertyField( easingProperty );
			if ( easingProperty.enumValueIndex == (int)TypeEasing.Custom ) {
				EditorGUILayout.PropertyField( curveProperty, new GUIContent( "Animation Curve" ), GUILayout.Height( EditorGUIUtility.singleLineHeight * 3.0f ) );
			}
			if ( EditorGUI.EndChangeCheck() == true ) {

			}

			EditorGUILayout.PropertyField( isPlayOnAwakeProperty, new GUIContent( "Play On Awake" ) );

			//DrawDefaultInspector();
			serializedObject.ApplyModifiedProperties();
		}
	}

}