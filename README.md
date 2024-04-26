# ML Agents deel 3 - Jumper Opdracht

## Documentatie

Om de opdracht te starten heb ik eerst een training area gebouwd, die bestaat uit 4 verschillende dingen.

### training area vloer

![image](./README_images/Floor.png)
Dit is gewoon de "grond" waarop de agent zal staan en is gewoon een plane.

### danger wall spawner

![image](./README_images/WallSpawner.png)
Dit is een gameobject dat op bepaalde intervallen DangerWall prefabs spawnt in het level waar de agent zal moeten over springen. Dit gebeurt door volgend script:

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float minSpawnIntervalMilliseconds = 3500f;
    public float maxSpawnIntervalMilliseconds = 5000f;
    private float timeUntilNextSpawn;

    void Start()
    {
        timeUntilNextSpawn = Random.Range(minSpawnIntervalMilliseconds, maxSpawnIntervalMilliseconds);
    }

    void Update()
    {
        timeUntilNextSpawn -= Time.deltaTime * 1000;

        if (timeUntilNextSpawn <= 0f)
        {
            SpawnObject();
            timeUntilNextSpawn = Random.Range(minSpawnIntervalMilliseconds, maxSpawnIntervalMilliseconds);
        }
    }

    private void SpawnObject()
    {
        Vector3 spawnerPosition = transform.position;
        Instantiate(objectToSpawn, new Vector3(spawnerPosition.x, 2.5f, spawnerPosition.z), Quaternion.identity);
    }
}
```

### back wall

![image](./README_images/BackWall.png)
Dit is de muur achter de agent. Als de agent succesvol over een muur is gesprongen zal dit gameobject er voor zorgen dat de agent punten krijgt. De backwall zal er ook voor zorgen dat muren waar de agent al is voer gesprongen verwijderd worden uit de game. Dit alles door volgende code op de wall prefabs (dus niet op de backwall zelf):

```cs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    public float speed = 20.0f;
    private GameManager gameManager;
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BackWall"))
        {
            gameManager.NotifyWallDestroyed();
            Destroy(gameObject);
        }
    }
}
```

### agent

![image](./README_images/Agent.png)
Dit is het belangrijkste gameobject van het project. De agent zal worden getrained om over de muren te springen die naar de agent toe bewegen.

### gamemanager

## Training

Ik heb de training meerdere keren moeten doen, omdat er bij de eerste dingen nog wat configuratie fouten waren die ik later heb moeten oplossen voor training 2.

### training 1

Deze training heeft niet zo lang geduurd (rond de 2 uur). Training 1 verliep in het begin traag, en de agent leerde niet snel wat nu eigelijk de bedoeling was. Dit veranderde snel na even trainen toen de agent doorhad dat ik de Jump() functie niet zo goed had geïmplementeerd. Hier moest de agent niet de grond raken om nog eens te kunnen springen. De agent maakte hier lustig gebruik van en vloog gewoon omhoog om alle muren onder zich heen te laten gaan om "oneindig" veel punten te verdienen.

### training 2

Voor training 2 startte heb ik eerst het sprong probleem opgelost door eerst te controleren of de agent de grond geraakt had voor deze terug kon springen.
Deze training heb ik veel langer laten duren (30 uur). Dit was niet de volledige 15000000 steps uit de config file, maar de agent was duidelijk al zeer goed in het springen over de muren. Ook in training 2 was het in het begin duidelijk dat de agent niet veel vooruitgang boekte, maar na ongeveer 1.400.000 steps begon de agent vooruitgang te boeken.
[img]
