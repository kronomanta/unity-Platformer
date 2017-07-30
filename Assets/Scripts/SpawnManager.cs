using UnityEngine;

public class SpawnManager : MonoBehaviour {

    public int MaxPlatformCount = 20;
    public GameObject PlatformPrefab;

    public float HorizontalDistanceMin = 6.5f;
    public float HorizontalDistanceMax = 14f;
    public float VerticalDistanceMin = -5f;
    public float VerticalDistanceMax = 5f;

    private Vector2 _originPosition;
    private Transform _groundHolder;

	void Start () {
        _originPosition = transform.position;
        _groundHolder = new GameObject("GroundBlocks").transform;
        Spawn();
	}

    void Spawn()
    {
        for (int i = 0; i < MaxPlatformCount; i++)
        {
            Vector2 randomPosition = _originPosition + 
                new Vector2(
                    Random.Range(HorizontalDistanceMin, HorizontalDistanceMax), 
                    Random.Range(VerticalDistanceMin, VerticalDistanceMax));

            Instantiate(PlatformPrefab, randomPosition, Quaternion.identity, _groundHolder);

            _originPosition = randomPosition;
        }
    }
}
