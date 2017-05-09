using UnityEngine;
using System.Collections;

public class EnumStringPopupAttribute : PropertyAttribute {

	public System.Type PopupType;
	public int SelectedIndex;
	//public string[] PopupStrings;

    public EnumStringPopupAttribute( System.Type popup_type )
	{
		this.PopupType = popup_type;
	}

}
