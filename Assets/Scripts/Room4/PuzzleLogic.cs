using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PrimeTween;

public class PuzzleLogic : MonoBehaviour
{

    [Header("Door Animation")]
    public float doorDownHeight = 2.7f;
    public float doorDownAngle = 90f;
    [SerializeField] Transform Door;

    [Header("Puzzle Items")]
    [SerializeField] List<MovingItem> PuzzleItems;
    int currentItemIndex = 0;

    [SerializeField] GameObject FamilyPicture;
    [SerializeField] RewardsManager rewardsManager;
    GameEffects effects;

    // Start is called before the first frame update
    void Start()
    {
        effects = GetComponent<GameEffects>();
        FamilyPicture.SetActive(false);
        SetItemsInteraction(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Vector3 rotateValue = new Vector3(0, 0, Door.rotation.z - doorDownAngle);
        // Door.Rotate(rotateValue);
    }

    public void StartPuzzle()
    {
        VanishDoor();
        SetItemsInteraction(true);
        MoveCurrentItem();

    }

    #region  Door Animation
    void VanishDoor()
    {
        TweenDoorHeight(height: doorDownHeight);

        // Debug.Log($"door rotation: {Door.transform.rotation}");
    }

    void ShowDoor()
    {
        TweenDoorHeight(height: -doorDownHeight);
    }

    void TweenDoorHeight(float height)
    {
        Vector3 endValue = new Vector3(Door.position.x, Door.position.y - height, Door.position.z);
        Tween.Position(Door, endValue, duration: 1, ease: Ease.InOutSine);
    }

    void TweenDoorRotation(float degree)
    {
        Vector3 endValue = new Vector3(Door.rotation.x, Door.rotation.y, Door.rotation.z + degree);
        Tween.Rotation(Door, endValue, duration: 1, ease: Ease.InOutSine);
    }
    #endregion

    #region Puzzle Logic

    void MoveCurrentItem()
    {
        // shake the camera, like shakeing the room
        ShakeMainCamera();
        PuzzleItems[currentItemIndex].goToSecondPos();
    }

    void ResetCurrentItem()
    {
        Debug.Log("Reset Item to first pos");
        PuzzleItems[currentItemIndex].goToFirstPos();
    }

    void ResetPuzzle()
    {
        // reset each item to its first place
        foreach (MovingItem item in PuzzleItems)
        {
            item.goToFirstPos();
        }
        // restart the puzzle
        currentItemIndex = 0;
        MoveCurrentItem();
    }

    // moves the next item to its second position
    public void NextItem(MovingItem item)
    {

        if (item == PuzzleItems[currentItemIndex])
        {
            // if the clicked item is the last changed one
            Debug.Log("Player got CORRECT Item");
            ResetCurrentItem();
            currentItemIndex++;
        }
        else
        {
            // the player clicked on a wrong item
            Debug.Log("Player got WRONG Item");
            ShakeMainCamera();
            return;
        }

        if (currentItemIndex < PuzzleItems.Count)
        {
            // player moved correct item
            MoveCurrentItem();
        }
        else
        {
            // player picked all items
            FinishPuzzle();
        }
    }

    private void FinishPuzzle()
    {
        ShowDoor();
        SetItemsInteraction(false);
        FamilyPicture.SetActive(true);

        if (rewardsManager) rewardsManager.PuzzleFinished();
    }

    #endregion

    #region Game Logic
    private void SetItemsInteraction(bool newState)
    {
        foreach (MovingItem item in PuzzleItems)
        {
            item.GetComponent<Interactable>().enabled = newState;
            item.GetComponent<Outline>().enabled = newState;
        }
    }

    private void ShakeMainCamera()
    {
        effects.ShakeCamera();
    }
    #endregion
}
