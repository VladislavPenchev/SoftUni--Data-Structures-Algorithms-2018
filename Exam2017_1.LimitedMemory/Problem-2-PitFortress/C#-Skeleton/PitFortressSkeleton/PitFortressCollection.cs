using System;
using System.Collections.Generic;
using System.Linq;
using Classes;
using Interfaces;
using Wintellect.PowerCollections;

public class PitFortressCollection : IPitFortress
{
    private int minionId = 1;
    private int mineId = 1;

    private Dictionary<string,Player> players;
    private SortedSet<Player> playerScores;
    private OrderedDictionary<int, SortedSet<Minion>> minions;
    private SortedSet<Mine> mines;

    public PitFortressCollection()
    {
        this.players = new Dictionary<string, Player>();
        this.playerScores = new SortedSet<Player>();
        this.minions = new OrderedDictionary<int, SortedSet<Minion>>();
        this.mines = new SortedSet<Mine>();
    }

    public int PlayersCount { get { return this.players.Count; } }

    public int MinionsCount { get { return this.minions.Sum(x => x.Value.Count); } }

    public int MinesCount { get { return this.mines.Count; } }

    public void AddPlayer(string name, int mineRadius)
    {
        if (this.players.ContainsKey(name))
        {
            throw new ArgumentException();
        }

        if (mineRadius < 0)
        {
            throw new ArgumentException();
        }

        var player = new Player(name, mineRadius);

        this.players.Add(name,player);
        this.playerScores.Add(player);
    }

    public void AddMinion(int xCoordinate)
    {
        if (xCoordinate < 0 || xCoordinate > 1000000)
        {
            throw new ArgumentException();
        }

        var minion = new Minion(this.mineId++, xCoordinate);

        if (!this.minions.ContainsKey(xCoordinate))
        {
            this.minions.Add(xCoordinate, new SortedSet<Minion>());
        }

        this.minions[xCoordinate].Add(minion);
    }

    public void SetMine(string playerName, int xCoordinate, int delay, int damage)
    {
        if (!this.players.ContainsKey(playerName))
        {
            throw new ArgumentException();
        }
        if (xCoordinate < 0 || xCoordinate > 1000000)
        {
            throw new ArgumentException();
        }
        if (delay < 0 || delay > 10000)
        {
            throw new ArgumentException();
        }
        if (damage < 0 || damage > 100)
        {
            throw new ArgumentException();
        }

        var player = this.players[playerName];

        var mine = new Mine(mineId++, delay, damage, xCoordinate, player);

        this.mines.Add(mine);
    }

    public IEnumerable<Minion> ReportMinions()
    {
        foreach (var set in this.minions.Values)
        {
            foreach (var minion in set)
            {
                yield return minion;
            }
        }
    }

    public IEnumerable<Player> Top3PlayersByScore()
    {
        if (this.players.Count < 3)
        {
            throw new ArgumentException();
        }

        return this.playerScores.Reverse().Take(3);
    }

    public IEnumerable<Player> Min3PlayersByScore()
    {
        if (this.players.Count < 3)
        {
            throw new ArgumentException();
        }

        return this.playerScores.Take(3);
    }

    public IEnumerable<Mine> GetMines()
    {
        return this.mines;
    }

    public void PlayTurn()
    {
        List<Mine> detonatedMines = new List<Mine>();
        foreach (var mine in mines)
        {
            mine.Delay--;
            if (mine.Delay <= 0)
            {
                detonatedMines.Add(mine);
            }            
        }

        foreach (var dmine in detonatedMines)
        {
            var start = dmine.XCoordinate - dmine.Player.Radius;
            var end = dmine.XCoordinate + dmine.Player.Radius;

            var player = dmine.Player;
            var minionsToUpdate = this.minions.Range(start, true, end, true).SelectMany(x => x.Value).ToList();

            foreach (var minion in minionsToUpdate)
            {
                minion.Health -= dmine.Damage;
                if (minion.Health <= 0)
                {
                    dmine.Player.Score++;
                    this.playerScores.Remove(player);
                    this.playerScores.Add(player);
                    this.minions[minion.XCoordinate].Remove(minion);
                }
            }
    
            foreach (var mine in detonatedMines)
            {
                this.mines.Remove(mine);
            }
        }
    }
}
