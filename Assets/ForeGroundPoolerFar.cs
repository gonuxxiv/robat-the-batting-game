using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForeGroundPoolerFar : MonoBehaviour
{

    [System.Serializable]
    public class PlayFieldPiece {
        public GameObject prefab;
    }

    #region Singleton
    public static ForeGroundPoolerFar Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<GameObject> groundTiles;
    public float nextCoordinate = 0;
    public float previousCoordinate = 0;
    public Queue<GameObject> objectPool = new Queue<GameObject>();
    System.Random random = new System.Random();
    public List<GameObject> preparedList = new List<GameObject>();
    public List<GameObject> unpreparedList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {   
        int i = 0;
        while (i < 6)
        {   
            preparedList.Add(groundTiles[i]);
            i++;
        }
        unpreparedList.Add(preparedList[3]);
        preparedList.RemoveAt(3);
        
    }


    public float nextCoordX(float coord) {
        var renderer = groundTiles[0].GetComponent<Renderer>();
        float width = renderer.bounds.size.x - 1;
        nextCoordinate = (coord + (width));
        return nextCoordinate;
    }
    
    public void previousCoord(float coordEntry){
        previousCoordinate = coordEntry;
    }

    public void DespawnFromList () {
        if (unpreparedList.Count > 3)
        {
        unpreparedList[0].SetActive(false);
        preparedList.Add(unpreparedList[0]);
        unpreparedList.RemoveAt(0);
        }
    }

    public GameObject SpawnFromPool (Vector3 position)
    {

        int randomNum = random.Next(1, (preparedList.Count + 1));
        unpreparedList.Add(preparedList[randomNum - 1]);
        // preparedList[randomNum - 1].transform.SetActive(true);
        preparedList[randomNum - 1].transform.position = position;
        GameObject gameTile = preparedList[randomNum - 1];
        gameTile.SetActive(true);
        preparedList.RemoveAt(randomNum - 1);
        return gameTile;
    }

    
}
