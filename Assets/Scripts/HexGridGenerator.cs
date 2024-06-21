using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class HexGridGenerator : MonoBehaviour
{
    public static HexGridGenerator instance;

    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> tileObjects;
    public GameManager gm;

    private GameObject firstTile;
    private GameObject lastTile;

    public GameObject camTransform;

    void Start()
    {
        gm = GameManager.instance;
        GenerateHexGrid();
    }

    public void GenerateHexGrid()
    {
        float hexWidth = Mathf.Sqrt(3) * gm.spacing;
        float hexHeight = 1.5f * gm.spacing;

        lastTile = null;

        for (int x = 0; x < gm.width; x++)
        {
            for (int y = 0; y < gm.height; y++)
            {
                int randomizer = Random.Range(0, 2);
                Debug.Log(randomizer);
                float yPos = Random.Range(gm.minHeight, gm.maxHeight);
                GameObject spawnObjectReference = null;

                Vector3 position;
                if (y % 2 == 0)
                {
                    position = new Vector3(x * hexWidth, 0, y * hexHeight);
                }
                else
                {
                    position = new Vector3((x + 0.5f) * hexWidth, 0, y * hexHeight);
                }

                if (randomizer == 0)
                {
                    GameObject hexGO = Instantiate(tileObjects[0].gameObject, position, Quaternion.identity);
                    spawnObjectReference = hexGO;
                }
                else if (randomizer == 1)
                {
                    GameObject hexGO = Instantiate(tileObjects[1].gameObject, position, Quaternion.identity);
                    spawnObjectReference = hexGO;
                }

                if (x == 0 && y == 0)
                {
                    firstTile = spawnObjectReference;
                    Debug.Log(firstTile.transform.position);
                }
                else if (x == gm.width - 1 && y == gm.height - 1)
                {
                    lastTile = spawnObjectReference;
                    Debug.Log(lastTile.transform.position);
                }

                position.y = yPos;
                spawnObjectReference.transform.position = position;
                spawnObjectReference.transform.SetParent(transform);
            }
        }

        if (firstTile != null && lastTile != null)
        {
            Vector3 averagePosition = new Vector3((firstTile.transform.position.x + lastTile.transform.position.x) / 2,
                camTransform.transform.position.y,
                (firstTile.transform.position.z + lastTile.transform.position.z) / 2);

            // X ve Z eksenlerinde 15 birim azalt
            averagePosition.x -= 15f;
            averagePosition.z -= 15f;
            averagePosition.y = 15f;

            camTransform.transform.position = averagePosition;
        }
    }
}
