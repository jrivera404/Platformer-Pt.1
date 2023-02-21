using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;
    public GameObject rock;
    public GameObject brick;
    public GameObject questionBox;
    public GameObject stone;
    public Transform parentTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using (StreamReader sr = new StreamReader(fileToParse))
        {
            string line = "";
            int row = 0;

            while ((line = sr.ReadLine()) != null)
            {
                int column = 0;
                char[] letters = line.ToCharArray();
                foreach (var letter in letters)
                {
                    SpawnPrefab(letter, new Vector3(column, -row, -0.5f));
                    column++;
                }
                row++;
            }

            sr.Close();
        }
    }

    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;
        switch (spot)
        {
            case 'b': ToSpawn = brick; break;
            //Debug.Log("Spawn Brick");
            case '?': ToSpawn = questionBox; break;
            //Debug.Log("Spawn QuestionBox");
            case 'x': ToSpawn = rock; break;
            //Debug.Log("Spawn Rock");
            case 's': ToSpawn = stone; break;
            //Debug.Log(""Spawn Rock");
            default: return;
            //ToSpawn = //Brick;       break;
        }

        ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        ToSpawn.transform.localPosition = positionToSpawn;   

    }

    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
        
    }
}
