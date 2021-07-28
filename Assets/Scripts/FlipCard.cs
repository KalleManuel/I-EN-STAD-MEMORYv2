using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipCard : MonoBehaviour
{
    public GameObject puzzleField;
    public float rotationY = 0.01f;

    public bool changeSide; 
    public bool firstCard;
    public bool secondCard;
    public int timer;

    private void Start()
    {
        changeSide = false;
        firstCard = true;
        secondCard = false;
    }

    private void Update()
    {
        if (timer == 90)
        {
            changeSide = true;
        }
    }

    public void FlipButton()
    {
        StartCoroutine(FlipCards());
    }

    IEnumerator FlipCards()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(rotationY);

            transform.Rotate(new Vector3(0, 18, 0));

            timer =+ 18;



        }
    }

}
