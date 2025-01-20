using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class MovingSlice : MonoBehaviour
{   
    [Tooltip("Required Item for the photo slice")]
    public InventoryItem item;

    // Start is called before the first frame update
    void Start(){
        outline = GetComponent<Outline>();
        if (!outline)
        {
            Debug.LogError("Outline Component Not Found!!");
        }        
    }

    #region Outline
    Outline outline;

    [SerializeField] Color HoverColor;
    [SerializeField] Color DragColor;

    void SetOutlineVisiblity(bool enabled){
        outline.enabled = enabled;
    }

    void SetOutlineColor(Color color){
        outline.OutlineColor = color;
    }
    #endregion



    #region Interaction
    Vector3 mPos ;
    bool isDragged = false;

    Vector3 GetMousePosition(){
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    // Show Outline
    private void OnMouseEnter() {
        SetOutlineVisiblity(true);
        if (isDragged){
            SetOutlineColor(DragColor);
        }else {
            SetOutlineColor(HoverColor);
        }
    }

    // Hide Outiline
    private void OnMouseExit() {
        SetOutlineVisiblity(false);
    }

    private void OnMouseDown() {
        mPos = Input.mousePosition - GetMousePosition();
        SetOutlineColor(DragColor);
    }

    private void OnMouseDrag() {
        isDragged = true;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mPos); 
    }

    private void OnMouseUpAsButton() {
        // Debug.Log("Mouse released");
        
        isDragged = false;
        
        SetOutlineColor(HoverColor);
        CheckCorrect();
    }
    #endregion


    #region Checking
    [SerializeField] Transform CorrectPosition;
    [SerializeField] float CorrectionOffset = 3f;

    public float distance;
    // cp: 5
    // 2 + 2 = 4

    bool CheckCorrect(){
        // bool xCorrect;
        Vector3 currentPos = transform.position;
        distance = Vector3.Distance(currentPos, CorrectPosition.position);
        if(distance <= CorrectionOffset){
            Debug.Log("Object within correct radius");
            TweenPosition();
            DisableCollider();
        }
        return false;
    }

    void TweenPosition(){
        Vector3 endValue = new Vector3(CorrectPosition.position.x, CorrectPosition.position.y, transform.position.z );
        Tween.Position(transform, endValue, duration: 0.5f, ease: Ease.InOutSine).OnComplete(() => transform.position = endValue);
    }
    void DisableCollider(){
        GetComponent<BoxCollider>().enabled = false;
    }
    #endregion
   
}
