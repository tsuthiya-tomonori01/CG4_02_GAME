using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

using Input = UnityEngine.Input;

public class PlayerScript : MonoBehaviour
{

    public Rigidbody rb;

    public GameObject BombParticle;

    private AudioSource audioSource;

    public Animator animator;

    const float moveSpeed = 3.0f;

    const float jumpSpeed = 1.0f;

    private bool isBlock = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);

            Instantiate(BombParticle, transform.position, Quaternion.identity);

            audioSource.Play();
            
            GameManagerScript.score += 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        Quaternion.Euler(0, 90, 0);
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (GoalScript.isGameClear == false) 
        {
            Vector3 v = rb.velocity;

            float stick = Input.GetAxis("Horizontal");

            if (Input.GetKey(KeyCode.RightArrow) || stick > 0)
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);

                animator.SetBool("mode", true);

                v.x = moveSpeed;
            }

            else if (Input.GetKey(KeyCode.LeftArrow) || stick < 0)
            {
                transform.rotation = Quaternion.Euler(0, 240, 0);

                animator.SetBool("mode", true);

                v.x = -moveSpeed;
            }

            else
            {
                v.x = 0;

                animator.SetBool("mode", false);
            }
            rb.velocity = v;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayPosition = transform.position + new Vector3(0.0f, 0.8f, 0.0f);

        Ray ray = new Ray(rayPosition, Vector3.down);

        float distance = 0.9f;
        
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.green);

        isBlock = Physics.Raycast(ray, distance);

        if (GoalScript.isGameClear == false)
        {
            Vector3 j = rb.velocity;

            if (Input.GetButtonDown("Jump") && isBlock == true)
            {
                j.y = jumpSpeed * 6;
            }

            if(isBlock == true)
            {
                animator.SetBool("Jamp", false);
            }
            else
            {
                animator.SetBool("Jamp", true);
            }

            rb.velocity = j;
        }
    }
}
