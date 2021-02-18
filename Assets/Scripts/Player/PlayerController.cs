using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 4f;

    [SerializeField]
    Transform target;

    public Animator animator;
    public Image image;
    public Image death;

    bool is_down = false;
    public int health = 100;

    void Start()
    {
        animator = GetComponent<Animator>();
        //image = GetComponent<Image>();
        death.enabled = false;
    }


    void Update()
    {
        Vector3 pos = target.transform.position;
        Vector3 pos2 = this.transform.position;
        pos2.y = 0;
        pos.y = 0;
        Vector3 dir = (pos - pos2);
        Debug.DrawLine(pos, pos2, Color.red);

        if (health <= 0)
        {
            death.enabled = true;
            return;
        }

        if (Input.GetMouseButtonDown(1)) is_down = true;
        if (Input.GetMouseButtonUp(1))
        {
            animator.ResetTrigger("Walking");
            animator.SetTrigger("Idle");
            is_down = false;

        }
        if (Input.GetMouseButton(1) && is_down)
        {
            animator.SetTrigger("Walking");
            animator.ResetTrigger("Idle");
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, dir, moveSpeed * Time.deltaTime * 10, 0.0f);
            Debug.DrawRay(transform.position, newDirection, Color.red);

            transform.position += dir.normalized * moveSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(newDirection);
        }

        if(Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
        image.fillAmount = (float) health / 100;
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Enemies")
        {
            health -= 5;
        }
    }
}
