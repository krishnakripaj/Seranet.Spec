using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class EngineeringDiscipline
    {
        private Area ed;

        public EngineeringDiscipline(Level[] levels) {
            Level level1 = levels[0];
            Level level2 = levels[1];
            Level level3 = levels[2];
            ed = new Area
            {
                GUID = Guid.NewGuid(),
                Name = "Engineering Discipline",
                Description = "todo",
                SubAreas = new List<SubArea> {
                        new SubArea{ GUID=Guid.NewGuid(), Code="VQ", Name="Visible Quality", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.1", Description="desc11", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.2", Description="desc12", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.3", Description="desc13", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.4", Description="desc14", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.1", Description="desc21", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.2", Description="desc22", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.3.1", Description="desc31", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="AD", Name="Agility in Design", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.1", Description="desc11", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.2", Description="desc12", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.3", Description="desc13", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.4", Description="desc14", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.2.1", Description="desc21", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.3.1", Description="desc31", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="PS", Name="Production Stability", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.1.1", Description="desc11", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.1.2", Description="desc12", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.2.1", Description="desc21", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.3.1", Description="desc31", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="SP", Name="Software Productization", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.1.1", Description="desc11", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.1", Description="desc21", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.2", Description="desc22", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.3", Description="desc23", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.3.1", Description="desc31", Level = level3 },
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="DA", Name="Delivery Automation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.1.1", Description="desc11", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.1.2", Description="desc12", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.2.1", Description="desc21", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.2.2", Description="desc22", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.1", Description="desc31", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.2", Description="desc32", Level = level3 },
                            }
                        },
                    }
            };
        }

        public Area Area 
        {
            get 
            {
                return ed;
            }
        }
    }
}
