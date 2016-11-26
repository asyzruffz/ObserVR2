﻿using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Director : Singleton<Director> {

	[ShowOnly]
    public bool inGame = false;

    private GameData data = new GameData();
    private bool playing = false;

    public delegate void StartGameDelegate();
    public delegate void EndGameDelegate();
    public event StartGameDelegate startEvent;
    public event EndGameDelegate endEvent;

    protected override void SingletonAwake() {

    }

    void Start () {
        Load();
    }
	
	void Update () {
        // Call the event for starting and ending the game
        if (inGame && !playing) {
            playing = true;
            if (startEvent != null)
                startEvent();
        } else if(!inGame && playing) {
            playing = false;
            if (endEvent != null)
                endEvent();
        }

        // Pressing back button exit the game
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void SetHighScore(int score) {
        if(score > data.highscore) {
            data.highscore = score;
            Save();
        }
    }

    public int HighScore { get { return data.highscore; } }

    public void Save() {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/GameInfo.dat");

        bf.Serialize(file, data);
        file.Close();
    }

    public void Load() {
        if (File.Exists(Application.persistentDataPath + "/GameInfo.dat")) {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/GameInfo.dat", FileMode.Open);

            data = (GameData)bf.Deserialize(file);
            file.Close();
        }
    }
}
