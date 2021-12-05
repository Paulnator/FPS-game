using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 0618
public class EnemySpawner : NetworkBehaviour{

    [SerializeField]
    private GameObject enemyPrefab;
    public int numEnemies;

    public override void OnStartServer()
    {
        base.OnStartServer();

        for (int i=0; i< numEnemies; i++)
        {
            var pos = new Vector3(
               Random.Range(-4.0f, 4.0f),
               1f,
               Random.Range(-4.0f, 4.0f)
               );

            var rotation = Quaternion.Euler(Random.Range(0, 0), Random.Range(0, 0), Random.Range(0, 0));

            var enemy = (GameObject)Instantiate(enemyPrefab, pos, rotation);
            NetworkServer.Spawn(enemy);
        }
    }
}
