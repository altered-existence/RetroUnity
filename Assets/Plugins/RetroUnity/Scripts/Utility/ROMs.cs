using AltX.UI;
using RetroUnity;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace AltX.Utilities
{
    public class ROMs
    {
        public GameManager gameManager;
        public static UIManager uiManager;
        public static string path;
        public int romArrayIndex;

        private static List<string> romList = new List<string>();

        public static List<string> RomList
        {
            get
            {
                return romList;
            }

            set
            {
                romList = value;
            }
        }

        public void Start()
        {

        }
        public static void GetInstalledroms() // Check "cores" folder for cores, count them, create a string array
        {
            try
            {
                GetPath();
                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] info = dir.GetFiles("*.smc");

                if (info.Length != 0)
                {
                    foreach (FileInfo f in info)
                    {
                        //coreArrayIndex = coreArrayIndex + 1;
                        RomList.Add(f.Name);
                        Debug.Log(f.Name);
                        //File.AppendText(Application.streamingAssetsPath + "/corelist.txt");
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
        }
        public static string GetPath()
        {
            path = (Application.streamingAssetsPath + "/roms");
            return path;
        }
    }
}
