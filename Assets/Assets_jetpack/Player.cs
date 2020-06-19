using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	
	Rigidbody body;
	
	public bool gameOver = false;
	public bool isGrounded = false;
	public Animator PlayerAnimator;
	public GameHandler GameHandler;
	public int force=50;
	public float velocity = 0.25f;
    public GameObject tiroPrefab;
    public Transform firePoint;


	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody>();
		GameHandler.GetComponentInParent<GameHandler>();
	}
	
	void FixedUpdate () {
		if (gameOver) {
			GameHandler.PlayerDied();
			return;
		}
		if (Input.GetMouseButton(0)) {
			body.AddForce(new Vector3(0, force, 0), ForceMode.Acceleration);
		} else if (Input.GetMouseButtonUp(0)) {
			body.velocity *= velocity;
		}
        if (Input.GetKeyDown("space"))
        {
            Shoot();
			SoundManager.PlaySound(SoundManager.Sound.Shoot);
            if (isGrounded)
            {
                PlayerAnimator.SetBool("shot_stand", true);
                PlayerAnimator.SetBool("shotting_air", false);
            }
            else
            {
                PlayerAnimator.SetBool("shotting_air", true);
                PlayerAnimator.SetBool("shot_stand", false);
            }
            
        }
        if (Input.GetKeyUp("space"))
        {
            PlayerAnimator.SetBool("shot_stand", false);
            PlayerAnimator.SetBool("shotting_air", false);
        }

    }

    void Shoot()
    {
        Instantiate(tiroPrefab, firePoint.position, firePoint.rotation);
    }
	
	void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("ground") && isGrounded==false)
        {
			PlayerAnimator.SetBool("ground",true);
			PlayerAnimator.SetBool("walk", true);
			isGrounded = true;
		}
        else
        {
			PlayerAnimator.SetBool("die_air", true);
			gameOver = true;
			body.isKinematic = true;
		}

	}
    private void OnTriggerExit(Collider collider)
    {
		if (collider.CompareTag("ground") && isGrounded==true)
		{
			PlayerAnimator.SetBool("ground", false);
			PlayerAnimator.SetBool("walk", false);
			isGrounded = false;
		}
	}
}
