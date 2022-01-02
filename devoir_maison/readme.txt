MADEJSKI Matthieu - 2021 
INET400 - Devoir maison : initiation au C#

Le projet est disponible au téléchargement à l'adresse suivante : https://github.com/MM12300/devoir_maison_C_sharp

Pour exécuter le projet :
- lancer l'executable devoir_maison.application, installer le programme et à partir du même fichier lancer le jeu, puis suivre les options proposées.
- il faut lancer le programme à partir d'un éditeur de code (ctrl + F5 avec Visual Studio) et choisir une option du menu.
Pour connaître les détails du menu en question, voir ci-dessous.

------------------------------------------------------------------------------------------------------------------

Voici une liste des choixs de conception que j'ai réalisé en plus des spécifications de l'énoncé : 

- Ajout d'un menu qui permet de choisir entre 4 options :
	=> (1 - DUEL) Un combat entre deux personnages dont on choisit le nom et le type.
	=> (2 - BATTLE-ROYALE) Un combat entre deux et huit personnages dont on choisit le nom, le type et en mode "battle-royale"
	=> (3 - DUEL) Un mode scenario : combat entre deux personnages avec type et nom choisit au hasard.
	=> (4 - BATTLE-ROYALE) Un mode scenario : combat entre les dix types de personnage en mode "battle-royale"

- Il a été choisis que la valeur des attaques soit exprimée avec un nombre entier (int en C#, pour integer).
En conséquence lorsqu'un calcul nécessite des décimales, on transforme le résultat en nombre entier (le programme arrondit au nombre entier supérieur, double => int)

- Les personnages de type Robot ne sont pas considérés comme des "Vivants", mais ne sont pas des "Morts-Vivants" pour autant. Ils ne sont pas sensibles à la douleur.

- Les personnages de type Robot augmente leur attaque tous les tours, et ceci à partir du premier tour.

- Les personnages de type Charognard déclenche leur capacité spéciale à la fin d'un round et non pas directement lors de la mort d'un personnage.

- Si les valeurs d'initiative de l'attaquant et du défenseur sont égales, alors on fait un jet de dès dit "jet de chance" (LuckyRoll) qui définit qui attaquera en premier.

- Nombre de round limités à 25 pour éviter les combats "sans fin" qui peuvent avoir lieu entre certaines combinaisons de combattants.

------------------------------------------------------------------------------------------------------------------
Axes d'amélioration :

- Gestion des erreurs dans les inputs réalisés par l'utilisateur.

- Ajouter un moyen de revenir en arrière dans les menus, voire de quitter le jeu (par exemple en appuyant sur la touche "échap").

- Refactoring de certaines méthodes en interface (par exemple l'attaque du Kamikaze),
ajouter cette interface ne permet pas d'alléger le code de façon conséquente bien que cela permettrait de faciliter sa maintenance.





