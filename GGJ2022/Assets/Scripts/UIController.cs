using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{
    public Button startButton;
    public Button quitButton;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>.rootVisualElement;
        quitButton = root.Q<Button>("QuitButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
           UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
