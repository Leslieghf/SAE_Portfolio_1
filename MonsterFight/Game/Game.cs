using System;
using System.Collections.Generic;

public class Game
{
    public Dictionary<int, string> MonsterIdentifiers { get; private set; }
    public Monster[] PlayerMonsters { get; private set; }

	public Game()
	{
        Console.Clear();

        MonsterIdentifiers = new Dictionary<int, string>();
        MonsterIdentifiers.Add(0, "Goblin");
        MonsterIdentifiers.Add(1, "Warrior");
        MonsterIdentifiers.Add(2, "Ranger");
        MonsterIdentifiers.Add(3, "Mage");

        PlayerMonsters = new Monster[2];

        while (true)
        {
            StartRound();
        }
    }

    private Monster SelectMonster(int playerID)
    {
        bool success;
        int inputID;

        do
        {
            Console.Clear();
            Console.WriteLine($"Select Player {playerID}'s Monster Type (Type ID and press Enter):");

            for (int i = 0; i < MonsterIdentifiers.Count; i++)
            {
                MonsterIdentifiers.TryGetValue(i, out string listMonsterName);
                Console.WriteLine($"ID {i}: {listMonsterName}");
            }

            success = int.TryParse(Console.ReadLine(), out inputID);

            if (!success)
            {
                Console.Clear();
                Console.WriteLine("Invalid input, try again. (Input must be an integer)");
                Console.ReadKey();
            }
            else if (inputID < 0 || inputID + 1 > MonsterIdentifiers.Count)
            {
                Console.Clear();
                Console.WriteLine($"No Monster found with ID {inputID}");
                Console.ReadKey();
                success = false;
            }

        } while (!success);

        MonsterIdentifiers.TryGetValue(inputID, out string monsterName);
        Console.Clear();
        Console.WriteLine($"Player {playerID} selected {monsterName}");
        Console.ReadKey();
        switch (monsterName)
        {
            case "Goblin":
                return new GoblinMonster();
            case "Warrior":
                return new WarriorMonster();
            case "Ranger":
                return new RangerMonster();
            case "Mage":
                return new MageMonster();
            default:
                return null;
        }
    }

    private bool SelectMonsters()
    {
        PlayerMonsters[0] = SelectMonster(0);
        PlayerMonsters[1] = SelectMonster(1);

        if (PlayerMonsters[0].name.Equals(PlayerMonsters[1].name))
        {
            Console.WriteLine("Both players chose the same race, this is invalid! Try again!");
            Console.ReadKey();
            return false;
        }

        return true;
    }

    private bool StartTurn(int attackingPlayerID, int defendingPlayerID)
    {
        bool defendSuccess;
        bool attackSuccess;
        Console.Clear();
        Console.WriteLine($"Player {attackingPlayerID}'s turn:");
        Console.WriteLine();
        Console.WriteLine($"Press any key to attack Player {defendingPlayerID}");
        Console.ReadKey();
        Console.WriteLine($"Attacking Player {defendingPlayerID}'s {PlayerMonsters[defendingPlayerID].name}");
        attackSuccess = PlayerMonsters[attackingPlayerID].Attack(PlayerMonsters[defendingPlayerID]);
        if (!attackSuccess)
        {
            Console.WriteLine("All damage has been blocked!");
        }

        if (PlayerMonsters[defendingPlayerID].isAlive)
        {
            Console.WriteLine($"Player {defendingPlayerID}'s {PlayerMonsters[defendingPlayerID].name} still has {PlayerMonsters[defendingPlayerID].health} health");
            defendSuccess = true;
        }
        else
        {
            Console.WriteLine($"Player {defendingPlayerID}'s {PlayerMonsters[defendingPlayerID].name} has been killed by Player {attackingPlayerID}'s {PlayerMonsters[attackingPlayerID].name}");
            defendSuccess = false;
        }
        Console.ReadKey();
        return defendSuccess;
    }

    private void StartRound()
    {
        Console.Clear();
        Console.WriteLine("Starting a new Round!");
        Console.ReadKey();

        bool monsterSelectionSuccess;
        do
        {
            monsterSelectionSuccess = SelectMonsters();
        } while (!monsterSelectionSuccess);

        Console.Clear();
        Console.WriteLine($"Player 0's {PlayerMonsters[0].name}'s Stats:");
        Console.WriteLine($"Health: {PlayerMonsters[0].health}");
        Console.WriteLine($"Damage: {PlayerMonsters[0].damage}");
        Console.WriteLine($"Defense: {PlayerMonsters[0].defense}");
        Console.WriteLine($"Speed: {PlayerMonsters[0].speed}");
        Console.WriteLine();
        Console.WriteLine($"Player 1's {PlayerMonsters[1].name}'s Stats:");
        Console.WriteLine($"Health: {PlayerMonsters[1].health}");
        Console.WriteLine($"Damage: {PlayerMonsters[1].damage}");
        Console.WriteLine($"Defense: {PlayerMonsters[1].defense}");
        Console.WriteLine($"Speed: {PlayerMonsters[1].speed}");
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("Press any key to start!");
        Console.ReadKey();

        int[] playerTurnSequence = new int[2];

        do
        {
            if (PlayerMonsters[0].speed > PlayerMonsters[1].speed)
            {
                playerTurnSequence[0] = 0;
                playerTurnSequence[1] = 1;
            }

            if (PlayerMonsters[0].speed < PlayerMonsters[1].speed)
            {
                playerTurnSequence[0] = 1;
                playerTurnSequence[1] = 0;
            }

            if (PlayerMonsters[0].speed == PlayerMonsters[1].speed)
            {
                int randomInt = new Random(DateTime.Now.Millisecond).Next(2);
                if (randomInt == 0)
                {
                    playerTurnSequence[0] = 0;
                    playerTurnSequence[1] = 1;
                }
                else
                {
                    playerTurnSequence[0] = 1;
                    playerTurnSequence[1] = 0;
                }
            }

            bool defendSuccess;
            defendSuccess = StartTurn(playerTurnSequence[0], playerTurnSequence[1]);
            if (defendSuccess)
            {
                defendSuccess = StartTurn(playerTurnSequence[1], playerTurnSequence[0]);
            }

            if (PlayerMonsters[0].isAlive && PlayerMonsters[1].isAlive)
            {
                Console.WriteLine("Both Player's Monsters are still alive, next round!");
                Console.ReadKey();
            }
        } while (PlayerMonsters[0].isAlive && PlayerMonsters[1].isAlive);

        if (PlayerMonsters[playerTurnSequence[0]].isAlive)
        {
            Console.WriteLine($"Player {playerTurnSequence[0]} won!");
            Console.WriteLine();
            Console.WriteLine("Press any key to rematch");
            Console.ReadKey();
            return;
        }

        if (!PlayerMonsters[playerTurnSequence[1]].isAlive)
        {
            Console.WriteLine($"Player {playerTurnSequence[1]} won!");
            Console.WriteLine();
            Console.WriteLine("Press any key to rematch");
            Console.ReadKey();
            return;
        }
    }
}
