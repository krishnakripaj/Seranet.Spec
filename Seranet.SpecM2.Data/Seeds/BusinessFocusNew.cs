using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class BusinessFocusNew
    {
        private Area bf;

        public BusinessFocusNew(Level[] levels)
        {
            Level level1 = levels[0];
            Level level2 = levels[1];
            Level level3 = levels[2];
            bf = new Area
            {
                GUID = Guid.NewGuid(),
                Name = "Businesss Focus",
                Description = "todo",
                SubAreas = new List<SubArea> {
                        new SubArea{ GUID=Guid.NewGuid(), Code="PA", Name="Persona Awareness", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.1.1", Description="The team has a plan to identify the different personas of the end user and such information is explicitly defined.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.1.2", Description="Team carry out discussions with the product owner to validate identified personas every 6 months.",Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.2.1", Description="New features are prioritized based on the applicability to the personas.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.3.1", Description="TStakeholders are categorized based on their “power” and “interest” levels over the system being developed (power-interest grid).", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.3.2", Description="Actions are taken to satisfy the needs of stakeholders in different grid quadrants.", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="HI", Name="Hypothesis Invalidation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="HI.1.1", Description="Team is equipped with a wireframing/prototyping tool and the prototypes can be shared, modified and discussed easily in a group context (preferably including end users).", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="HI.3.1", Description="In major feature (epic) implementations, assumptions upon the feature success is based on are identified and prioritized as per the risk of failure. Development plan is made to test these hypotheses through progressive MVPs.", Level = level3},
                                new Practice{ GUID=Guid.NewGuid(), Code="HI.3.2", Description="Team is able to perform split tests, feature fakes to gain insight in to real preferences of users in statistical means. ", Level = level3}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="FD", Name="Feature Delivery", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.1.1", Description="Team is aware of the total identified epic backlog and is analyzed depending on the importance (preferably using a method such as MoSCoW analysis)", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.1.2", Description="Team is aware of the next market release milestone and rough estimations are in place indicating the viable feature scope.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.2.1", Description="Staging deployments are done after every iteration and demonstrations are carried out only through the staging environment.", Level = level2},
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.3.1", Description="Team is able to deliver to production every quarter minimally. Production releases are repeatedly done (in an agreed interval) to keep the platform up to date, even if there is no demand for new features.", Level = level3},
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.3.1", Description="Releases are decoupled from deployments. Features can be dark launched using feature toggles.", Level = level3}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="OA", Name="Operational Analytics", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="OA.1.1", Description="Product is equipped with a tracking tool that can analyze not just page access, but also the process flow of the user. This information should be analyzed to optimize the business process funnels.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="OA.1.2", Description="Public facing web interfaces should be tracked with a broad visitor analysis tool that lets identifying demography, browser, language, etc.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="OA.2.1", Description="All major screens of the application has a click tracking tool integrated, which can generate a heat maps. Usability of the application is improved based on the feedback of such maps.", Level = level2}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="UE", Name="User Experience", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="UE.1.1", Description="All major prototypes (wireframes) received by the designers are peer tested preferably by members from other teams.",Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UE.2.1", Description="All major prototypes (wireframes) received by the designers are peer tested preferably by members from other teams.",Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UE.2.2", Description="Performance of the application is statistically analyzed through critical path analysis and actions are taken to maximize the rendering speed.",Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UE.3.1", Description="Application is usability tested with real users and behaviour is recorded for further analysis. Improvements are identified and added as backlog items.",Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UE.3.2", Description="All major screens are rated for usability on different user experience aspects and actions are taken to improve the usability  through an improvement plan.",Level = level3 }                             
                            }
                        },
                    }
            };
        }

        public Area Area 
        {
            get 
            {
                return bf;
            }
        }
    }
}
