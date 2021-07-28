using System.Collections;
using UnityEngine;

public class MediumLevel : MonoBehaviour {

    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;


    void Awake() {

        for(int i = 0; i < 18; i++) {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
       }
   }

}
