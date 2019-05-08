using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace AltX.UI
{
    public class Themer : MonoBehaviour
    {
        public int ThemeSelected;
        public static string assetsPath;
        public string themePath;

        

        // Theme Paths from RetroArch
        public static string ozoneThemePath = "assets/ozone/png/icons/";
        public static string retrosystemThemePath = "assets/xmb/retrosystem/png/";
        public static string systematicThemePath = "assets/xmb/systematic/png/";


        #region Common File Names
        // Common File Names
        // Nintendo Entertainment System
        public static string nesIcon = "Nintendo - Nintendo Entertainment System.png";
        public static string nesContentIcon = "Nintendo - Nintendo Entertainment System-content.png";
        // Nintendo Super Nintendo
        public static string snesIcon = "Nintendo - Super Nintendo Entertainment System.png";
        public static string snesContentIcon = "Nintendo - Super Nintendo Entertainment System-content.png";
        // Nintendo Gameboy Advance
        public static string gbaIcon = "Nintendo - Game Boy Advance.png";
        public static string gbaContentIcon = "Nintendo - Game Boy Advance-content.png";
        // Sega Genesis
        public static string genesisIcon = "Sega - Mega Drive - Genesis.png";
        public static string genesisContentIcon = "Sega - Mega Drive - Genesis-content.png";
        #endregion

        public static string[] platforms;
        public static Sprite[] platformIcons;

        // Start is called before the first frame update
        void Start()
        {
            assetsPath = (Application.streamingAssetsPath + "/assets/");
        }

        // Update is called once per frame
        void Update()
        {

        }
        void ThemeSelect()
        {
            if (ThemeSelected == 1)
            {
                themePath = assetsPath + ozoneThemePath;
            }
            if (ThemeSelected == 2)
            {
                themePath = assetsPath + retrosystemThemePath;
            }
            if (ThemeSelected == 3)
            {
                themePath = assetsPath + systematicThemePath;
            }
        }
        void SetTheme()
        {

        }
    }
}

