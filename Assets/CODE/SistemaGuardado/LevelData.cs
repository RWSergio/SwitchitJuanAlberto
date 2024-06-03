using UnityEngine;
using Newtonsoft.Json.Linq;

[CreateAssetMenu(menuName = "ScriptableObjects/LevelData")]
public class LevelData : Data
{
    public bool isComplete;
    public float bestTime = 100;
    public int collectables;
    public int retries;

    public override JObject Serialize()
    {
        SaveData sd = new SaveData(isComplete, bestTime, collectables, retries);
        string jsonString = JsonUtility.ToJson(sd);
        JObject retVal = JObject.Parse(jsonString);
        return retVal;
    }
    public override void DeSerialize(string jsonString)
    {
        SaveData sd = JsonUtility.FromJson<SaveData>(jsonString);

        isComplete = sd.isComplete;
        bestTime = sd.bestTime;
        collectables = sd.collectables;
        retries = sd.retries;
        
    }

    public class SaveData
    {
        public bool isComplete;
        public float bestTime;
        public int collectables;
        public int retries;

        public SaveData(bool isComplete, float bestTime, int collectables, int retries)
        {
            this.isComplete = isComplete;
            this.bestTime = bestTime;
            this.collectables = collectables;
            this.retries = retries;
        }
    }
}
