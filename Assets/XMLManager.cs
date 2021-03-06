using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using UnityEngine;



public class XMLManager : MonoBehaviour {

    public int points;
    // singleton pattern
    public static XMLManager ins;

	void Awake () {
        ins = this;
	}

    // list
    public ItemDatabase itemBase;

    // save
    public void save() {
        // create xml
        XmlSerializer xmls = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.persistentDataPath + "/StreamingAssets/XML/high.xml", FileMode.Create);
        xmls.Serialize(stream, itemBase);
        stream.Close();
    }
    // load
    public void loadItems() {
        XmlSerializer xmls = new XmlSerializer(typeof(ItemDatabase));
        FileStream stream = new FileStream(Application.persistentDataPath + "/StreamingAssets/XML/high.xml", FileMode.Open);
        itemBase = xmls.Deserialize(stream) as ItemDatabase;
        stream.Close();
    }
}

[System.Serializable]
public class ItemEntry {
    public int points;
    //public resolution resolution;
   // public string username;
}

[System.Serializable]
public class ItemDatabase {
    [XmlArray("highscore")]
    public List<ItemEntry> list = new List<ItemEntry>();
}

public enum resolution {
    SD,
    HD,
    FullHD,
    QuadHD,
    UltraHD
}

