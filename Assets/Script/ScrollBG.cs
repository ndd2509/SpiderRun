using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    public float speed = 5f;
    float Offset;
    Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Offset += speed * Time.deltaTime;
       renderer.material.mainTextureOffset = new Vector2(Offset, 0f);

    }
}
