using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    [SerializeField] private float topMargin, lateralMargin;
    private Vector2 screenLimits;
    private GameController gameController;

    // Metodo chamado antes do start
    private void Awake() 
    {
        Initialize();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        InvokeRepeating("SpawnInvoke", 2.0f, Random.Range(2.0f, 3.0f));
    }

    private void Initialize()
    {
        screenLimits = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.width, Screen.safeArea.height));

        // Camera.main.orthographicSize posiciona objeto no limite superior da camera
        // topMargin deixa o objeto fora da tela
        Vector2 heightPosition = new Vector2(transform.position.x, Camera.main.orthographicSize + topMargin);
        transform.position = heightPosition;
    }

    private void SpawnInvoke()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        if(gameController.gameStarted)
        {
            // Tudo que vier depois desta linha ira ocorrer apos 2s
            yield return new WaitForSeconds(0f);
            transform.position = new Vector2(Random.Range(-screenLimits.x + lateralMargin, screenLimits.x - lateralMargin), transform.position.y);
            // Instantiate clona objetos
            // Quaternion.identiry mantem mesma rotacao do objeto original
            GameObject tempBallPrefab = Instantiate(ballPrefab, transform.position, Quaternion.identity) as GameObject;
        } 
        else
        {
            yield return null;
        }
    }
}
