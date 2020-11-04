using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.AI;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
	private ARRaycastManager raycastManager;
	private ARPlaneManager planeManager;
	//private PredictionManager predictionManager;
	public static bool surfaceSelected = false;
	public static ARPlane selectedPlane;
	public GameObject target;
	public GameObject ammo;
	public int level = 1;
	public int numberOfTargets = 5;
	public Text text;
	public GameObject startButton;
	public static bool gameStarted;
	public GameObject[] targetList;
	private GameObject[] targets;

	public UIManager uIManager;

	static List<ARRaycastHit> s_hits = new List<ARRaycastHit>();

	void Awake()
	{
		raycastManager = GetComponent<ARRaycastManager>();
		planeManager = GetComponent<ARPlaneManager>();
		//predictionManager = FindObjectOfType<PredictionManager>();
		//predictionManager = GetComponent<PredictionManager>();

		//uIManager = FindObjectOfType<UIManager>();
	}

	void Update()
	{
		Vector2 touchPosition;

		// Check for touches
		if (Input.touchCount > 0)
			touchPosition = Input.GetTouch(0).position;
		else
			return;

		// Select surface
		if (!surfaceSelected && raycastManager.Raycast(touchPosition, s_hits, TrackableType.PlaneWithinPolygon))
		{
			// Get plane from plane manager
			selectedPlane = planeManager.GetPlane(s_hits[0].trackableId);
			//if (selectedPlane.size[0] > 2 && selectedPlane.size[1] > 2)
			if (selectedPlane.size[0] > 1 && selectedPlane.size[1] > 1)
			{
				surfaceSelected = true;

				text.text = "Surface selected!";

				Debug.Log("Surface selected");

				// Disable all other planes
				DisablePlanes(selectedPlane.trackableId);

				// Build nav mesh on plane
				//selectedPlane.GetComponent<NavMeshSurface>().BuildNavMesh();


				Debug.Log("Nav mesh built");
				Debug.Log("Plane size: " + selectedPlane.size);

				// Disable text and enable start button
				text.gameObject.SetActive(false);
				startButton.SetActive(true);
			}
			else
				text.text = "Surface too small!";
		}

	}

	void DisablePlanes(TrackableId id)
	{
		planeManager.enabled = false;

		foreach (var plane in planeManager.trackables)
		{
			if (plane.trackableId != id)
				plane.gameObject.SetActive(false);

			
			else if (plane.trackableId == id)
			{
				plane.GetComponent<LineRenderer>().enabled = false;
				plane.GetComponent<MeshRenderer>().enabled = false;
				plane.GetComponent<ARPlaneMeshVisualizer>().enabled = false;
			}
			
				
		}


		Debug.Log("Planes disabled");
	}

	public void RestartGame()
	{
		foreach (GameObject target in targets)
			Destroy(target);

		StartGame();
	}

	public void StartGame()
    {
		startButton.SetActive(false);
		SpawnTargets();
		SpawnAmmo();
		uIManager.PlayGameUI();
		GameManager.PlayAgain();
		gameStarted = true;
	}

	public void QuitGame()
    {
		Application.Quit();
    }

	void SpawnTargets()
    {
		Bounds bounds = selectedPlane.GetComponent<MeshCollider>().bounds;

		for (int i = 0; i < numberOfTargets; i++)
		{
			
			Vector3 position = bounds.center;
			position.y += 0.07f;
			int rand = Random.Range(0, 4);
			GameObject targetObject = Instantiate(targetList[rand], position, Quaternion.identity);

			/*
			Vector3 point;
			do
			{
				point = new Vector3(Random.Range(bounds.min.x, bounds.max.x), selectedPlane.transform.position.y, Random.Range(bounds.min.z, bounds.max.z));
			} while (point != selectedPlane.GetComponent<MeshCollider>().ClosestPoint(point));

			point.y += 0.07f;

			targetObject.transform.position = point;
			
			
			for (int j = 0; j < 30; j++)
			{
				//Vector3 randomDirection = Random.insideUnitSphere * 2 + transform.position;
				Vector3 randomDirection = Random.insideUnitSphere * 1 + selectedPlane.center;
				NavMeshHit navHit;
				if (NavMesh.SamplePosition(randomDirection, out navHit, 1, NavMesh.AllAreas))
				{
					Debug.Log("Nav mesh exists???????");
					Debug.Log("Navmesh hit point" + navHit.position);
					GameObject targetObject = Instantiate(target, navHit.position, Quaternion.identity);
					//GameObject targetObject = Instantiate(target, selectedPlane.transform.position, Quaternion.identity);
					if (!targetObject.GetComponent<NavMeshAgent>().Warp(navHit.position))
						continue;
					//Debug.Log("Target placed");
					break;
				}
			}
			*/
		}
		
		targets = GameObject.FindGameObjectsWithTag("Target");

		Debug.Log("Targets spawned");
    }

	public void SpawnAmmo()
    {
		//Instantiate(ammo, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane)), Quaternion.identity, Camera.main.transform);

		GameObject instantiatedAmmo = Instantiate(ammo, Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane)), Quaternion.identity);
		instantiatedAmmo.GetComponent<PredictionManager>().enabled = true;

		Debug.Log("Ammo spawned");
    }

    private void OnEnable()
    {
		Debug.Log("OnEnable");
		surfaceSelected = false;
		selectedPlane = null;
    }
}