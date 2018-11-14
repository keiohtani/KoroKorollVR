using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {
    
    public GameObject lockedDoor;
    GameManager gameManager;
    Transform rightTorchFireTF;
    Transform leftTorchFireTF;
    ParticleSystem rightTorchFireParticleSystem;
    Light rightTorchFireLight;
    ParticleSystem leftTorchFireParticleSystem;
    Light leftTorchFireLight;

    private void Start()
    {
        rightTorchFireTF = lockedDoor.transform.Find("RightTorch").Find("Fire");
        leftTorchFireTF = lockedDoor.transform.Find("LeftTorch").Find("Fire");

        rightTorchFireLight = rightTorchFireTF.Find("Point Light").gameObject.GetComponent<Light>();
        leftTorchFireLight = leftTorchFireTF.Find("Point Light").gameObject.GetComponent<Light>();

        rightTorchFireParticleSystem = rightTorchFireTF.gameObject.GetComponent<ParticleSystem>();
        leftTorchFireParticleSystem = leftTorchFireTF.gameObject.GetComponent<ParticleSystem>();

        rightTorchFireLight.enabled = false;
        leftTorchFireLight.enabled = false;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Senser")
        {
           
            lockedDoor.GetComponent<Animator>().SetBool("IsUnlocked", true);
            LightUpTorch();
            gameManager.PlayGame();
        }
    }

    void LightUpTorch()
    {
        rightTorchFireParticleSystem.Play();
        leftTorchFireParticleSystem.Play();
        rightTorchFireLight.enabled = true;
        leftTorchFireLight.enabled = true;
    }
}
