using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private int requiredPartID;
    [SerializeField] private AudioSource s;
    [SerializeField] private AudioClip t;

    private static List<Table> allSlots = new List<Table>();
    private static bool puzzleSolved;

    private bodypart _current;

    private void Awake()
    {
        allSlots.Add(this);
    }

    private void OnDestroy()
    {
        allSlots.Remove(this);
    }

    private void OnTriggerEnter(Collider other)
    {
      if (puzzleSolved)
            return;

      bodypart part = other.GetComponent<bodypart>();
        _current = part;
       
        CheckPuzzle();
        s.PlayOneShot(t);
    }

    private void OnTriggerExit(Collider other)
    {

      bodypart part = other.GetComponent<bodypart>();
        if (_current = part) { 
         _current = null;
        }
    }

    private void CheckPuzzle() { 
     if (puzzleSolved) return;

        for (int i = 0; i < allSlots.Count; i++) {
        if (allSlots[i]._current==null) return ;
        if (allSlots[i]._current.partID != allSlots[i].requiredPartID) return ;
        }
        puzzleSolved = true;

    }


}
