using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleRope : MonoBehaviour
{
    //grapple gun feature
    Vector3 direction;
    [SerializeField]
    private float dis;
    public Transform shootPoint;

    private LineRenderer Rope;
    private SpringJoint2D grappleJoint;
    Vector3 grapplePoint;
    // float time = 20f;
    //grapple gun feature

    void Start()
    {
        // grapple gun
        grappleJoint = gameObject.AddComponent<SpringJoint2D>();
        grappleJoint.enabled = false;   
        Rope = gameObject.GetComponent<LineRenderer>();
        // grapple gun

        
    }

    void Update()
    {
        

        // grapple gun
        if(Input.GetMouseButtonDown(1)){
            StartGrapple();
        }
        else if(Input.GetMouseButtonUp(1)){
            StopGrapple();        
        }
        DrawRope();
        // grapple gun

        
    }
    // grapple gun feature functions
    void StartGrapple()
    {
        direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootPoint.position;
        RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, direction, dis);
        if (hit.collider != null)
        {
            grapplePoint = hit.point;
            grappleJoint.enabled = true;
            grappleJoint.connectedAnchor = grapplePoint;
            grappleJoint.autoConfigureConnectedAnchor = false;
            grappleJoint.distance = hit.distance*Time.deltaTime;
            // grappleJoint.dampingRatio = 10f;
            
        }        
    }
    void StopGrapple(){
        grappleJoint.enabled = false;
    }

    void Rope_Line(Vector3 start_point, Vector3 end_point){
        Rope.positionCount = 2;
        Vector3[] points = new Vector3[2];
        points[0] = start_point;
        points[1] = end_point;
        Rope.SetPositions(points);
    }

    void EndLine(){
        Rope.positionCount = 0;
    }

    void DrawRope(){
        if(grappleJoint.isActiveAndEnabled){
            Rope_Line(shootPoint.position, grapplePoint);
        }
        else{
            EndLine();
        }
    } 
    // grapple gun feature functions


    
   

}
