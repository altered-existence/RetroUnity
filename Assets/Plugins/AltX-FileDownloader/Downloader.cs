using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEditor;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace AltX.Utilities
{
    [AddComponentMenu("AltX/Downloader")]
    public class Downloader : MonoBehaviour
    {
        public string downloadURL;
        public Text downloadURLText;
        public string downloadPath;
        public Text downloadPathText;
        public string downloadFilename;
        public Text downloadFilenameText;
        [HideInInspector]
        public float downloadSizeMB;
        [HideInInspector]
        public int downloadPercent;

        private void Awake()
        {
            downloadPath = (Application.streamingAssetsPath + "/downloads");
        }
        private void Start()
        {
            UpdateUI();
        }
        // Update is called once per frame
        void Update()
        {

        }
        public void Download()
        {
            UpdateUI();
            using (var client = new WebClient())
            {
                client.DownloadFile(downloadURL + "/" + downloadFilename, downloadPath + "/" + downloadFilename);
            }
        }
        void UpdateUI()
        {
            downloadURLText.text = downloadURL;
            downloadPathText.text = downloadPath;
            downloadFilenameText.text = downloadFilename;
        }
    }

}

