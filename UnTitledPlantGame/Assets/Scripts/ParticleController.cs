using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] ParticleSystem movementParticle;

    [Range(0,10)]
    [SerializeField] int occurAfterVelocity;

    [Range(0,0.2f)]
    [SerializeField] float dustFormationPeriod;

    [SerializeField] Rigidbody2D playerRb;

    float counter;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)) 
        {
            dustFormationPeriod /= 2f;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            dustFormationPeriod *= 2f;
        }
        
        counter += Time.deltaTime;

        if (Mathf.Abs(playerRb.velocity.x) > occurAfterVelocity || Mathf.Abs(playerRb.velocity.y) > occurAfterVelocity)
        {
            if (counter > dustFormationPeriod)
            {
                
                movementParticle.Play();
                counter = 0;         
            }
        }
    }
}
