using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class DoorsManager : MonoBehaviour
{
    
    // door handler should handle when a door is clicked, it saves the position infront of it
    // so that when the player returns through that door, he is spawned in that position
    // 
    [SerializeField] GeneralGameManager PlayerManager;
    public Transform lastUsedDoor;

    
    string fullPath = Application.dataPath + "/Saves/";
    public string SaveFile = "PosSave";
    string fileName;

    private void Start() {
        fileName = SaveFile + ".txt";
        Load();
        PlayerManager.SetStartPosition(lastUsedDoor);
    }


    // called from doors used to go from area to another
    public void SetLastUsed(Transform lastDoor){
        lastUsedDoor = lastDoor;

        Save();
    }

    void Save(){
        PosSaver saver = new PosSaver{
            pos = lastUsedDoor.position,
            rot = lastUsedDoor.parent.localEulerAngles
        };

        string saveString = JsonUtility.ToJson(saver);
        
        CheckFileDir();

        File.WriteAllText(fullPath + fileName, saveString);
        // Debug.Log("Last used pos is saved");

    }

    void Load(){
        if (File.Exists(fullPath + fileName)){
            string loadString = File.ReadAllText(fullPath + fileName);
            // Debug.Log("Loaded last Pos.");

            PosSaver loader = JsonUtility.FromJson<PosSaver>(loadString);
            
            // Debug.Log($"loaded: {loader.pos} .");

            lastUsedDoor.position = loader.pos;
            lastUsedDoor.eulerAngles = loader.rot;
        }

    }

    // saves the position and rotation
    class PosSaver{
        public Vector3 pos;
        public Vector3 rot;
    }

    void CheckFileDir(){
        if(!Directory.Exists(fullPath)){
            Directory.CreateDirectory(fullPath);
        }
    }
}
