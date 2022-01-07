using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Section", menuName = "ScriptableObjects/Section", order = 1)]
public class SectionSO : ScriptableObject
{
    public string sectionName;
    public Section section;
    public int sectionLength;
    public SpawnerType spawnerType;
    public float spawnTime;
    public Move move;
    public float speed;

    public SectionSO[] availableSections;

}
