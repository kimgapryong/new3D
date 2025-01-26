using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputManager inputManager;
    public float speed = 10;
    Vector3 mousePoint;

    bool moveDest;
    private void Start()
    {
        inputManager = Manager.inputManager;
        inputManager.inputAction -= MoveInput;
        inputManager.inputAction += MoveInput;
    }

    private void LateUpdate()
    {
        if(moveDest)
        {
            Vector3 newPoint = mousePoint - transform.position;
            if (newPoint.magnitude < 0.1f)
            {
                moveDest = false;
            }
            else
            {
                float dir = Mathf.Clamp(speed * Time.deltaTime, 0, newPoint.magnitude);
                transform.position += speed * dir * newPoint.normalized;
                transform.LookAt(newPoint);
            }

        }

    }
    public void MoveInput(InputManager.InputMode inputMode)
    {
        if(inputMode == InputManager.InputMode.Click)
            return;
        
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f, LayerMask.GetMask("Ground")))
            {
                mousePoint = hit.point;
                moveDest = true;
            }
        
    }
}
