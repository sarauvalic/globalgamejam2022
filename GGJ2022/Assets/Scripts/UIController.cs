using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class UIController : MonoBehaviour
{
    private Button newGameButton;
    private Button continueButton;
    private Button quitButton;

    public Label gameNameLabel;
    private Label pauseMenuTitleLabel;


    public UnityEvent OnNewGame;
    public UnityEvent OnContinue;
    public UnityEvent OnQuit;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;
        newGameButton = root.Q<Button>("NewGameButton");
        continueButton = root.Q<Button>("ContinueButton");
        quitButton = root.Q<Button>("QuitButton");
        gameNameLabel = root.Q<Label>("GameName");
        pauseMenuTitleLabel = root.Q<Label>("PauseMenuTitle");

        newGameButton.clicked += NewGameButtonPressed;
        continueButton.clicked += ContinueButtonPressed;
        quitButton.clicked += QuitButtonPressed;
    }

    private void NewGameButtonPressed()
	{
        OnNewGame.Invoke();
	}
    
    private void ContinueButtonPressed()
	{
        OnContinue.Invoke();
	}
   
    private void QuitButtonPressed()
	{
        OnQuit.Invoke();
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
