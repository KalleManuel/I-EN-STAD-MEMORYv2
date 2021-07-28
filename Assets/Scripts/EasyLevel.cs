using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyLevel : MonoBehaviour {

    public float offsetAngle;

    [SerializeField]
    private Transform puzzleField;

    [SerializeField]
    private GameObject btn;

    private void Start()
    {
       
    }

    void Awake() {


        GridLayoutGroup puzzleFieldLayout = GetComponent<GridLayoutGroup>();
        puzzleFieldLayout.cellSize = new Vector2(200, 200);
        puzzleFieldLayout.spacing = new Vector2(30, 30);
        puzzleFieldLayout.constraintCount = 2;

        puzzleField.transform.position = new Vector3(0, -80, 0);
        

        for(int i = 0; i < 8; i++) {
            GameObject button = Instantiate(btn);
            button.name = "" + i;
            button.transform.SetParent(puzzleField, false);
            offsetAngle = Random.Range(-5,5);
            Vector3 offset = new Vector3(0, 0, offsetAngle);
            button.transform.rotation = Quaternion.Euler (0, 0, offsetAngle);
           

       }
   }

}
