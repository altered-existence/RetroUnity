using RetroUnity;
using RetroUnity.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    
    public InputField CoreInput;
    public Text CoreInputText;
    public Text CoreNameText;
    public InputField RomInput;
    public Text RomInputText;
    public GameManager gameManager;
    //public string RetroInfo;

    void Start()
    {
        gameManager = GetComponent<GameManager>();
    }
    public void CoreNameChanged()
    {
        gameManager.CoreName = CoreInputText.text;
        //CoreNameText.text = LibretroWrapper.SystemInfo.library_name;
    }
    public void ROMNameChanged()
    {
        gameManager.RomName = RomInputText.text;
    }
    public void StartButtonPressed()
    {
        gameManager.LoadRom(gameManager.romPath + "/" + gameManager.RomName);
    }
}
