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
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.1.1", Description="The team has a plan to identify the different personas of the end user.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.2.1", Description=" The team has a plan to implement the ideas gathered", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.2.2", Description=" The team has a feedback mechanism on the different usage patterns", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.3.1", Description="The team has a plan to incorporate the different feedback received", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.3.2", Description=" The team has incorporated this loop into the day to day planning and product roadmap.", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="HV", Name="Hypothesis Validation", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="HV.1.1", Description="desc11", Level = level1}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="FM", Name="Feature Measures", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="FM.1.1", Description="desc11", Level = level1}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="MR", Name="Micro Releases", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="MR.1.1", Description="desc11", Level = level1}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="UT", Name="Usability Testing", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.1.1", Description="No(or less) focus on Usability (Product Engineering with no usability testing. Focus is mainly towards the system centric assuming users of the product are dumb (or user same as us)).", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.1.2", Description=" Usage of Stereotypes, prototypes are used to validate the concerns", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.2.1", Description="User Analysis & Profiling (The mindset that Product will be used by users (who do not necessarily same as us) and list the users of the Product and their characteristics) Analysis on actual users, Creating user profiles, Choosing user profiles for testing", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.2.2", Description=" Selecting the testing scenarios (What to be tested) Choosing the testing purpose(s), Determining the objective(s), Choosing the type of test(s), Selecting the Task(s) based on cost/complexity/Priority, Test scenario/Time Matrix", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.3.1", Description=" Test Preparation:Choosing the testing order, Listing the required testing materials, Have a team comprising actual users, Preparing test plans & environments.", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.3.2", Description="Conducting the test Observe and record the test results", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.3.3", Description="Analyze the test data Collect data into findings, Analyse(determine cause, severity & changes to the product), Report the findings", Level = level3 },
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
