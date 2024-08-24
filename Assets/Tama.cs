using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tama : MonoBehaviour
{


    // �j��ΏۂƂȂ�GameObject
    [SerializeField] private GameObject targetObject;
    // �Đ�������܂ł̑ҋ@����
    [SerializeField] private float respawnDelay = 2.0f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        // �j��Ώۂ̏����ʒu�Ɖ�]��ۑ�
        originalPosition = targetObject.transform.position;
        originalRotation = targetObject.transform.rotation;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // ���������I�u�W�F�N�g��targetObject�Ɠ����Ȃ�
        if (collision.gameObject == targetObject)
        {
            // �j�󂵂�
            Destroy(targetObject);

            // ��莞�Ԍ�ɍĐ���
            Invoke(nameof(Respawn), respawnDelay);
        }
    }

    private void Respawn()
    {
        // targetObject�����̈ʒu�Ɖ�]�ōĐ���
        targetObject = Instantiate(targetObject, originalPosition, originalRotation);
    }
}
