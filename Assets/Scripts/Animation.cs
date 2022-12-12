using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    public Animator animator;
    float velocity = 0.0f;
    public float acceleration = 0.2f;
    public float deceleration = 0.5f;
    int VelocityHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        VelocityHash = Animator.StringToHash("Velocity");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(x, 0, z);
        
        if (move.magnitude > 0.0f)
        {
            velocity += Time.deltaTime * acceleration;
        }
        if (move.magnitude < 0.1f)
        {
            velocity -= Time.deltaTime * acceleration;
            velocity = 0.0f;
        }
        animator.SetFloat(VelocityHash, velocity);
    }
}
