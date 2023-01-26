using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        DragTouch();
    }

    private void DragTouch()
    {
        // Se quantidade de toques na tela for maior que zero e se o tipo 
        // de toque e movimento
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved && gameController.gameStarted)
        {
            // Recuperando posicao do toque na tela
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;

            // Movimentando chapeu no eixo x
            // Time.deltaTime faz a normalização pela quantidade de frames
            transform.Translate(touchDeltaPosition.x * speed * Time.deltaTime, 0f, 0f);
        }
    }
}
