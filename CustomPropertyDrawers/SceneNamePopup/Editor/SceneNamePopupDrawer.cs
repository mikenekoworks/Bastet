using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System;
using System.Collections.Generic;

[CustomPropertyDrawer( typeof( SceneNamePopupAttribute ) )]
public class SceneNamePopupDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

        SceneNamePopupAttribute popup = ( SceneNamePopupAttribute )attribute;

        List< string > scenes = new List<string>();
        foreach ( var scene in EditorBuildSettings.scenes ) {
            scenes.Add( System.IO.Path.GetFileNameWithoutExtension( scene.path ) );
        }

        int select_index = 0;
        for ( int i = 0; i < scenes.Count; ++i ) {
            if ( scenes[ i ] == property.stringValue ) {
                select_index = i;
            }
        }

        EditorGUI.BeginChangeCheck ();
        select_index = EditorGUI.Popup( position, popup.Caption, select_index, scenes.ToArray() );
        if (EditorGUI.EndChangeCheck ()) {
            property.stringValue = scenes[ select_index ];
        }

	}
	
}
