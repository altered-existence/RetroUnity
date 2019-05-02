using System.IO;
using RetroUnity.Utility;
using UnityEngine;

namespace RetroUnity {
    public class GameManager : MonoBehaviour {

        [SerializeField] public string CoreName = "";
        [SerializeField] public string RomName = "";
        private LibretroWrapper.Wrapper wrapper;

        private float _frameTimer;

        public Material Display;
        
        public string romPath; // To change which path ROMs are loaded from. For use with multiple cores.

        private void Awake() {
            romPath = (Application.streamingAssetsPath + "/roms");
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

            wrapper = new LibretroWrapper.Wrapper(Application.streamingAssetsPath + "/cores/" + CoreName);

            wrapper.Init();
            wrapper.LoadGame(path);
        }

        private void OnDestroy() {
            WindowsDLLHandler.Instance.UnloadCore();
        }
    }
}
