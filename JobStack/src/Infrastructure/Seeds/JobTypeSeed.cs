namespace JobStack.Infrastructure.Seeds;

public static class JobTypeSeed
{
    public static List<JobType> JobTypesData = new()
    {
        new JobType{ TypeName="Full Time"},
        new JobType{ TypeName="Part Time"},
        new JobType{ TypeName="Work From Home"},
        new JobType{ TypeName="Remote Job"}
    };
}
