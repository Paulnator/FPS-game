using UnityEngine;
using UnityEngine.Networking;

#pragma warning disable 0618 //'NetworkBehaviour' is obsolete: 'The high level API classes are deprecated and will be removed in the future.
public class PlayerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componentsToDisable;
    [SerializeField]
    string remoteLayerName = "RemotePlayer";

    Camera SceneCamera;

    void Start()
    {
        if (!isLocalPlayer)
        {
            DisableComponents();
            AssingRemoteLayer();
        }
        else
        {
            SceneCamera = Camera.main;
            if(SceneCamera != null)
            {
                SceneCamera.gameObject.SetActive(false);
            }      
        }

        RegisterPlayer();

    }

    void RegisterPlayer()
    {
        string _ID = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = _ID;
    }

    void  AssingRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    void  DisableComponents()
    {
        for (int i = 0; i < componentsToDisable.Length; i++)
        {
            componentsToDisable[i].enabled = false;
        }
    }

    void OnDisable()
    {
        if(SceneCamera != null)
        {
            SceneCamera.gameObject.SetActive(true);
        }
    }


}
