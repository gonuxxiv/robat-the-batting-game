using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundPoolerHigh : MonoBehaviour
{
    // Start is called before the first frame update
    #region Singleton
    public static BackGroundPoolerHigh Instance;

    private void Awake()
    {
        Instance = this;
    }
    #endregion

    public List<GameObject> skyTiles;
    public float nextCoordinateX = 0;
    public float nextCoordinateY = 0;
    public float previousCoordinateX = 0;
    public float previousCoordinateY = 0;
    public Queue<GameObject> objectPool = new Queue<GameObject>();
    System.Random random = new System.Random();
    public List<GameObject> preparedList = new List<GameObject>();
    public List<GameObject> unpreparedList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {   
        int i = 0;
        while (i < 3)
        {   
            
            GameObject obj = Instantiate(skyTiles[i]);
            GameObject obj2 = Instantiate(skyTiles[i]);
            GameObject obj3 = Instantiate(skyTiles[i]);
            GameObject obj4 = Instantiate(skyTiles[i]);
            GameObject obj5 = Instantiate(skyTiles[i]);
            obj.SetActive(false);
            obj2.SetActive(false);
            obj3.SetActive(false);
            obj4.SetActive(false);
            obj5.SetActive(false);
            preparedList.Add(obj);
            preparedList.Add(obj2);
            preparedList.Add(obj3);
            preparedList.Add(obj4);
            preparedList.Add(obj5);
            i++;
        }
        
    }


    public float nextCoordX(float coord) {
        var renderer = skyTiles[0].GetComponent<Renderer>();
        float width = renderer.bounds.size.x - 1;
        nextCoordinateX = (coord + (width));
        return nextCoordinateX;
    }

    public float nextCoordY(float coord) {
        var renderer = skyTiles[0].GetComponent<Renderer>();
        float width = renderer.bounds.size.y - 1;
        nextCoordinateY = (coord + (width));
        return nextCoordinateY;
    }
    
    public void previousCoordX(float coordEntry){
        previousCoordinateX = coordEntry;
    }

    public void previousCoordY(float coordEntry){
        previousCoordinateY = coordEntry;
    }

    public void DespawnFromList () {
        if (unpreparedList.Count > 6)
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

