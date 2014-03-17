using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class StakeholderEngagement
    {
        private Area se;

        public StakeholderEngagement(Level[] levels)
        {
            Level level1 = levels[0];
            Level level2 = levels[1];
            Level level3 = levels[2];
            se = new Area
            {
                GUID = Guid.NewGuid(),
                Name = "Stakeholder Engagement",
                Description = "todo",
                SubAreas = new List<SubArea> {
                        new SubArea{ GUID=Guid.NewGuid(), Code="CS", Name="Community Sharing", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="CS.1.1", Description="desc11", Level = level1}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="PA", Name="Product Assistance", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.1.1", Description="desc11", Level = level1}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="RM", Name="Relationship Management", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="RM.1.1", Description="desc11", Level = level1}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="SI", Name="Service Introduction", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="SI.1.1", Description="desc11", Level = level1}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="OS", Name="Organizational Sharing", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="OS.1.1", Description="desc11", Level = level1}
                            }
                        },
                    }
            };
        }

        public Area Area 
        {
            get 
            {
                return se;
            }
        }
    }
}
