using RetroUnity;
using RetroUnity.Utility;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AltX.UI
{
    public class UIManager : MonoBehaviour
    {
        public Dropdown CoreDropdownList;
        public InputField CoreInput;
        public Text CoreInputText;
        public Text CoreNameText;
        public InputField RomInput;
        public Text RomInputText;
        public GameManager gameManager;
        public LibretroWrapper.Wrapper wrapper;

        public string platformInfo;
        [HideInInspector]
        public Text platformInfoText;
        //public string RetroInfo;

        void Start()
        {
            gameManager = GetComponent<GameManager>();
            platformInfo = (Application.platform).ToString();
            platformInfoText.text = platformInfo;
        }
        public void CoreNameChanged()
        {
            gameManager.CoreName = CoreInputText.text;
        }
        public void ROMNameChanged()
        {
            gameManager.RomName = RomInputText.text;
        }
        public void StartButtonPressed()
        {
            gameManager.LoadRom(gameManager.romPath + "/" + gameManager.RomName);
        }

        public void PopulateCoreList()
        {
            CoreDropdownList.AddOptions(Utilities.Cores.CoreList);
        }
    }
}

