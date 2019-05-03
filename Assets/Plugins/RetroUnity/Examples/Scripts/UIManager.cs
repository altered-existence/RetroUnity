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
        public Dropdown CoreDropdownList;
        public Dropdown.OptionData[] CoreDropdownOptionData;
        public Dropdown RomDropdownList;
        public Dropdown.OptionData[] RomDropdownOptionData;
        public InputField CoreInput;
        private Text coreInputText;
        public Text CoreNameText;
        public InputField RomInput;
        public Text RomInputText;
        public GameManager gameManager;
        public LibretroWrapper.Wrapper wrapper;

        public string platformInfo;
        [HideInInspector]
        public Text platformInfoText;
        private Dropdown.OptionData allSelectables;
        private char[] trim = { '.', 'd', 'l', 'l' };
        public Text CoreInputText
        {
            get
            {
                return coreInputText;
            }

            set
            {
                coreInputText = value;
            }
        }

        //public string RetroInfo;

        void Start()
        {
            gameManager = GetComponent<GameManager>();
            platformInfo = (Application.platform).ToString();
            platformInfoText.text = platformInfo;
        }
        public void CoreNameChanged()
        {
            CoreInput.text = gameManager.CoreName;
        }
        public void RomNameChanged()
        {
            RomInput.text = gameManager.RomName;
        }
        public void StartButtonPressed()
        {
            gameManager.LoadRom(gameManager.romPath + "/" + gameManager.RomName);
        }
        public void OnCoreDropdownChange()
        {
            gameManager.CoreName = CoreDropdownOptionData[CoreDropdownList.value].text;
            CoreNameChanged();
        }
        public void OnRomDropdownChange()
        {
            gameManager.RomName = RomDropdownOptionData[RomDropdownList.value].text;
            RomNameChanged();
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

