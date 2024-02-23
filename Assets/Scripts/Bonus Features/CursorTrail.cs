using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrail : MonoBehaviour
{
    public Color trailColor = new Color(0, 0, 255);
    public float distanceFromCamera = 10;
    public float startWidth = 0.1f;
    public float endWidth = 0f;
    public float trailTime = 4f;

    private Transform trailTransform;
    private Camera mainCamera;

    public GameObject trailObj;
    public TrailRenderer trail;

    //public GameObject edgeColliderObject;
    public BoxCollider boxCollider;

    private GameManagerB gameManager;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GetComponent<Camera>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerB>();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && trailObj == null && !gameManager.isGamePaused&& gameManager.isGameActive)
        {
            trailObj = new GameObject("Mouse Trail");
            trailObj.tag = "Cursor Trail";
            trail = trailObj.AddComponent<TrailRenderer>();

            boxCollider = trailObj.AddComponent<BoxCollider>();
            boxCollider.size = new Vector3(0.3f, 0.3f,0.3f);

            trail.sharedMaterial = new Material(Shader.Find("Unlit/Color"));
            trail.sharedMaterial.color = trailColor;
        }

        if (Input.GetMouseButtonUp(0))
        {

            //Destroy(edgeColliderObject);
            Destroy(trailObj);

        }

        if (trailObj != null)
        {
            trailTransform = trailObj.transform;
            trail.time = trailTime;
            MoveTrailToCursor(Input.mousePosition);
            trail.time = trailTime;
            trail.startWidth = startWidth;
            trail.endWidth = endWidth;
            trail.numCapVertices = 2;
        }
    }


    void MoveTrailToCursor(Vector3 screenPosition)
    {
        trailTransform.position = mainCamera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, distanceFromCamera));
    }
}
