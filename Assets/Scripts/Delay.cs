using UnityEngine;
using System.Collections;

public class Delay : MonoBehaviour
{
    public float delayTime = 5;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(delayTime);
        Application.LoadLevel(1);
    }
}