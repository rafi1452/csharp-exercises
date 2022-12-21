using System;
using System.Text;

using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using Exercises.DataObjects;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SixLabors.ImageSharp;
using Windows.System;
using Windows.UI.Xaml.Controls.Primitives;
using SixLabors.ImageSharp.Drawing;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Xml;
using Windows.UI.Xaml;
using TechTalk.SpecFlow.Time;
using SpecFlow.Internal.Json;

public class Exercise14
{
    public Exercise14()
    {
    }

    public void run()
    {
        using (sampleContext context = new sampleContext())
        {
            q13(context);
        }
    }

    public void q1(sampleContext context)
    {
        var numOfArticles = (from data in context.Articles
                             select data).Count();
        Console.WriteLine($"Q1. {numOfArticles} ");
    }
    public void q2(sampleContext context)
    {
        var recentlyModifiedArticle = (from data in context.Articles
                                       orderby data.Modified descending
                                       select data.Title).First();
        Console.WriteLine($"Q2. {recentlyModifiedArticle}");
    }
    public void q3(sampleContext context)
    {
        var matchedArticle = (from x in context.Articles
                              where x.Title == "Resurgent Luculent"
                              select new
                              {
                                  id = x.Id,
                                  alias = x.Alias,
                                  created = x.Created,
                                  modified = x.Modified
                              }).Single();
        Console.Write($"Q3. {matchedArticle}");
    }
    public void q4(sampleContext context)
    {
        var numOfMatchedArticles = (from x in context.Articles
                                    where x.Title.StartsWith("S") || x.Title.StartsWith("D")
                                    select x.Title).Count();
        Console.WriteLine("Q4. {numOfMatchedArticles}");
    }
    public void q5(sampleContext context)
    {
        var monthlyStats = from x in context.Articles
                           group x by new { month = x.Created.Month, year = x.Created.Year } into grouping
                           select new
                           {
                               month = String.Format("{0}/{1}", grouping.Key.month, grouping.Key.year),
                               count = grouping.Count()
                           };
        Console.WriteLine("Q5. \t");
        foreach (var item in monthlyStats)
        {

            Console.WriteLine($"{item.month} {item.count}");
        }
    }
    public void q6(sampleContext context)
    {
        var versionCount = from x in context.Articles
                           group x.Version by x.Version into grouping
                           orderby grouping.First() ascending
                           select new
                           {
                               version = grouping.First(),
                               count = grouping.Count()
                           };
        Console.WriteLine("Q6.\nVersion\tCount");
        foreach (var item in versionCount)
        {
            Console.WriteLine($"{item.version}\t{item.count}");
        }
    }
    public void q7(sampleContext context)
    {
        var mostVersionArticles = from x in context.Articles
                                  where x.Version == (from y in context.Articles
                                                      select y.Version).Max()
                                  select x.Title;
        Console.WriteLine("Q7. ");
        foreach (var item in mostVersionArticles)
        {
            Console.WriteLine("\t" + item);

        }
    }
    public void q8(sampleContext context)
    {
        var numOfArticlesByUser = from c in context.Articles
                                  join i in context.Users
                                  on (int)c.CreatedBy equals i.Id
                                  group i by i.Id into grouping
                                  orderby grouping.First().Username ascending
                                  select new
                                  {
                                      userName = grouping.First().Username,
                                      Email = grouping.First().Email,
                                      numOfArticles = grouping.Count()
                                  };

        foreach (var item in numOfArticlesByUser)
        {
            Console.WriteLine(item);
        }
    }
    public void q9(sampleContext context)
    {
        var creatorIds = (from c in context.Articles select (int)c.CreatedBy).ToList();
        var userIds = (from i in context.Users select i.Id).ToList();
        var result = userIds.Except(creatorIds);

        foreach (var item in result)
        {
            Console.WriteLine(item);
        }
    }
    public void q10(sampleContext context)
    {

    }
    public void q11(sampleContext context)
    {
        var tagMatchedArticles = from a in context.Articles
                                 join t in context.ArticleTags
                                 on (int)a.Id equals t.ContentItemId
                                 join k in context.Tags
                                 on (int)t.TagId equals (int)k.Id
                                 where k.Title == "polymer"
                                 select a.Title;
                                 
        foreach (var item in tagMatchedArticles)
        {
            Console.WriteLine(item);
        }
    }
    public void q12(sampleContext context)
    {
        var draftData = from c in context.ArticleDrafts
                        where c.Modified.Day > 15 || c.Modified.Month > 1
                        select new
                        {
                            c.Title,
                            c.Modified,
                            size = c.Introtext.Length
                        };
        foreach (var item in draftData)
        {
            Console.WriteLine(item);
        }
    }
    public void q13(sampleContext context)
    {
        var removeRecord = (from y in context.ArticleDrafts
                               where y.Id == 18                          
                               select y).First();
        context.ArticleDrafts.Remove(removeRecord);
        context.SaveChanges();
    }
    public void q14(sampleContext context)
    {
        var updateRecord = from c in context.Tags
                  where c.Title == "camorra"
                  select c;
        foreach (var item in updateRecord)
        {
            item.Title = "helloworld";
            item.Alias = "helooworld";
            item.ModifiedTime = item.ModifiedTime.ToUniversalTime();
        }
        context.SaveChanges();
    }
    public void q15(sampleContext context)
    {

    }


    
}
