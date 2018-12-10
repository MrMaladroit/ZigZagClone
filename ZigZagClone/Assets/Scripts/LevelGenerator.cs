using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector3 lastPosition;
    [SerializeField]
    private GameObject roadPrefab;
    [SerializeField]
    private GameObject crystalRoadPiece;

    private float spawnDelay = 0.30f;
    private float directionalOffset = 0.71f;

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
                Instantiate(crystalRoadPiece, lastPosition, Quaternion.Euler(0, 45, 0));
            }
            else
            {
                lastPosition += new Vector3(directionalOffset, 0, directionalOffset);
                Instantiate(roadPrefab, lastPosition, Quaternion.Euler(0, 45, 0));
            }
        }
        else
        {
            int spawnCrystalRoad = Random.Range(1, 100);
            if(spawnCrystalRoad < 10)
            {
                lastPosition += new Vector3(-directionalOffset, 0, directionalOffset);
                Instantiate(crystalRoadPiece, lastPosition, Quaternion.Euler(0, 45, 0));
            }
            else
            {
                lastPosition += new Vector3(-directionalOffset, 0, directionalOffset);
                Instantiate(roadPrefab, lastPosition, Quaternion.Euler(0, 45, 0));
            }
        }

    }

}