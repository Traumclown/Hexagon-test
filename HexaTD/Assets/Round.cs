using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Round : MonoBehaviour
{

    int roundCounter;
    public delegate void OnRoundUpdateHandler();
    public event OnRoundUpdateHandler OnRoundUpdate;

    public void UpdateRound()
    {
        if (OnRoundUpdate != null)
        {
            OnRoundUpdate();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }



}
