using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonH : MonoBehaviour
{
    public GameObject door; // ドアオブジェクト
    public Vector3 doorOpenPosition; // ドアの開く位置
    public float moveSpeed = 1f; // ドアの移動速度

    private bool isOpening = false;
    private Vector3 originalPosition;

    void Start()
    {
        if (door != null)
        {
            originalPosition = door.transform.position; // ドアの元の位置を保存
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Shoot") // Shootが当たったかどうか確認
        {
            isOpening = true; // ドアを開くフラグを設定
        }
    }

    void Update()
    {
        if (isOpening && door != null)
        {
            // ドアを開く位置まで移動
            door.transform.position = Vector3.MoveTowards(door.transform.position, doorOpenPosition, moveSpeed * Time.deltaTime);
        }
    }
}
