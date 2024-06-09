using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    private const double _V = 0.1;
    private const double V = 0.3;
    float x, z;
    float speed = 0.1f;


    public GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 3f, Ysensityvity = 3f;

    bool cursorLock = true;

    //�ϐ��̐錾(�p�x�̐����p)
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
        // �}�E�X�̓��͂��擾
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;



        if (Time.timeScale > 0) // �^�C���X�P�[����0�łȂ��ꍇ�ɂ̂݉�]������
        {
            // �J�����̉�]����
            cameraRot *= Quaternion.Euler(yRot, 0, 0);
            characterRot *= Quaternion.Euler(0, xRot, 0);

            // Update�̒��ō쐬�����֐����Ă�
            cameraRot = ClampRotation(cameraRot);

            // �J�����ƃL�����N�^�[�̉�]��K�p
            cam.transform.localRotation = cameraRot;
            transform.localRotation = characterRot;

            // �J�[�\���̃��b�N��Ԃ��X�V
            UpdateCursorLock();
        }
    }

    void StepUp(float stepHeight)
    {
        RaycastHit hit;
        float raycastDistance = stepHeight + 0.1f; // Ray���K�i�Ƀq�b�g���鋗����\�ߐݒ�

        if (Physics.Raycast(transform.position, Vector3.down, out hit, raycastDistance))
        {
            // �n�ʂ�Ray������������A�v���C���[����Ɉړ�������
            Vector3 groundNormal = hit.normal; // �q�b�g�����n�_�̖@�����擾

            // �v���C���[���K�i�̖@���ɏ]���Ĉړ�������
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

        transform.position += cam.transform.forward * z + cam.transform.right * -x;

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

    //�p�x�����֐��̍쐬
    public Quaternion ClampRotation(Quaternion q)
    {
        //q = x,y,z,w (x,y,z�̓x�N�g���i�ʂƌ����j�Fw�̓X�J���[�i���W�Ƃ͖��֌W�̗ʁj)

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