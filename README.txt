Informations sur la PFI: 

Histoire du jeu: 

Une pirate tente de survivre à une attaque de fishman. 
Elle peut manger des oranges qui lui redonnent de la vie (et guérit son scorbut).
Elle peut aussi récupérer des potions d'endurance qui remplissent sa jauge d'endurance.
Le jeu prend place a l'époque des pirates, il y a donc bien des objets reconnaissables à la mer et à cette époque.

Éléments importans du jeu: 

Génération procédurale:
Les tonneaux font partie de notre génération procédurale.
Ils apparaissent tous à des endroits aléatoires au début du jeu.
Lorsque le joueur saute sur l'un d'eux, celui-ci va disparaître après quelques secondes et réapparaitre ailleurs dans l'eau.

Déformation de maillage: 
Les vagues constituent la déformation de maillage. Deux vagues sont empilés l'une par-dessus l'autre.

Terrain:
les parties terrestres et le fond de la carte de jeu ont été fait avec des terrains.

Pro Builder:
la plupart de la surface de jeu a été créée avec probuilder. Les tonneaux ont aussi été fabriqué avec pro Builder.

NavMesh:
nous avons deux navmesh dans le jeu, un das l'eau et l'autre sur la surface des structures en bois.
Les fishman dans l'eau restent dans l'eau et ceux à la surface restent à la surface. Il y a quelques endroits où ils peuvent descendre et monter.

Animator:
la personnage principale a beaucoup d'animation: sauter, courir, sprinter, nager et une idle animation.
Les ennemies dans l'eau ont une animation de nage et ceux sur la surface une animation de course.

FSM et/ou Behaviour Tree: 
Comme mentionner, il y a deux parties au terrain de jeu: une partie sur la surface et l'autre dans l'eau. 
Si nous somme dans l'eau, les ennemis sur la surface vont se promener aléatoirement et vice-versa pour les ennemis dans l'eau. 