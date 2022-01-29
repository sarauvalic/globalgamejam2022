using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BottleController : MonoBehaviour
{
    public int MaxPlayers = 6;
    public List<string> CurrentPlayers;

    public string ChosenPlayer;

    public List<Player> PlayerList;
    public Text ChosenPlayerText;

    public UnityEvent OnSpin;
    public UnityEvent OnPlayerChoosen;

    private InputField NewPlayer;

    public int totalWeight;
    public int weightAdded;
    public List<int> weights;
    
    

    // Start is called before the first frame update
    void Start()
    {
        weights = new List<int>();
        NewPlayer = FindObjectOfType<InputField>();
        foreach (var item in PlayerList)
	    {
            item.gameObject.SetActive(false);
	    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer()
	{
        var name = NewPlayer.text;
        var index = CurrentPlayers.Count -1;
        if (CurrentPlayers.Count < MaxPlayers)
	    {
            CurrentPlayers.Add(name);
            index = CurrentPlayers.Count-1;
            PlayerList[index].name = name;
            PlayerList[index].text.text = name;
            PlayerList[index].gameObject.SetActive(true);
	    }
        if (CurrentPlayers.Count >= MaxPlayers)
	    {
            NewPlayer.gameObject.SetActive(false);
            AllPlayersAdded();
	    }
	}

    public void AllPlayersAdded()
	{
        weights.Clear();

        for (int i = 0; i < CurrentPlayers.Count; i++)
		{
            weights.Add(weightAdded * 10);
            totalWeight += weightAdded * 10;
		}
	}

    public void SpinBottle()
	{
        ChosenPlayer = ChoosePlayer();
	}

    private string ChoosePlayer()
	{
        var random = Random.Range(1, totalWeight + 1);
        var extra = 0;

        for (int i = 0; i < weights.Count; i++)
		{
            if(random <= weights[i] + extra)
            {
                weights[i] -= weightAdded;
                totalWeight -= weightAdded;
                return CurrentPlayers[i];
            }
            extra += weights[i];
		}
        return "";
	}
}
