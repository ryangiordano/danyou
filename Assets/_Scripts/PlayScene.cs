using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.SceneManagement;
using System;
using System.Collections.Generic;

class EditorScripts : EditorWindow
{
    private static List<string> Scenes = new List<string>{
        "Assets/_Scenes/Loading.unity",
        "Assets/_Scenes/Main.unity",
        "Assets/_Scenes/Orchard.unity"
    };

  [MenuItem("Play/PlayMe _%h")]
  public static void GoToLoadingScene()
  {
    EditorSceneManager.SaveOpenScenes();
    EditorSceneManager.OpenScene("Assets/_Scenes/Loading.unity");
    EditorApplication.isPlaying = true;

  }
  [MenuItem("Play/PlayMe _%m")]
  public static void ToNextScene()
  {
    EditorSceneManager.SaveOpenScenes();
    var currentIndex = EditorSceneManager.GetActiveScene().buildIndex;
    var nextIndex = currentIndex == Scenes.Count - 1 ? 0 : currentIndex + 1;
    Console.WriteLine(nextIndex);
    var nextScene = EditorScripts.Scenes[nextIndex];

    EditorSceneManager.OpenScene(nextScene);
  }
  [MenuItem("Play/PlayMe _%l")]
  public static void GoToOrchard()
  {
    EditorSceneManager.SaveOpenScenes();
    EditorSceneManager.OpenScene("Assets/_Scenes/Orchard.unity");
  }
}
