using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

using UnityEngine.Events;

public class GameController : MonoBehaviour
{
	
	public void QuitGame()
	{
		#if UNITY_EDITOR
			EditorApplication.isPlaying = false;		
		#else
			Application.Quit();
		#endif
	}

	public void GoToCoin()
	{

	}

	public void GoToSpinTheBottle()
	{

	}
}
