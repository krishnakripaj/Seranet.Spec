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
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.1", Description="Team should have a clear understanding of the SPEG model and should be able to demonstrate this.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.2", Description="Team should have a activity backlog (a roadmap) with specific tasks demonstrating how it plans to progress through the SPEC model.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.3", Description="Team should produce evidence that meetings has happened in every iteration to monitor the progress of the SPEC backlog.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="MB.1.4", Description="Team should produce evidence to support their claims for completed tasks in order to be certified under a particular practice.", Level = level1 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="TC", Name="Team Culture", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.1", Description="Team has a plan to ensure newcomers to the team are absorbed to their team culture successfully with a high positive note.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.1.2", Description="Team has carried out explicit activities to improve peer bonding of the team continuously", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.2.1", Description="Internal team satisfaction survey is conducted quarterly and results are discussed within the team to take improvement actions.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.2.2", Description="All team members are aware of cross cultural aspects. Members are able the explain the means of neutralizing such differences in a distributed work environment.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.3.1", Description="Members are aware of travel information to the counterpart countries. They possess reasonable knowledge of social practices in conversations, dining, clothing, etc.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="TC.3.2", Description="Team is knowledgeable of the important information such as history, geology, politics, sports, etc. of the counterpart countries.", Level = level1 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="BO", Name="Blue Oceans", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.1.1", Description="Individuals have explicitly identified one or many project-domain (technology or business) focus areas for the coming year.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.1.2", Description="Team is aware of the project-domain blue oceans selected by the peers and related activities performed by them recently.", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.2.1", Description="Individuals have quarterly goals defined on the project-domain blue oceans and have progressed through the plan accordingly.", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="BO.3.1", Description="Project members has selected a industry-domain blue ocean for the coming year and his/her related contributions are clearly visible during last quarter. ", Level = level3 }
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="PF", Name="Peer Feedback", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="PF.1.1", Description="Team conducts retrospectives where team members provide feedback on the iteration progress. Identified improvements are actioned upon and reviewed.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="PF.2.1", Description="Team conducts offline surveys/assessments (possibly anonymous) where every member would provide feedback to others in the team at least quarterly. ", Level = level2},
                                new Practice{ GUID=Guid.NewGuid(), Code="PF.3.1", Description="Team conducts one-on-one peer feedback sessions where each member suggesting at least 2 improvement areas for the other at least quarterly.", Level = level3}
                            }
                        },
                        new SubArea{ GUID=Guid.NewGuid(), Code="CL", Name="Continuous Learning", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="CL.1.1", Description="Team should maintain a training backlog/improvement plan for the members and be in sync with the organizational training department.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="CL.1.2", Description="Establish mechanisms to share domain and technical knowledge within the team continuously.", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="CL.2.1", Description="Team should have a knowledge base preferably in the form of a wiki with live documentation maintained in it.", Level = level2},
                                new Practice{ GUID=Guid.NewGuid(), Code="CL.2.2", Description="Team should establish mechanisms to continuously acquire domain knowledge from the onsite counterparts.", Level = level2},
                                new Practice{ GUID=Guid.NewGuid(), Code="CL.2.3", Description="Information regarding day-today activities of the team is continuously shared across everyone in the distributed team in real-time. ", Level = level2}
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
