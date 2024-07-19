using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Threading;

#if UNITY_EDITOR
using UnityEditor;
#endif


public class MenuUiHandler : MonoBehaviour
{

    public TMP_InputField Iname;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void StartGame() {
        SceneManager.LoadScene(1);
    }

    public void QuiteGame() {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif

    }

    public void SaveName() {
        if (MenueManager.Instance != null) {
            MenueManager.Instance.UName = Iname.text;
            Debug.Log($"CALLED SaveName()! and saved {MenueManager.Instance.UName}");
        }
    }
    
}
