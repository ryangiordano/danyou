using UnityEngine;
using UnityEditor;
using System.Collections;
using UnityEditor.SceneManagement;

class EditorScrips : EditorWindow
{

    [MenuItem("Play/PlayMe _%h")]
    public static void GoToLoadingScene()
    {
        EditorSceneManager.SaveOpenScenes();
        EditorSceneManager.OpenScene("Assets/_Scenes/Loading.unity");
        EditorApplication.isPlaying = true;

    }
    [MenuItem("Play/PlayMe _%m")]
    public static void GoToMainScene()
    {
        EditorSceneManager.SaveOpenScenes();
        EditorSceneManager.OpenScene("Assets/_Scenes/Main.unity");
    }
}
