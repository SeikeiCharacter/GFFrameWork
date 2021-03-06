using System.Collections;
using System.Collections.Generic;
using GFFramework.Editor;
using GFFramework.Editor.Tools;
using GFFramework.Helper;
using UnityEditor;
using UnityEngine;

public class EditorWindow_Table : EditorWindow
{
  public void OnGUI()
  {
    GUILayout.BeginVertical();
    GUILayout.Label("3.表格打包",EditorGUIHelper.TitleStyle);
    GUILayout.Space(5);
    if (GUILayout.Button("表格导出成Sqlite" ,GUILayout.Width(300),GUILayout.Height(30)))
    {
      var outPath = Application.persistentDataPath+"/"+Utils.GetPlatformPath(RuntimePlatform.Android);
      //3.打包表格
       Excel2SQLiteTools.GenSQLite(outPath);
    }
    GUILayout.EndVertical();
  }
}
