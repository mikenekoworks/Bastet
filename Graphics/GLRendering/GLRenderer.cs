using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bastet.Graphics.GLRendering {

    public class GLRenderer : MonoBehaviour {

        public Material DrawMaterial;

        public class LineData {
            public Vector2 v0;
            public Vector2 v1;
            public Color Color;
        }

        private List< LineData > lines = new List<LineData>();

        public void AddLine( Vector3 start, Vector3 end, Color color ) {

            LineData new_line = new LineData();
            new_line.v0 = GetComponent<Camera>().ScreenToViewportPoint( start );
            new_line.v1 = GetComponent<Camera>().ScreenToViewportPoint( end );
            new_line.Color = color;

            lines.Add( new_line );

        }

        void OnPostRender() {

            for ( int i = 0; i < lines.Count; ++i ) {
                DrawMaterial.color = lines[ i ].Color;

                Vector3[] p = new Vector3[ 2 ];
                p[ 0 ] = lines[ i ].v0;
                p[ 1 ] = lines[ i ].v1;

                GLDrawing.DrawLines( DrawMaterial, p );
            }

            lines.Clear();
        }

    }

}   // end of namespace Bastet.Graphics.GLRendering