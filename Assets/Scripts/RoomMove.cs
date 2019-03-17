using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 CameraChange;
    public Vector3 PlayerChange;

    private CameraMovement mCameraMovement;

    public bool NeedText;
    public string PlaceName;

    public GameObject Text;
    public Text PlaceText;
    
    private void Awake() {
        mCameraMovement = Camera.main.GetComponent<CameraMovement>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("2d.");

        if(other.CompareTag("Player")){
            mCameraMovement.MinPos += CameraChange;
            mCameraMovement.MaxPos += CameraChange;
            other.transform.position += PlayerChange;

            if(NeedText){
                StartCoroutine(placeNameCo());
            }
        }
    }

    private IEnumerator placeNameCo(){

        Text.SetActive(true);
        PlaceText.text = PlaceName;
        yield return new WaitForSeconds(4f);
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
