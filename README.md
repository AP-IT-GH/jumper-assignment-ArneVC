# ML Agents deel 3 - Jumper Opdracht

## Documentatie

Om de opdracht te starten heb ik eerst een training area gebouwd, die bestaat uit 4 verschillende dingen.

### training area vloer

### danger wall spawner

### back wall

### agent

## Training

Ik heb de training meerdere keren moeten doen, omdat er bij de eerste dingen nog wat configuratie fouten waren die ik later heb moeten oplossen voor training 2.

### training 1

Deze training heeft niet zo lang geduurd (rond de 2 uur). Training 1 verliep in het begin traag, en de agent leerde niet snel wat nu eigelijk de bedoeling was. Dit veranderde snel na even trainen toen de agent doorhad dat ik de Jump() functie niet zo goed had geïmplementeerd. Hier moest de agent niet de grond raken om nog eens te kunnen springen. De agent maakte hier lustig gebruik van en vloog gewoon omhoog om alle muren onder zich heen te laten gaan om "oneindig" veel punten te verdienen.

### training 2

Voor training 2 startte heb ik eerst het sprong probleem opgelost door eerst te controleren of de agent de grond geraakt had voor deze terug kon springen.
Deze training heb ik veel langer laten duren (30 uur). Dit was niet de volledige 15000000 steps uit de config file, maar de agent was duidelijk al zeer goed in het springen over de muren. Ook in training 2 was het in het begin duidelijk dat de agent niet veel vooruitgang boekte, maar na ongeveer 1.400.000 steps begon de agent vooruitgang te boeken.
[img]
