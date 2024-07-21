using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private BulletScript_3D Bulletspeed = new BulletScript_3D();
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
    void Update()
    {
        if(Vector3.Distance(this.transform.position,playerObj.transform.position) < shootDistance)
        {
            MoveSpeedNow = playerObj.transform.position - MoveSpeedBefore;
            MoveSpeedBefore = playerObj.transform.position;
            TargetDistance = Vector3.Distance(this.transform.position, playerObj.transform.position);
            MoveSpeedAfter = playerObj.transform.position + MoveSpeedNow;
            //* TargetDistance / (Bulletspeed.BulletSpeed / 0.5f) / Time.deltaTime;
            Debug.Log(MoveSpeedNow@+ "(ˆÚ“®‹——£)");
            Debug.Log(MoveSpeedAfter + "(—\‘ªæ)");
            transform.LookAt(MoveSpeedAfter);
        }
    }
}
