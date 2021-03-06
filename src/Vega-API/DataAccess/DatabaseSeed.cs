using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Vega_API.Entities;

namespace Vega_API.DataAccess
{
    public class DatabaseSeed
    {
        public static async Task SeedAsync(VegaDbContext context, ILogger logger)
        {
            if(!await context.Makes.AnyAsync())
            {
                await context.Makes.AddRangeAsync(GetPreconfiguredData(logger));
                await context.SaveChangesAsync();
            }
            if(!await context.Features.AnyAsync()){
                await context.Features.AddRangeAsync(GetPreconfiguredFeatureData(logger));
                await context.SaveChangesAsync();   
            }
        } 

        public static IEnumerable<VegaMake> GetPreconfiguredData(ILogger logger)
        {
            var make1Id = Guid.NewGuid();
            var make2Id = Guid.NewGuid();
            var make3Id = Guid.NewGuid();

            var data = new List<VegaMake>
            {
                new VegaMake
                {
                    Id = make1Id,
                    Name = "Make1",
                    Models =
                    {
                        new VegaModel{Id = Guid.NewGuid(), Name = "Make1-ModelA", MakeId = make1Id},
                        new VegaModel{Id = Guid.NewGuid(), Name = "Make1-ModelB", MakeId = make1Id},
                        new VegaModel{Id = Guid.NewGuid(), Name = "Make1-ModelC", MakeId = make1Id},
                    }
                },

                new VegaMake
                {
                    Id = make2Id,
                    Name = "Make2",
                    Models =
                    {
                        new VegaModel{Id = Guid.NewGuid(), Name = "Make2-ModelA", MakeId = make2Id},
                        new VegaModel{Id = Guid.NewGuid(), Name = "Make2-ModelB", MakeId = make2Id},
                        new VegaModel{Id = Guid.NewGuid(), Name = "Make2-ModelC", MakeId = make2Id},
                    }
                },

                new VegaMake
                {
                    Id = make3Id,
                    Name = "Make3",
                    Models =
                    {
                        new VegaModel{Id = Guid.NewGuid(), Name = "Make3-ModelA", MakeId = make3Id},
                        new VegaModel{Id = Guid.NewGuid(), Name = "Make3-ModelB", MakeId = make3Id},
                        new VegaModel{Id = Guid.NewGuid(), Name = "Make3-ModelC", MakeId = make3Id},
                    }
                }
            };

            logger.Information("Seed data successfully prepared");
            return data;
        } 

        public static IEnumerable<VegaFeature> GetPreconfiguredFeatureData(ILogger logger){
            var data = new List<VegaFeature>{
                new VegaFeature{
                    Id = Guid.NewGuid(),
                    Name = "Feature1",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new VegaFeature{
                    Id = Guid.NewGuid(),
                    Name = "Feature2",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                },
                new VegaFeature{
                    Id = Guid.NewGuid(),
                    Name = "Feature3",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                }
            };
            logger.Information("Seed data successfully prepared");
            return data;
        }
    }
}
