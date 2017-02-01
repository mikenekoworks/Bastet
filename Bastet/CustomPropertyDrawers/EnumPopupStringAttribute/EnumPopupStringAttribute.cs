using UnityEngine;
using System.Collections;

public class EnumPopupStringAttribute : PropertyAttribute {

	public System.Type PopupType;
	public int SelectedIndex;
	//public string[] PopupStrings;

	public EnumPopupStringAttribute ( System.Type popup_type )
	{
		this.PopupType = popup_type;
	}

}
