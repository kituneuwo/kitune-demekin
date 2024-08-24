using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{


    // 破壊対象となるGameObject
    [SerializeField] private GameObject targetObject;
    // 再生成するまでの待機時間
    [SerializeField] private float respawnDelay = 2.0f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        // 破壊対象の初期位置と回転を保存
        originalPosition = targetObject.transform.position;
        originalRotation = targetObject.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // 当たったオブジェクトがtargetObjectと同じなら
        if (collision.gameObject == targetObject)
        {
            // 破壊して
            Destroy(targetObject);

            // 一定時間後に再生成
            Invoke(nameof(Respawn), respawnDelay);
        }
    }

    private void Respawn()
    {
        // targetObjectを元の位置と回転で再生成
        targetObject = Instantiate(targetObject, originalPosition, originalRotation);
    }
}
