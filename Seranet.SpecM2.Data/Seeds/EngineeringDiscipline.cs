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
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.1", Description="A unit testing framework is integrated to the solution. Team has the ability of test execution at least upon build time.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.2", Description="Code quality is analyzed automatically at the development environment (IDE). A common ruleset used for analysis is shared across the team members.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.1.3", Description="Team understands the test-pyramid roles played by different test types . Tooling and infrastructure for the same is agreed and is being built.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.1", Description="Critical areas of the system are covered with unit, integration and functional tests as applicable. ", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.2", Description="Continuous Integration is in place and tests are automatically executed upon builds. Commits are stopped if a test/build is broken, until fixed.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.2.3", Description="Central code quality analysis tool is integrated to monitor continuously. Overall quality indicators follow upward trend during current quarter.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.3.1", Description="Team is aware and practices of TDD in developing new code modules. All new code written is testable with proper dependency handling techniques.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="VQ.3.2", Description="Acceptance tests for new features are automated and maintained as a regression test suite. Coverage levels are incrementing over time.", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="AD", Name="Agility in Design", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.1", Description="Refactoring and standardization (generalization) needs are identified (preferably through automation). A backlog for managing technical debt is maintained by the team.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.2", Description="System design is modular where changes in one module is minimally impacting others. Team members are able to explain the modularity of the system at different levels.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.1.3", Description="Contexts in which the product may operate are identified. Designs are in place to meet required compatibility needs (form-factors, devices, browsers, etc.).", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.2.1", Description="All third-party libraries are continuously kept upgraded such that dependencies would not make the product legacy at any point of the time. ", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.2.2", Description="Non-functional requirements for cross cutting architectural aspects (security, globalization, etc.) are identified and maintained in a form of a backlog. ", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="AD.3.1", Description="The team is in favor of deferred decisions uses delaying techniques such as abstractions. A log of deferred decisions is maintained and actioned appropriately.", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="PS", Name="Production Stability", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.1.1", Description="Product should have the performance criteria defined for critical use cases. Testing performed should verify the adherence.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.1.2", Description="Security architecture of the product is explicitly defined and validated against possible threats.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.2.1", Description="Team is aware of scalability limits of the production system. Average load of the production environment is being monitored continuously.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.2.2", Description="Periodic performance assessments are scheduled and practiced on the staging/production environment. Actions are taken on the issues identified.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.2.3", Description="Periodic security assessments are scheduled and practiced on the production/staging environment. Actions are taken on the vulnerabilities found.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PS.3.1", Description="Critical components of the production system are covered with health monitoring techniques. Notifications are raised upon anomalies.", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="SP", Name="Software Productization", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.1.1", Description="Product has the capabilities of catering to globalization needs (language, currency, date/time, numbers, etc.).", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.1.2", Description="Look and feel (theming) of the product is cleanly decoupled from the structure of the user interface and can be configured as needed.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.1.3", Description="User interface is decomposed into components and strategies to handle actions (buttons, toolbars, menus), notifications, progression, error-handling, navigation, etc. are in place.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.1.4", Description="Product is capable of exposing services for integration. API layer is clearly identified and exposed business entities are modeled according to the best practices.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.1", Description="Strategy for multi-tenancy is clearly identified and necessary isolation means are in place.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.2", Description="The designs for billing and licensing features of the product are available and reporting/accounting required for such are in place.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.2.3", Description="Product is made modular such that it is possible to configure different editions catering different market needs if required.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.3.1", Description="Features required for presale needs such as demo versions, trial periods, etc. are considered and implemented as necessary.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.3.1", Description="Service APIs are versioned and strategy is in place for maintaining the service API.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="SP.3.1", Description="Product is designed to have extensibility through the means of plugins, configurations, etc.", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="DA", Name="Delivery Automation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.1.1", Description="Any code change may trigger a build, and any successful build can be deployed to staging automatically. ", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.1.2", Description="Data migrations are performed automatically as a part of release process.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.2.1", Description="All code is integrated daily and all artifacts required to compile a release are version controlled together with code.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.2.2", Description="Any change to CSM artifacts should be linked to a task for traceability purposes.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.2.3", Description="Delivery pipeline is orchestrated. Releases are repeatable and has the ability to rollback.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.1", Description="Development, staging, production environments can be automatically provisioned. All artifacts, configurations required are version controlled.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.2", Description="Acceptance test results, release notes and audit trails are automatically generated.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.3", Description="Database versioning/upgrading is decoupled from code versioning. Database migrations lead the code deployments in staging as well as in production.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="DA.3.4", Description="Team has the ability to push a release to production on demand, with just a 3 day notice.", Level = level3 }
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
