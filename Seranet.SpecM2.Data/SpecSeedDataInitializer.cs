using Seranet.Spec.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Seranet.Spec.Data
{
    public class SpecSeedDataInitializer: System.Data.Entity. DropCreateDatabaseAlways<SpecDbContext>
    {
        protected override void Seed(SpecDbContext context)
        {
            /* insert the level base data */
            var levels = new List<Level>
            {
                new Level{Id=1, GUID=Guid.NewGuid(), Name="Explorer"},
                new Level{Id=2, GUID=Guid.NewGuid(), Name="Veteran"},
                new Level{Id=3, GUID=Guid.NewGuid(), Name="Optimizer"}
            };
            levels.ForEach(l => context.Levels.Add(l));
            context.SaveChanges();
            var level1 = context.Levels.FirstOrDefault(l => l.Id == 1);
            var level2 = context.Levels.FirstOrDefault(l => l.Id == 2);
            var level3 = context.Levels.FirstOrDefault(l => l.Id == 3);

            /* insert Engineering Discipline data */
            var ed = new Area
            {
                GUID = Guid.NewGuid(),
                Name = "Engineering Discipline",
                Description = "todo",
                SubAreas = new List<SubArea> {
                        new SubArea{ GUID=Guid.NewGuid(), Code="TA", Name="Test Automation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="TA.1.1", Description="desc111", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="TA.1.2", Description="desc112", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TA.2.1", Description="desc121", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TA.2.2", Description="desc122", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TA.3.1", Description="desc122", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="ED.2", Name="Test Automation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.1.1", Description="desc111", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.1.2", Description="desc112", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.2.1", Description="desc121", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.2.2", Description="desc122", Level = level2 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="ED.3", Name="Test Automation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.1.1", Description="desc111", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.1.2", Description="desc112", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.2.1", Description="desc121", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.2.2", Description="desc122", Level = level2 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="ED.4", Name="Test Automation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.1.1", Description="desc111", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.1.2", Description="desc112", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.2.1", Description="desc121", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.2.2", Description="desc122", Level = level2 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="ED.5", Name="Test Automation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.1.1", Description="desc111", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.1.2", Description="desc112", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.2.1", Description="desc121", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="ED.1.2.2", Description="desc122", Level = level2 }
                            }
                        },
                    }
            };
            context.Areas.Add(ed);
            context.SaveChanges();


            var areas = new List<Area>
            {
                
                new Area{ GUID=Guid.NewGuid(), Name = "Business Focus", Description = "todo"},
                new Area{ GUID=Guid.NewGuid(), Name = "Team Building", Description = "todo"},
                new Area{ GUID=Guid.NewGuid(), Name = "Stakeholder Engagement", Description = "todo"}
            };

            areas.ForEach(s => context.Areas.Add(s));
            context.SaveChanges();


            var subAreas = new List<SubArea>
            {
                new SubArea{Code = "ED1", Name="Test Automation"},

            };
        }
    }
}