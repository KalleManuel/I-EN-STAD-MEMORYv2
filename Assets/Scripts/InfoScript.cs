using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour
{

    public int panel;

    public GameObject panels;

    public Vector3 pos1;
    public Vector3 pos2;
    public Vector3 pos3;

    public Button leftArrow;
    public Button rightArrow;

    public float speed;

    public StartMenu timer;
    public GameObject theClock;


    // Start is called before the first frame update
    void Start()
    {
        panel = 1;

        pos1 = new Vector3(0, 0, 0);
        pos2 = new Vector3(-600, 0, 0);
        pos3 = new Vector3(-1200, 0, 0);

        speed = 30f;

        theClock = GameObject.FindGameObjectWithTag("menu");
        timer = theClock.GetComponent<StartMenu>();

        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (panel == 1)
        {
            panels.transform.localPosition = Vector3.MoveTowards(panels.transform.localPosition, pos1, speed);
            leftArrow.interactable = false;
            rightArrow.interactable = true;
        }

        else if (panel == 2)
        {
            panels.transform.localPosition = Vector3.MoveTowards(panels.transform.localPosition, pos2, speed);
            leftArrow.interactable = true;
            rightArrow.interactable = true;
        }

        else if (panel == 3)
        {
            panels.transform.localPosition = Vector3.MoveTowards(panels.transform.localPosition, pos3, speed);
            leftArrow.interactable = true;
            rightArrow.interactable = false;
        }
    }


    public void LeftArrow()
    {
        if (panel == 1)
        {
            panel = 3;
        }

        else if (panel == 2)
        {
            panel = 1;
        }

        else if (panel == 3)
        {
            panel = 2;
            
        }

    }

    public void RightArrow()
    {
        if (panel == 1)
        {
            panel = 2;
        }

        else if (panel == 2)
        {
            panel = 3;
        }

        else if (panel == 3)
        {
            panel = 1;
        }
    }

    public void CloseInfo()
    {
        timer.timer = timer.TimeUntilNextHint;
        
        Destroy(gameObject);
    }

    public void LinkPod()
    {
        Application.OpenURL("https://open.spotify.com/show/4WiQp9IdQa1rVzpxvUSrgW?si=74c31b7bd6264e2c");
    }

    public void LinkMusic()
    {
        Application.OpenURL("https://open.spotify.com/artist/77DeqXVjjwxKo59Ni0UUPf?si=ub70rBS6SCmZldUAdzemqw&dl_branch=1");
    }
}


