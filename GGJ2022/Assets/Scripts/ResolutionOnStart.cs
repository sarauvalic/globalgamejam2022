using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolutionOnStart : MonoBehaviour
{
   private void Awake()
     {
         //Set screen size for Standalone
		#if UNITY_STANDALONE
         Screen.SetResolution(375, 812, false);
         Screen.fullScreen = false;
		#endif
     }
}
