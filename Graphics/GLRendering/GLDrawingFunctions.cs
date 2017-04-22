using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Bastet.Graphics.GLRendering {

    public static class GLDrawing {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mtx"></param>
        /// <param name="material"></param>
        /// <param name="v0"></param>
        /// <param name="v1"></param>
        public static void DrawLine( Material material, Vector3 v0, Vector3 v1 ) {

            material.SetPass( 0 );

            GL.PushMatrix();
            GL.LoadOrtho();

            GL.Begin( GL.LINES );

            GL.Vertex( v0 );
            GL.Vertex( v1 );

            GL.End();
            GL.PopMatrix();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mtx"></param>
        /// <param name="material"></param>
        /// <param name="pos"></param>
        public static void DrawLines( Material material, Vector3[] pos ) {

            if ( pos.Length < 1 ) {
                return;
            }

            material.SetPass( 0 );

            GL.PushMatrix();
            GL.LoadOrtho();

            GL.Begin( GL.LINES );

            for ( int i = 0; i < pos.Length - 1; ++i ) {
                GL.Vertex( pos[ i ] );
                GL.Vertex( pos[ i + 1 ] );
            }
            GL.End();
            GL.PopMatrix();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mtx"></param>
        /// <param name="material"></param>
        /// <param name="center"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public static void DrawRectangle( Material material, Vector3 center, float width, float height ) {

            float half_width = width / 2.0f;
            float half_height = height / 2.0f;

            Vector3 [] pos = new Vector3[ 5 ];
            pos[ 0 ] = new Vector3( center.x - half_width, center.y - half_height, 0.0f );
            pos[ 1 ] = new Vector3( center.x + half_width, center.y - half_height, 0.0f );
            pos[ 2 ] = new Vector3( center.x + half_width, center.y + half_height, 0.0f );
            pos[ 3 ] = new Vector3( center.x - half_width, center.y + half_height, 0.0f );
            pos[ 4 ] = pos[ 0 ];

            DrawLines( material, pos );

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mtx"></param>
        /// <param name="material"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="segments"></param>
        public static void DrawCircle( Material material, Vector3 center, float radius, int segments ) {

            float angle_diff = ( Mathf.PI * 2.0f ) / ( float )segments;
            Vector3[] pos = new Vector3[ segments + 1 ];

            float angle = 0.0f;
            for ( int i = 0; i < ( segments + 1 ); ++i ) {
                pos[ i ].x = center.x + Mathf.Cos( angle ) * radius;
                pos[ i ].y = center.y + Mathf.Sin( angle ) * radius;
                pos[ i ].z = 0.0f;
                angle += angle_diff;
            }

            DrawLines( material, pos );

        }

    }

}   // end of namespace Bastet.Graphics.GLRendering
