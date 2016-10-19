using UnityEngine;
using System.Collections;

public class FrostTowerProperty : TowerProperty {
    public float slowPercent = .5f;
    public float slowDuration = 2f;
	// Use this for initialization
	protected override void Start () {
        base.Start();
        if (slowPercent > 1)
            slowPercent = 1;
        if (slowPercent < -1)
            slowPercent = -1;
	}

    // Update is called once per frame
    protected override void Update () {
        base.Update();
	}

    protected override void AttackEnemy()
    {
        base.AttackEnemy();
        nearestEnemy.BecomeSlowed(slowPercent, slowDuration);
    }
}
