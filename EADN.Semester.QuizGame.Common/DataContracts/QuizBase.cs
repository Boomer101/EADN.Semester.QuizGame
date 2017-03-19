﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace EADN.Semester.QuizGame.Common
{
    [DataContract(Name = "QuizBase", Namespace = ConstantValues.XmlNamespace, IsReference = true)]
    [KnownType(typeof(Quiz))]
    [KnownType(typeof(Topic))]
    [KnownType(typeof(Question))]
    [KnownType(typeof(Answer))]
    public abstract class QuizBase
    {
        [DataMember(Name ="Id", Order = 0)]
        public Guid Id { get; set; }

        [DataMember(Order = 0)]
        public string Name { get; set; }
    }
}
