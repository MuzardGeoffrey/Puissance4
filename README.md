# Puissance4

## Specification fonctionnelle

Fontionnaliter mise en place :  
* Gameplay du puissance 4 avec la possibiliter de gagner. Le joueur gagnant sera afficher en cas de victoire.
* API avec la possibiliter de creer, lire, modifier et supprement un joueur en base de donnees.  
* Le client peut faire une demande de connexion a l'API. Si le pseudo et le mot de passe existe pour un player en bdd alors l'API renvoie le player qui correspond.

Algorithme du puissance 4 :

``  
//Pour choisir dans quel collone on met le jeton 
    private void choiseColumn()
    {
        //si on appuis sur la fleche gauche
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //si le block sur le quel on est n'est pas le plus a gauche
            if (BlockActif != 6)
            {
                // on color le block sur le quel on etait en rouge
                choiseButtons[BlockActif].gameObject.GetComponent<MeshRenderer>().material.color = Color.red; ``
                BlockActif++;
                //on color le block sur le quel on vient de selectionner en vert
                choiseButtons[BlockActif].gameObject.GetComponent<MeshRenderer>().material.color = Color.green; ``
            }
        }
        //si on appuis sur la fleche droite
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //si le block sur le quel on est n'est pas le plus a droite
            if (BlockActif != 0)
            {
                // on color le block sur le quel on etait en rouge
                choiseButtons[BlockActif].gameObject.GetComponent<MeshRenderer>().material.color = Color.red; ``
                BlockActif--;
                //on color le block sur le quel on vient de selectionner en vert
                choiseButtons[BlockActif].gameObject.GetComponent<MeshRenderer>().material.color = Color.green; ``
            }
        }
    }

    //Methode pour faire apparaitre le jeton
    private void summonJeton()
    {
        //si c'est au joueur 1 de jouer le jeton sera de couleur rouge, si c'est le joueur 2 il sera jaune
        switch (GameGestion.PlayerTurn)
        {
            case 1:
                ColorJeton = Color.red;
                break;
            case 2:
                ColorJeton = Color.yellow;
                break;
            default:

                break;
        }

        // invoque un jeton si on appuis sur la fleche du bas
        if (Input.GetKeyDown(KeyCode.DownArrow) && GameGestion.gameSpace[BlockActif,5] == 0)
        {
            Cooldown = 1;
            //fait apparaitre un jeton dans la collone choisie
            choiseButtons[BlockActif].SummunJeton(ColorJeton);
            GameGestion.Playjeton(BlockActif);
        }
    }

    //ajoute le jeton invoquer dans le tableau representant le jeu
    public void Playjeton(int culumn)
    {   
        //boucle pour parcourir la collone pour trouver une ligne sans jeton et ajouter le nouveau
        for (int row = 0; row <= 5; row++)
        {
            // si l'emplace est a 0 alors ca veut dire qu'il est vide
            if (gameSpace[culumn, row] == 0)
            {
                //on ajoute a l'emplacement vide le jeton avec le numero du player
                gameSpace[culumn, row] = PlayerTurn;
                
                //a chaque ajoute de jeton, on verifie si les conditions de victoire sont possible
                if (DetecWin(culumn, row))
                {
                    this.win();
                }
                
                on change du player actif et on casse la boucle
                switch (PlayerTurn)
                {
                    case 1 :
                        PlayerTurn = 2;
                        row = 6;
                        break;
                    case 2:
                        PlayerTurn = 1;
                        row = 6;
                        break;

                    default:
                        Debug.LogError("Error player turn");
                        break;
                }
            }
        }
    }

    // on cherche si une des conditions de victoire est remplis
    private bool DetecWin(int collumn, int row)
    {
        if (this.checkColumn(collumn, row)) return true;
        if (this.checkRow(row)) return true; 
        if (this.checkDiag(collumn, row)) return true;
        return false;
    }

    // pour verifier si, sur la ligne ou le jeton a ete mis, il y a 4 jeton du meme joueur aligne 
     private bool checkRow( int row)
    {
        int check = 0;
        //parcour la ligne
        for (int i = 0; i < 6; i++)
        {
            //verifier si on depasse pas la limite du tableau
            if (i >= 0)
            {
                if (gameSpace[i, row] == PlayerTurn)
                {
                    check++;
                }
                else
                {
                    check = 0;
                }
            }
        }

        if (check >= 4)
        {
            return true;
        }
        return false;
    }

    //pour verifier si, sur la colonne ou le jeton a ete mis, il y a 4 jeton du meme joueur aligne 
    private bool checkColumn(int Collumn, int row)
    {
        int check = 0;
        for (int i = 0; i < 5; i++)
        {
            //verifier si on depasse pas la limite du tableau
            if (i >= 0)
            {
                if (gameSpace[Collumn, i] == PlayerTurn)
                {
                    check++;
                }
                else
                {
                    check = 0;
                }
            }
        }

        if (check >= 4)
        {
            return true;
        }
        return false;
    }

    //verifie si, dans les 4 diagonales ou le jeton est tombe, si il y en a 4 du meme joueur aligne 
     private bool checkDiag(int Collumn, int row)
    {
        int check = 1;
        int checkCollumn = Collumn;
        int checkrow = row;
        for (int i = 1; i < 4; i++)
        {
            checkrow++;
            checkCollumn++;
            if (checkrow < 5 && checkCollumn < 6)
            {
                if (gameSpace[checkCollumn, checkrow] == PlayerTurn)
                {
                    check++;
                }
            }
        }

        if (check >= 4)
        {
            return true;
        }

        check = 1;
        checkCollumn = Collumn;
        checkrow = row;

        for (int i = 1; i < 4; i++)
        {
            checkrow--;
            checkCollumn++;
            if (checkrow >= 0 && checkCollumn < 6)
            {
                if (gameSpace[checkCollumn, checkrow] == PlayerTurn)
                {
                    check++;
                }
            }
        }
        if (check >= 4)
        {
            return true;
        }

        check = 1;
        checkCollumn = Collumn;
        checkrow = row;

        for (int i = 1; i < 4; i++)
        {
            checkrow--;
            checkCollumn--;
            if (checkrow >= 0 && checkCollumn >= 0)
            {
                if (gameSpace[checkCollumn, checkrow] == PlayerTurn)
                {
                    check++;
                }
            }
        }

        if (check >= 4)
        {
            return true;
        }

        check = 1;
        checkCollumn = Collumn;
        checkrow = row;

        for (int i = 1; i < 4; i++)
        {
            checkrow++;
            checkCollumn--;
            if (checkrow < 5 && checkCollumn >= 0)
            {
                if (gameSpace[checkCollumn, checkrow] == PlayerTurn)
                {
                    check++;
                }
            }
        }
        if (check >= 4)
        {
            return true;
        }

        return false;

    }
``

## Specification technique

Le langage de l'API et du client est du C#.  
L'API utilise Entity Framework core pour la connexion a la base de donnee et razor qui devait servir pour afficher la page de creation et la liste des scores.  
  
La structure de l'API est organiser de facon suivante:
* Model qui contient les objets comme le Player.  
* Data qui contient la configuration de la BDD ainsi que les donnees a insere dedans si elle est vide.  
* Views qui contient les pages Razor.  
* Controllers, c'est la que sont exposer les methodes pour les clients.  
* Route qui contient les constantes des chemins de l'API.  

La base de donnee est gerer par SQL Server directement integrer a visual studio, Il suffit de lancer l'API pour avoir la base de donnees generer avec des donnees test dedans.  
Le Framework du client est Unity.  
