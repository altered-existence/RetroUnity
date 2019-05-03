using RetroUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AltX.Utilities
{
    public class ROMs : MonoBehaviour
    {
        public GameManager gameManager;
        public string RomPath; // Set from Cores.cs

        List<string> romList = new List<string>();

        void Start()
        {
            
        }
    }
}
