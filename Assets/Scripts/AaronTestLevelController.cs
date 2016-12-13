using UnityEngine;
using System.Collections;

public class AaronTestLevelController : BaseLevelController {
    bool bossSpawned = false;

	// Use this for initialization
	void Start () {
        PoolController.Instance.SetInitialPoolSize(ProjectileReferences.SmallLaser, 400);
        PoolController.Instance.SetInitialPoolSize(ProjectileReferences.LargeLaser, 5);
        PoolController.Instance.SetInitialPoolSize(ProjectileReferences.GuidedMissile, 5);
        PoolController.Instance.Initialize();
        
        UnitSpawner.SpawnUnit(UnitReferences.EnemyCruiserLight1, new Vector3(-100, 50, 100));
        UnitSpawner.SpawnUnit(UnitReferences.EnemyCruiserLight1, new Vector3(0, 50, 100));
        UnitSpawner.SpawnUnit(UnitReferences.EnemyCruiserLight1, new Vector3(100, 50, 100));
        UnitSpawner.SpawnUnit(UnitReferences.AlliedCruiserHeavy1, new Vector3(0, 50, -200), Quaternion.Euler(0,0,0));

        UnitSpawner.SpawnUnitsInArea(UnitReferences.EnemyFighter1, 75, enemySpawns[0]);
        UnitSpawner.SpawnUnitsInArea(UnitReferences.AlliedFighter1, 15, allySpawns[0]);
    }

    protected override void UnitDeath()
    {
        if (UnitTracker.GetActiveEnemyCount() == 0 && !bossSpawned)
        {
            UnitSpawner.SpawnUnit(UnitReferences.EnemyBattleship, new Vector3(0, 100, 200));
            bossSpawned = true;
        }
        
    }

}
