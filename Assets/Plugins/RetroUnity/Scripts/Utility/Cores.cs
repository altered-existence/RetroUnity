// Altered Existence - Set Path Utility
// Set a File System Path as a string

using AltX.UI;
using RetroUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AltX.Utilities
{
    public class Cores : MonoBehaviour
    {
        public GameManager gameManager;
        public UIManager uiManager;
        public string path;
        public int coreArrayIndex;

        private static List<string> coreList = new List<string>();

        public static List<string> CoreList
        {
            get
            {
                return coreList;
            }

            set
            {
                coreList = value;
            }
        }

        public void Start()
        {
            GetPath();

        }
        public void GetInstalledCores() // Check "cores" folder for cores, count them, create a string array
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] info = dir.GetFiles("*.dll");

            foreach (FileInfo f in info)
            {
                //coreArrayIndex = coreArrayIndex + 1;
                CoreList.Add(f.Name);
                Debug.Log(f.Name);
                //File.AppendText(Application.streamingAssetsPath + "/corelist.txt");
            }
        }
        public string GetPath()
        {
            path = (Application.streamingAssetsPath + "/cores");
            return path;
        }
    }
}

