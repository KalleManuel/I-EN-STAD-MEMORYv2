using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudController : MonoBehaviour
{

    public GameObject mayorAvatar;
    public GameObject pipAvatar;
    public GameObject playersChoices;
    public JoinedPlayers joinedPlayers;

    public Vector3 firstAvatarPos;
    public Vector3 secondAvatorPos;

    // Start is called before the first frame update
    void Start()
    {
        playersChoices = GameObject.FindGameObjectWithTag("PlayersChoice");
        joinedPlayers = playersChoices.GetComponent<JoinedPlayers>();

        firstAvatarPos = new Vector3(-200,0, 0);
        secondAvatorPos = new Vector3(210, 0, 0);

        if (joinedPlayers.myHelpers == JoinedPlayers.Helpers.MAYOR)
        {
            mayorAvatar.SetActive(true);
            mayorAvatar.transform.localPosition = firstAvatarPos;
            pipAvatar.SetActive(false);
        }
        else if (joinedPlayers.myHelpers == JoinedPlayers.Helpers.PIP)
        {
            pipAvatar.SetActive(true);
            pipAvatar.transform.localPosition = firstAvatarPos;
            mayorAvatar.SetActive(false);
        }

        if (joinedPlayers.myHelpers == JoinedPlayers.Helpers.BOTH)
        {
            pipAvatar.SetActive(true);
            mayorAvatar.SetActive(true);
            pipAvatar.transform.localPosition = firstAvatarPos;
            mayorAvatar.transform.localPosition = secondAvatorPos;
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
