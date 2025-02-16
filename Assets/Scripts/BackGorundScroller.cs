using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGorundScroller : MonoBehaviour
{
    public float scrollSpeed = 0.1f; // Velocidad de desplazamiento
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset)); // Cambiado a eje Y
    }
}
