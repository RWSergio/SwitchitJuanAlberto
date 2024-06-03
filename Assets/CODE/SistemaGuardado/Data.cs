using Newtonsoft.Json.Linq;
using UnityEngine;

public abstract class Data : ScriptableObject, ISave
{
    public virtual void DeSerialize(string jsonString)
    {
        throw new System.NotImplementedException();
    }

    public virtual JObject Serialize()
    {
        throw new System.NotImplementedException();
    }
}
