using RetroUnity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AltX.UI
{
    public class ROMListButton : MonoBehaviour
    {
        public GameManager gameManager;
        public string coreFileName;
        public string coreName;
        public string romFileName;
        public string romName;

        public Sprite platformIcon; // SNES.png
        public Sprite platformMediaIcon; // SNES-Cartridge.png

        public Image iconSlot;
        public Text romNameSlot;

        private void Start()
        {
            gameManager = GameObject.Find("Libretro").GetComponent<GameManager>();
            romNameSlot.text = romName;
            iconSlot.sprite = platformIcon;
        }
        public void OnPressed()
        {
            gameManager.CoreFileName = coreFileName;
            gameManager.RomName = romFileName;
            gameManager.LoadRom(gameManager.romPath + "/snes/" + gameManager.RomName);
        }
    }
}
