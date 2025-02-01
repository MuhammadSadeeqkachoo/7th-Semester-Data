using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class PlayerController11 : MonoBehaviour
{
    Animator animator;
    float speed = 2.0f;
    public float rotationSpeed = 5f;
    public GameObject W, A, S, D;
    private Vector3 movementDirection = Vector3.zero;
    AudioSource punchSound;
    public float playerHealth = 100;
    public Image Healthbar;
    public GameObject gameOverPanel;



    int walkHash, punchHash, defeatHash;
    Quaternion targetRotation;

    public delegate void PlayerActionHandler();
    public static event PlayerActionHandler OnPunch;
    public static event PlayerActionHandler OnKick;




    // Start is called before the first frame update
    void Start()
    {

        punchSound = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        walkHash = Animator.StringToHash("Walk");
        punchHash = Animator.StringToHash("Punch");
        defeatHash = Animator.StringToHash("PlayerHealth");

        EventTrigger W_ET = W.AddComponent<EventTrigger>();
        EventTrigger S_ET = S.AddComponent<EventTrigger>();
        EventTrigger A_ET = A.AddComponent<EventTrigger>();
        EventTrigger D_ET = D.AddComponent<EventTrigger>();


        EventTrigger.Entry Forwardwalk = new EventTrigger.Entry();
        EventTrigger.Entry Backwardwalk = new EventTrigger.Entry();
        EventTrigger.Entry Leftwalk = new EventTrigger.Entry();
        EventTrigger.Entry Rightwalk = new EventTrigger.Entry();

        EventTrigger.Entry release = new EventTrigger.Entry();

        Forwardwalk.eventID = EventTriggerType.PointerDown;
        Backwardwalk.eventID = EventTriggerType.PointerDown;
        Leftwalk.eventID = EventTriggerType.PointerDown;
        Rightwalk.eventID = EventTriggerType.PointerDown;

        release.eventID = EventTriggerType.PointerUp;
        release.callback.AddListener(upPointer);

        Forwardwalk.callback.AddListener(forward);
        Backwardwalk.callback.AddListener(backward);
        Leftwalk.callback.AddListener(left);
        Rightwalk.callback.AddListener(right);

        W_ET.triggers.Add(Forwardwalk);
        W_ET.triggers.Add(release);

        S_ET.triggers.Add(Backwardwalk);
        S_ET.triggers.Add(release);

        A_ET.triggers.Add(Leftwalk);
        A_ET.triggers.Add(release);

        D_ET.triggers.Add(Rightwalk);
        D_ET.triggers.Add(release);



    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(movementDirection * speed * Time.deltaTime);

        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.Q))
        {
            OnPunch = TriggerPunchAnimation;
            OnPunch();
            OnPunch -= TriggerPunchAnimation;

        }

        // Trigger kick animation (Mouse0 + W)
        if (Input.GetMouseButtonDown(0) && Input.GetKey(KeyCode.W))
        {
            OnKick = TriggerKickAnimation;
            OnKick();
            OnKick = TriggerKickAnimation;

        }

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);


    }

    private void TriggerPunchAnimation()
    {
        animator.SetTrigger("Punch");
    }

    private void TriggerKickAnimation()
    {
        animator.SetTrigger("Kick");
    }

    public void forward(BaseEventData x)
    {


        animator.SetTrigger(walkHash);
        movementDirection = Vector3.forward;
        targetRotation = Quaternion.Euler(0, 0, 0);

    }

    public void backward(BaseEventData x)
    {
        animator.SetBool(walkHash, true);
        movementDirection = Vector3.forward;
        targetRotation = Quaternion.Euler(0, 180, 0);


    }

    public void left(BaseEventData x)
    {
        animator.SetBool(walkHash, true);
        movementDirection = Vector3.forward;
        targetRotation = Quaternion.Euler(0, -90, 0);


    }

    public void right(BaseEventData x)
    {
        animator.SetBool(walkHash, true);
        movementDirection = Vector3.forward;
        targetRotation = Quaternion.Euler(0, 90, 0);


    }


    public void upPointer(BaseEventData x)
    {
        animator.SetBool(walkHash, false);
        movementDirection = Vector3.zero;

    }

    public void PunchSound()
    {
        punchSound.Play();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EDamage"))
        {
            TakeDamage(10);
            animator.SetFloat(defeatHash,playerHealth);

        }
    }
    


    void TakeDamage(float Damage )
    {
        playerHealth -= Damage;
        Healthbar.fillAmount -= Damage/100;
    }

    public void PlayerDied()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }
}