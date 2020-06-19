using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour {
	
	public GameObject prevCeiling;
	public GameObject prevFloor;
    public GameObject prevFundo;
    public GameObject ceiling;
	public GameObject floor;
    public GameObject fundo;

    public GameObject player;
	
	public GameObject obstacle1;
	public GameObject obstacle2;
	public GameObject obstacle3;
	public GameObject obstacle4;
    public GameObject nave;
    public GameObject fundoPrefab;

    public GameObject obstaclePrefab;
    public GameObject navePrebab;
    public int Mode = 0;
	public float minObstacleY;
	public float maxObstacleY;
	
	public float minObstacleSpacing;
	public float maxObstacleSpacing;
	
	public float minObstacleScaleY;
	public float maxObstacleScaleY;

	// Use this for initialization
	void Start () {
		obstacle1 = GenerateObstacle(player.transform.position.x + 10, obstaclePrefab, 1);
		obstacle2 = GenerateObstacle(obstacle1.transform.position.x, obstaclePrefab, 1);
		obstacle3 = GenerateObstacle(obstacle2.transform.position.x, obstaclePrefab, 1);
		obstacle4 = GenerateObstacle(obstacle3.transform.position.x, obstaclePrefab, 1);
        if (Mode == 0)
        {
            nave = GenerateObstacle(player.transform.position.x + 15, navePrebab, 2);
        }
    }
    // TIPO 1 = obstaculo Tipo 2 = nave Tipo 3 = alien
    GameObject GenerateObstacle(float referenceX, GameObject objeto, int tipo) {
		GameObject obstacle = GameObject.Instantiate(objeto);
		SetTransform(obstacle,referenceX, tipo);
		return obstacle;
	}
	
	void SetTransform(GameObject obstacle, float referenceX, int tipo) {
		obstacle.transform.position = new Vector3(referenceX + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObstacleY), 0);
        if (Mode == 1)
        {
			obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, 0.15f, obstacle.transform.localScale.z);
		}
        else if (Mode == 0 && tipo == 1)
        {
			obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, Random.Range(minObstacleScaleY / 5, maxObstacleY / 10), obstacle.transform.localScale.z);
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (player.transform.position.x > floor.transform.position.x) {
			var tempCeiling = prevCeiling;
			var tempFloor = prevFloor;
            var tempFundo = prevFundo;
            prevCeiling = ceiling;
			prevFloor = floor;
            prevFundo = fundo;
            tempCeiling.transform.position += new Vector3(80, 0, 0);
			tempFloor.transform.position += new Vector3(80, 0, 0);
            tempFundo.transform.position += new Vector3(80, 0, 0);
            ceiling = tempCeiling;
			floor = tempFloor;
            fundo = tempFundo;
        }
		
		if (player.transform.position.x > obstacle2.transform.position.x) {
			var tempObstacle = obstacle1;
			obstacle1 = obstacle2;
			obstacle2 = obstacle3;
			obstacle3 = obstacle4;
			
			SetTransform(tempObstacle, obstacle3.transform.position.x, 1);
            obstacle4 = tempObstacle;
			
		}
        if (player.transform.position.x - 7 > nave.transform.position.x && Mode == 0)
        {
            nave.SetActive(true);
            SetTransform(nave, nave.transform.position.x + 24, 2);
        }
    }
}
