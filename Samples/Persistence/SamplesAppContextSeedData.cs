using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Samples.Persistence
{
    public class SamplesAppContextSeedData
    {
        private SamplesAppContext _context;
        private IHostingEnvironment _hostingEnv;

        public SamplesAppContextSeedData(IHostingEnvironment hostingEnv, SamplesAppContext context)
        {
            _hostingEnv = hostingEnv;
            _context = context;
        }

        public void EnsureSeedData()
        {
            if (_context.Users.Any() || _context.Statuses.Any() || _context.Samples.Any()) return;

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Users] ON");
                var userTestFile = Path.Combine(_hostingEnv.ContentRootPath, "TestData", "Users.csv");
                using (var streamReader = System.IO.File.OpenText(userTestFile))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        _context.Database.ExecuteSqlCommand("INSERT Users (UserId, FirstName, LastName) " +
                                                           "VALUES (@p0, @p1, @p2)",
                                                           Convert.ToInt32(data[0]), data[1], data[2]);

                    }
                }
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Users] OFF");

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Statuses] ON");
                var statusesTestFile = Path.Combine(_hostingEnv.ContentRootPath, "TestData", "Statuses.csv");
                using (var streamReader = System.IO.File.OpenText(statusesTestFile))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        _context.Database.ExecuteSqlCommand("INSERT Statuses (StatusId, Status) " +
                                                            "VALUES (@p0, @p1)",
                                                            Convert.ToInt32(data[0]), data[1]);
                    }
                }
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Statuses] OFF");

                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Samples] ON");
                var samplesTestFile = Path.Combine(_hostingEnv.ContentRootPath, "TestData", "Samples.csv");
                using (var streamReader = System.IO.File.OpenText(samplesTestFile))
                {
                    streamReader.ReadLine();
                    while (!streamReader.EndOfStream)
                    {
                        var line = streamReader.ReadLine();
                        var data = line.Split(new[] { ',' });
                        _context.Database.ExecuteSqlCommand("INSERT Samples (SampleId, Barcode, CreatedAt, CreatedBy, StatusId) " +
                                                            "VALUES (@p0, @p1, @p2, @p3, @p4)",
                                                            Convert.ToInt32(data[0]), data[1], Convert.ToDateTime(data[2]), Convert.ToInt32(data[3]), Convert.ToInt32(data[4]));
                    }
                }
                _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT [dbo].[Samples] OFF");
       
                dbContextTransaction.Commit();
            }
        }
    }
}
