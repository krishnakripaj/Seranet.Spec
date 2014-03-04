using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class TeamBuilding
    {
        private Area tb;

        public TeamBuilding(Level[] levels)
        {
            Level level1 = levels[0];
            Level level2 = levels[1];
            Level level3 = levels[2];
            tb = new Area
            {
                GUID = Guid.NewGuid(),
                Name = "Team Building",
                Description = "todo",
                SubAreas = new List<SubArea> {
                        new SubArea{ GUID=Guid.NewGuid(), Code="MB", Name="Model Bootstrap", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.1", Description="desc11", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.2", Description="desc12", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.3", Description="desc13", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.4", Description="desc14", Level = level1 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="TC", Name="Team Culture", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.1", Description="desc11", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.2", Description="desc12", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.3", Description="desc13", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.4", Description="desc14", Level = level1 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="BO", Name="Blue Oceans", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.1.1", Description="desc11", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.1.2", Description="desc12", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.2.1", Description="desc21", Level = level2 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="PF", Name="Peer Feedback", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="PF.1.1", Description="desc11", Level = level1}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="CL", Name="Continuous Learning", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="CL.1.1", Description="desc11", Level = level1}
                            }
                        },
                    }
            };
        }

        public Area Area 
        {
            get 
            {
                return tb;
            }
        }
    }
}
