using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameController : MonoBehaviour
{
	public void QuitGame()
	{
		#if UNITY_EDITOR
			EditorApplication.isPlaying = true;		
		#else
			Application.Quit();
		#endif
	}
}
