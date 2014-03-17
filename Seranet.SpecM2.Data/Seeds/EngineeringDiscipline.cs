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
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.1", Description="An unit testing framework is integrated to the solution and ability of the test execution upon project build time", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.2", Description="Code quality is analyzed automatically and results are made available to the team members.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.3", Description="Team has a plan to implement a ‘test pyramid’ with different test types. Tooling and infrastructure for the same is agreed and being built.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.4", Description="Team should have a knowledge base built in a wiki with proper documentation", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.1", Description="Critical areas of the system are covered with unit, performance, integration and security tests. Tests are automatically executed and pipeline is stopped if broken", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.2", Description="Team is aware of TDD and practicing the same whenever applicable. All new code modules developed are testable.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.3.1", Description="Acceptance tests for new features are automated", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="AD", Name="Agility in Design", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.1", Description="A backlog for technical debt management is existing.  Refactoring needs are identified in planning meetings and added to the backlog", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.2", Description="Code module complexity is automatically analyzed and steps are taken to refactor the high complexity modules", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.3", Description=" System design is modular where changes in one module is minimally impacting others. All team members are knowledgeable to explain the modularity of the system.(DI)", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.4", Description="Team is acknowledged about the best suited design patterns used for the solution.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.2.1", Description="desc21", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.3.1", Description="desc31", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="PS", Name="Production Stability", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.1.1", Description="Team is aware of scalability limits of the production system. Average load of the production environment is being monitored continuously.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.1.2", Description="Periodic security/performance assessments are scheduled and practiced on the production environment. Actions are taken on the vulnerabilities found.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.2.1", Description=" Critical components of the production system are covered with system monitoring and notifications are raised upon anomalies.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.3.1", Description="desc31", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="SP", Name="Software Productization", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.1.1", Description=" The designs for billing and licensing features of the product are available and reporting required for such is in place", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.1", Description=" Look and feel of the product is configurable. Depending on the needs theming, white-labeling features are availabl", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.2", Description="Product is made modular such that it is possible to configure different editions catering different market needs.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.3", Description="desc23", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.3.1", Description="desc31", Level = level3 },
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="DA", Name="Delivery Automation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.1.1", Description=" Any code changes should trigger a build, and any successful build can be deployed to staging automatically. Releases are repeatable.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.1.2", Description=" Database changes and migrations are performed automatically as a part of release process", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.2.1", Description=" All code is integrated daily and artifacts required to create a deployment are version control together with code", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.2.2", Description=" Delivery pipeline is orchestrated. Ability to rollback releases, components versioned separately,", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.1", Description=" Deployment/development environments are automatically provisioned. All artifacts, configurations required to provision environments are version controlled.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.2", Description=" Features can be dark launched, AB tested and effectiveness can be statistically decided", Level = level3 },
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
