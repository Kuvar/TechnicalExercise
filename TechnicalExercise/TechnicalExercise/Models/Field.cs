using System;
using System.Collections.Generic;
using System.ComponentModel;
using TechnicalExercise.ViewModels;

namespace TechnicalExercise.Models
{
    public class Field : BaseViewModel
    {
        public string Value { get; set; }
        public bool IsNotValid { get; set; }
        public string NotValidMessageError { get; set; }
    }
}
