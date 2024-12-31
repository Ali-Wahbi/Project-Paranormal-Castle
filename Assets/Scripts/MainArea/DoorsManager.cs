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



    public void SetLastUsed(Transform lastDoor){
        lastUsedDoor = lastDoor;
        Debug.Log("Last used door changed");

        Save();
    }

    void Save(){
        PosSaver saver = new PosSaver{
            pos = lastUsedDoor.position
        };

        string saveString = JsonUtility.ToJson(saver);
        
        CheckFileDir();

        File.WriteAllText(fullPath + fileName, saveString);
        Debug.Log("Last used pos is saved");

    }

    [ContextMenu("Load Pos")]
    void Load(){
        if (File.Exists(fullPath + fileName)){
            string loadString = File.ReadAllText(fullPath + fileName);
            Debug.Log("Loaded last Pos.");

            PosSaver loader = JsonUtility.FromJson<PosSaver>(loadString);
            
            Debug.Log($"loaded: {loader.pos} .");

            lastUsedDoor.position = loader.pos;
        }

    }

    
    class PosSaver{
        public Vector3 pos;
    }

    void CheckFileDir(){
        if(!Directory.Exists(fullPath)){
            Directory.CreateDirectory(fullPath);
        }
    }
}
