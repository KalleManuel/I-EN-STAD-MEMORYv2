using System.Collections;
using UnityEngine;

public class HardLevel : MonoBehaviour {

    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;


    void Awake() {

        for(int i = 0; i < 40; i++) {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
       }
   }

}
