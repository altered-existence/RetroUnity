using System.IO;
using AltX.UI;
using AltX.Utilities;
using RetroUnity.Utility;
using UnityEngine;

namespace RetroUnity {
    public class GameManager : MonoBehaviour {

        UIManager uiManager;
        [SerializeField] public string CoreFileName = "";
        [SerializeField] public string RomFileName = "";

        public LibretroWrapper.Wrapper wrapper;

        private float _frameTimer;

        public Material Display;

        public string corePath; // Future-proofing for changing Core Path at Runtime
        public string romPath; // Change depending which core is loaded

        private void Awake() {
            corePath = (Application.streamingAssetsPath + "/cores");
            romPath = (Application.streamingAssetsPath + "/roms/snes");
            Cores.GetInstalledCores();
            uiManager = gameObject.GetComponent<UIManager>();
            uiManager.PopulateCoreList();
            //uiManager.PopulateRomList();
            LoadRom(romPath + "/" + RomFileName); // Call from External Script/UI
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
            }
        }

        public void LoadRom(string romPath) {
#if !UNITY_ANDROID || UNITY_EDITOR
            // Doesn't work on Android because you can't do File.Exists in StreamingAssets folder.
            // Should figure out a different way to perform check later.
            // If the file doesn't exist the application gets stuck in a loop.
            if (!File.Exists(romPath)) {
                Debug.LogError(romPath + " not found.");
                return;
            }
#endif
            Display.color = Color.white;

            wrapper = new LibretroWrapper.Wrapper(Application.streamingAssetsPath + "/cores/" + CoreFileName);
            wrapper.Init(); // Grab Core Info?

            wrapper.LoadGame(romPath);
        }

        //public void LoadSelectedCore()
        //{
        //    wrapper = new LibretroWrapper.Wrapper(Application.streamingAssetsPath + "/cores/" + CoreFileName);
        //    wrapper.Init(); // Grab Core Info?
        //}
        //public void LoadSelectedRom(string romPath)
        //{
        //    wrapper.LoadGame(romPath);
        //}
        private void OnDestroy() {
            WindowsDLLHandler.Instance.UnloadCore();
        }
    }
}
