using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Kreta.Models.AbstractClass;
using Kreta.Models.DataModel;

namespace Kreta.Models.DataTranferObjects
{
    public class SubjectForCreationDto : SubjectBaseWithAttributes
    {
          public SubjectForCreationDto(Subject subject)
          {
              this.Id = subject.Id;
              this.SubjectName= subject.SubjectName;
          }

          public SubjectForCreationDto(long id, string subName)
              :base(id, subName)
          {
          }

          public SubjectForCreationDto()
              : base()
          { }
        /*public void Clone(Subject subject)
        {
            this.Id = subject.Id;
            this.SubjectName = subject.SubjectName;
        }*/
    }
}
