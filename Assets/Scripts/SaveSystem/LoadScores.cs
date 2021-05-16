using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadScores : MonoBehaviour
{
    [SerializeField] private Text[] _records;
    private int[] _scores;
    private void Start()
    {
        LoadData();
    }
    private void LoadData()
    {
        RecordData data = SaveSystem.LoadData();
        _scores = data.Records;
        for(int i = 0; i < _scores.Length; i++)
        {
            _records[i].text = "Record" + ":" + _scores[i].ToString();
        }
    }
}
