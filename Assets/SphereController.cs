using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class SphereController : MonoBehaviour
{
    public SteamVR_Action_Vector2 moveAction = 
        SteamVR_Input.GetAction<SteamVR_Action_Vector2>("platformer", "Move");
    private SteamVR_Input_Sources hand;
    public RemoteControlledCharacter character;

    private Interactable interactable;
    private Vector3 movement;
    
    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interactable.attachedToHand)
        {
            hand = interactable.attachedToHand.handType;
            Vector2 m = moveAction[hand].axis;
            movement = new Vector3(m.x, 0, m.y);
            
            float rot = transform.eulerAngles.y;

            movement = Quaternion.AngleAxis(rot, Vector3.up) * movement;
            character.Move(movement);  
        }
    }
}
