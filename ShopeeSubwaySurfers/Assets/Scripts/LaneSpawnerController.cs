using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneSpawnerController : MonoBehaviour
{
    [SerializeField]
    private GameObject[] lanes = new GameObject[6];
    private Vector3 offset;
    private float timer = 1f;

    void Start()
    {
        offset = transform.position + new Vector3(0f, 0f, transform.position.z + 8f);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Instantiate(lanes[Random.Range(0, 5)], offset, Quaternion.identity);
            timer = 3f;
        }
    }
}
