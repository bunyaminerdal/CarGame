using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Section : MonoBehaviour
{
    [SerializeField] private Transform spawnerRight;
    [SerializeField] private Transform spawnerLeft;
    private Move spawnedGO;
    private float spawnTime = 2f;
    private float spawnerTime = 2f;
    private float moveSpeed = 10f;
    private SpawnerType spawnerType;
    private bool isContinue = true;

    public Move SpawnedGO { get => spawnedGO; set => spawnedGO = value; }
    public float SpawnTime { get => spawnTime; set => spawnTime = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public SpawnerType SpawnerType { get => spawnerType; set => spawnerType = value; }

    private void Awake()
    {

    }
    private void OnEnable()
    {
        StaticEvents.LevelWon.AddListener(Stop);
    }
    // Start is called before the first frame update
    void Start()
    {
        spawnerTime = spawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isContinue) return;
        spawnerTime -= Time.deltaTime;
        if (spawnerTime < 0)
        {

            switch (spawnerType)
            {
                case SpawnerType.Right:
                    Move gameObject = Instantiate(spawnedGO, spawnerRight);
                    gameObject.transform.rotation = Quaternion.Euler(0, -90, 0);
                    gameObject.direction = Vector3.left;
                    gameObject.speed = moveSpeed;
                    break;
                case SpawnerType.Left:
                    Move gameObject1 = Instantiate(spawnedGO, spawnerLeft);
                    gameObject1.transform.rotation = Quaternion.Euler(0, 90, 0);
                    gameObject1.direction = Vector3.right;
                    gameObject1.speed = moveSpeed;
                    break;
                case SpawnerType.TwoWay:
                    int way = Random.Range(0, 2);

                    if (way < 1)
                    {
                        Move gameObject3 = Instantiate(spawnedGO, spawnerRight);
                        gameObject3.transform.rotation = Quaternion.Euler(0, -90, 0);
                        gameObject3.direction = Vector3.left;
                        gameObject3.speed = moveSpeed;
                    }
                    else
                    {
                        Move gameObject4 = Instantiate(spawnedGO, spawnerLeft);
                        gameObject4.transform.rotation = Quaternion.Euler(0, 90, 0);
                        gameObject4.direction = Vector3.right;
                        gameObject4.speed = moveSpeed;
                    }
                    break;
                case SpawnerType.None:
                    break;
                default:
                    break;
            }
            spawnerTime = spawnTime;


        }
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
