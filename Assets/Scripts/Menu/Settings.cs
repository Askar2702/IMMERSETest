using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    
    public void SetComplexity(int level)
    {
        PlayerPrefs.SetInt("Complexity", level);
    }
}
