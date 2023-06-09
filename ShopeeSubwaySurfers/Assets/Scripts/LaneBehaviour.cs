using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneBehaviour : MonoBehaviour
{
    private float speed = 3f;

    private void Start()
    {
        Destroy(this.gameObject, 10f);
    }

    private void Update()
    {
        transform.position -= new Vector3(0f, 0f, speed) * Time.deltaTime;
    }
}
