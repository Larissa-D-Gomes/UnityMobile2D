using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTrigger : MonoBehaviour
{
    private GameController gameController;

    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter2D(Collider2D target) 
    {
        if(target.gameObject.CompareTag("Destroyer"))
        {
            // Destroi objeto que possui este script
            Destroy(this.gameObject);
        } 
        else if(target.gameObject.CompareTag("Point")) 
        {
            gameController.score++;
            Destroy(this.gameObject);
        }
    }
}
