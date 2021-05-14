using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PocketCfg.Res;
using UnityEngine;
using SimpleFileBrowser;
using UnityEngine.Assertions;

namespace PocketCfg.HudEditor
{
    public class HudLoader : MonoBehaviour
    {
        public class ClientSchemeRes
        {
            public Dictionary<string, ResColor> Colors { get; } = new Dictionary<string, ResColor>();
            public Dictionary<string, ResObject> BaseSettings { get; } = new Dictionary<string, ResObject>();

            public ClientSchemeRes(ResUnit unit)
            {
                var scheme = unit.Objects.First(o => o.Name == "Scheme");
                var colors = scheme.Properties.First(o => o.Name == "Colors");
                var baseSettings = scheme.Properties.First(o => o.Name == "BaseSettings");
                var bitmapFontFiles = scheme.Properties.First(o => o.Name == "BitmapFontFiles");
                var fonts = scheme.Properties.First(o => o.Name == "Fonts");
                var borders = scheme.Properties.First(o => o.Name == "Borders");
                var customFontFiles = scheme.Properties.First(o => o.Name == "CustomFontFiles");

                foreach (var color in colors.Properties)
                {
                    // TODO: if not valid color, display loading error message
                    Colors.Add(color.Name, color.GetColor() ?? throw new InvalidOperationException());
                }

                foreach (var setting in baseSettings.Properties)
                    BaseSettings.Add(setting.Name, setting);
                
                // TODO: load fonts, bitmap fonts, and custom fonts
                // TODO: borders
            }
        }
        
        public ClientSchemeRes ClientScheme { get; private set; }

        private void OnGUI()
        {
            if (GUI.Button(new Rect(50, 10, 100, 20), "Open HUD"))
                FileBrowser.ShowLoadDialog(OnLoadSuccess, OnLoadCancel, FileBrowser.PickMode.Folders,
                    title: "Load HUD Folder");
        }

        private void OnLoadCancel()
        {
        }

        private void OnLoadSuccess(string[] paths)
        {
            Assert.AreEqual(1, paths.Length);
            var hudPath = paths[0];

            var resourcePath = Path.Combine(hudPath, "resource");
            var uiPath = Path.Combine(resourcePath, "ui");

            ClientScheme =
                new ClientSchemeRes(ResProcessor.FromFile(Path.Combine(resourcePath, "ClientScheme.res")).Process());
        }
    }
}
