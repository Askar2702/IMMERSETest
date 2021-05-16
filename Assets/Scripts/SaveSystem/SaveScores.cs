using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SaveScores : MonoBehaviour
{
    public int[] Scores;
   
    private void Start()
    {
        if (SaveSystem.LoadData() != null)
        {
            RecordData data = SaveSystem.LoadData();
            Scores = data.Records;
        }
        
    }
    private int LoadData(int score)
    {
        int index = 0;
        for (int i = 0; i < Scores.Length; i++)
        {
            if (Scores[i] == 0)
            {
                return i;
            }
            else
            {
                if (Scores[i] < score)
                {
                    return i;
                }
            }
        }
        return index;
    }
    public void SaveData(int score)
    {
        Scores[LoadData(score)] = score;
        SaveSystem.SaveData(this);
    }
   
}
