using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollisionHandler : MonoBehaviour
{
    #region Serialized Fields
    [Header("Enemy Particle System")]
    [SerializeField] private ParticleSystem _particleSystem;

    [Header("Enemy Mesh")]
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;

    [Header("Enemy Audio controller")]
    [SerializeField] private EnemyAudioController _enemyAudioController;

    [Header("Gameplay Controller")]
    [SerializeField] private IdContainer _IdProvider;
    #endregion
    private bool dead = false;
    private bool canDie = true;
    private GameplayInputProvider _gameplayInputProvider;

    private void Awake()
    {
        _gameplayInputProvider = PlayerController.Instance.GetInput<GameplayInputProvider>(_IdProvider.Id);
        _gameplayInputProvider.EnableInput();
    }

    private void OnEnable()
    {
        _gameplayInputProvider.OnUsedPower += PlayerPower;
        _gameplayInputProvider.OnPowerEnd += PlayerPowerEnd;
    }

    private void OnDisable()
    {
        _gameplayInputProvider.OnUsedPower -= PlayerPower;
        _gameplayInputProvider.OnPowerEnd -= PlayerPowerEnd;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && !dead)
        {
            dead = true;
            Debug.Log("Enemy Collision");
            if (canDie)
            {
                StartCoroutine(DestroyEnemy());
            }
        }
    }

    private void PlayerPower()
    {
        //Debug.Log("Enemy Power");
        canDie = false;
    }

    private void PlayerPowerEnd()
    {
        //Debug.Log("Enemy Power End");
        canDie = true;
        if (dead)
        {
            StartCoroutine(DestroyEnemy());
        }
    }

    private IEnumerator DestroyEnemy()
    {
        _meshRenderer.enabled = false;
        _particleSystem.Play();
        _enemyAudioController.PlayDeath();
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

}
