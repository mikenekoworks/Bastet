using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Bastet.Input.Touch;

namespace Bastet.Input.Gesture {

    public interface IGesture {

        int FingerCount {
            get;
        }

        void OnStart( TouchData touch_data );
        void OnUpdate( TouchData touch_data );
        void OnFinish( TouchData touch_data );

    }

}   // end of namespace Bastet.Input.Gesture
