using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Enemy Collision");
            //PlayerController.Instance.GetInput<GameplayInputProvider>(0).OnUsedPower?.Invoke();
        }
    }

}
