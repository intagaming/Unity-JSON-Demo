using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonRead : MonoBehaviour
{
  string saveFile;

  GameData gameData = new GameData();

  void Awake()
  {
    saveFile = Application.persistentDataPath + "/gamedata.json";

    gameData.x = 5;
    gameData.y = 6;

    writeFile();
  }

  void Start()
  {
    readFile();
    print($"Read: x={gameData.x}; y={gameData.y}");
  }

  public void readFile()
  {
    if (File.Exists(saveFile))
    {
      string fileContents = File.ReadAllText(saveFile);

      gameData = JsonUtility.FromJson<GameData>(fileContents);
    }
  }

  public void writeFile()
  {
    string jsonString = JsonUtility.ToJson(gameData);

    File.WriteAllText(saveFile, jsonString);
  }
}
