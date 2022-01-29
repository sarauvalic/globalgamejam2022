using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class QuestionController : MonoBehaviour
{
    public Text TopQuestion;
    public Text BottomQuestion;

    public UnityEvent OnTopChosen;
    public UnityEvent OnBottomChosen;
    
    public List<string> Pairs;
    
    private List<string> pairsCopy;

    // Start is called before the first frame update
    void Start()
    {
        pairsCopy = new List<string>(Pairs);
    }

    public void NextPair()
	{
        if (pairsCopy.Count <= 1)
	    {
            pairsCopy.Clear();
            pairsCopy.AddRange(Pairs);
	    }
        var index = Random.Range(0, pairsCopy.Count);
        
        var pair = pairsCopy[index].Split(';');
        TopQuestion.text = pair[0].Trim();
        BottomQuestion.text = pair[1].Trim();
        pairsCopy.RemoveAt(index);
	}

    public void ChooseQuestion(int side)
	{
        if (side == 0)
	    {
            OnBottomChosen.Invoke();
	    }
		else
		{
            OnTopChosen.Invoke();
		}
	}
}
