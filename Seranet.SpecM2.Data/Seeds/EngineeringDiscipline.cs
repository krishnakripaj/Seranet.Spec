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

        public EngineeringDiscipline(Level level1, Level  level2, Level level3  ) {
            ed = new Area
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
