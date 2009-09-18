﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.Reflection;
using System.IO;

namespace DDay.iCal.Validator.RFC2445
{
    public class CalScaleValidator : 
        IValidator
    {
        #region Public Properties

        public iCalendar iCalendar { get; set; }

        #endregion

        #region Constructors

        public CalScaleValidator(iCalendar cal)
        {
            iCalendar = cal;
        }

        #endregion

        #region IValidator Members

        public IValidationResult[] Validate()
        {
            return new IValidationResult[] { 
                ValidationResult.GetCompositeResults("calScale", new PropertyCountValidator(iCalendar, "VCALENDAR", "CALSCALE"))
            };
        }

        #endregion
    }
}
