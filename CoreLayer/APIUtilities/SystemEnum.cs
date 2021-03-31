using System;
using System.Collections.Generic;
using System.Text;

namespace Attendleave.Erp.Core.APIUtilities
{
   public class SystemEnum
    {
        public enum CustomerRelated
        {
            All = 1,
            ByBranch = 2,
            Specific = 3
        }

        public enum CustomerType
        {
            All = 1,
            PreCustomer = 2,
            ExistCustomer = 3
        }

        public enum VisitPurpose
        {
            All = -1,
            NewContract = 1,
            AddDevices = 2,
            Discussion = 3,
            Collection = 4
        }

        public enum PaymentType
        {
            All = 1,
            Pay = 2,
            NoPay = 3
        }

        public enum PaymentMethod
        {
            All = -1,
            Transfer = 1,
            Cheque = 2,
            Cash = 3

        }

        public enum NoPaymentReason
        {
            All = -1,
            ForClosing = 1,
            HasTechnicalProblem = 2,
            HasAccountingProblem = 3,
            NeedDiscount = 4,
            HasCashFlowIssue = 5
        }

        public enum ContractStauts
        {
            Pending = 1,
            Approved = 2,
            Deleted = 3
        }
    }
}
