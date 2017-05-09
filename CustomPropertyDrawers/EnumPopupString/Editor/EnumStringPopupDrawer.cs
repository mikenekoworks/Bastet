using UnityEngine;
using UnityEditor;
using System;
using System.Collections.Generic;

[CustomPropertyDrawer( typeof( EnumStringPopupAttribute ) )]
public class EnumStringPopupDrawer : PropertyDrawer {

	public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {

        EnumStringPopupAttribute popup = ( EnumStringPopupAttribute )attribute;

		System.Array array = System.Enum.GetValues( popup.PopupType );
		string[] popup_list = new string[ array.Length ];
		for ( int i = 0; i < array.Length; ++i ) {
			popup_list[ i ] = array.GetValue( i ).ToString();
		}
		
		int select_index = 0;
		for ( int i = 0; i < array.Length; ++i ) {
			if ( popup_list[ i ] == property.stringValue ) {
				select_index = i;
			}
		}

		EditorGUI.BeginChangeCheck ();
		select_index = EditorGUI.Popup ( position, property.name, select_index, popup_list );
		if (EditorGUI.EndChangeCheck ()) {
			property.stringValue = popup_list[ select_index ].ToString();
			
		}
	}
	
}
