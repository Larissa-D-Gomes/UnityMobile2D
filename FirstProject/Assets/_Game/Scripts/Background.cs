using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Selecionando filho de background do tipo SpriteRenderer
        SpriteRenderer sprite = GetComponentInChildren<SpriteRenderer>();

        // Selecionando transform do unico objeto filho (Position, rotation, scale) 
        // e selecionando a escala
        Vector3 scaleTemp  = GetComponentInChildren<Transform>().transform.localScale;

        // Selecionando largura e altura da imagem
        float width = sprite.bounds.size.x; 
        float height = sprite.bounds.size.y;

        // Selecionando altura da camera principal (ativa na cena)
        float heightCamera = Camera.main.orthographicSize * 2f;
        // Calculando largura da tela
        float widthWorld = heightCamera / Screen.height * Screen.width;

        scaleTemp.x = widthWorld / width;
        scaleTemp.y = heightCamera / height;

        transform.localScale = scaleTemp;
    }
}
