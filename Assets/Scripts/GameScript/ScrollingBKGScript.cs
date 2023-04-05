// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class ScrollingBKGScript : MonoBehaviour
{
    [Range(-1f,1f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;

    [SerializeField]
    // private Renderer bgRenderer;

    void Start() {
      mat = GetComponent<Renderer>().material;
    }
    
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex",new Vector2(offset,0));
        // bgRenderer.material.mainTextureOffset += new Vector2(scrollSpeed * Time.deltaTime, 0);
    }
}
