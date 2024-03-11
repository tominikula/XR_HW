using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PuzzleScript : MonoBehaviour
{
    public GameObject dropZoneLU;
    public GameObject dropZoneLD;
    public GameObject dropZoneRU;
    public GameObject dropZoneRD;
    public GameObject puzzleLU;
    public GameObject puzzleLD;
    public GameObject puzzleRU;
    public GameObject puzzleRD;
    private bool puzzleStatus;
    public PhysicsButton button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        puzzleStatus = CheckPuzzle();
        if(puzzleStatus){
            button.SetPuzzleStatus(puzzleStatus);
        }
    }

    private bool CheckPuzzle(){
        var status = false;
        if(dropZoneLU.transform.position != puzzleLU.transform.position){
            return status;
        }
        if(dropZoneLD.transform.position != puzzleLD.transform.position){
            return status;
        }
        if(dropZoneRU.transform.position != puzzleRU.transform.position){
            return status;
        }
        if(dropZoneRD.transform.position != puzzleRD.transform.position){
            return status;
        }
        status = true;
        return status;
    }
}
