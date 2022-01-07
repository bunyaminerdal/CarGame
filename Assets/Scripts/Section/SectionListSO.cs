using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Section", menuName = "ScriptableObjects/SectionList", order = 1)]

public class SectionListSO : ScriptableObject
{
    public SectionSO SectionStart;
    public SectionSO SectionFinish;
}
