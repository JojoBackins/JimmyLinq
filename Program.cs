using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace JimmyLinq;
class Program
{
    static void Main(string[] args)
    {
        var done = false;
        while (!done)
        {
            Console.WriteLine("\nPress G to group comics by price, R to get reviews, any other key to quit\n");
            switch (Console.ReadKey(true).KeyChar.ToString().ToUpper())
            {
                case "G":
                    done = GroupComicsByPrice();
                    break;
                case "R":
                    done = GetReviews();
                    break;
                default:
                    done = true;
                    break;
            }
        }
    }
    public static bool GroupComicsByPrice()
    {
        var groups = ComicAnalyzer.GroupComicsByPrice(Comic.Catalog, Comic.Prices);
        foreach (var group in groups)
        {
            Console.WriteLine($"{group.Key} comics:");
            foreach (var comic in group)
            Console.WriteLine($"#{comic.Issue} {comic.Name}: {Comic.Prices[comic.Issue]:c}");
        }
        return false;
    }
    public static bool GetReviews()
    {
        var reviews = ComicAnalyzer.GetReviews(Comic.Catalog, Comic.Reviews);
        foreach (var review in reviews)
        {
            Console.WriteLine(review);
        }
        return false;
    }
}
public enum Critics
{
    MuddyCritic,
    RottenTornadoes,
}
public enum PriceRange
{
    Cheap,
    Expensive,
}
public class Review
{
    public int Issue { get; set; }
    public Critics Critic { get; set; }
    public double Score { get; set; }
}



