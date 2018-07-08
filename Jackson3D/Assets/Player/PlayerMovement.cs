using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.EventSystems;

[RequireComponent(typeof(ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float walkMoveStopRadius = 0.2f;

    int floorMask;
    float camRayLength = 100;
    Animator anim;

    ThirdPersonCharacter thirdPersonCharacter;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster;
    Vector3 currentDestination, clickPoint;
    Shooting _shooting;
    Item _weapon;
    bool isInDirectMode = false;
    GameObject weapon;
    Rigidbody rigid;
    public bool canShoot;
    bool isWalkable;
    public bool isItem;
    float walkTimer;
    

    private void Start()
    {
        anim = GetComponent<Animator>();
        floorMask = LayerMask.GetMask("Walkable");
        rigid = GetComponent<Rigidbody>();
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        currentDestination = transform.position;
    }

    // Fixed update is called in sync with physics
    private void FixedUpdate()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (thirdPersonCharacter.carol == Vector3.zero)
        {
            canShoot = true;
        }
        if (thirdPersonCharacter.carol != Vector3.zero)
        {
            canShoot = false;
        }
 
        Turning();
        if (Input.GetKeyDown(KeyCode.G)) // G for gamepad. TODO add to menu
        {
            isInDirectMode = !isInDirectMode; // toggle mode
            currentDestination = transform.position; // clear the click target
        }
        ProcessMouseMovement();
        
    }

    private void ProcessDirectMovement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // calculate camera relative direction to move:
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 movement = v * cameraForward + h * Camera.main.transform.right;

        thirdPersonCharacter.Move(movement, false, false);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;

        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;

            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            rigid.MoveRotation(newRotation);
        }
    }

    private void ProcessMouseMovement()
    {
        if (Input.GetMouseButton(0))
        {
            clickPoint = cameraRaycaster.hit.point;
            switch (cameraRaycaster.currentLayerHit)
            {


                case Layer.Enemy:

                    Shoot();
                    break;
                case Layer.Walkable:

                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        Shoot();
                    }
                    else
                    {
                        isWalkable = true;
                        isItem = false;
                        currentDestination = clickPoint;
                        currentDestination = ShortDestination(clickPoint, walkMoveStopRadius);
                        walkTimer += Time.deltaTime;
                    }                  
                    break;
                case Layer.Item:
                    isWalkable = true;
                    isItem = true;
                    currentDestination = clickPoint;
                    currentDestination = ShortDestination(clickPoint, walkMoveStopRadius );
                    walkTimer += Time.deltaTime;
                    
                    break;
                default:
                    print("Unexpected layer found");
                    return;
            }
        }
        
        var playerToClickPoint = currentDestination - transform.position;
        if (playerToClickPoint.magnitude >= walkMoveStopRadius && isWalkable)
        {
            thirdPersonCharacter.Move(playerToClickPoint, false, false);
        }
        else
        {
            thirdPersonCharacter.Move(Vector3.zero, false, false);
        }
        


    }

    private void Shoot()
    {
        weapon = GameObject.FindGameObjectWithTag("Arma");
        _weapon = weapon.GetComponentInChildren<Item>();
        _shooting = weapon.GetComponentInChildren<Shooting>();
        isWalkable = false;
        isItem = false;
        thirdPersonCharacter.Move(Vector3.zero, false, false);


        if (_shooting.timer >= _weapon.fireRate && canShoot)
        {
            _shooting.Shoot();
        }
    }

    Vector3 ShortDestination(Vector3 destination, float shortening)
    {
        Vector3 reductionVector = (destination - transform.position).normalized * shortening;
        return destination - reductionVector;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(currentDestination, 0.1f);
    }

    
}

