using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bastet.Input.Touch;

public class TouchDataReciever : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTouchBegan( TouchData touch_data ) {
        Debug.Log( "Finger Id: " + touch_data.FingerId + " Pos: " + touch_data.Position + " Delta: " + touch_data.DeltaPosition + " State: " + touch_data.Phase );
    }
    public void OnTouchMoved( TouchData touch_data ) {
        Debug.Log( "Finger Id: " + touch_data.FingerId + " Pos: " + touch_data.Position + " Delta: " + touch_data.DeltaPosition + " State: " + touch_data.Phase );
    }
    public void OnTouchStationary( TouchData touch_data ) {
        Debug.Log( "Finger Id: " + touch_data.FingerId + " Pos: " + touch_data.Position + " Delta: " + touch_data.DeltaPosition + " State: " + touch_data.Phase );
    }
    public void OnTouchEnd( TouchData touch_data ) {
        Debug.Log( "Finger Id: " + touch_data.FingerId + " Pos: " + touch_data.Position + " Delta: " + touch_data.DeltaPosition + " State: " + touch_data.Phase );
    }

}
