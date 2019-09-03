using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public Texture2D mapTexture;
    public PixelToObject[] pixelColourMappings;
    private Color pixelColour;
    
    // Start is called before the first frame update
    void Start()
    {
        GenerateLevel();
    }

    /*
    // Update is called once per frame
    void Update()
    {
        
    }
    */
    void GenerateLevel()
    {
        for(int x = 0; x < mapTexture.width; x++)
        {
            for (int y = 0; y < mapTexture.height; y++)
            {
                GenerateObject(x, y);
            }
        }
    }

    void GenerateObject(int x, int y)
    {
        pixelColour = mapTexture.GetPixel(x, y);

        if (pixelColour.a != 0)
        {
            foreach(PixelToObject pcm in pixelColourMappings) // pixelColourMapping
            {
                if (pcm.pixelColour.Equals(pixelColour))
                {
                    Vector2 position = new Vector2(x, y);
                    Instantiate(pcm.prefab, position, Quaternion.identity, transform);
                }
            }
        }
        /*
        if (pixelColour.a == 0)
        {
            return;
        }
        else
        {
            // Do terrain generation stuff
        }
        */
    }
}
