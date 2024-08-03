using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonH : MonoBehaviour
{
    public GameObject door; // �h�A�I�u�W�F�N�g
    public Vector3 doorOpenPosition; // �h�A�̊J���ʒu
    public float moveSpeed = 1f; // �h�A�̈ړ����x

    private bool isOpening = false;
    private Vector3 originalPosition;

    void Start()
    {
        if (door != null)
        {
            originalPosition = door.transform.position; // �h�A�̌��̈ʒu��ۑ�
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Shoot") // Shoot�������������ǂ����m�F
        {
            isOpening = true; // �h�A���J���t���O��ݒ�
        }
    }

    void Update()
    {
        if (isOpening && door != null)
        {
            // �h�A���J���ʒu�܂ňړ�
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorOpenPosition, moveSpeed * Time.deltaTime);
        }
    }
}
