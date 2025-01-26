using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerController10 : MonoBehaviour
{
    Animator animator;
    Rigidbody rb;
    float speed = 1.0f;
    public float rotationSpeed = 5f;
    public GameObject W, A, S, D;
    private Vector3 movementDirection = Vector3.zero;


    int walkHash, punchHash;
    Quaternion targetRotation;

    public delegate void PlayerActionHandler();
    public static event PlayerActionHandler OnPunch;
    public static event PlayerActionHandler OnKick;




    // Start is called before the first frame update
    void Start()
    {

        OnPunch += TriggerPunchAnimation;
        OnKick += TriggerKickAnimation;

        animator = GetComponent<Animator>();
        walkHash = Animator.StringToHash("Walk");
        punchHash = Animator.StringToHash("Punch");

        rb = GetComponent<Rigidbody>();

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

        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.Q))
        {
            OnPunch?.Invoke();
        }

        // Trigger kick animation (Mouse0 + W)
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.W))
        {
            OnKick?.Invoke();
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


    private void OnDestroy()
    {
        // Unsubscribe methods to avoid memory leaks
        OnPunch -= TriggerPunchAnimation;
        OnKick -= TriggerKickAnimation;
    }

    public void upPointer(BaseEventData x)
    {
        animator.SetBool(walkHash, false);
        movementDirection = Vector3.zero;

    }
}