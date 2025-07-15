using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    

    [Header("Shoot State Parameters")]
    public GameObject shootStateBulletPrefab;
    public Transform[] shootStateBulletSpawnPoints;
    public float shootStateFireRate;

    [Header("Barrier State Parameters")]
    public GameObject barrierStateBulletPrefab;
    public Transform[] barrierStateBulletSpawnPoints;
    public float barrierStateFireRate;

    [Header("Missiles State Parameters")]
    public GameObject missilesStateBulletPrefab;
    public Transform[] missilesStateBulletSpawnPoints;
    public float missileStateFireRate;

    [Header("Bomb State Parameters")]
    public GameObject bombStateBulletPrefab;
    public Transform[] bombStateBulletSpawnPoints;
    public float bombStateFireRate;

    [Header("Saw State Parameters")]
    public GameObject sawStateBulletPrefab;
    public Transform[] sawStateBulletSpawnPoints;
    public float sawStateFireRate;

    private BossHealthController healthController;
    private ShootController shootController;
    private BossStates currentState;

    // Booleanos para controlar estados
    private bool firstSawStateTrigger = false;
    private float maxHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        healthController = GetComponent<BossHealthController>();
        maxHealth = healthController.health;
        shootController = GetComponent<ShootController>();
        InvokeRepeating("RunStateMachine", 0f, 4f);
    }   

    private void RunStateMachine()
    {
        switch (currentState)
        {
            case BossStates.Shoot:
                ShootState();
                break;
            case BossStates.Barrier:
                BarrierState();
                break;
            case BossStates.Missiles:
                MissilesState();
                break;
            case BossStates.Bomb:
                BombState();
                break;
            case BossStates.Saw:
                SawState();
                break;
            default:
                break;
        } 
    }


    #region States

    void ShootState()
    {
        // Altera os parametros do Shoot Controller para o estado correspondente
        shootController.bulletSpawnPoints = shootStateBulletSpawnPoints;
        shootController.bulletPrefab = shootStateBulletPrefab;
        shootController.fireRate = shootStateFireRate;

        currentState = NextState();
    }

    void BarrierState()
    {
        // Altera os parametros do Shoot Controller para o estado correspondente
        shootController.bulletSpawnPoints = barrierStateBulletSpawnPoints;
        shootController.bulletPrefab = barrierStateBulletPrefab;
        shootController.fireRate = barrierStateFireRate;

        currentState = NextState();
    }

    void MissilesState()
    {
        // Altera os parametros do Shoot Controller para o estado correspondente
        shootController.bulletSpawnPoints = missilesStateBulletSpawnPoints;
        shootController.bulletPrefab = missilesStateBulletPrefab;
        shootController.fireRate = missileStateFireRate;

        currentState = NextState();
    }

    void BombState()
    {
        // Altera os parametros do Shoot Controller para o estado correspondente
        shootController.bulletSpawnPoints = bombStateBulletSpawnPoints;
        shootController.bulletPrefab = bombStateBulletPrefab;
        shootController.fireRate = bombStateFireRate;

        currentState = NextState();
    }

    void SawState()
    {
        // Altera os parametros do Shoot Controller para o estado correspondente
        shootController.bulletSpawnPoints = sawStateBulletSpawnPoints;
        shootController.bulletPrefab = sawStateBulletPrefab;
        shootController.fireRate = sawStateFireRate;

        currentState = NextState();
    }

    #endregion

    private BossStates NextState()
    {
        // Determina qual e o proximo estado do Boss

        BossStates nextstate = currentState;
        float rand = Random.Range(0f, 1f);

        switch (currentState)
        {
            case BossStates.Shoot:
                // Transicao para o estado Saw
                if (healthController.health <= maxHealth/2 && (!firstSawStateTrigger || rand <= 0.1f))
                {
                    Debug.Log("Serra");
                    nextstate = BossStates.Saw;
                    firstSawStateTrigger = true;
                }
                // Transicao para o estado Barrier
                else if (0.1f < rand && rand <= 0.5f)
                {
                    nextstate = BossStates.Barrier;
                }
                // Transicao para o estado Missiles
                else if (0.5f < rand && rand <= 0.7f)
                {
                    nextstate = BossStates.Missiles;
                }
                // Transicao para o estado Bomb
                else if (0.7f < rand && rand <= 1f)
                {
                    nextstate = BossStates.Bomb;
                }
                break;
            case BossStates.Barrier:
                nextstate = BossStates.Shoot;
                break;
            case BossStates.Missiles:
                nextstate = BossStates.Shoot;
                break;
            case BossStates.Bomb:
                nextstate = BossStates.Shoot;
                break;
            case BossStates.Saw:
                nextstate = BossStates.Shoot;
                break;
        }

        return nextstate;
    }

    enum BossStates
    {
        // Estabelece os estados do boss
        
        Shoot = 0,
        Barrier = 1,
        Missiles = 2,
        Bomb = 3,
        Saw = 4
    }
}
