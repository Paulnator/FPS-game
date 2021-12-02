using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 0618 //'NetworkBehaviour' is obsolete: 'The high level API classes are deprecated and will be removed in the future.
public class PlayerShoot : NetworkBehaviour{

    private const string PLAYER_TAG = "Player";

    public PlayerWeapon weapon;

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

     void Start()
    {
        if(cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced");
            this.enabled = false;
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    [Client]
    void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask ))
        {
            if(_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name);
            }
        }

    }

    [Command]
    void CmdPlayerShot(string _ID)
    {

        Debug.Log(_ID + "has been shot");

        

    }
}