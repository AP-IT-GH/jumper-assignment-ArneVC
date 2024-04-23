using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class AgentScript : Agent
{
    Rigidbody rb;
    public float jumpForce = 10f;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    public override void OnEpisodeBegin()
    {
        this.transform.localPosition = new Vector3(0.0f, 1.5f, -43.0f);
        this.transform.localRotation = Quaternion.identity;
    }

    public override void CollectObservations(VectorSensor sensor)
    {

    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var actions = actionBuffers.DiscreteActions;
        if (actions[0] == 1)
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
