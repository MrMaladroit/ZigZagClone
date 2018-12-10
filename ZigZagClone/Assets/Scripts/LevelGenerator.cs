using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector3 lastPosition;
    [SerializeField]
    private GameObject roadPrefab;
    [SerializeField]
    private GameObject crystalRoadPiece;
    [SerializeField]
    private int collectibleSpawnRate = 20;

    private float spawnDelay = 0.15f;
    private float directionalOffset = 0.71f;
    private GameObject newestPrefab;

    // Blocks should be placed 0.71 on the X and Z axises away from each other.
    private void Start()
    {
        InvokeRepeating("SpawnRoad", spawnDelay, spawnDelay);
    }


    private void SpawnRoad()
    {

        int pickDireciton = Random.Range(1, 100);
        if(pickDireciton < 50)
        {
            int spawnCrystalRoad = Random.Range(1, 100);
            if(spawnCrystalRoad < 10)
            {
                lastPosition += new Vector3(directionalOffset, 0, directionalOffset);
                newestPrefab = Instantiate(crystalRoadPiece, lastPosition, Quaternion.Euler(0, 45, 0));
                newestPrefab.transform.SetParent(this.transform, true);
            }
            else
            {
                lastPosition += new Vector3(directionalOffset, 0, directionalOffset);
                newestPrefab = Instantiate(roadPrefab, lastPosition, Quaternion.Euler(0, 45, 0));
                newestPrefab.transform.SetParent(this.transform, true);
            }
        }
        else
        {
            int spawnCrystalRoad = Random.Range(1, 100);
            if(spawnCrystalRoad < collectibleSpawnRate)
            {
                lastPosition += new Vector3(-directionalOffset, 0, directionalOffset);
                newestPrefab = Instantiate(crystalRoadPiece, lastPosition, Quaternion.Euler(0, 45, 0));
                newestPrefab.transform.SetParent(this.transform, true);
            }
            else
            {
                lastPosition += new Vector3(-directionalOffset, 0, directionalOffset);
                newestPrefab = Instantiate(roadPrefab, lastPosition, Quaternion.Euler(0, 45, 0));
                newestPrefab.transform.SetParent(this.transform, true);
            }
        }

    }

}