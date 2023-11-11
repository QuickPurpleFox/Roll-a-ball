using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject prefab;
    public Transform parent;
    public Vector2 mapSize = new Vector2(10, 10);

    void Start()
    {
        Quaternion rotation = new Quaternion();
        rotation.eulerAngles = Vector3.right*90;
        for (int x = 0; x < mapSize.x; x++) 
        { 
            for(int z = 0; z < mapSize.y; z++)
            {
                Vector3 tilePosition = new Vector3(-mapSize.x/2 + 0.5f + x, 0, -mapSize.y / 2 + 0.5f + z);
                Object.Instantiate(prefab, tilePosition, rotation, parent);
            }
        }
    }
}
