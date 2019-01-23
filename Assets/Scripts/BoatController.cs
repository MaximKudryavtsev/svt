using UnityEngine;

public class BoatController : MonoBehaviour
{
    public PropellerBoats ship;
    bool forward = true;

    public bool isControll = true;

    public bool isMove = false;

    public bool doubleSpeed = false;

    public Animator animator;

    public AudioSource audioSource;
    public AudioClip moveSound;
    public AudioClip staySound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySound(staySound);
    }

    void Update()
    {
        if (isControll)
        {
            BoatControll();
            SoundControll();
            SteeringWheelAnimationControll();
        }
        else
        {
            ship.angle = 0;
            ship.ThrottleDown();
        }
    }

    //Управление лодкой
    private void BoatControll()
    {
        Move();
        Turning();
    }

    private void Move()
    {
        if (Input.GetKeyUp(KeyCode.JoystickButton1) || Input.GetKeyUp(KeyCode.C))
            isMove = !isMove;

        if (Input.GetKeyUp(KeyCode.JoystickButton5) || Input.GetKeyUp(KeyCode.R))
            doubleSpeed = !doubleSpeed;

        if (doubleSpeed)
            ship.engine_max_rpm = 3000;
        else
            ship.engine_max_rpm = 1000;

        if (isMove)
            ship.ThrottleUp();
        else
            ship.ThrottleDown();
    }

    private void Turning()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            ship.angle = 0;
        }
        else
        {
            if (PressLeft())
                ship.RudderLeft();
            if (PressRight())
                ship.RudderRight();
        }
    }

    private void SteeringWheelAnimationControll()
    {
        if (Input.GetAxis("Horizontal") == 0)
        {
            animator.SetInteger("direction", 0);
        }
        else
        {
            if (PressLeft())
                animator.SetInteger("direction", -1);
            if (PressRight())
                animator.SetInteger("direction", 1);
        }
    }

    private void SoundControll()
    {
        if (isMove)
        {
            PlaySound(moveSound);
            if (doubleSpeed)
                audioSource.pitch = 0.5f;
            else
                audioSource.pitch = 0.4f;
        }
        else
        {
            PlaySound(staySound);
            audioSource.pitch = 1.0f;
        }
    }

    void PlaySound(AudioClip audioClip)
    {
        if (audioSource.clip != audioClip)
            audioSource.clip = audioClip;
        if (!audioSource.isPlaying)
            audioSource.Play();
    }

    bool PressLeft()
    {
        return Input.GetAxis("Horizontal") < 0 || Input.GetKey(KeyCode.A);
    }

    bool PressRight()
    {
        return Input.GetAxis("Horizontal") > 0 || Input.GetKey(KeyCode.D);
    }
}
