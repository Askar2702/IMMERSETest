using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecordData 
{
    public int[] Records;

    public RecordData (SaveScores score)
    {
        Records = score.Scores;
    }
}
