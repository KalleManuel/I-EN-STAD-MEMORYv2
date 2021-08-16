using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckButton : MonoBehaviour
{
    public Sprite[] Btnsprite;

    public Image lowerCard;
    public Image upperCard;

    public JoinedPlayers playerDeck;




    // Start is called before the first frame update
    void Start()
    {
        lowerCard.sprite = Btnsprite[0];
        upperCard.sprite = Btnsprite[1];

        GameObject playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
        playerDeck = playersChoices.GetComponent<JoinedPlayers>();



    }

    public void ChangeDeck()
    {
        if (playerDeck.myDeck == JoinedPlayers.Deck.PICTURES)
        {
            playerDeck.myDeck = JoinedPlayers.Deck.ALPHABET;
            lowerCard.sprite = Btnsprite[2];
            upperCard.sprite = Btnsprite[3];

        }

        else if (playerDeck.myDeck == JoinedPlayers.Deck.ALPHABET)
        {
            playerDeck.myDeck = JoinedPlayers.Deck.PICTURES;
            lowerCard.sprite = Btnsprite[0];
            upperCard.sprite = Btnsprite[1];

        }
    }
}
