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
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.1", Description=" Team should have a clear understanding of the SPEG model", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.2", Description=" Team should have a detail Activity backlog (Team Road map) with specific tasks created ", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.3", Description=" Team should have a weekley meeting to show to progress of the backlog ", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.4", Description=" Team should have clearly marked the completed tasks with evidence", Level = level1 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="TC", Name="Team Culture", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.1", Description="Team has a plan to ensure newcomers to the team are absorbed to their team culture successfully ", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.2", Description="Regular team culture improvement activities are carried out within team", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.3", Description=" Team member birthdays are celebrated within the team", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.4", Description=") Every achievement of team members(no matter how big or small) are celebrated by the team", Level = level1 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="BO", Name="Blue Oceans", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.1.1", Description=" Individuals have explicitly identified his/her blue ocean for the coming year ", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.1.2", Description="Team is aware of the blue oceans selected by the peers", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.2.1", Description="Individuals have quarterly goals defined", Level = level2 }
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
