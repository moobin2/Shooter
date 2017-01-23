using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public enum CharacterGender
{
    Man, Woman
}

public class CharacterData
{
    public CharacterGender Gender;
    public int Hair;
    public int Clothes;
}

public class CharacterDataIO : MonoBehaviour
{

    public static void Write(List<CharacterData> CharacterList, string filePath)
    {
        XmlDocument Document = new XmlDocument();
        XmlElement CharacterListElement = Document.CreateElement("ChracterData");
        Document.AppendChild(CharacterListElement);

        foreach (CharacterData Character in CharacterList)
        {
            XmlElement CharacterElement = Document.CreateElement("Item");
            CharacterElement.SetAttribute("Gender", Character.Gender.ToString());
            CharacterElement.SetAttribute("Hair", Character.Hair.ToString());
            CharacterElement.SetAttribute("Clothes", Character.Clothes.ToString());
            CharacterListElement.AppendChild(CharacterElement);
        }
        Document.Save(filePath);
    }

    public static List<CharacterData> Read(string filePath)
    {
        XmlDocument Document = new XmlDocument();
        Document.Load(filePath);
        XmlElement CharacterListElement = Document["CharacterList"];

        List<CharacterData> CharacterList = new List<CharacterData>();

        foreach (XmlElement CharacterElement in CharacterListElement.ChildNodes)
        {
            CharacterData Character = new CharacterData();
            Character.Gender = (CharacterGender)System.Convert.ToInt32(CharacterElement.GetAttribute("Gender"));
            Character.Hair = System.Convert.ToInt32(CharacterElement.GetAttribute("Hair"));
            Character.Clothes = System.Convert.ToInt32(CharacterElement.GetAttribute("Clothes"));
            CharacterList.Add(Character);
        }
        return CharacterList;
    }
}
