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
    public class Cores
    {
        public GameManager gameManager;
        public static UIManager uiManager;
        public static string corePath;
        public int coreArrayIndex;
        public string[] coreListArray;
        public string[] coreNameArray;

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

        }
        public static void GetInstalledCores() // Check "cores" folder for cores, count them, create a string array
        {
            try
            {
                GetCorePath();
                DirectoryInfo dir = new DirectoryInfo(corePath);
                FileInfo[] info = dir.GetFiles("*.dll");

                if(info.Length != 0)
                {
                    foreach (FileInfo f in info)
                    {
                        //coreArrayIndex = coreArrayIndex + 1;
                        CoreList.Add(f.Name);
                        Debug.Log(f.Name);
                        //File.AppendText(Application.streamingAssetsPath + "/corelist.txt");
                    }
                }
            }
            catch(Exception e)
            {
                Debug.Log(e);
            }
    }
        public static string GetCorePath()
        {
            corePath = (Application.streamingAssetsPath + "/cores");
            if (!File.Exists(corePath + "*.dll"))
            {
                Debug.LogError("----> No Cores ");
                Debug.LogError("----> found in /cores folder");
                return "ERROR";
            }
            return corePath;
        }
    }
}

