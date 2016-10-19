using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
	private UnitProperty m_SelectedUnit;
	public float m_SpawnWait = 2;
	private bool m_Spawning = true;

	public Transform playerBase;
	public Transform enemyBase;

	public List<UnitProperty> allUnits;
    public int health = 100;

    public Canvas uiCanvas;
    public int intendedTower = 1;
    public int points = 300;
	// Use this for initialization
	void Start()
	{
		StartCoroutine(SpawnWaves());
	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(m_SpawnWait);
		while (m_Spawning)
		{
			Vector3 pos = enemyBase.transform.position + (Vector3.forward * -2);
			//UnitProperty temp = UnitProperty.Create(this, "BlueBot", pos, 1);
			UnitProperty temp = UnitProperty.Create(this, "GoatSoldier", pos, 1);

			allUnits.Add(temp);
			yield return new WaitForSeconds(m_SpawnWait);
		}
	}

	// Update is called once per frame
	void Update()
	{
        if (health < 0)
        {
            Time.timeScale = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Time.timeScale = 1;
                Application.LoadLevel(0);
            }
        }
	}

	public void SelectUnit(UnitProperty unit)
	{
		m_SelectedUnit = unit;
	}
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {

        }
    }
    public int GetHealth()
    {
        return health;
    }
	public void SpawnTower(Vector3 pos)
	{
		GameObject nTower;
        if (points >= 100)
        {
            if (intendedTower == 1)
                nTower = Instantiate(Resources.Load("Prefabs/FrostTower")) as GameObject;

            else if (intendedTower == 2)
                nTower = Instantiate(Resources.Load("Prefabs/MeleeTower")) as GameObject;

            else
                nTower = Instantiate(Resources.Load("Prefabs/RangedTower")) as GameObject;

            nTower.transform.position = pos;
            points -= 100;
        }

		foreach (UnitProperty temp in allUnits)
		{
			temp.SetTarget(temp.m_Target);
		}
	}

	public void MoveUnit(Vector3 position)
	{
		if (m_SelectedUnit)
		{
			m_SelectedUnit.SetTarget(position);
		}
	}

	public void AttackUnit(UnitProperty unit)
	{
		if (unit.m_Team != m_SelectedUnit.m_Team)
		{
			unit.TakeAttack(m_SelectedUnit);
		}
	}
}
