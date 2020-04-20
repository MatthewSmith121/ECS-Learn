
using UnityEngine;
using UnityEngine.UI;

public class Activate : MonoBehaviour
{
    public Text activateText;
    public GameObject magicItem;
    Material dissolveMaterial;
    bool inRange;
    bool dissolve; // for tracking dissolving
    float dissolveAmount;
    const float dissolveSpeed = 1f;
    bool activated; // for tracking activate text visibility

    private void Start() {
        dissolveMaterial = magicItem.GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other) {
        if (!activated) {
            activateText.enabled = true;
        }
        inRange = true;
    }

    private void OnTriggerExit(Collider other) {
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
            Settings.ItemActivated();
            activated = true;
            activateText.enabled = false;
            dissolve = true;
        }
    }

    public void Reset() {
        dissolve = false;
        dissolveAmount = 0;
        activated = false;
        dissolveMaterial.SetFloat("_DissolveAmount", dissolveAmount);
    }
}
