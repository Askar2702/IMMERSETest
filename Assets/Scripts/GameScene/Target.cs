using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour , ITarget
{
    private GameManager _gameManager;
    private void Awake()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void TakeDamage()
    {
        StartCoroutine(DelayRotation());
        _gameManager.ChangeScore(1);
    }

    IEnumerator DelayRotation()
    {
        ChangeRotation(360f);
        yield return new WaitForSeconds(2f);
        ChangeRotation(270f);
    }

    private void ChangeRotation(float angleX , float angleY = 180f , float angleZ = 0f)
    {
        transform.rotation = Quaternion.Euler(angleX, angleY, angleZ);
    }

}
