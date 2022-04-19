using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocean : MonoBehaviour
{
    public Material oceanmat;
    System.Random rand;
    public float x=.01f;
    public float y = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        oceanmat.mainTextureOffset += (new Vector2(x,y)) * Time.deltaTime;
    }
}
