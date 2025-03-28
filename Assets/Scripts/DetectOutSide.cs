using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectOutSide : MonoBehaviour
{
    public GameObject losePanel;
    public GameObject controle;
    public GameObject player;
    Player playerScript;
    ControleGame controleGameScript;

    bool lose;

    private void Start() {
        controleGameScript = controle.GetComponent<ControleGame>();
        playerScript = player.GetComponent<Player>();
    }
    
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "emptyball" || other.gameObject.tag == "colorball")
        {
            if (!lose)
            {
                controleGameScript.lose = true;
                playerScript.RunGame = false;
                Invoke("showLosePanel" , 2f);
                lose = true;
            }
        }
    }

    void showLosePanel()
    {
        losePanel.SetActive(true);
    }
}
