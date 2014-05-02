using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class BusinessFocus
    {
        private Area bf;

        public BusinessFocus(Level[] levels)
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
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.1.1", Description="Team has identified different personas of end users and such information is explicitly declared and validated with the PO.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.1.2", Description="Every team member should be able to do a product/module elevator pitch explaining USP and UVP.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.2.1", Description="Team is aware of the details of at least few real users who are using the system to have an idea of real user lifestyle.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.2.2", Description="New features are prioritized based on the applicability and importance to the personas. Methods such as MoSCoW are used to ensure prioritization of feature requests.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.3.1", Description="Important stakeholders (not users) are known and categorized based on their “power” and “interest” levels (e.g. power-interest grid).", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.3.2", Description="Actions are taken to satisfy the needs of different stakeholders of the project.", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="HI", Name="Hypothesis Invalidation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="HI.1.1", Description="Team is equipped with a wireframing/prototyping tool. Prototypes can be shared, modified and discussed easily in a group context (preferably including end users).", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="HI.2.1", Description="Assumptions upon the major feature success depends are identified. Implementation plan is made to test these hypotheses through progressive MVPs.", Level = level2},
                                new Practice{ GUID=Guid.NewGuid(), Code="HI.3.1", Description="Important features will be accompanied with the expected usage estimations. Methods for measuring feature usage/effectiveness are a part of the feature spec itself.", Level = level3},
                                new Practice{ GUID=Guid.NewGuid(), Code="HI.3.2", Description="Team is able to perform split tests, feature fakes, etc. to gain better insight in to real user preferences through statistical means. ", Level = level3}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="FD", Name="Feature Delivery", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.1.1", Description="Team is aware of the coming up release milestones and rough estimations are in place indicating the viable feature scopes.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.1.2", Description="Demonstrations to the stakeholders are carried out in a systematic manner with the records of the demo available.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.2.1", Description="Deployment to staging is done at every iteration and demonstrations are carried out only through staging environments.", Level = level2},
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.3.1", Description="Production deployments are repeatedly done (in an agreed interval) to keep the platform up to date, even if there is no market demand for new feature releases.", Level = level3},
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.3.2", Description="Releases are decoupled from deployments. Features can be dark launched using feature toggles.", Level = level3},
                                new Practice{ GUID=Guid.NewGuid(), Code="FD.3.3", Description="Team is able to measure the delivery effectiveness of an iteration in comparison with other iterations.", Level = level3}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="OA", Name="Operational Analytics", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="OA.1.1", Description="Product is equipped with a tracking tool which can analyze not just page access, but also the process flow actions of the user.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="OA.1.2", Description="Public facing web interfaces should be accompanied with a broad visitor analysis tool which can capture visitor details such as demography, browser, language, etc.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="OA.2.1", Description="User process flow information are analyzed to optimize the business process funnels for improved usability. Evidences of such improvements are available.", Level = level2},
                                new Practice{ GUID=Guid.NewGuid(), Code="OA.3.1", Description="All major screens of the application has a click tracking tool integrated, generating heat maps and other relevant reports. Usability is improved based on such feedback.", Level = level3}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="UE", Name="User Experience", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="UE.1.1", Description="All major prototypes (wireframes) and peer tested preferably by team members, members from other teams, etc.", Level = level1},                                
                                new Practice{ GUID=Guid.NewGuid(), Code="UE.2.1", Description="Performance of the application is statistically analyzed to identify the critical path and actions are taken to maximize the user perception of speed.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UE.3.1", Description="Application is usability tested with real users and behaviour is recorded for further analysis. Improvements are identified and added as backlog items.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UE.3.2", Description="All major screens are rated for usability on different user experience aspects and the improvement plan is maintained.", Level = level3 }
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
