using UnityEngine;

public class SpawnCoin : MonoBehaviour {

    public Transform[] CoinSpawnPoints;
    public GameObject CoinPrefab;

    void Spawn()
    {
        for (int i = 0; i < CoinSpawnPoints.Length; i++)
        {
            int coinFlip = Random.Range(0, 2);
            if (coinFlip > 0)
                Instantiate(CoinPrefab, CoinSpawnPoints[i].position, Quaternion.identity);
        }
    }

	void Start () {
        Spawn();	
	}
}
