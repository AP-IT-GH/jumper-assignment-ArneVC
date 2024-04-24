using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class AgentScript : Agent
{
    Rigidbody rb;
    public float jumpForce = 2.5f;
    private GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    public override void OnEpisodeBegin()
    {
        this.transform.localPosition = new Vector3(0.0f, 1.5f, -43.0f);
        this.transform.localRotation = Quaternion.identity;
        rb.freezeRotation = true;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(transform.localPosition.y);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var actions = actionBuffers.ContinuousActions;
        if (actions[0] > 0)
        {
            Jump();
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut.Clear();
        if (Input.GetKey(KeyCode.Space))
        {
            continuousActionsOut[0] = 1;
        }
        else
        {
            continuousActionsOut[0] = 0;
        }
    }
    public void WallDestroyed()
    {
        AddReward(0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        rb.freezeRotation = true;
        if(!collision.gameObject.CompareTag("Floor"))
        {
            gameManager.ResetWalls();
            EndEpisode();
        }        
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
