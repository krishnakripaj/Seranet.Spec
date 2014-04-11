using Seranet.SpecM2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seranet.SpecM2.Data.Seeds
{
    class EngineeringDisciplineNew
    {
        private Area ed;

        public EngineeringDisciplineNew(Level[] levels) {
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
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.2", Description="Code quality is analyzed automatically and results are made available to the developer. Ruleset used for analysis is shared across the team members.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.3", Description="Team has a plan to implement a ‘test pyramid’ with different test types. Tooling and infrastructure for the same is agreed and being built.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.4", Description="Team should have a knowledge base preferably in the form of a wiki with live documentation in it.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.5", Description="Pre - major release non functional test execution and  results made available to the team", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.1", Description="Critical areas of the system are covered with unit, integration and UI tests as applicable. Team has defined the acceptable coverage levels and ensures increment over time.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.2", Description="Continuous Integration is in place and tests are automatically executed upon builds. Production line is stopped if a test is broken, until it’s fixed.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.3", Description="Integrated code analysis (inspection) tool kit to monitor the code quality centrally", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.3.1", Description="Team is aware of TDD and practicing in writing new code modules. All new code written is testable with pragmatic dependency handling techniques.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.3.2", Description="Acceptance tests for new features are automated and maintained as a regression test suite. ",Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.3.3", Description="Code quality analysis framework integrated with the CI (For automated documentation)",Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="AD", Name="Agility in Design", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.1", Description="A backlog for technical debt management is existing.  Refactoring needs are identified through automation and added to the backlog", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.2", Description="System design is modular where changes in one module is minimally impacting others. Team members are able to explain the modularity of the system at different levels.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.3", Description="Team has identified different contexts in which the product may operate and plans to meet required compatibility needs.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.4", Description="Team is acknowledged about the best suited design patterns used for the solution.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.2.1", Description="Product has the capability to support different form factors (devices/browsers) and required boilerplate code is in place.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.2.2", Description="Architecture is evolved over time and such design refactoring needs (generalizing the specialized feature designs) are identified and treated regularly.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.3.1", Description="All third-party libraries are continuously kept upgraded such that dependencies would not make the product legacy at any point of the time. Proper use of a package manager can be demonstrated whenever applicable.",Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.3.2", Description="The team is in favor of deferred decisions uses delaying techniques such as abstractions. A log of deferred decisions is maintained and visited frequently to see if the ‘last responsible moment’ is reached in any of the items.",Level = level3 },
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="PS", Name="Production Stability", 
                            Practices= new List<Practice> {
                                //1.1 was not defined below are the old ones
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.1.1", Description="Team is aware of scalability limits of the production system. Average load of the production environment is being monitored continuously.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.1.2", Description="Periodic security/performance assessments are scheduled and practiced on the production environment. Actions are taken on the vulnerabilities found.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.2.1", Description="Team is aware of scalability limits of the production system. Average load of the production environment is being monitored continuously.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.2.2", Description="Periodic performance assessments are scheduled and practiced on the production environment.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.2.3", Description="Periodic security assessments are scheduled and practiced on the production environment. Actions are taken on the vulnerabilities found.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.3.1", Description="Critical components of the production system are covered with system health monitoring. Notifications are raised upon possible anomalies.", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="SP", Name="Software Productization", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.1.1", Description="Product has a framework capable of catering to globalization needs (language, currency, date/time, numbers, etc.).", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.1.2", Description="Look and feel of the product is decoupled from the structure of the user interface and can be changed easily as needed.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.1.3", Description="Strategy for multi-tenancy is clearly identified and necessary isolation means are in place.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.1", Description="The designs for billing and licensing features of the product are available and reporting/accounting required for such are in place.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.2", Description="Product is made modular such that it is possible to configure different editions catering different market needs.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.3.1", Description="Features required for presale needs such as demo versions, trial periods, etc. are designed and implemented as necessary.", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="DA", Name="Delivery Automation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.1.1", Description="Any code changes should trigger a build, and any successful build can be deployed to staging automatically.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.1.2", Description="Data migrations are performed automatically as a part of release process", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.2.1", Description="All code is integrated daily and artifacts required to create a deployment are version control together with code", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.2.2", Description="Delivery pipeline is orchestrated. Releases are repeatable and has ability to rollback releases.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.1", Description="Development environments can be automatically provisioned. All artifacts, configurations required are version controlled.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.2", Description="Staging and production environments are automatically provisioned. All artifacts, configurations required are version controlled.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.3", Description="Database versioning/upgrading is decoupled from code versioning. Database migrations lead the code deployments in staging as well as in production.", Level = level3 }
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
