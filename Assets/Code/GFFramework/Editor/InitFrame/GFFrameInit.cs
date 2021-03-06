using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using Path = System.IO.Path;

namespace GFFramework.Editor
{
    static public class GFFrameInit
    {
        /// <summary>
        /// 工程必须要用到的目录
        /// </summary>
        static private List<string> PathList = new List<string>()
        {
            "3rdPlugins",
            "Code",
            "Code/Game",
            "Code/Game/Data",
            "Code/Game/ScreenView",
            "Code/Game/Windows",
            "Code/Game/Window_MVC",
            "Code/Game@hotfix",
            "Code/Game@hotfix/Data",
            "Code/Game@hotfix/ScreenView",
            "Code/Game@hotfix/Windows",
            "Code/Game@hotfix/Window_MVC",
            "Resource/AssetBundle",
            "Resource/Effect",
            "Resource/Img",
            "Resource/Model",
            "Resource/Resources",
            "Resource/Table",
            "Scene",
            "StreammingAssets",
        };
   
        static public void Init()
        {
            foreach (var p in PathList)
            {
                var _p = IPath.Combine(Application.dataPath, p);
                if (Directory.Exists(_p) == false)
                {
                    Directory.CreateDirectory(_p);
                }
            }

            EditorUtility.DisplayDialog("提示", "目录生成完毕", "OK");
            AssetDatabase.Refresh();
        }
    }

}

