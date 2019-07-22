﻿using InvoicingSystem_XMl.Models;

namespace InvoicingSystem_XML.Models
{
    public class Customer : Enterprenour
    {
        #region Properties

        public string CorporationName { get; set; }

        #endregion Properties

        #region Overriden Methods

        public override string ToString()
        {
            return CorporationName;
        }

        #endregion Overriden Methods
    }
}
