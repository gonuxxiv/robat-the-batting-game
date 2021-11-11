using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayFieldCreatorScript : MonoBehaviour
{

    public PlayFieldPooler playFieldPoolerGround;
    public ForeGroundPoolerNear foreGroundPoolerNear;
    public ForeGroundPoolerFar foreGroundPoolerFar;
    public ForeGroundPoolerFarther foreGroundPoolerFarther;
    public BackGroundPoolerLow backGroundPoolerLow;
    public BackGroundPoolerHigh backGroundPoolerHigh;
    public AirPooler airPooler;
    public VentPooler ventPooler;
    public Rigidbody2D ball;
    System.Random random = new System.Random();
    public float x_coord_foreground_far;
    public float x_coord_foreground_far_old;
    public float x_coord_foreground_far_older;
    public float x_coord = -40;
    public float old_coord_x = -40;
    public float older_coord_x = -70;
    public float y_coord;
    public float old_coord_y;
    public float older_coord_y;
    public bool moveObj;
    public int spawnCount = 0;
    public Vector3 ballLocation;
    public Vector3 ballLocationOld;
    public Vector3 ballLocationOlder;
    System.Random randomX = new System.Random();
    System.Random randomY = new System.Random();
    public bool canSpawn = true;


    
    // Start is called before the first frame update
    void Start()
    {   
        ballLocation = getSpawnLocation(-8, 3, 0);
        ballLocationOld = getSpawnLocation(-33, -31, 0);
        ballLocationOlder = getSpawnLocation(-66, -62, 0);
        old_coord_y += 10;
        x_coord_foreground_far += 3;
        playFieldPoolerGround = PlayFieldPooler.Instance;
        foreGroundPoolerNear = ForeGroundPoolerNear.Instance;
        foreGroundPoolerFar = ForeGroundPoolerFar.Instance;
        foreGroundPoolerFarther = ForeGroundPoolerFarther.Instance;
        backGroundPoolerLow = BackGroundPoolerLow.Instance;
        backGroundPoolerHigh = BackGroundPoolerHigh.Instance;
        ventPooler = VentPooler.Instance;
        airPooler = AirPooler.Instance;
    }

    public float randomizeXLocation(float x_coordinate){
        float randLoc = randomX.Next(-11, 11);
        float newLoc = randLoc + x_coordinate;
        return newLoc;
    }
    
    public float randomizeYLocation(){
        float randLoc = randomY.Next(17, 61);
        return randLoc;
    }

    public Vector3 getSpawnLocation (float x_axis, float y_axis, int z_axis){
        Vector3 spawnLocation = new Vector3(x_axis, y_axis, z_axis);
        return spawnLocation;
    }

    void Update()
    {   

        if(older_coord_x - ball.position.x < (playFieldPoolerGround.nextCoordX(old_coord_x) - 15))
        {
            playFieldPoolerGround.DespawnFromList();
            foreGroundPoolerNear.DespawnFromList();
            backGroundPoolerLow.DespawnFromList();
            ventPooler.DespawnFromList();
            airPooler.DespawnFromList();

        }
        if(x_coord_foreground_far_older - ball.position.x < ((foreGroundPoolerFar.nextCoordX(old_coord_x) - 15)))
        {
            foreGroundPoolerFar.DespawnFromList();
            foreGroundPoolerFarther.DespawnFromList();

        }

        if(ball.position.x > (playFieldPoolerGround.nextCoordX(old_coord_x) - 15))
        {
            
            older_coord_x = old_coord_x;
            old_coord_x = x_coord;
            x_coord = playFieldPoolerGround.nextCoordX(old_coord_x);
            Vector3 groundSpawnLocation = getSpawnLocation(x_coord, -3, 0);
            Vector3 foreGroundSpawnLocationNear = getSpawnLocation(x_coord, 1, 0);
            Vector3 ventSpawnLocation = getSpawnLocation(randomizeXLocation(x_coord), 1 , 0);
            Vector3 airSpawnLocation = getSpawnLocation(randomizeXLocation(x_coord), randomizeYLocation(), 0);
            Vector3 backGroundSpawnLocationLow = getSpawnLocation(x_coord, 17, 0);
            // Vector3 backGroundSpawnLocationHigh1 = getSpawnLocation((x_coord - 4), (old_coord_y - 24), 0);
            // Vector3 backGroundSpawnLocationHigh2 = getSpawnLocation((x_coord - 4), (old_coord_y + 9), 0);
            playFieldPoolerGround.SpawnFromPool(groundSpawnLocation);
            foreGroundPoolerNear.SpawnFromPool(foreGroundSpawnLocationNear);
            backGroundPoolerLow.SpawnFromPool(backGroundSpawnLocationLow);
            if(ball.transform.position.x > 40){
            ventPooler.SpawnFromPool(ventSpawnLocation);
            airPooler.SpawnFromPool(airSpawnLocation);
            }
            // backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationHigh1);
            // backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationHigh2);
                
        }

        if(ball.position.x > (foreGroundPoolerFar.nextCoordX(x_coord_foreground_far_old) - 30))
        {
            x_coord_foreground_far_older = x_coord_foreground_far_old;
            x_coord_foreground_far_old = x_coord_foreground_far;
            x_coord_foreground_far = foreGroundPoolerFar.nextCoordX(x_coord_foreground_far_old);
            Vector3 foreGroundSpawnLocationFar = getSpawnLocation(x_coord_foreground_far, 12, 0);
            Vector3 foreGroundSpawnLocationFarther = getSpawnLocation(x_coord_foreground_far, 18, 0);
            foreGroundPoolerFar.SpawnFromPool(foreGroundSpawnLocationFar);
            foreGroundPoolerFarther.SpawnFromPool(foreGroundSpawnLocationFarther);
            foreGroundPoolerFar.previousCoord(x_coord_foreground_far_old);
            foreGroundPoolerFarther.previousCoord(x_coord_foreground_far_old);

        }

        if (ball.position.x > (ballLocationOlder.x + 59) && ball.position.y > (ballLocationOlder.y + 59))
        {
            backGroundPoolerHigh.DespawnFromList();
            backGroundPoolerHigh.DespawnFromList();
            backGroundPoolerHigh.DespawnFromList();
            Vector3 backGroundSpawnLocationVertical = getSpawnLocation((ball.position.x - 5), (ball.position.y + 48), 0);
            Vector3 backGroundSpawnLocationDiagonal = getSpawnLocation((ball.position.x + 43), (ball.position.y + 48), 0);
            Vector3 backGroundSpawnLocationHorizontal = getSpawnLocation((ball.position.x + 43), (ball.position.y), 0);
            backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationVertical);
            backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationDiagonal);
            backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationHorizontal);
            ballLocationOlder = ballLocationOld;
            ballLocationOld = ballLocation;
            ballLocation = ball.position;
        }

        else if (ball.position.x > (ballLocationOlder.x + 85))
        {
            backGroundPoolerHigh.DespawnFromList();
            backGroundPoolerHigh.DespawnFromList();
            Vector3 backGroundSpawnLocationHorizontalUp = getSpawnLocation((ball.position.x + 52), (ball.position.y + 25), 0);
            Vector3 backGroundSpawnLocationHorizontalDown = getSpawnLocation((ball.position.x + 52), (ball.position.y - 25), 0);
            backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationHorizontalUp);
            backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationHorizontalDown);
            ballLocationOlder = ballLocationOld;
            ballLocationOld = ballLocation;
            ballLocation = ball.position;

        }

        else if (ball.position.y > (ballLocationOlder.y + 80))
        {

            backGroundPoolerHigh.DespawnFromList();
            backGroundPoolerHigh.DespawnFromList();
            Vector3 backGroundSpawnLocationVerticalRight = getSpawnLocation((ball.position.x + 23), (ball.position.y + 51), 0);
            Vector3 backGroundSpawnLocationVerticalLeft = getSpawnLocation((ball.position.x - 20), (ball.position.y + 51), 0);
            backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationVerticalRight);
            backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationVerticalLeft);
            ballLocationOlder = ballLocationOld;
            ballLocationOld = ballLocation;
            ballLocation = ball.position;
        }

        else if (ball.position.y < (ballLocation.y - 8))
        {
            backGroundPoolerHigh.DespawnFromList();
            backGroundPoolerHigh.DespawnFromList();
            Vector3 backGroundSpawnLocationDownRight = getSpawnLocation((ball.position.x + 38), (ball.position.y - 25), 0);
            Vector3 backGroundSpawnLocationDownLeft = getSpawnLocation((ball.position.x - 7), (ball.position.y - 45), 0);
            backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationDownRight);
            backGroundPoolerHigh.SpawnFromPool(backGroundSpawnLocationDownLeft);
            ballLocationOlder = ballLocationOld;
            ballLocationOld = ballLocation;
            ballLocation = ball.position;
        }


    }
}