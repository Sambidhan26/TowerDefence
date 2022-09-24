using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    Enemy enemy;

    [SerializeField]
    int maxHealthPoint = 5;
    [SerializeField]
    int currentHitPoints = 0;

    [Tooltip("Add health or increase health when enemy dies")]
    [SerializeField] int levelDifficulty = 1;
    // Start is called before the first frame update
    void OnEnable()
    {
        currentHitPoints = maxHealthPoint;
    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();

    }

    private void Update()
    {
        //Debug.Log(maxHealthPoint + "___" + currentHitPoints);
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();   
    }

    void ProcessHit()
    {
        currentHitPoints--;

        if(currentHitPoints <= 0)
        {
            //Destroy(gameObject);
            gameObject.SetActive(false);
            maxHealthPoint += levelDifficulty;
            enemy.RewardGold();
        }
    }
}
