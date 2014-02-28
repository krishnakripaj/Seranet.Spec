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

        public BusinessFocus(Level level1, Level level2, Level level3)
        {
            bf = new Area
            {
                GUID = Guid.NewGuid(),
                Name = "Businesss Focus",
                Description = "todo",
                SubAreas = new List<SubArea> {
                        new SubArea{ GUID=Guid.NewGuid(), Code="PA", Name="Persona Awareness", 
                            Practices= new List<Practice> {
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.1.1", Description="desc11", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.2.1", Description="desc21", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.2.2", Description="desc22", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.3.1", Description="desc31", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="PA.3.2", Description="desc32", Level = level3 }
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
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.1.1", Description="desc11", Level = level1},
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.1.2", Description="desc12", Level = level1 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.2.1", Description="desc21", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.2.2", Description="desc22", Level = level2 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.3.1", Description="desc31", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.3.2", Description="desc32", Level = level3 },
                                new Practice{ GUID=Guid.NewGuid(), Code="UT.3.3", Description="desc32", Level = level3 },
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
