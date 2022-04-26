using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) transform.Translate(-speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(KeyCode.D)) transform.Translate(speed * Time.deltaTime, 0, 0);
    }
}
