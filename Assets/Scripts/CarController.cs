using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private bool isContinue = true;
    [SerializeField] private float speed = 10f;
    private void Awake()
    {
    }
    private void Update()
    {
        if (isContinue) transform.position += transform.forward * speed * Time.deltaTime;
    }

    public void Stop()
    {
        isContinue = false;
    }
}
