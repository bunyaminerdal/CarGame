using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionController : MonoBehaviour
{
    [SerializeField] SectionListSO sectionListSO;
    private SectionSO currentSection;
    private int totalSectionCountInLevel = 100;
    private int realTimeSectionCount = 15;
    private int pathLength = 0;
    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        CreateFirstSection();
        for (int i = 0; i < realTimeSectionCount; i++)
        {
            CreateRandomSection();
        }
    }
    private void CreateFirstSection()
    {
        currentSection = sectionListSO.SectionStart;
        Section section = Instantiate(sectionListSO.SectionStart.section, transform);
        section.transform.position = new Vector3(0, 0, pathLength);
        pathLength += sectionListSO.SectionStart.sectionLength;
        section.SpawnedGO = sectionListSO.SectionStart.move;
        section.SpawnTime = sectionListSO.SectionStart.spawnTime;
        section.MoveSpeed = sectionListSO.SectionStart.speed;
        section.SpawnerType = sectionListSO.SectionStart.spawnerType;
    }

    private void CreateRandomSection()
    {
        currentSection = currentSection.availableSections[Random.Range(0, currentSection.availableSections.Length)];
        Section section = Instantiate(currentSection.section, transform);
        section.transform.position = new Vector3(0, 0, pathLength);
        pathLength += currentSection.sectionLength;
        section.SpawnedGO = currentSection.move;
        section.SpawnTime = currentSection.spawnTime;
        section.MoveSpeed = currentSection.speed;
        section.SpawnerType = currentSection.spawnerType;
    }
    private void CreateFinishSection()
    {
        currentSection = sectionListSO.SectionFinish;
        Section section = Instantiate(sectionListSO.SectionFinish.section, transform);
        section.transform.position = new Vector3(0, 0, pathLength);
        pathLength += sectionListSO.SectionFinish.sectionLength;
        section.SpawnedGO = sectionListSO.SectionFinish.move;
        section.SpawnTime = sectionListSO.SectionFinish.spawnTime;
        section.MoveSpeed = sectionListSO.SectionFinish.speed;
        section.SpawnerType = sectionListSO.SectionFinish.spawnerType;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SectionReplace(Section section, int ID)
    {
        if (ID + realTimeSectionCount == totalSectionCountInLevel)
        {
            CreateFinishSection();

        }
        if (ID + realTimeSectionCount < totalSectionCountInLevel)
        {
            Destroy(section.gameObject, 1f);
            ID += realTimeSectionCount;
            CreateRandomSection();
        }
    }
}
public enum SpawnerType
{
    Right,
    Left,
    TwoWay,
    None
}
