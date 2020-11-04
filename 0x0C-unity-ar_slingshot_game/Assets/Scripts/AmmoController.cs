using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    private TouchController touchController;
    private PlaneController planeController;
    private PredictionManager predictionManager;
    private Rigidbody rb;
    public static bool inAir;
    LineRenderer lineRenderer;
    int targetsHit = 0;
    public int ammoCount = 7;
    private Vector3 direction;

    public UIManager uIManager;
    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("AMMO START FUNCTION!!!!!!!!!!!!!!!");
        rb = GetComponent<Rigidbody>();
        touchController = FindObjectOfType<TouchController>();
        lineRenderer = GetComponent<LineRenderer>();
        planeController = FindObjectOfType<PlaneController>();
        predictionManager = FindObjectOfType<PredictionManager>();
        uIManager = FindObjectOfType<UIManager>();
        soundManager = FindObjectOfType<SoundManager>();
        inAir = false;
    }

    /*
    private void FixedUpdate()
    {
        if (touchController.shoot)
        {
            inAir = true;
            lineRenderer.enabled = false;
            touchController.shoot = false;
            rb.useGravity = true;
            rb.velocity = Vector3.zero;

            //rb.AddForce(transform.forward * touchController.power);
            rb.AddForce(direction * touchController.power, ForceMode.Impulse);
            Debug.Log("Power: " + touchController.power);

            uIManager.UpdateAmmo();
        }
    }
    */

    // Update is called once per frame
    void Update()
    {

        if (targetsHit == planeController.numberOfTargets || ammoCount == 0)
        {
            Debug.Log("Out of ammo/targets");
            uIManager.GameOverUI();
            soundManager.PlayGameOver();

            Destroy(gameObject);
        }

        // Keep ammo in center of screen
        if (!touchController.dragging && !touchController.shoot && !inAir && PlaneController.gameStarted)
        {

            Debug.Log("Center of screen");

            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane));
            transform.position = newPosition;
            //transform.rotation = Camera.main.transform.rotation;
            lineRenderer.enabled = false;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            rb.isKinematic = true;
        }
        // Update position to thumb position, enable trajectory prediction 
        else if (touchController.dragging)
        {

            Debug.Log("Dragging");

            lineRenderer.enabled = true;
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(touchController.currentPosition.x, touchController.currentPosition.y, Camera.main.nearClipPlane));
            direction = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, Camera.main.nearClipPlane + 0.5f)) - transform.position;

            predictionManager.Predict(transform.gameObject, transform.position, transform.rotation, direction * touchController.power, lineRenderer);
        }

        // Shoot projectile
        else if (touchController.shoot)
        {
            Debug.Log("Shoot");


            inAir = true;
            lineRenderer.enabled = false;
            touchController.shoot = false;
            rb.isKinematic = false;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
            rb.velocity = Vector3.zero;
            rb.AddForce(direction * touchController.power, ForceMode.Impulse);
            //Debug.Log("Power: " + touchController.power);

            uIManager.UpdateAmmo();
            ammoCount -= 1;
        }
        
       
        // Below plane
        if (transform.position.y < PlaneController.selectedPlane.transform.position.y)
        {
            Debug.Log("Below plane!");
            inAir = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        inAir = false;
        if (collision.gameObject.tag == "Target")
        {
            collision.gameObject.SetActive(false);
            targetsHit += 1;
            uIManager.UpdateScore();
            soundManager.PlayExplosion();
        }
    }
}
