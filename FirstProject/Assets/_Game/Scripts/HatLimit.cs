using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HatLimit : MonoBehaviour
{
    private float minX, maxX;
    [SerializeField] private float minDistance, maxDistance;

    void Start() 
    {
        setMinAndMaxX();
    }

    void Update()
    {
        SetPlayerPosition();
    }

    private void SetPlayerPosition()
    {
        Debug.Log(minX + " " + maxX);
        Debug.Log(transform.position.x);
        // Caso ultrapassar limites redefinir posição do objeto
        // igual ao limite maximo ou minimo
        if(transform.position.x < minX) 
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        } 
        else if(transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }

    private void setMinAndMaxX()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.safeArea.width, 0f, 0f)); 
        maxX = bounds.x - maxDistance;
        minX = -bounds.x + minDistance;
    }
}
