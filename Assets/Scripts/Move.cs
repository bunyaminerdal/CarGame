using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    private bool isContinue = true;
    private void OnEnable()
    {
        StaticEvents.LevelWon.AddListener(Stop);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isContinue) transform.position += direction * speed * Time.deltaTime;
    }
    private void OnDestroy()
    {
        StaticEvents.LevelWon.RemoveListener(Stop);
    }
    private void Stop()
    {
        isContinue = false;
    }

}
