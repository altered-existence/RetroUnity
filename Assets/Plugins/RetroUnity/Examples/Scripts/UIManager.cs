using RetroUnity;
using RetroUnity.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

namespace AltX.UI
{
    public class UIManager : MonoBehaviour
    {
        // Dropdowns
        public Dropdown CoreDropdownList;
        public Dropdown.OptionData[] CoreDropdownOptionData;
        public Dropdown RomDropdownList;
        public Dropdown.OptionData[] RomDropdownOptionData;
        // Lists
        public GameObject CoreButtonListObject;
        public GameObject ROMButtonListObject;

        public Text CoreNameText;

        public GameManager gameManager;
        public LibretroWrapper.Wrapper wrapper;

        public string platformInfo;
        //[HideInInspector]
        public Text platformInfoText;
        //public string RetroInfo;

        void Start()
        {
            gameManager = GetComponent<GameManager>();
            platformInfo = (Application.platform).ToString();
            platformInfoText.text = platformInfo;
        }
        public void StartButtonPressed()
        {
            gameManager.LoadRom(gameManager.romPath + "/" + gameManager.RomName);
        }
        public void OnCoreDropdownChange()
        {
            gameManager.CoreFileName = CoreDropdownOptionData[CoreDropdownList.value].text;
            
        }
        public void OnRomDropdownChange()
        {
            gameManager.RomName = RomDropdownOptionData[RomDropdownList.value].text;
        }
        public void PopulateCoreList()
        {
            CoreDropdownList.AddOptions(Utilities.Cores.CoreList);
            CoreDropdownOptionData = CoreDropdownList.options.ToArray<Dropdown.OptionData>();
        }
        public void PopulateRomList()
        {
            RomDropdownList.AddOptions(Utilities.ROMs.RomList);
            RomDropdownOptionData = RomDropdownList.options.ToArray<Dropdown.OptionData>();
        }
    }
}

