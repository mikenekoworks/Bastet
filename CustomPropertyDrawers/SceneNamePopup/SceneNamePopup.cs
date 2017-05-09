using UnityEngine;
using System.Collections;

public class SceneNamePopupAttribute : PropertyAttribute {

    public string Caption;

    public SceneNamePopupAttribute( string caption )
	{
        Caption = caption;
	}

}
