using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viscosity : MonoBehaviour {
    public float viscosityConstant = 0.01f;     // 粘滞阻力系数
    public float criticalVelocity = 5;      // 使粘滞物体散乱的临界速度

    void OnTriggerStay2D(Collider2D other)
    {
        ViscosityRigibody viscosityObj = other.GetComponent<ViscosityRigibody>();

        if(viscosityObj != null)
        {
            Vector2 velocity = other.GetComponent<Rigidbody2D>().velocity;

            if(velocity.magnitude < criticalVelocity)
            {
                other.GetComponent<Rigidbody2D>().AddForce(-viscosityConstant * viscosityObj.constant * velocity.magnitude * velocity.normalized, ForceMode2D.Impulse);
            }
            else
            {
                other.GetComponent<Rigidbody2D>().AddForce(-viscosityConstant * viscosityObj.constant * Mathf.Pow(velocity.magnitude, 2) * velocity.normalized, ForceMode2D.Impulse);
            }
        }
    }
}
