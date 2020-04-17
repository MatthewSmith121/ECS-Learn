
using UnityEngine;
using UnityEngine.UI;

public class Activate : MonoBehaviour
{
    public Text activateText;
    public GameObject magicItem;
    Material dissolveMaterial;
    bool inRange;
    bool dissolve;
    float dissolveAmount;
    const float dissolveSpeed = 1f;

    private void Start() {
        dissolveMaterial = magicItem.GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Enter");
        activateText.enabled = true;
        inRange = true;
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Exit");
        activateText.enabled = false;
        inRange = false;
    }

    private void Update() {
        if (dissolve) {
            if (dissolveAmount >= 1f) {
                dissolve = false;
            }
            else {
                dissolveAmount += dissolveSpeed * Time.deltaTime;
                dissolveMaterial.SetFloat("_DissolveAmount", dissolveAmount);
            }
        }

        if (!inRange) {
            return;
        }   

        if (Input.GetKeyDown(KeyCode.E)) {
            //magicItem.SetActive(false);
            dissolve = true;
        }
    }
}
