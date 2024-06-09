using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private const double _V = 0.1;
    private const double V = 0.3;
    float x, z;
    [SerializeField]
    float speed;

    public GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;

    bool cursorLock = true;

    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

    // Start is called before the first frame update
    void Start()
    {

        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;

    }


    // Update is called once per frame
    void Update()
    {
        // マウスの入力を取得
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;



        if (Time.timeScale > 0) // タイムスケールが0でない場合にのみ回転を処理
        {
            // カメラの回転処理
            cameraRot *= Quaternion.Euler(yRot, 0, 0);
            characterRot *= Quaternion.Euler(0, xRot, 0);

            // Updateの中で作成した関数を呼ぶ
            cameraRot = ClampRotation(cameraRot);

            // カメラとキャラクターの回転を適用
            cam.transform.localRotation = cameraRot;
            transform.localRotation = characterRot;

            // カーソルのロック状態を更新
            UpdateCursorLock();
        }
    }

    void StepUp(float stepHeight)
    {
        RaycastHit hit;
        float raycastDistance = stepHeight + 0.1f; // Rayが階段にヒットする距離を予め設定

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            // 地面にRayが当たったら、プレイヤーを上に移動させる
            Vector3 groundNormal = hit.normal; // ヒットした地点の法線を取得

            // プレイヤーを階段の法線に従って移動させる
            Vector3 newPosition = transform.position + groundNormal * (stepHeight - hit.distance);
            transform.position = newPosition;
        }
    }


    private void FixedUpdate()
    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        //transform.position += new Vector3(x,0,z);

        transform.position -= cam.transform.forward * z + cam.transform.right * x;

    }


    public void UpdateCursorLock()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {

            speed = (float)V;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = (float)_V;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cursorLock = false;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            cursorLock = false;
        }
        else if (Input.GetMouseButton(0))
        {
            cursorLock = true;
        }


        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if (!cursorLock)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }

}