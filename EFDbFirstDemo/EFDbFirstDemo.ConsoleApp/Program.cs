using EfDbFirstDemo.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace EFDbFirstDemo.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // "reverse engineering" from database => code
            // code is ef model
            //    - a class derived from dbcontext

            using var logStream = new StreamWriter("ef-logs.txt", append: false);
            string connectionString = File.ReadAllText("C:/revature/chinook-connection-string.txt");
            var options = new DbContextOptionsBuilder<ChinookContext>()
                .UseSqlServer(connectionString)
                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                .Options;
            using var context = new ChinookContext(options);

            // IQueryable version of LINQ methods
            // the logic of the LINQ calls is not executed in .NET but examined, translated to SQL and executed by SQL Server
            // var anArtist = context.Artists.First(x => x.Name.Contains("sabbath"));

            // use the reference material

            Display5Tracks(context);

            EditOneOfThoseTracks(context);

            Display5Tracks(context);

            InsertANewTrack(context);

            Display5Tracks(context);

            DeleteTheNewTrack(context);

            Display5Tracks(context);

        }

        public static void Display5Tracks(ChinookContext context)
        {
            foreach (Track t in context.Tracks.Take(5))
            {
                Console.WriteLine($"{t.Name} {t.AlbumId}");
            }
            Console.WriteLine("");
        }

        public static void EditOneOfThoseTracks(ChinookContext context)
        {
            Track t = context.Tracks.First();
            t.Name = "This_Is_The_New_Name";
            context.Update(t);
            context.SaveChanges();
        }

        public static void printAndrewTracks(ChinookContext context)
        {
            foreach (Track t in context.Tracks.Where(track => track.Composer == "Andrew"))
            {
                Console.WriteLine($"{t.Name} {t.AlbumId}");
            }
            Console.WriteLine("");
        }

        public static void InsertANewTrack(ChinookContext context)
        {
            Track t = new Track();
            t.TrackId = context.Tracks.Max(track => track.TrackId) + 1;
            t.Name = "New_Album_EF";
            t.Composer = "Andrew";
            t.GenreId = 3;
            t.UnitPrice = 3;
            t.Milliseconds = 3000;
            t.MediaTypeId = 4;
            if (!context.Tracks.Any(track => track.Name == "New_Album_EF"))
            {
                context.Add(t);
                context.SaveChanges();
            }
            printAndrewTracks(context);
        }

        public static void DeleteTheNewTrack(ChinookContext context)
        {
            Track t = context.Tracks.Where(track => track.Name == "New_Album_EF").FirstOrDefault();
            if (t != null)
            {
                context.Remove(t);
                context.SaveChanges();
            }
        }
    }
}
