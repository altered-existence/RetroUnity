using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AltX.Utilities
{
    //[CustomEditor(typeof(Downloader))]
    public class DowloaderEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            GUILayout.Label("Downloader: ", EditorStyles.boldLabel);
        }

        void OnButtonPressed()
        {
            //Download();
        }

    }

}
