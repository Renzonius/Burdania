using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida_barra : MonoBehaviour
{
    public RectTransform Rect_transform;
    public static float Heath{get; set;}
    void Start()
    {
        Heath = 100f;
        Rect_transform = GetComponent<RectTransform>();
        
    }

    void Update()
    {
        float Vida_act = Mathf.MoveTowards(Rect_transform.rect.height, Heath, 5.0f);

        Rect_transform.sizeDelta = new Vector2(100f, Mathf.Clamp(Vida_act, 0.0f, 100f));
        
    }
}
