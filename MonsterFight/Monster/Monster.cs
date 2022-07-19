using System;
using Utilities;

public abstract class Monster
{
    public string name { get; protected init; }
    public float health { get; protected set; }
    public float damage { get; protected set; }
    public float defense { get; protected set; }
    public float speed { get; protected set; }
    public bool isAlive { get; protected set; }

    public Monster(string name)
    {
        this.name = name;
        health = ConsoleWrapper.ReadFloat("Please enter a Health value:");
        damage = ConsoleWrapper.ReadFloat("Please enter a Damage value:");
        defense = ConsoleWrapper.ReadFloat("Please enter a Defense value:");
        speed = ConsoleWrapper.ReadFloat("Please enter a Speed value:");
        isAlive = true;
    }

    public bool Damage(float damage)
    {
        if (damage <= 0.0f)
        {
            return false;
        }

        if (health - damage <= 0.0f)
        {
            health = 0.0f;
            Kill();
            return true;
        }

        health -= damage;
        return true;
    }

    public bool Attack(Monster targetMonster)
    {
        return targetMonster.Damage(damage);
    }

    public void Kill()
    {
        isAlive = false;
    }
}
