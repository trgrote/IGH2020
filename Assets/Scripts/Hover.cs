using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    private Vector3 pos;
    private float maxVariance = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(pos.x, pos.y + (Mathf.Sin(Time.time) * maxVariance), pos.z);
    }
}
