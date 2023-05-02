using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    [Header("Enemy Particle System")]
    [SerializeField] private ParticleSystem _particleSystem;

    [Header("Enemy Mesh")]
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;

    private bool dead = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !dead)
        {
            dead = true;
            Debug.Log("Enemy Collision");
            _meshRenderer.enabled = false;
            _particleSystem.Play();
            StartCoroutine(DestroyEnemy());
            //PlayerController.Instance.GetInput<GameplayInputProvider>(0).OnUsedPower?.Invoke();
        }
    }

    private IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
