using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using RetroUnity;
using RetroUnity.Utility;

namespace AltX.UI {

    public class UIManager : MonoBehaviour
    {
        public GameManager gameManager;

        public Dropdown CoreDropdownList;
        public Dropdown.OptionData[] CoreDropdownOptionData;
        //public GameObject CoreButtonPrefab;
        //public Dropdown RomDropdownList;
        //public Dropdown.OptionData[] RomDropdownOptionData;
        public GameObject RomButtonPrefab;
        public InputField CoreInput;
        public Text CoreInputText;
        public Text CoreNameText;
        public InputField RomInput;
        public Text RomInputText;
        
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
            gameManager.LoadRom(gameManager.romPath + "/" + gameManager.RomFileName);
        }
        /// <summary>
        /// Cores
        /// </summary>
        public void CoreNameChanged()
        {
            gameManager.CoreFileName = CoreInputText.text;
            //CoreNameText.text = LibretroWrapper.SystemInfo().library_name;
        }
        public void OnCoreDropdownChange()
        {
            gameManager.CoreFileName = CoreDropdownOptionData[CoreDropdownList.value].text;
            //CoreNameText.text = CoreNameChanged().TrimEnd('_', 'l', 'i', 'b', 'r', 'e', 't', 'r', 'o', '.', 'd', 'l', 'l').ToUpper();
        }
        public void PopulateCoreList()
        {
            CoreDropdownList.AddOptions(Utilities.Cores.CoreList);
            CoreDropdownOptionData = CoreDropdownList.options.ToArray<Dropdown.OptionData>();
        }
        /// <summary>
        /// ROMs
        /// </summary>
        public void ROMNameChanged()
        {
            gameManager.RomFileName = RomInputText.text;
        }
        //public void OnRomDropdownChange()
        //{
        //    gameManager.RomName = RomDropdownOptionData[RomDropdownList.value].text;
        //    RomNameChanged();
        //}

        //public void PopulateRomList()
        //{
        //    RomDropdownList.AddOptions(Utilities.ROMs.RomList);
        //    RomDropdownOptionData = RomDropdownList.options.ToArray<Dropdown.OptionData>();
        //}
    }
}

