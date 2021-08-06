using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinedPlayers : MonoBehaviour
{
    
    public enum PlayerMode { ONEPLAYER, TWOPLAYERS };

    public enum Helpers { MAYOR, PIP, BOTH };

    public enum Difficulty { EASY, MEDIUM, HARD };

    public PlayerMode myPlayerMode = PlayerMode.ONEPLAYER;
    public Helpers myHelpers = Helpers.PIP;
    public Difficulty myDyfficulty = Difficulty.EASY;


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        
    }
    

    
}

