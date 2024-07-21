using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    [SerializeField]
    private float Bulletspeed;
    [SerializeField]
    private GameObject playerObj;
    [SerializeField]
    private float shootDistance;
    private float TargetDistance;
    private Vector3 MoveSpeedBefore;
    private Vector3 MoveSpeedNow;
    private Vector3 MoveSpeedAfter;
    [SerializeField]
    private float limitup;
    [SerializeField]
    private float limitdown;
    [SerializeField]
    private GameObject BulletObject;
    private PlayerC_3D playerC = new PlayerC_3D();
    void Update()
    {
            if (Vector3.Distance(this.transform.position, playerObj.transform.position) < shootDistance)
            {
                MoveSpeedNow = playerObj.transform.position - MoveSpeedBefore;
                MoveSpeedBefore = playerObj.transform.position;
                TargetDistance = Vector3.Distance(this.transform.position, playerObj.transform.position);
                MoveSpeedAfter = MoveSpeedNow * TargetDistance / Bulletspeed / Time.deltaTime + playerObj.transform.position;
                transform.LookAt(MoveSpeedAfter);
                Instantiate(BulletObject, transform.forward * 2.5f + transform.position, Quaternion.Euler(transform.localEulerAngles.x, transform.localEulerAngles.y, -90));
            }
        
    }
}
