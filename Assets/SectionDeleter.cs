using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionDeleter : MonoBehaviour
{
    [SerializeField] SectionController sectionController;
    private int count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Section section))
        {
            sectionController.SectionReplace(section, count);
            count++;
        }

    }
}
