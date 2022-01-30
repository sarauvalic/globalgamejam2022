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

	private QuestionController questionController;

	void Start()
	{
		questionController = FindObjectOfType<QuestionController>();
	}


	public void ResetCoin()
	{
		animator.ResetTrigger("A2A");
		animator.ResetTrigger("A2D");
		animator.SetTrigger("Still");
	}

	public void FlipCoin()
	{
		Debug.Log("start flip");
		

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
		Debug.Log("coin flipped");
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
		Debug.Log("wait for flip");
		var seconds = animator.GetCurrentAnimatorClipInfo(0)[0].clip.length;
		
		yield return new WaitForSeconds(seconds);
		
		CoinFlipped();
		OnCoinFlipped.Invoke();
	}
}
