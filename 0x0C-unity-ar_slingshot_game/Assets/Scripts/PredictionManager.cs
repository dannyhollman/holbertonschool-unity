using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


public class PredictionManager : MonoBehaviour
{
    Scene currentScene;
    Scene predictionScene;

    PhysicsScene currentPhysicsScene;
    PhysicsScene predictionPhysicsScene;

    GameObject dummy;

    // Start is called before the first frame update
    void Start()
    {
        Physics.autoSimulation = false;

        //touchController = FindObjectOfType<TouchController>();

        currentScene = SceneManager.GetActiveScene();
        currentPhysicsScene = currentScene.GetPhysicsScene();

        CreateSceneParameters parameters = new CreateSceneParameters(LocalPhysicsMode.Physics3D);
        if (SceneManager.GetSceneByName("Prediction").IsValid())
            predictionScene = SceneManager.GetSceneByName("Prediction");
        else
            predictionScene = SceneManager.CreateScene("Prediction", parameters);
        predictionPhysicsScene = predictionScene.GetPhysicsScene();

        //CopyPlane();
    }

    void FixedUpdate()
    {
        if (currentPhysicsScene.IsValid())
        {
            currentPhysicsScene.Simulate(Time.fixedDeltaTime);
        }
    }

    public void CopyPlane()
    {
                GameObject plane = Instantiate(PlaneController.selectedPlane.gameObject);
                plane.transform.position = PlaneController.selectedPlane.transform.position;
                plane.transform.rotation = PlaneController.selectedPlane.transform.rotation;
                Renderer planeR = plane.GetComponent<MeshRenderer>();
                if (planeR)
                {
                    planeR.enabled = false;
                }
                SceneManager.MoveGameObjectToScene(plane, predictionScene);
    }

    public void Predict(GameObject subject, Vector3 currentPosition, Quaternion currentRotation, Vector3 force, LineRenderer lineRenderer)
    {
        if (currentPhysicsScene.IsValid() && predictionPhysicsScene.IsValid())
        {
            if (dummy == null)
            {
                dummy = Instantiate(subject);
                SceneManager.MoveGameObjectToScene(dummy, predictionScene);
            }

            dummy.transform.position = currentPosition;
            dummy.GetComponent<Rigidbody>().isKinematic = false;
            dummy.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
            lineRenderer.positionCount = 0;
            lineRenderer.positionCount = 20;

            int i;
            for (i = 0; i < 20; i++)
            {
                lineRenderer.SetPosition(i, dummy.transform.position);
                predictionPhysicsScene.Simulate(Time.fixedDeltaTime);
            }

            Destroy(dummy);
        }
    }
}