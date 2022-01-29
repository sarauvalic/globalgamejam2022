using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BottleController : MonoBehaviour
{
    public int MaxPlayers = 6;
    public List<string> Players;

    public string ChosenPlayer;

    public GameObject PlayerListContainer;
    public Text ChosenPlayerText;

    public UnityEvent OnSpin;
    public UnityEvent OnPlayerChoosen;

    public int totalWeight;
    public int weightAdded;
    public List<int> weights;
    
    

    // Start is called before the first frame update
    void Start()
    {
        weights = new List<int>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlayer(string name)
	{
        if (Players.Count < MaxPlayers)
	    {
            Players.Add(name);
	    }
	}

    public void AllPlayersAdded()
	{
        weights.Clear();
        for (int i = 0; i < Players.Count; i++)
		{
            weights.Add(weightAdded*10);
            totalWeight += weightAdded*10;
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
                return Players[i];
            }
            extra += weights[i];
		}
        return "";
	}
}
