using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DestroyonClick : MonoBehaviour
{

    [SerializeField] Text coinText;
    [SerializeField] Text scoreText;
    public int coins = 0;
    public int score = 0;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                BoxCollider boxCollider = hit.collider as BoxCollider;

                if (boxCollider.tag == "questionbox")
                {
                    score = score + 100;
                    coins = coins + 1;
                    coinText.text = coins.ToString("00");
                    scoreText.text = score.ToString("000000");
                }

                if(boxCollider.tag == "brick")
                {
                    Destroy(boxCollider.gameObject);
                }

            }
        }
    }
}