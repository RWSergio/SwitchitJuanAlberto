using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO; 
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using UnityEngine.SceneManagement;

public class ManagerGuardo : MonoBehaviour
{
    public static ManagerGuardo Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType(typeof(ManagerGuardo)) as ManagerGuardo;
            return instance;
        }
        set
        {
            instance = value;
        }
    }
    public bool loadData = false;
    private static ManagerGuardo instance;
    public string saveFileName = "/SwitchIt.sav";
    public LevelData levelData;
    public LevelData[] levels;
    public Data[] objectToSave;

    private void Start()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu")
        {
            foreach(LevelData level in levels)
            {
                level.retries = 0;
            }
        }
        if(loadData)
        {
            Load();
        }
    }

    public void Save()
    {
        JObject jSaveGame = new JObject();

        foreach (Data data in objectToSave) 
        { 
            Data currentData = data;
            JObject serializedData = currentData.Serialize();
            jSaveGame.Add(currentData.name, serializedData);
        }
        string saveFilePath = Application.persistentDataPath + saveFileName;

        byte[] encryptSavegame = Encrypt(jSaveGame.ToString());
        File.WriteAllBytes(saveFilePath, encryptSavegame);

        Debug.Log("Saving to: " + saveFilePath);
    }

    public void Load()
    {
        string saveFilePath = Application.persistentDataPath + saveFileName;
        Debug.Log("Loading from: " + saveFilePath);
        byte[] decryptedSavegame = File.ReadAllBytes(saveFilePath);
        string jsonString = Decrypt(decryptedSavegame);
        JObject jSaveGame = JObject.Parse(jsonString);

        foreach (Data data in objectToSave) 
        {
            Data currentData = data;
            string dataJsonString = jSaveGame[currentData.name].ToString();
            currentData.DeSerialize(dataJsonString);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
    #region encriptar
    /*PARA ENCRIPTAR Y DESENCRIPTAR LA INFORMACI�N DEL ARCHIVO DE GUARDADO
    */

    //Clave generada para la encriptaci�n en formato bytes, 16 posiciones
    byte[] _key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
    //Vector de inicializaci�n para la clave
    byte[] _initializationVector = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };

    //Encriptamos los datos del archivo de guardado que le pasaremos en un string
    byte[] Encrypt(string message)
    {
        //Usamos esta librer�a que nos permitir� a trav�s de una referencia crear un encriptador de la informaci�n
        AesManaged aes = new AesManaged();
        //Para usar este encriptador le pasamos tanto la clave como el vector de inicializaci�n que hemos creado nosotros arriba
        ICryptoTransform encryptor = aes.CreateEncryptor(_key, _initializationVector);
        //Lugar en memoria donde guardamos la informaci�n encriptada
        MemoryStream memoryStream = new MemoryStream();
        //Con esta referencia podremos escribir en el MemoryStream de arriba la informaci�n ya encriptada usando el encriptador con sus claves que ya hab�amos creado
        CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
        //Con el StreamWriter podemos escribir en el archivo la informaci�n encriptada, que se habr� guardado en el MemoryStream
        StreamWriter streamWriter = new StreamWriter(cryptoStream);

        //Usando todo lo anterior, guardamos en el archivo de guardado el json que le pasamos por par�metro, haciendo el siguiente proceso: recibimos el string, lo encriptamos, queda guardado en la memoria reservada para la encriptaci�n
        streamWriter.WriteLine(message);

        //Una vez hemos usado estas referencias las cerramos para evitar problemas de guardado o corrupci�n del archivo o de la propia encriptaci�n
        streamWriter.Close();
        cryptoStream.Close();
        memoryStream.Close();

        //Por �ltimo el m�todo devolver� esta informaci�n que reside en el hueco de memoria con la informaci�n encriptada, convertida esta informaci�n en array de bytes
        return memoryStream.ToArray();
    }

    //Generamos un m�todo que nos devuelva la informaci�n del archivo de guardado desencriptada
    string Decrypt(byte[] message)
    {
        //Usamos esta librer�a que nos permitir� a trav�s de una referencia crear un desencriptador de la informaci�n
        AesManaged aes = new AesManaged();
        //Para usar este desencriptador le pasamos tanto la clave como el vector de inicializaci�n que hemos creado nosotros arriba
        ICryptoTransform decrypter = aes.CreateDecryptor(_key, _initializationVector);
        //Lugar en memoria donde guardamos la informaci�n desencriptada
        MemoryStream memoryStream = new MemoryStream(message);
        //Con esta referencia podremos escribir en el MemoryStream de arriba la informaci�n ya desencriptada usando el desencriptador con sus claves que ya hab�amos creado
        CryptoStream cryptoStream = new CryptoStream(memoryStream, decrypter, CryptoStreamMode.Read);
        //Con el StreamReader podemos leer del archivo la informaci�n desencriptada, que se habr� guardado en el MemoryStream
        StreamReader streamReader = new StreamReader(cryptoStream);

        //Usando todo lo anterior, cargamos del archivo de guardado el json que le pasamos por par�metro, haciendo el siguiente proceso: recibimos el string, lo desencriptamos, queda guardado en la memoria reservada para la desencriptaci�n
        string decryptedMessage = streamReader.ReadToEnd();

        //Una vez hemos usado estas referencias las cerramos para evitar problemas de guardado o corrupci�n del archivo o de la propia encriptaci�n
        streamReader.Close();
        cryptoStream.Close();
        memoryStream.Close();

        //Por �ltimo el m�todo devolver� esta informaci�n que reside en el hueco de memoria con la informaci�n desencriptada, convertida esta en un string
        return decryptedMessage;
    }
    #endregion
}
