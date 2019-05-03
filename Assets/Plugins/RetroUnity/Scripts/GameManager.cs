using System.IO;
using RetroUnity.Utility;
using UnityEngine;
using AltX.Utilities;
using AltX.UI;

namespace RetroUnity {
    public class GameManager : MonoBehaviour
    {
        //readonly Cores cores;
        UIManager uiManager;
        [SerializeField] public string CoreName = "";
        [SerializeField] public string RomName = "";
        [HideInInspector] public string corePath; // Future-proofing for changing Core Path at Runtime
        public string romPath; // Change depending which core is loaded

        public LibretroWrapper.Wrapper wrapper;

        private float _frameTimer;

        public Material Display; // Changed to Material to support 2D Renderers
        //public Texture2D DisplayTexture; // TESTING


        
        private void Awake() {
            corePath = (Application.streamingAssetsPath + "/cores");
            romPath = (Application.streamingAssetsPath + "/roms"); // SNES = roms/snes | Genesis = roms/genesis | Gameboy = roms/gb(a/c)
            Cores.GetInstalledCores();
            uiManager = gameObject.GetComponent<UIManager>();
            uiManager.PopulateCoreList();
            LoadRom(romPath + "/" + RomName); // Call from External Script/UI
        }

        private void Update() {
            if (wrapper != null) {
                _frameTimer += Time.deltaTime;
                float timePerFrame = 1f / (float)wrapper.GetAVInfo().timing.fps;

                while (_frameTimer >= timePerFrame)
                {
                    wrapper.Update();
                    _frameTimer -= timePerFrame;
                }
            }
            if (LibretroWrapper.tex != null) {
                Display.mainTexture = LibretroWrapper.tex;
                //DisplayTexture = LibretroWrapper.tex;
            }
        }

        public void LoadRom(string path) {
#if !UNITY_ANDROID || UNITY_EDITOR
            // Doesn't work on Android because you can't do File.Exists in StreamingAssets folder.
            // Should figure out a different way to perform check later.
            // If the file doesn't exist the application gets stuck in a loop.
            if (!File.Exists(path)) {
                Debug.LogError(path + " not found.");
                return;
            }
#endif
            Display.color = Color.white;

            wrapper = new LibretroWrapper.Wrapper(Application.streamingAssetsPath + corePath + "/" + CoreName);

            wrapper.Init();
            wrapper.LoadGame(path);
        }

        private void OnDestroy() {
            WindowsDLLHandler.Instance.UnloadCore();
        }
    }
}
