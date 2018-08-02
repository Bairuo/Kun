using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViscosityRigibody : MonoBehaviour {
    // 意义类似于现实中粘滞阻力模型中的半径
    public float constant = 1;
    public float originConstant = 1;

    void Start()
    {
        originConstant = constant;
    }
}
