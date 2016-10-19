using UnityEngine;
using System.Collections;

public class TowerProperty : MonoBehaviour {
    //Tweakables
    public float mAttackRadius = 10;
    public int mAttackDamage = 50;
    public float mAttackSpeed = 1;
    //References
    [SerializeField]
    private GameManager gameManager;
    //Internal states
    protected UnitProperty nearestEnemy;
    protected bool canShoot = false;

	// Use this for initialization
	protected virtual void Start () {
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }
        StartCoroutine(startAttack());
	}

    // Update is called once per frame
    protected virtual void Update () {
        findNearaestEnemy();
        if (nearestEnemy != null)
        {
            float distanceToNearestEnemy = Mathf.Abs(Vector3.Distance(nearestEnemy.transform.position, transform.position));
            if (distanceToNearestEnemy <= mAttackRadius)
            {
                canShoot = true;
            }
            else
            {
                canShoot = false;
            }
        }
        else
        {
            canShoot = false;
        }
    }

    private void findNearaestEnemy()
    {
        foreach(UnitProperty unit in gameManager.allUnits)
        {
            if (nearestEnemy == null)
            {
                nearestEnemy = unit;
            }
            else
            {
                if (unit != null)
                {
                    float distanceToNearestEnemy = Mathf.Abs(Vector3.Distance(nearestEnemy.transform.position, transform.position));
                    float distanceToCurrentEnemy = Mathf.Abs(Vector3.Distance(unit.transform.position, transform.position));
                    if (distanceToCurrentEnemy < distanceToNearestEnemy)
                    {
                        nearestEnemy = unit;
                    }
                }
                
            }
        }
    }

    protected virtual void AttackEnemy()
    {
        nearestEnemy.TakeDamage(mAttackDamage);
        Debug.Log("Bang");
    }

    private IEnumerator startAttack()
    {
        while (true)
        {
            yield return new WaitForSeconds(mAttackSpeed);
            if (canShoot)
            {
                AttackEnemy();
            }
        }
    }
}
