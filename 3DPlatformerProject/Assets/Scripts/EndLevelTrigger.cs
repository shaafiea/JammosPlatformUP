using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        MyGameManager.Instance.levelcompleted();
    }
}
