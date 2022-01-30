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

	public UnityEvent OnCoinFlipped;

	public int currentSide = 0;
	public int nextSide = 0;

	private QuestionController questionController;

	void Start()
	{
		questionController = FindObjectOfType<QuestionController>();
	}


	public void ResetCoin()
	{
		animator.SetTrigger("Reset");
		animator.ResetTrigger("A2A");
		animator.ResetTrigger("A2D");
		
	}

	public void FlipCoin()
	{
		animator.ResetTrigger("Reset");
		Debug.Log("start flip");
		currentSide = 0;

		nextSide = CalculateSide();

		if (currentSide == nextSide)
		{
			animator.SetTrigger("A2A");
		}
		else
		{
			animator.SetTrigger("A2D");
		}

		StartCoroutine(WaitForFlip());
	}

	public void CoinFlipped()
	{
		Debug.Log("coin flipped");
		questionController.ChooseQuestion(nextSide);
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
		var seconds = 3;
		
		yield return new WaitForSeconds(seconds);
		
		CoinFlipped();
		OnCoinFlipped.Invoke();
	}
}
