using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
	[Range(0,1)]
	public float RandomThreshold;
	[Range((float)0.01,(float)0.99)]
	public float Weight;
	public Animator animator;
	public Text Text;

	public List<DelayableEvent> OnClick;
	public int currentSide = 0;

	private QuestionController questionController;

	void Start()
	{
		Text.text = currentSide.ToString();
		questionController = FindObjectOfType<QuestionController>();
	}

	private void Update()
	{
		Vector3 screenpoint = new Vector3(100000,100000,100000);
		if (Input.GetMouseButtonDown(0))
		{
			screenpoint = Input.mousePosition;
		}
        else if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                screenpoint = touch.position;
            }
		}

		if(IsHit(screenpoint))
			InvokeEvents();
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

	public void InvokeEvents()
	{
		foreach (var item in OnClick)
		{
			StartCoroutine(Delay(item));
		}
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

	private IEnumerator Delay(DelayableEvent delayableEvent)
	{
		yield return new WaitForSeconds(delayableEvent.delay);
		delayableEvent.OnInvoke.Invoke();
	}
}
