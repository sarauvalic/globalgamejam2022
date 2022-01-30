using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

public class Coin : MonoBehaviour
{
	[Range(0,1)]
	public float RandomThreshold;

	[Range((float)0.01,(float)0.99)]
	public float Weight;
	public Animator animator;


	//public List<DelayableEvent> OnClick;
	public int currentSide = 0;

	private QuestionController questionController;

	void Start()
	{
		questionController = FindObjectOfType<QuestionController>();
	}

	private void Update()
	{
	//	Vector3 screenpoint = new Vector3(100000,100000,100000);
	//	if (Input.GetMouseButtonDown(0))
	//	{
	//		screenpoint = Input.mousePosition;
	//	}
    //    else if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);
	//
    //        if (touch.phase == TouchPhase.Began)
    //        {
    //            screenpoint = touch.position;
    //        }
	//	}
	//
	//	if(IsHit(screenpoint))
	//		InvokeEvents();
	}

	private bool IsHit(Vector3 screenpoint)
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(screenpoint);
		if(Physics.Raycast(ray, out hit))
			return true;
		else 
			return false;
	}

	public void FlipCoin()
	{
		animator.ResetTrigger("A2A");
		animator.ResetTrigger("A2D");

		var nextSide = CalculateSide();

		if (currentSide == nextSide)
		{
			animator.SetTrigger("A2A");
		}
		else
		{
			animator.SetTrigger("A2D");
		}

		currentSide = 0;
		StartCoroutine(WaitForFlip());
	}

	public void CoinFlipped()
	{
		questionController.ChooseQuestion(currentSide);
	}

	private int CalculateSide()
	{
		var random = Random.value;
		if (random > RandomThreshold)
		{ 
			RandomThreshold += Weight;
			return 1;
		}
		else
		{
			RandomThreshold -= Weight;
			return 0;
		}
	}

	private IEnumerator WaitForFlip()
	{
		//var seconds = animator.GetCurrentAnimatorClipInfo(0).Length;
		var clips = animator.runtimeAnimatorController.animationClips;
		
		
		
		yield return new WaitForSeconds((float)3.542);
		
		CoinFlipped();
	}
}
