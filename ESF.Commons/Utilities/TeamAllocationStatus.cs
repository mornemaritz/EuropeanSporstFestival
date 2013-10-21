namespace ESF.Commons.Utilities
{
    public enum TeamAllocationStatus
    {
        [StringValue("Not a Team Sport")]
        NotApplicable,
        [StringValue("Allocation Required")]
        AllocationRequired,
        [StringValue("Available for Team Allocation")]
        AvailableForTeamAllocation,
        [StringValue("Unconfirmed Team Member")]
        UnconfirmedTeamMember,
        [StringValue("Confirmed Team Member")]
        ConfirmedTeamMember
    }
}
