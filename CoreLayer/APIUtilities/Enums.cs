namespace Attendleave.Erp.Core.APIUtilities
{
    public enum RepositoryActionStatus
    {
        Ok,
        Created,
        Updated,
        NotFound,
        Deleted,
        NothingModified,
        Error,
        BadRequest,
        UnAuthorized,
        ExistedBefore,
        NothingAdded,
        ImportScussfully,
        ImportWithErrors,
        UpdateFileScussfully,
        UpdateFileWithErrors,
        EmptyFile,
        IsShiftOpen
    }

    public enum GeneralPermissionIds
    {
        // those ids come from database permission table
        AllBranches = 8,
        ByBranch = 9,
        ByTeam = 10,

    }
    public enum QuotationAccessPermissionIds
    {
        // those ids come from database permission table
        SalesMan = 11,
        SalesManager = 12,
        BranchManager = 13,
        GBranchManager = 14,
    }
    // use it in end point 
    public enum CheckInPermissionIds
    {
        // those ids come from database permission table
        CheckInVisit = 15,
        CheckInNew = 16

    }
    public enum Language
    {
        Arabic = 2,
        English = 1
    }
    public enum Extenssions
    {
        Invalid = 0,
        Xls = 1,
        Xlsx = 2

    }
    public enum ResponseMessages
    {
        Created = 1,
        Updated = 2,
        NotFound = 3,
        Deleted = 4,
        Blocked = 5,
        UnBlocked = 6,
        Return = 7,
        Error = 8,
        BadRequest = 9,
        BadBlockRole = 10,
        WrongUser = 11,
        BlockedUser = 12,
        NotAllowUserAccess = 13,
        EmployeeExisted = 14,
        CustomerNameExisted = 15,
        ImportScussfully = 16,
        ImportWithErrors = 17,
        UpdateFileScussfully = 18,
        UpdateFileWithErrors = 19,
        EmptyFile = 20,
        ModelTypeExist = 22

    }
    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3
    }
    public enum VacationType
    {
        Employee = 1,
        Branch = 2,
        Adminsteration = 3,
        Department = 4,
        AllBranchs = 5
    }
    public enum Permission
    {
        Add = 1,
        Updated = 2,
        Delete = 3,
        Get = 4,
        Print = 5
    }
    public enum Pages
    {

        Branches = 1,
        Jobs = 2,
        Projects = 3,
        Nationalities = 4,
        Tasks = 5,
        WorkingTime = 6,
        Employees = 7,
        EmployeesGroups = 8,
        Vacations = 9,
        OfficialHolidays = 10,
        Unregisteredemployees = 11,
        GetBranchesTrans = 12,
        TransferTrans = 13,
        DisplayTrans = 14,
        CancelTransferTrans = 15,
        AddEditeTrans = 16,
        AddPermission = 17,
        AddVacation = 18,
        EmployeesReport = 19,
        WorkingTimeReport = 20,
        DayStatus = 21,
        DetailedAttendance = 22,
        TotalAttendance = 23,
        Absence = 24,
        Delay = 25,
        IncompleteTrans = 26,
        EarlyAttendance = 27,
        AttendanceReportSummary = 28,
        TotalAttendanceSummaryForBranches = 29,
        OverTime = 30,
        WorkingTimeDetails = 31,
        AttendanceBranches = 32,
        VacationsReport = 33,
        PermissionsReport = 34,
        DelayandEarlyLeave = 35,
        TotalAbsence = 36,
        TotalDelay = 37,
        Devices = 38,
        ActivetheWorkingTimeforRamadan = 39,
        Permissions = 40,
        GeneralSettings = 41,
        CompanyInformation = 42,
        UserAccounts = 43
    }
    public enum ShiftType
    {
        NormalShiftsForYear = 1,
        RamdanShifts = 2
    }
    public enum Status
    {
        NotStartedYet = 1,
        StartedCurrently = 2,
        Ended = 3
    }
    public enum PermissionType
    {
        TemporaryPermission = 1,
        lateAttendancePermission = 2,
        EarlyLeavePermission = 3,
        AllDayPermission = 4
    }
    public enum EmpDayStatus
    {
        Working = 1,
        Vocation = 2,
        Holiday = 3,
        OfficialVocation = 4,
        Absence = 5,
        late=6,
        earlyLeave=7,
        permission=8
    }


}

